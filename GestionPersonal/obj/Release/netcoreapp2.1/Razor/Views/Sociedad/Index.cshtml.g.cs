#pragma checksum "C:\Luis Martinez backup\Personal\Developments\NET\GrupoSplittel\GrupoSplittel\GestionPersonal\Views\Sociedad\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "26e4fca5f14d547ddee60df6b8128662efc0e622"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Sociedad_Index), @"mvc.1.0.view", @"/Views/Sociedad/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Sociedad/Index.cshtml", typeof(AspNetCore.Views_Sociedad_Index))]
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
#line 1 "C:\Luis Martinez backup\Personal\Developments\NET\GrupoSplittel\GrupoSplittel\GestionPersonal\Views\_ViewImports.cshtml"
using GestionPersonal;

#line default
#line hidden
#line 2 "C:\Luis Martinez backup\Personal\Developments\NET\GrupoSplittel\GrupoSplittel\GestionPersonal\Views\_ViewImports.cshtml"
using GestionPersonal.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"26e4fca5f14d547ddee60df6b8128662efc0e622", @"/Views/Sociedad/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"44f628e23a2086c1f04f862587f80afdb82e0a32", @"/Views/_ViewImports.cshtml")]
    public class Views_Sociedad_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<GPSInformation.Models.Sociedad>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-outline-primary btn-sm d-flex align-items-center"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
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
            BeginContext(52, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Luis Martinez backup\Personal\Developments\NET\GrupoSplittel\GrupoSplittel\GestionPersonal\Views\Sociedad\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
            BeginContext(95, 102, true);
            WriteLiteral("<div class=\"d-flex align-items-center justify-content-between mg-b-30\">\r\n    <h4 class=\"tx-15 mg-b-0\">");
            EndContext();
            BeginContext(198, 17, false);
#line 7 "C:\Luis Martinez backup\Personal\Developments\NET\GrupoSplittel\GrupoSplittel\GestionPersonal\Views\Sociedad\Index.cshtml"
                        Write(ViewData["Title"]);

#line default
#line hidden
            EndContext();
            BeginContext(215, 124, true);
            WriteLiteral("</h4>\r\n    <div class=\"btn-group\" role=\"group\" aria-label=\"Basic example\">\r\n        <h2 class=\"tx-15 mg-b-0\"></h2>\r\n        ");
            EndContext();
            BeginContext(339, 154, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5beaf5821090441494a3b1734589fab8", async() => {
                BeginContext(427, 62, true);
                WriteLiteral("<i class=\"icon ion-md-time mg-r-5 tx-16 lh--9\"></i>Crear nuevo");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(493, 114, true);
            WriteLiteral("\r\n    </div>\r\n</div>\r\n<hr />\r\n<table class=\"table\">\r\n    <thead>\r\n        <tr>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(608, 46, false);
#line 18 "C:\Luis Martinez backup\Personal\Developments\NET\GrupoSplittel\GrupoSplittel\GestionPersonal\Views\Sociedad\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.IdSociedad));

#line default
#line hidden
            EndContext();
            BeginContext(654, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(710, 47, false);
#line 21 "C:\Luis Martinez backup\Personal\Developments\NET\GrupoSplittel\GrupoSplittel\GestionPersonal\Views\Sociedad\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Descripcion));

#line default
#line hidden
            EndContext();
            BeginContext(757, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(813, 45, false);
#line 24 "C:\Luis Martinez backup\Personal\Developments\NET\GrupoSplittel\GrupoSplittel\GestionPersonal\Views\Sociedad\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Direccion));

#line default
#line hidden
            EndContext();
            BeginContext(858, 86, true);
            WriteLiteral("\r\n            </th>\r\n            <th></th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
            EndContext();
#line 30 "C:\Luis Martinez backup\Personal\Developments\NET\GrupoSplittel\GrupoSplittel\GestionPersonal\Views\Sociedad\Index.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
            BeginContext(993, 60, true);
            WriteLiteral("            <tr>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(1054, 45, false);
#line 34 "C:\Luis Martinez backup\Personal\Developments\NET\GrupoSplittel\GrupoSplittel\GestionPersonal\Views\Sociedad\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.IdSociedad));

#line default
#line hidden
            EndContext();
            BeginContext(1099, 67, true);
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(1167, 46, false);
#line 37 "C:\Luis Martinez backup\Personal\Developments\NET\GrupoSplittel\GrupoSplittel\GestionPersonal\Views\Sociedad\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.Descripcion));

#line default
#line hidden
            EndContext();
            BeginContext(1213, 67, true);
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(1281, 44, false);
#line 40 "C:\Luis Martinez backup\Personal\Developments\NET\GrupoSplittel\GrupoSplittel\GestionPersonal\Views\Sociedad\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.Direccion));

#line default
#line hidden
            EndContext();
            BeginContext(1325, 67, true);
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(1393, 63, false);
#line 43 "C:\Luis Martinez backup\Personal\Developments\NET\GrupoSplittel\GrupoSplittel\GestionPersonal\Views\Sociedad\Index.cshtml"
               Write(Html.ActionLink("Editar", "Edit", new { id = item.IdSociedad }));

#line default
#line hidden
            EndContext();
            BeginContext(1456, 1, true);
            WriteLiteral(" ");
            EndContext();
            BeginContext(1658, 44, true);
            WriteLiteral("\r\n                </td>\r\n            </tr>\r\n");
            EndContext();
#line 48 "C:\Luis Martinez backup\Personal\Developments\NET\GrupoSplittel\GrupoSplittel\GestionPersonal\Views\Sociedad\Index.cshtml"
        }

#line default
#line hidden
            BeginContext(1713, 24, true);
            WriteLiteral("    </tbody>\r\n</table>\r\n");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<GPSInformation.Models.Sociedad>> Html { get; private set; }
    }
}
#pragma warning restore 1591
