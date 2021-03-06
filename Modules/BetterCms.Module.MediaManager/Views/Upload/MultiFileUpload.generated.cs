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

namespace BetterCms.Module.MediaManager.Views.Upload
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
    
    #line 1 "..\..\Views\Upload\MultiFileUpload.cshtml"
    using BetterCms.Module.MediaManager.Content.Resources;
    
    #line default
    #line hidden
    
    #line 2 "..\..\Views\Upload\MultiFileUpload.cshtml"
    using BetterCms.Module.MediaManager.Controllers;
    
    #line default
    #line hidden
    
    #line 3 "..\..\Views\Upload\MultiFileUpload.cshtml"
    using BetterCms.Module.Root;
    
    #line default
    #line hidden
    
    #line 4 "..\..\Views\Upload\MultiFileUpload.cshtml"
    using BetterCms.Module.Root.Content.Resources;
    
    #line default
    #line hidden
    
    #line 5 "..\..\Views\Upload\MultiFileUpload.cshtml"
    using BetterCms.Module.Root.Mvc;
    
    #line default
    #line hidden
    
    #line 6 "..\..\Views\Upload\MultiFileUpload.cshtml"
    using BetterCms.Module.Root.Mvc.Helpers;
    
    #line default
    #line hidden
    
    #line 7 "..\..\Views\Upload\MultiFileUpload.cshtml"
    using Microsoft.Web.Mvc;
    
    #line default
    #line hidden
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    [System.Web.WebPages.PageVirtualPathAttribute("~/Views/Upload/MultiFileUpload.cshtml")]
    public partial class MultiFileUpload : System.Web.Mvc.WebViewPage<BetterCms.Module.MediaManager.ViewModels.Upload.MultiFileUploadViewModel>
    {
        public MultiFileUpload()
        {
        }
        public override void Execute()
        {
WriteLiteral("<div");

WriteLiteral(" class=\"bcms-scroll-window\"");

WriteLiteral(">\r\n");

WriteLiteral("    ");

            
            #line 11 "..\..\Views\Upload\MultiFileUpload.cshtml"
Write(Html.TabbedContentMessagesBox("bcms-multi-file-upload-messages"));

            
            #line default
            #line hidden
WriteLiteral("\r\n    \r\n");

            
            #line 13 "..\..\Views\Upload\MultiFileUpload.cshtml"
    
            
            #line default
            #line hidden
            
            #line 13 "..\..\Views\Upload\MultiFileUpload.cshtml"
     if (Model != null)
{

            
            #line default
            #line hidden
WriteLiteral("    <div");

WriteLiteral(" class=\"bcms-file-manager-inner bcms-clearfix\"");

WriteLiteral(">\r\n\r\n");

            
            #line 17 "..\..\Views\Upload\MultiFileUpload.cshtml"
        
            
            #line default
            #line hidden
            
            #line 17 "..\..\Views\Upload\MultiFileUpload.cshtml"
         using (Html.BeginForm<UploadController>(f => f.SaveUploads(null), FormMethod.Post, new { @class = "bcms-ajax-form" }))
        {

            
            #line default
            #line hidden
WriteLiteral("            <div");

WriteLiteral(" class=\"bcms-input-list-holder\"");

WriteLiteral(">\r\n");

WriteLiteral("                ");

            
            #line 20 "..\..\Views\Upload\MultiFileUpload.cshtml"
           Write(Html.HiddenFor(f => f.ReuploadMediaId));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                ");

            
            #line 21 "..\..\Views\Upload\MultiFileUpload.cshtml"
           Write(Html.HiddenFor(f => f.RootFolderId));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

WriteLiteral("                ");

            
            #line 22 "..\..\Views\Upload\MultiFileUpload.cshtml"
           Write(Html.HiddenFor(f => f.AccessControlEnabled));

            
            #line default
            #line hidden
WriteLiteral("\r\n");

            
            #line 23 "..\..\Views\Upload\MultiFileUpload.cshtml"
                
            
            #line default
            #line hidden
            
            #line 23 "..\..\Views\Upload\MultiFileUpload.cshtml"
                 if (Model.RootFolderId.HasDefaultValue() && Model.ReuploadMediaId.HasDefaultValue())
                {
                    
            
            #line default
            #line hidden
            
            #line 25 "..\..\Views\Upload\MultiFileUpload.cshtml"
               Write(Html.Tooltip(MediaGlobalization.MultiFileUpload_SelectFolder_Help_Message));

            
            #line default
            #line hidden
            
            #line 25 "..\..\Views\Upload\MultiFileUpload.cshtml"
                                                                                               

            
            #line default
            #line hidden
WriteLiteral("                    <div");

WriteLiteral(" class=\"bcms-content-titles\"");

WriteLiteral(">");

            
            #line 26 "..\..\Views\Upload\MultiFileUpload.cshtml"
                                                Write(MediaGlobalization.MultiFileUpload_SelectFolder);

            
            #line default
            #line hidden
WriteLiteral("</div>\r\n");

            
            #line 27 "..\..\Views\Upload\MultiFileUpload.cshtml"
                    
            
            #line default
            #line hidden
            
            #line 27 "..\..\Views\Upload\MultiFileUpload.cshtml"
               Write(Html.DropDownListFor(f => f.SelectedFolderId, Model.Folders.Select(o => new SelectListItem { Selected = Model.SelectedFolderId == o.Item1, Text = o.Item2, Value = o.Item1.ToString() }), new { @class = "bcms-global-select" }));

            
            #line default
            #line hidden
            
            #line 27 "..\..\Views\Upload\MultiFileUpload.cshtml"
                                                                                                                                                                                                                                                     
                }
                else
                {
                    
            
            #line default
            #line hidden
            
            #line 31 "..\..\Views\Upload\MultiFileUpload.cshtml"
               Write(Html.HiddenFor(f => f.SelectedFolderId, new { @Value = Model.RootFolderId }));

            
            #line default
            #line hidden
            
            #line 31 "..\..\Views\Upload\MultiFileUpload.cshtml"
                                                                                                 
                }

            
            #line default
            #line hidden
WriteLiteral("            </div>\r\n");

            
            #line 34 "..\..\Views\Upload\MultiFileUpload.cshtml"


            
            #line default
            #line hidden
WriteLiteral("            <div");

WriteLiteral(" id=\"bcms-media-uploads\"");

WriteLiteral(">\r\n                <div");

WriteLiteral(" id=\"bcms-files-dropzone\"");

WriteLiteral(" class=\"bcms-dropzone\"");

WriteLiteral(">\r\n");

            
            #line 37 "..\..\Views\Upload\MultiFileUpload.cshtml"
                    
            
            #line default
            #line hidden
            
            #line 37 "..\..\Views\Upload\MultiFileUpload.cshtml"
                     if (Model.ReuploadMediaId.HasDefaultValue())
                    {

            
            #line default
            #line hidden
WriteLiteral("                        <div");

WriteLiteral(" class=\"bcms-dropzone-infotext\"");

WriteLiteral(">");

            
            #line 39 "..\..\Views\Upload\MultiFileUpload.cshtml"
                                                       Write(MediaGlobalization.MultiFileUpload_DragDropBox);

            
            #line default
            #line hidden
WriteLiteral("</div>\r\n");

            
            #line 40 "..\..\Views\Upload\MultiFileUpload.cshtml"
                    }
                    else
                    {

            
            #line default
            #line hidden
WriteLiteral("                        <div");

WriteLiteral(" class=\"bcms-dropzone-infotext\"");

WriteLiteral(">");

            
            #line 43 "..\..\Views\Upload\MultiFileUpload.cshtml"
                                                       Write(MediaGlobalization.MultiFileUpload_DragDropBox_Reupload);

            
            #line default
            #line hidden
WriteLiteral("</div>\r\n");

            
            #line 44 "..\..\Views\Upload\MultiFileUpload.cshtml"
                    }

            
            #line default
            #line hidden
WriteLiteral("                    <div");

WriteLiteral(" class=\"bcms-btn-upload-files\"");

WriteLiteral(">\r\n                        <label");

WriteLiteral(" for=\"bcms-files-upload-input\"");

WriteLiteral(" class=\"bcms-btn-upload-files-text\"");

WriteLiteral(">");

            
            #line 46 "..\..\Views\Upload\MultiFileUpload.cshtml"
                                                                                           Write(MediaGlobalization.MultiFileUpload_UploadButton);

            
            #line default
            #line hidden
WriteLiteral("</label>\r\n                        <input");

WriteLiteral(" type=\"file\"");

WriteLiteral("\r\n                               ");

            
            #line 48 "..\..\Views\Upload\MultiFileUpload.cshtml"
                           Write(Model.ReuploadMediaId.HasDefaultValue() ? "multiple=\"multiple\"" : string.Empty);

            
            #line default
            #line hidden
WriteLiteral(@"
                               name=""uploadFiles"" id=""bcms-files-upload-input"" style=""position: absolute; left: -999em; top: -999em;""
                               data-bind=""attr: { accept : filesToAccept() }"" />
                    </div>
                </div>

                <div");

WriteLiteral(" class=\"bcms-upload-holder\"");

WriteLiteral(" data-bind=\"template: { name: \'bcms-file-upload-template\' }\"");

WriteLiteral(">\r\n                </div>\r\n            </div>\r\n");

            
            #line 57 "..\..\Views\Upload\MultiFileUpload.cshtml"

            if (Model.AccessControlEnabled)
            {
                
            
            #line default
            #line hidden
            
            #line 60 "..\..\Views\Upload\MultiFileUpload.cshtml"
           Write(Html.Partial(RootModuleConstants.AccessControlTemplate));

            
            #line default
            #line hidden
            
            #line 60 "..\..\Views\Upload\MultiFileUpload.cshtml"
                                                                        
            }
        }

            
            #line default
            #line hidden
WriteLiteral("        <script");

WriteLiteral(" type=\"text/html\"");

WriteLiteral(" id=\"bcms-file-upload-template\"");

WriteLiteral(">\r\n            <div data-bind=\"visible: activeUploads().length > 0\">\r\n           " +
"     <div class=\"bcms-content-titles\">");

            
            #line 65 "..\..\Views\Upload\MultiFileUpload.cshtml"
                                            Write(MediaGlobalization.MultiFileUpload_Uploading);

            
            #line default
            #line hidden
WriteLiteral("<a class=\"bcms-icn-delete-link\" data-bind=\"click: cancelAllActiveUploads\">");

            
            #line 65 "..\..\Views\Upload\MultiFileUpload.cshtml"
                                                                                                                                                                   Write(MediaGlobalization.MultiFileUpload_CancelUploading);

            
            #line default
            #line hidden
WriteLiteral(@"</a></div>
            </div>
            <div data-bind=""foreach: uploads"">
                <div data-bind=""css: {
                     'bcms-upload-block': true,
                     'bcms-upload-success': uploadCompleted() && !uploadProcessing() && !uploadFailed(),
                     'bcms-upload-failed': uploadFailed(),
                     'bcms-single-tag-active': isActive()
                     }"">
                    <div class=""bcms-upload-file-titles"" data-bind=""text: fileName""></div>
                    <!-- ko if: !uploadFailed() -->
");

WriteLiteral("                    ");

            
            #line 76 "..\..\Views\Upload\MultiFileUpload.cshtml"
               Write(Html.HiddenFor(model => model.UploadedFiles, new { id = (string)null, data_bind = "value:fileId()" }));

            
            #line default
            #line hidden
WriteLiteral(@"
                    <!-- /ko -->
                    <div class=""bcms-upload-bar-holder"">
                        <div class=""bcms-progress-bar"" data-bind=""visible: !uploadCompleted() && !uploadFailed() && !uploadProcessing()"">
                            <div class=""bcms-progress"" style=""width: 0;"" data-bind=""style: { width: uploadProgress() + '%' }""></div>
                        </div>
                        <div class=""bcms-upload-description"" data-bind=""visible: uploadProcessing()"">
");

WriteLiteral("                            ");

            
            #line 83 "..\..\Views\Upload\MultiFileUpload.cshtml"
                       Write(MediaGlobalization.MultiFileUpload_Processing_ServerSide);

            
            #line default
            #line hidden
WriteLiteral(@"
                        </div>
                        <div class=""bcms-upload-description"" data-bind=""visible: uploadFailed(), attr: { title: failureMessage() }"">
                            <span data-bind=""visible: !(failureMessage() != null && failureMessage().length > 0)"">");

            
            #line 86 "..\..\Views\Upload\MultiFileUpload.cshtml"
                                                                                                             Write(MediaGlobalization.MultiFileUpload_Failed);

            
            #line default
            #line hidden
WriteLiteral(@"</span>
                            <span data-bind=""visible: failureMessage() != null && failureMessage().length > 0, text: failureMessage""></span>
                        </div>
                        <div class=""bcms-upload-description"" data-bind=""visible: uploadCompleted() && !uploadProcessing() && !uploadFailed()"">
");

WriteLiteral("                            ");

            
            #line 90 "..\..\Views\Upload\MultiFileUpload.cshtml"
                       Write(MediaGlobalization.MultiFileUpload_Success);

            
            #line default
            #line hidden
WriteLiteral(@"
                        </div>
                    </div>
                    <!-- ko if: isProgressVisible() -->
                    <div class=""bcms-uploaded-info"" data-bind=""text: uploadProgress() + '%'""></div>
                    <!-- /ko -->
                    <!-- ko if: !isProgressVisible() -->
                    <div class=""bcms-uploaded-info"">&nbsp;</div>
                    <!-- /ko -->
                    <div class=""bcms-upload-size-info""><b>");

            
            #line 99 "..\..\Views\Upload\MultiFileUpload.cshtml"
                                                     Write(MediaGlobalization.MultiFileUpload_FileSize);

            
            #line default
            #line hidden
WriteLiteral(@"</b> <span data-bind=""text: fileSizeFormated""></span></div>
                    <div class=""bcms-media-delete-holder"">
                        <a class=""bcms-icn-delete"" data-bind=""click: function() { $root.removeUpload($data); }, text: uploadCompleted() || uploadFailed() ? '");

            
            #line 101 "..\..\Views\Upload\MultiFileUpload.cshtml"
                                                                                                                                                        Write(RootGlobalization.Button_Remove);

            
            #line default
            #line hidden
WriteLiteral("\' : \'");

            
            #line 101 "..\..\Views\Upload\MultiFileUpload.cshtml"
                                                                                                                                                                                             Write(RootGlobalization.Button_Cancel);

            
            #line default
            #line hidden
WriteLiteral("\'\"></a>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n" +
"        </script>\r\n    </div>\r\n");

            
            #line 107 "..\..\Views\Upload\MultiFileUpload.cshtml"
}

            
            #line default
            #line hidden
WriteLiteral("</div>\r\n");

        }
    }
}
#pragma warning restore 1591
