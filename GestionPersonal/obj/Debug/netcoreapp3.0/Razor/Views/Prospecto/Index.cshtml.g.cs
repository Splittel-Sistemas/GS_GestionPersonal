#pragma checksum "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Prospecto\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7ce5a642e2bdd9dcbdca11b9cddd2d549d70efba"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Prospecto_Index), @"mvc.1.0.view", @"/Views/Prospecto/Index.cshtml")]
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
#line 1 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\_ViewImports.cshtml"
using GestionPersonal;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\_ViewImports.cshtml"
using GestionPersonal.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7ce5a642e2bdd9dcbdca11b9cddd2d549d70efba", @"/Views/Prospecto/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"44f628e23a2086c1f04f862587f80afdb82e0a32", @"/Views/_ViewImports.cshtml")]
    public class Views_Prospecto_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<GPSInformation.Models.Persona>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-outline-primary btn-sm d-flex align-items-center"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Prospecto\Index.cshtml"
  
    ViewData["Title"] = "Prospectos";

#line default
#line hidden
#nullable disable
            WriteLiteral("<div class=\"d-flex align-items-center justify-content-between mg-b-30\">\r\n    <h4 class=\"tx-15 mg-b-0\">");
#nullable restore
#line 7 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Prospecto\Index.cshtml"
                        Write(ViewData["Title"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\r\n    <div class=\"btn-group\" role=\"group\" aria-label=\"Basic example\">\r\n        <h2 class=\"tx-15 mg-b-0\"></h2>\r\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7ce5a642e2bdd9dcbdca11b9cddd2d549d70efba4696", async() => {
                WriteLiteral("<i class=\"icon ion-md-time mg-r-5 tx-16 lh--9\"></i>Crear nuevo");
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
            WriteLiteral("\r\n    </div>\r\n</div>\r\n<hr />\r\n<table class=\"table table-sm\">\r\n    <thead>\r\n        <tr>\r\n            <th>\r\n                ");
#nullable restore
#line 18 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Prospecto\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.IdPersona));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 21 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Prospecto\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.NombreCompelto));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 24 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Prospecto\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Nacimiento));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 27 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Prospecto\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.IdPuesto));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 30 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Prospecto\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.IdEstatusPros));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n\r\n            <th></th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
#nullable restore
#line 37 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Prospecto\Index.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\r\n            <td>\r\n                ");
#nullable restore
#line 41 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Prospecto\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.IdPersona));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 44 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Prospecto\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.NombreCompelto));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 47 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Prospecto\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Nacimiento));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            \r\n            <td>\r\n                ");
#nullable restore
#line 51 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Prospecto\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.IdPuesto));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 54 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Prospecto\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.IdEstatusPros));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 57 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Prospecto\Index.cshtml"
           Write(Html.ActionLink("Editar", "Edit", new {id=item.IdPersona }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n        </tr>\r\n");
#nullable restore
#line 60 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Prospecto\Index.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<GPSInformation.Models.Persona>> Html { get; private set; }
    }
}
#pragma warning restore 1591
