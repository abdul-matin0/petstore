#pragma checksum "C:\Users\Admin\source\repos\PetsFactory\PetsFactory\Areas\Admin\Views\Notifications\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "37dc9c6e812e525e9cd3c7ee1198e0566f47a1d6"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Notifications_Index), @"mvc.1.0.view", @"/Areas/Admin/Views/Notifications/Index.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\Admin\source\repos\PetsFactory\PetsFactory\Areas\Admin\Views\_ViewImports.cshtml"
using PetsFactory;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Admin\source\repos\PetsFactory\PetsFactory\Areas\Admin\Views\_ViewImports.cshtml"
using PetsFactory.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"37dc9c6e812e525e9cd3c7ee1198e0566f47a1d6", @"/Areas/Admin/Views/Notifications/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"55bd61a6f9ea53260e12fcc90a6879e2f7389bb4", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_Notifications_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Notifications>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-area", "Admin", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Home", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Users\Admin\source\repos\PetsFactory\PetsFactory\Areas\Admin\Views\Notifications\Index.cshtml"
  
    ViewData["Title"] = "Notificatoins";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<div class=""page-wrapper"">
    <!-- Page-header start -->
    <div class=""page-header card"">
        <div class=""row align-items-end"">
            <div class=""col-lg-8"">
                <div class=""page-header-title"">
                    <i class=""icofont icofont-alarm bg-c-blue""></i>
                    <div class=""d-inline"">
                        <h4>");
#nullable restore
#line 14 "C:\Users\Admin\source\repos\PetsFactory\PetsFactory\Areas\Admin\Views\Notifications\Index.cshtml"
                       Write(ViewData["Title"]);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h4>
                    </div>
                </div>
            </div>
            <div class=""col-lg-4"">
                <div class=""page-header-breadcrumb"">
                    <ul class=""breadcrumb-title"">
                        <li class=""breadcrumb-item"">
                            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "37dc9c6e812e525e9cd3c7ee1198e0566f47a1d65289", async() => {
                WriteLiteral("\r\n                                <i class=\"icofont icofont-home\"></i>\r\n                            ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Area = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                        </li>
                        <li class=""breadcrumb-item"">
                            Notifications
                        </li>
                    </ul>
                </div>
            </div>
        </div>
    </div>
    <!-- Page-header end -->



    <div class=""page-body"">
        <div class=""row"">
            <div class=""col-md-12 col-xl-6"">
                <div class=""card add-task-card"">
                    <div class=""card-header"">
                        <div class=""card-header-left"">
                            <h5>Notifications list</h5>
                        </div>
                        
                    </div>
                    <div class=""card-block"">
                        <!-- notificaitons cards block -->
");
#nullable restore
#line 50 "C:\Users\Admin\source\repos\PetsFactory\PetsFactory\Areas\Admin\Views\Notifications\Index.cshtml"
                         foreach (var item in Model)
                        {
                            

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                            <div class=""to-do-list"">
                                <div class=""checkbox-fade fade-in-primary d-block"">
                                    <label class=""check-task d-block"">
                                        <a onClick=Delete(""/Admin/Notifications/Delete/");
#nullable restore
#line 56 "C:\Users\Admin\source\repos\PetsFactory\PetsFactory\Areas\Admin\Views\Notifications\Index.cshtml"
                                                                                  Write(item.Id);

#line default
#line hidden
#nullable disable
            WriteLiteral(@""") class=""btn btn-danger"" style=""cursor: pointer"">
                                            <i class=""icofont icofont-trash text-white"" style=""color: #fff;""></i>
                                        </a>
                                        <span>
                                            <h6>");
#nullable restore
#line 60 "C:\Users\Admin\source\repos\PetsFactory\PetsFactory\Areas\Admin\Views\Notifications\Index.cshtml"
                                           Write(item.Message);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h6>\r\n                                            <p class=\"text-muted m-l-40\">");
#nullable restore
#line 61 "C:\Users\Admin\source\repos\PetsFactory\PetsFactory\Areas\Admin\Views\Notifications\Index.cshtml"
                                                                    Write(item.DateAdded.ToString("dd MMM yy"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                                        </span>\r\n                                    </label>\r\n                                </div>\r\n                            </div>\r\n");
#nullable restore
#line 66 "C:\Users\Admin\source\repos\PetsFactory\PetsFactory\Areas\Admin\Views\Notifications\Index.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Notifications>> Html { get; private set; }
    }
}
#pragma warning restore 1591
