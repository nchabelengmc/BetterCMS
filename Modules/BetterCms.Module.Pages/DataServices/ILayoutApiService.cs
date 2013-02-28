﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;

using BetterCms.Module.Root.Models;

namespace BetterCms.Module.Pages.DataServices
{
    public interface ILayoutApiService
    {
        /// <summary>
        /// Gets the list of layout entities.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <param name="order">The order.</param>
        /// <param name="orderDescending">if set to <c>true</c> order by descending.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="itemsPerPage">The items per page.</param>
        /// <returns>
        /// The list of layout entities
        /// </returns>
        IList<Layout> GetLayouts(Expression<Func<Layout, bool>> filter = null,
            Expression<Func<Layout, dynamic>> order = null,
            bool orderDescending = false,
            int? pageNumber = null,
            int? itemsPerPage = null);

        /// <summary>
        /// Gets the list of region entities.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <param name="order">The order.</param>
        /// <param name="orderDescending">if set to <c>true</c> order by descending.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="itemsPerPage">The items per page.</param>
        /// <returns>
        /// The list of region entities
        /// </returns>
        IList<Region> GetRegions(Expression<Func<Region, bool>> filter = null,
            Expression<Func<Region, dynamic>> order = null,
            bool orderDescending = false,
            int? pageNumber = null,
            int? itemsPerPage = null);

        /// <summary>
        /// Gets the list of specified layout region entities.
        /// </summary>
        /// <param name="layoutId">The layout id.</param>
        /// <param name="filter">The filter.</param>
        /// <param name="order">The order.</param>
        /// <param name="orderDescending">if set to <c>true</c> order by descending.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="itemsPerPage">The items per page.</param>
        /// <returns>
        /// The list of specified layout region entities
        /// </returns>
        IList<LayoutRegion> GetLayoutRegions(Guid layoutId,
            Expression<Func<LayoutRegion, bool>> filter = null,
            Expression<Func<LayoutRegion, dynamic>> order = null,
            bool orderDescending = false,
            int? pageNumber = null,
            int? itemsPerPage = null);
    }
}
