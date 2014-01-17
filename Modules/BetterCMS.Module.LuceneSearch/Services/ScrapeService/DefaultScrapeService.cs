﻿using System;
using System.Collections.Generic;
using System.Linq;

using BetterCms;
using BetterCms.Core.DataAccess;
using BetterCms.Core.DataAccess.DataContext;
using BetterCms.Core.DataContracts.Enums;

using BetterCMS.Module.LuceneSearch.Models;

using BetterCms.Module.Root.Models;

namespace BetterCMS.Module.LuceneSearch.Services.ScrapeService
{
    public class DefaultScrapeService : IScrapeService
    {
        private readonly IRepository Repository;

        private IUnitOfWork UnitOfWork { get; set; }

        private readonly int scrapeLimit;
        
        private readonly bool scrapePrivatePages;

        private readonly TimeSpan pageExpireTimeout;

        private readonly TimeSpan failedPageTimeout;

        public DefaultScrapeService(IRepository repository, IUnitOfWork unitOfWork, ICmsConfiguration cmsConfiguration)
        {
            Repository = repository;
            UnitOfWork = unitOfWork;

            if (!int.TryParse(cmsConfiguration.Search.GetValue(LuceneSearchConstants.ConfigurationKeys.LuceneMaxPagesPerQuery), out scrapeLimit)
                || scrapeLimit < 0)
            {
                scrapeLimit = 1000;
            }

            if (!TimeSpan.TryParse(cmsConfiguration.Search.GetValue(LuceneSearchConstants.ConfigurationKeys.LucenePageExpireTimeout), out pageExpireTimeout))
            {
                pageExpireTimeout = TimeSpan.FromMinutes(10);
            }

            if (!TimeSpan.TryParse(cmsConfiguration.Search.GetValue(LuceneSearchConstants.ConfigurationKeys.LuceneFailedPageReindexingTimeout), out failedPageTimeout))
            {
                failedPageTimeout = TimeSpan.FromMinutes(10);
            }

            bool.TryParse(cmsConfiguration.Search.GetValue(LuceneSearchConstants.ConfigurationKeys.LuceneIndexPrivatePages), out scrapePrivatePages);
        }

        public void FetchNewUrls()
        {
            var query = Repository.AsQueryable<Page>()
                          .Where(page => !page.IsDeleted && !page.IsMasterPage)
                          .Where(page => !Repository.AsQueryable<IndexSource>().Any(crawlUrl => crawlUrl.SourceId == page.Id));

            if (!scrapePrivatePages)
            {
                query = query.Where(page => page.Status == PageStatus.Published);
            }

            var newSources = query
                          .Select(page =>
                                    new IndexSource
                                    {
                                        Path = page.PageUrl,
                                        SourceId = page.Id,
                                        IsPublished = page.Status == PageStatus.Published
                                    })
                          .ToList();
                          
            
            UnitOfWork.BeginTransaction();

            int i = 0;
            foreach (var source in newSources)
            {
                Repository.Save(source);

                // Flushes every 20-size batch.
                if (i++ % 20 == 0)
                {
                    UnitOfWork.Session.Flush();
                    UnitOfWork.Session.Clear();
                }
            }
            
            UnitOfWork.Commit();
        }

        public Queue<CrawlLink> GetLinksForProcessing(int? limit = null)
        {
            if (!limit.HasValue)
            {
                limit = scrapeLimit;
            }

            var queue = new Queue<CrawlLink>();

            var unprocessedLinks = GetUnprocessedLinks(limit.Value);
            var processed = unprocessedLinks.Count;
            AddLinksToQueue(queue, unprocessedLinks);

            if (processed < limit)
            {
                var expiredLinks = GetExpiredLinks(limit.Value - processed);
                processed += expiredLinks.Count;
                AddLinksToQueue(queue, expiredLinks);
            }

            if (processed < limit)
            {
                var failedLinks = GetFailedLinks(limit.Value - processed);
                AddLinksToQueue(queue, failedLinks);
            }

            return queue;
        }

        private void AddLinksToQueue(Queue<CrawlLink> queue, IList<IndexSource> links)
        {
            foreach (var url in links)
            {
                queue.Enqueue(new CrawlLink { Id = url.Id, Path = url.Path, IsPublished = url.IsPublished });
            }
        }

        private IList<IndexSource> GetUnprocessedLinks(int limit)
        {
            IndexSource indexSourceAlias = null;

            var unprocessedUrls =
                Repository.AsQueryOver(() => indexSourceAlias)
                          .Where(() => indexSourceAlias.StartTime == null)
                          .OrderByAlias(() => indexSourceAlias.Id)
                          .Asc.Lock(() => indexSourceAlias)
                          .Read.Take(limit)
                          .List();

            return unprocessedUrls;
        }

        private IList<IndexSource> GetExpiredLinks(int limit)
        {
            IndexSource indexSourceAlias = null;
            var endDate =  DateTime.Now.Subtract(pageExpireTimeout);

            var expiredUrls =
                Repository.AsQueryOver(() => indexSourceAlias)
                          .Where(() => indexSourceAlias.EndTime != null)
                          .Where(() => indexSourceAlias.EndTime <= endDate)
                          .OrderByAlias(() => indexSourceAlias.EndTime)
                          .Desc.Lock(() => indexSourceAlias)
                          .Read.Take(limit)
                          .List();

            return expiredUrls;
        }

        private IList<IndexSource> GetFailedLinks(int limit)
        {
            IndexSource indexSourceAlias = null;
            var startDate = DateTime.Now.Subtract(failedPageTimeout);

            var urls =
                Repository.AsQueryOver(() => indexSourceAlias)
                          .Where(() => indexSourceAlias.StartTime != null && indexSourceAlias.EndTime == null)
                          .Where(() => indexSourceAlias.StartTime <= startDate)
                          .OrderByAlias(() => indexSourceAlias.EndTime)
                          .Desc.Lock(() => indexSourceAlias)
                          .Read.Take(limit)
                          .List();

            return urls;
        }

        public void MarkStarted(Guid id)
        {
            var url = Repository.First<IndexSource>(x => x.Id == id);
            url.StartTime = DateTime.Now;

            UnitOfWork.BeginTransaction();
            Repository.Save(url);
            UnitOfWork.Commit();
        }

        public void MarkVisited(Guid id)
        {
            var url = Repository.First<IndexSource>(x => x.Id == id);
            url.EndTime = DateTime.Now;

            UnitOfWork.BeginTransaction();
            Repository.Save(url);
            UnitOfWork.Commit();
        }

        public void Delete(Guid id)
        {
            var url = Repository.First<IndexSource>(x => x.Id == id);

            UnitOfWork.BeginTransaction();
            Repository.Delete(url);
            UnitOfWork.Commit();
        }
    }
}