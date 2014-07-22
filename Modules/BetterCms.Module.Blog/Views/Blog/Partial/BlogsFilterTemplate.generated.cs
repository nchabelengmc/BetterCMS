﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18449
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BetterCms.Module.Blog.Views.Blog.Partial
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Text;
    using System.Web;
    using System.Web.Helpers;
    using System.Web.Mvc;
    using System.Web.Mvc.Ajax;
    using System.Web.Mvc.Html;
    using System.Web.Routing;
    using System.Web.Security;
    using System.Web.UI;
    using System.Web.WebPages;
    
    #line 1 "..\..\Views\Blog\Partial\BlogsFilterTemplate.cshtml"
    using BetterCms.Module.Blog.Content.Resources;
    
    #line default
    #line hidden
    
    #line 3 "..\..\Views\Blog\Partial\BlogsFilterTemplate.cshtml"
    using BetterCms.Module.Blog.ViewModels.Blog;
    
    #line default
    #line hidden
    
    #line 4 "..\..\Views\Blog\Partial\BlogsFilterTemplate.cshtml"
    using BetterCms.Module.Blog.ViewModels.Filter;
    
    #line default
    #line hidden
    
    #line 2 "..\..\Views\Blog\Partial\BlogsFilterTemplate.cshtml"
    using BetterCms.Module.Root.Content.Resources;
    
    #line default
    #line hidden
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Blog/Partial/BlogsFilterTemplate.cshtml")]
    public partial class BlogsFilterTemplate : System.Web.Mvc.WebViewPage<BlogsGridViewModel<SiteSettingBlogPostViewModel>>
    {
        public BlogsFilterTemplate()
        {
        }
        public override void Execute()
        {
WriteLiteral("\r\n");

WriteLiteral("<div");

WriteLiteral(" id=\"bcms-filter-template\"");

WriteLiteral(">\r\n    <div");

WriteLiteral(" class=\"bcms-grid-filtering\"");

WriteLiteral(" data-bind=\"css: { \'bcms-active-filter\': isVisible() }\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"bcms-filterbox\"");

WriteLiteral(" data-bind=\"click: toggleFilter\"");

WriteLiteral(">\r\n");

WriteLiteral("            ");

            
            #line 10 "..\..\Views\Blog\Partial\BlogsFilterTemplate.cshtml"
       Write(BlogGlobalization.SiteSettings_Blogs_Filter);

            
            #line default
            #line hidden
WriteLiteral("\r\n            <div");

WriteLiteral(" class=\"bcms-filter-modified\"");

WriteLiteral(" data-bind=\"style: { display: isEdited() ? \'inline-block\' : \'none\' }\"");

WriteLiteral(">");

            
            #line 11 "..\..\Views\Blog\Partial\BlogsFilterTemplate.cshtml"
                                                                                                              Write(BlogGlobalization.SiteSettings_Blogs_FilterIsModified);

            
            #line default
            #line hidden
WriteLiteral("</div>\r\n        </div>\r\n    </div>\r\n    <div");

WriteLiteral(" class=\"bcms-tags-block\"");

WriteLiteral(" style=\"display: none;\"");

WriteLiteral(" data-bind=\"visible: isVisible()\"");

WriteLiteral(">\r\n        <div");

WriteLiteral(" class=\"bcms-featured-tags\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"bcms-clearfix\"");

WriteLiteral(">\r\n\r\n                <div");

WriteLiteral(" class=\"bcms-filter-options\"");

WriteLiteral(" data-bind=\"with: tags\"");

WriteLiteral(">\r\n                    <div");

WriteLiteral(" class=\"bcms-filter-text\"");

WriteLiteral(">");

            
            #line 19 "..\..\Views\Blog\Partial\BlogsFilterTemplate.cshtml"
                                             Write(BlogGlobalization.SiteSettings_Blogs_FilterByTags);

            
            #line default
            #line hidden
WriteLiteral("</div>\r\n                    <div");

WriteLiteral(" class=\"bcms-filter-field-holder\"");

WriteLiteral(">\r\n                        <input");

WriteLiteral(" type=\"text\"");

WriteLiteral(" class=\"bcms-add-tags-field\"");

WriteLiteral(" data-bind=\"\r\n    css: { \'bcms-tag-validation-error\': newItem.hasError() },\r\n    " +
"value: newItem,\r\n    valueUpdate: \'afterkeydown\',\r\n    escPress: clearItem,\r\n   " +
" autocompleteList: \'onlyExisting\'\"");

WriteLiteral(" />\r\n                        <!-- ko if: newItem.hasError()  -->\r\n               " +
"         <span");

WriteLiteral(" class=\"bcms-tag-field-validation-error\"");

WriteLiteral(">\r\n                            <span");

WriteLiteral(" data-bind=\"text: newItem.validationMessage()\"");

WriteLiteral("></span>\r\n                        </span>\r\n                        <!-- /ko -->\r\n" +
"                    </div>\r\n                </div>\r\n\r\n                <div");

WriteLiteral(" class=\"bcms-filter-options\"");

WriteLiteral(">\r\n                    <div");

WriteLiteral(" class=\"bcms-filter-text\"");

WriteLiteral(">");

            
            #line 36 "..\..\Views\Blog\Partial\BlogsFilterTemplate.cshtml"
                                             Write(BlogGlobalization.SiteSettings_Blogs_FilterByCategory);

            
            #line default
            #line hidden
WriteLiteral("</div>\r\n                    <select");

WriteLiteral(" class=\"bcms-global-select\"");

WriteLiteral(" name=\"CategoryId\"");

WriteLiteral(" data-bind=\"options: categories, value: categoryId, optionsText: \'Value\', options" +
"Value: \'Key\'\"");

WriteLiteral(" />\r\n                </div>\r\n                \r\n                <div");

WriteLiteral(" class=\"bcms-filter-options\"");

WriteLiteral(">\r\n                    <div");

WriteLiteral(" class=\"bcms-filter-text\"");

WriteLiteral(">");

            
            #line 41 "..\..\Views\Blog\Partial\BlogsFilterTemplate.cshtml"
                                             Write(BlogGlobalization.SiteSettings_Blogs_FilterByStatus);

            
            #line default
            #line hidden
WriteLiteral("</div>\r\n");

WriteLiteral("                    ");

            
            #line 42 "..\..\Views\Blog\Partial\BlogsFilterTemplate.cshtml"
               Write(Html.DropDownListFor(m => m.Status, new List<SelectListItem>(), new
                                                                      {
                                                                          data_bind = "options: statuses, value: status, optionsText: 'Value', optionsValue: 'Key'",
                                                                          @class = "bcms-global-select"
                                                                      }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                </div>\r\n\r\n                <div");

WriteLiteral(" class=\"bcms-filter-options\"");

WriteLiteral(">\r\n                    <div");

WriteLiteral(" class=\"bcms-filter-text\"");

WriteLiteral(">");

            
            #line 50 "..\..\Views\Blog\Partial\BlogsFilterTemplate.cshtml"
                                             Write(BlogGlobalization.SiteSettings_Blogs_FilterBySEO);

            
            #line default
            #line hidden
WriteLiteral("</div>\r\n");

WriteLiteral("                    ");

            
            #line 51 "..\..\Views\Blog\Partial\BlogsFilterTemplate.cshtml"
               Write(Html.DropDownListFor(m => m.SeoStatus, new List<SelectListItem>(), new
                                                                                            {
                                                                                                data_bind = "options: seoStatuses, value: seoStatus, optionsText: 'Value', optionsValue: 'Key'",
                                                                                                @class = "bcms-global-select"
                                                                                            }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                </div>\r\n\r\n");

            
            #line 58 "..\..\Views\Blog\Partial\BlogsFilterTemplate.cshtml"
                
            
            #line default
            #line hidden
            
            #line 58 "..\..\Views\Blog\Partial\BlogsFilterTemplate.cshtml"
                 if (Model.Languages != null && Model.Languages.Any())
                {

            
            #line default
            #line hidden
WriteLiteral("                    <div");

WriteLiteral(" class=\"bcms-filter-options\"");

WriteLiteral(">\r\n                        <div");

WriteLiteral(" class=\"bcms-filter-text\"");

WriteLiteral(">");

            
            #line 61 "..\..\Views\Blog\Partial\BlogsFilterTemplate.cshtml"
                                                 Write(BlogGlobalization.SiteSettings_Blogs_FilterByLanguage);

            
            #line default
            #line hidden
WriteLiteral("</div>\r\n                        <select");

WriteLiteral(" class=\"bcms-global-select\"");

WriteLiteral(" name=\"LanguageId\"");

WriteLiteral(" data-bind=\"options: languages, value: languageId, optionsText: \'Value\', optionsV" +
"alue: \'Key\'\"");

WriteLiteral(" />\r\n                    </div>\r\n");

            
            #line 64 "..\..\Views\Blog\Partial\BlogsFilterTemplate.cshtml"
                }

            
            #line default
            #line hidden
WriteLiteral("\r\n            </div>\r\n\r\n            <div");

WriteLiteral(" class=\"bcms-single-tag-holder\"");

WriteLiteral(" data-bind=\"foreach: tags.items()\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" class=\"bcms-single-tag\"");

WriteLiteral(" data-bind=\"css: { \'bcms-single-tag-active\': isActive() }\"");

WriteLiteral(">\r\n                    <span");

WriteLiteral(" data-bind=\"text: name()\"");

WriteLiteral("></span><a");

WriteLiteral(" data-bind=\"    click: remove\"");

WriteLiteral(">");

            
            #line 70 "..\..\Views\Blog\Partial\BlogsFilterTemplate.cshtml"
                                                                                      Write(RootGlobalization.Button_Remove);

            
            #line default
            #line hidden
WriteLiteral("</a>\r\n                </div>\r\n                <input");

WriteLiteral(" type=\"hidden\"");

WriteLiteral(" data-bind=\"attr: { name: getItemInputName($index()) + \'.Key\', value: id() }\"");

WriteLiteral(" />\r\n                <input");

WriteLiteral(" type=\"hidden\"");

WriteLiteral(" data-bind=\"attr: { name: getItemInputName($index()) + \'.Value\', value: name() }\"" +
"");

WriteLiteral(" />\r\n            </div>\r\n\r\n        </div>\r\n\r\n        <div");

WriteLiteral(" class=\"bcms-clearfix\"");

WriteLiteral(">\r\n            <div");

WriteLiteral(" class=\"bcms-check-field-holder\"");

WriteLiteral(">\r\n");

WriteLiteral("                ");

            
            #line 80 "..\..\Views\Blog\Partial\BlogsFilterTemplate.cshtml"
           Write(Html.CheckBoxFor(model => model.IncludeArchived, new { data_bind = "checked: includeArchived" }));

            
            #line default
            #line hidden
WriteLiteral("\r\n                <span");

WriteLiteral(" class=\"bcms-pointer\"");

WriteLiteral(" data-bind=\"click: changeIncludeArchived\"");

WriteLiteral(">");

            
            #line 81 "..\..\Views\Blog\Partial\BlogsFilterTemplate.cshtml"
                                                                               Write(BlogGlobalization.SiteSettings_Blogs_FilterIncludeArchived);

            
            #line default
            #line hidden
WriteLiteral("</span>\r\n            </div>\r\n            <div");

WriteLiteral(" class=\"bcms-btn-field-holder\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" class=\"bcms-btn-links-small\"");

WriteLiteral(" data-bind=\"click: clearFilter\"");

WriteLiteral(">");

            
            #line 84 "..\..\Views\Blog\Partial\BlogsFilterTemplate.cshtml"
                                                                            Write(BlogGlobalization.SiteSettings_Blogs_FilterClear);

            
            #line default
            #line hidden
WriteLiteral("</div>\r\n                <div");

WriteLiteral(" class=\"bcms-btn-small\"");

WriteLiteral(" data-bind=\"click: searchWithFilter\"");

WriteLiteral(">");

            
            #line 85 "..\..\Views\Blog\Partial\BlogsFilterTemplate.cshtml"
                                                                           Write(BlogGlobalization.SiteSettings_Blogs_FilterSearch);

            
            #line default
            #line hidden
WriteLiteral("</div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n");

        }
    }
}
#pragma warning restore 1591