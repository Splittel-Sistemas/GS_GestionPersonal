#pragma checksum "C:\Luis Martinez backup\Personal\Developments\NET\GrupoSplittel\GrupoSplittel\GestionPersonal\Views\Organigrama\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0e99177b8166cc73ba900802677affd5d036bfa2"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Organigrama_Index), @"mvc.1.0.view", @"/Views/Organigrama/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Organigrama/Index.cshtml", typeof(AspNetCore.Views_Organigrama_Index))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0e99177b8166cc73ba900802677affd5d036bfa2", @"/Views/Organigrama/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"44f628e23a2086c1f04f862587f80afdb82e0a32", @"/Views/_ViewImports.cshtml")]
    public class Views_Organigrama_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<GPSInformation.Models.OrganigramaVersion>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "CreateNewVersion", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "C:\Luis Martinez backup\Personal\Developments\NET\GrupoSplittel\GrupoSplittel\GestionPersonal\Views\Organigrama\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
            BeginContext(103, 32, true);
            WriteLiteral("    <div id=\"app_organigrama\">\r\n");
            EndContext();
#line 6 "C:\Luis Martinez backup\Personal\Developments\NET\GrupoSplittel\GrupoSplittel\GestionPersonal\Views\Organigrama\Index.cshtml"
         if (Model.Where(a => a.Autirizada == 2).ToList().Count <= 0)
        {

#line default
#line hidden
            BeginContext(217, 462, true);
            WriteLiteral(@"            <div class=""alert alert-warning "" role=""alert"">
                <h4 class=""alert-heading"">Advertencia!</h4>
                <p>Gestión de personal necesita un tener un organigrama autorizado para poder funcionar correctamente, de ello depende que los empleados puedan generar sus solicitudes de vaciones y permisos</p>
                <hr>
                <p class=""mb-0"">Por favor crea un organigrama o autoriza alguno!</p>
            </div>
");
            EndContext();
#line 14 "C:\Luis Martinez backup\Personal\Developments\NET\GrupoSplittel\GrupoSplittel\GestionPersonal\Views\Organigrama\Index.cshtml"
        }

#line default
#line hidden
            BeginContext(690, 240, true);
            WriteLiteral("\r\n        <div id=\"contactLogs\" class=\"tab-pane pd-20 pd-xl-25 active\">\r\n            <div class=\"d-flex align-items-center justify-content-between mg-b-30\">\r\n                <h4 class=\"tx-15 mg-b-0\">Lista de versiones</h4>\r\n                ");
            EndContext();
            BeginContext(930, 193, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d449a34e37c54c16ab698ca78be6009a", async() => {
                BeginContext(966, 150, true);
                WriteLiteral("\r\n                    <button type=\"submit\" class=\"btn btn-outline-primary btn-sm  d-flex align-items-center\">Agregar nueva</button>\r\n                ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1123, 162, true);
            WriteLiteral("\r\n            </div>\r\n        </div>\r\n        <table class=\"table\">\r\n            <thead>\r\n                <tr>\r\n                    <th>\r\n                        ");
            EndContext();
            BeginContext(1286, 56, false);
#line 28 "C:\Luis Martinez backup\Personal\Developments\NET\GrupoSplittel\GrupoSplittel\GestionPersonal\Views\Organigrama\Index.cshtml"
                   Write(Html.DisplayNameFor(model => model.IdOrganigramaVersion));

#line default
#line hidden
            EndContext();
            BeginContext(1342, 79, true);
            WriteLiteral("\r\n                    </th>\r\n                    <th>\r\n                        ");
            EndContext();
            BeginContext(1422, 49, false);
#line 31 "C:\Luis Martinez backup\Personal\Developments\NET\GrupoSplittel\GrupoSplittel\GestionPersonal\Views\Organigrama\Index.cshtml"
                   Write(Html.DisplayNameFor(model => model.FechaCreacion));

#line default
#line hidden
            EndContext();
            BeginContext(1471, 79, true);
            WriteLiteral("\r\n                    </th>\r\n                    <th>\r\n                        ");
            EndContext();
            BeginContext(1551, 54, false);
#line 34 "C:\Luis Martinez backup\Personal\Developments\NET\GrupoSplittel\GrupoSplittel\GestionPersonal\Views\Organigrama\Index.cshtml"
                   Write(Html.DisplayNameFor(model => model.FechaActualizacion));

#line default
#line hidden
            EndContext();
            BeginContext(1605, 79, true);
            WriteLiteral("\r\n                    </th>\r\n                    <th>\r\n                        ");
            EndContext();
            BeginContext(1685, 46, false);
#line 37 "C:\Luis Martinez backup\Personal\Developments\NET\GrupoSplittel\GrupoSplittel\GestionPersonal\Views\Organigrama\Index.cshtml"
                   Write(Html.DisplayNameFor(model => model.Autirizada));

#line default
#line hidden
            EndContext();
            BeginContext(1731, 126, true);
            WriteLiteral("\r\n                    </th>\r\n                    <th></th>\r\n                </tr>\r\n            </thead>\r\n            <tbody>\r\n");
            EndContext();
#line 43 "C:\Luis Martinez backup\Personal\Developments\NET\GrupoSplittel\GrupoSplittel\GestionPersonal\Views\Organigrama\Index.cshtml"
                 foreach (var item in Model)
                {

#line default
#line hidden
            BeginContext(1922, 84, true);
            WriteLiteral("                    <tr>\r\n                        <td>\r\n                            ");
            EndContext();
            BeginContext(2007, 55, false);
#line 47 "C:\Luis Martinez backup\Personal\Developments\NET\GrupoSplittel\GrupoSplittel\GestionPersonal\Views\Organigrama\Index.cshtml"
                       Write(Html.DisplayFor(modelItem => item.IdOrganigramaVersion));

#line default
#line hidden
            EndContext();
            BeginContext(2062, 91, true);
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
            EndContext();
            BeginContext(2154, 48, false);
#line 50 "C:\Luis Martinez backup\Personal\Developments\NET\GrupoSplittel\GrupoSplittel\GestionPersonal\Views\Organigrama\Index.cshtml"
                       Write(Html.DisplayFor(modelItem => item.FechaCreacion));

#line default
#line hidden
            EndContext();
            BeginContext(2202, 91, true);
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
            EndContext();
            BeginContext(2294, 53, false);
#line 53 "C:\Luis Martinez backup\Personal\Developments\NET\GrupoSplittel\GrupoSplittel\GestionPersonal\Views\Organigrama\Index.cshtml"
                       Write(Html.DisplayFor(modelItem => item.FechaActualizacion));

#line default
#line hidden
            EndContext();
            BeginContext(2347, 63, true);
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n");
            EndContext();
#line 56 "C:\Luis Martinez backup\Personal\Developments\NET\GrupoSplittel\GrupoSplittel\GestionPersonal\Views\Organigrama\Index.cshtml"
                             if (item.Autirizada == 2)
                            {

#line default
#line hidden
            BeginContext(2497, 96, true);
            WriteLiteral("                                <span class=\"badge badge-pill badge-primary\">Antorizado</span>\r\n");
            EndContext();
#line 59 "C:\Luis Martinez backup\Personal\Developments\NET\GrupoSplittel\GrupoSplittel\GestionPersonal\Views\Organigrama\Index.cshtml"
                            }
                            else
                            {

#line default
#line hidden
            BeginContext(2689, 97, true);
            WriteLiteral("                                <span class=\"badge badge-pill badge-light\">No Antorizado</span>\r\n");
            EndContext();
#line 63 "C:\Luis Martinez backup\Personal\Developments\NET\GrupoSplittel\GrupoSplittel\GestionPersonal\Views\Organigrama\Index.cshtml"
                            }

#line default
#line hidden
            BeginContext(2817, 89, true);
            WriteLiteral("                        </td>\r\n                        <td>\r\n                            ");
            EndContext();
            BeginContext(2907, 71, false);
#line 66 "C:\Luis Martinez backup\Personal\Developments\NET\GrupoSplittel\GrupoSplittel\GestionPersonal\Views\Organigrama\Index.cshtml"
                       Write(Html.ActionLink("Editar", "Edit", new { id=item.IdOrganigramaVersion }));

#line default
#line hidden
            EndContext();
            BeginContext(2978, 61, true);
            WriteLiteral(" \r\n                        </td>\r\n                    </tr>\r\n");
            EndContext();
#line 69 "C:\Luis Martinez backup\Personal\Developments\NET\GrupoSplittel\GrupoSplittel\GestionPersonal\Views\Organigrama\Index.cshtml"
                }

#line default
#line hidden
            BeginContext(3058, 54, true);
            WriteLiteral("            </tbody>\r\n        </table>\r\n    </div>\r\n\r\n");
            EndContext();
            DefineSection("Scripts", async() => {
                BeginContext(3130, 4, true);
                WriteLiteral("\r\n\r\n");
                EndContext();
            }
            );
            BeginContext(3137, 4, true);
            WriteLiteral("\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<GPSInformation.Models.OrganigramaVersion>> Html { get; private set; }
    }
}
#pragma warning restore 1591
