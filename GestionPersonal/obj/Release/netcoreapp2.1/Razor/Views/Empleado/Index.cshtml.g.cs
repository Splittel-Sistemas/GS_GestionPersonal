#pragma checksum "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Empleado\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "15a7ff4ec4eadfcb6dacc131febde887224cff2f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Empleado_Index), @"mvc.1.0.view", @"/Views/Empleado/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Empleado/Index.cshtml", typeof(AspNetCore.Views_Empleado_Index))]
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
#line 1 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\_ViewImports.cshtml"
using GestionPersonal;

#line default
#line hidden
#line 2 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\_ViewImports.cshtml"
using GestionPersonal.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"15a7ff4ec4eadfcb6dacc131febde887224cff2f", @"/Views/Empleado/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"44f628e23a2086c1f04f862587f80afdb82e0a32", @"/Views/_ViewImports.cshtml")]
    public class Views_Empleado_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<GPSInformation.Views.View_empleado>>
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
            BeginContext(56, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Empleado\Index.cshtml"
  
    ViewData["Title"] = "Lista de empleados";

#line default
#line hidden
            BeginContext(112, 102, true);
            WriteLiteral("<div class=\"d-flex align-items-center justify-content-between mg-b-30\">\r\n    <h4 class=\"tx-15 mg-b-0\">");
            EndContext();
            BeginContext(215, 17, false);
#line 7 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Empleado\Index.cshtml"
                        Write(ViewData["Title"]);

#line default
#line hidden
            EndContext();
            BeginContext(232, 116, true);
            WriteLiteral("</h4>\r\n    <div class=\"btn-group\" role=\"group\" aria-label=\"Basic example\">\r\n        <h2 class=\"tx-15 mg-b-0\"></h2>\r\n");
            EndContext();
#line 10 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Empleado\Index.cshtml"
         if ((bool)ViewBag.AccesoEdit == true)
        {

#line default
#line hidden
            BeginContext(407, 12, true);
            WriteLiteral("            ");
            EndContext();
            BeginContext(419, 154, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9407bd89261f4248a332ba554740cade", async() => {
                BeginContext(507, 62, true);
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
            BeginContext(573, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 13 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Empleado\Index.cshtml"
        }

#line default
#line hidden
            BeginContext(586, 310, true);
            WriteLiteral(@"    </div>
</div>
<hr />
<table class=""table table-sm"">
    <thead>
        <tr>
            <th>Nomina</th>
            <th>Empleado</th>
            <th>Departamento</th>
            <th>Puesto</th>
            <th>Tipo Nomina</th>
            <th></th>
        </tr>
    </thead>
    <tbody>
");
            EndContext();
#line 29 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Empleado\Index.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
            BeginContext(945, 30, true);
            WriteLiteral("        <tr>\r\n            <td>");
            EndContext();
            BeginContext(976, 17, false);
#line 32 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Empleado\Index.cshtml"
           Write(item.NumeroNomina);

#line default
#line hidden
            EndContext();
            BeginContext(993, 23, true);
            WriteLiteral("</td>\r\n            <td>");
            EndContext();
            BeginContext(1017, 19, false);
#line 33 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Empleado\Index.cshtml"
           Write(item.NombreCompleto);

#line default
#line hidden
            EndContext();
            BeginContext(1036, 23, true);
            WriteLiteral("</td>\r\n            <td>");
            EndContext();
            BeginContext(1060, 23, false);
#line 34 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Empleado\Index.cshtml"
           Write(item.NombreDepartamento);

#line default
#line hidden
            EndContext();
            BeginContext(1083, 23, true);
            WriteLiteral("</td>\r\n            <td>");
            EndContext();
            BeginContext(1107, 17, false);
#line 35 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Empleado\Index.cshtml"
           Write(item.PuestoNombre);

#line default
#line hidden
            EndContext();
            BeginContext(1124, 41, true);
            WriteLiteral("</td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(1166, 15, false);
#line 37 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Empleado\Index.cshtml"
           Write(item.TipoNomina);

#line default
#line hidden
            EndContext();
            BeginContext(1181, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 38 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Empleado\Index.cshtml"
                 if (item.IdEstatus != 19)
                {

#line default
#line hidden
            BeginContext(1246, 53, true);
            WriteLiteral("                    <span class=\"badge badge-danger\">");
            EndContext();
            BeginContext(1300, 23, false);
#line 40 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Empleado\Index.cshtml"
                                                Write(item.EstatusDescripcion);

#line default
#line hidden
            EndContext();
            BeginContext(1323, 9, true);
            WriteLiteral("</span>\r\n");
            EndContext();
#line 41 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Empleado\Index.cshtml"
                }

#line default
#line hidden
            BeginContext(1351, 435, true);
            WriteLiteral(@"            </td>
            <td>


                <div class=""dropdown"">
                    <button class=""btn btn-light btn-sm dropdown-toggle"" type=""button"" id=""dropleftMenuButton"" data-toggle=""dropdown"" aria-haspopup=""true"" aria-expanded=""false"">
                        Opciones
                    </button>
                    <div class=""dropdown-menu"" aria-labelledby=""dropleftMenuButton"">
                        ");
            EndContext();
            BeginContext(1787, 138, false);
#line 51 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Empleado\Index.cshtml"
                   Write(Html.ActionLink((bool)ViewBag.AccesoEdit == true ? "Editar": "Ver", "Edit", new { id = item.IdPersona }, new { @class = "dropdown-item" }));

#line default
#line hidden
            EndContext();
            BeginContext(1925, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 52 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Empleado\Index.cshtml"
                         if ((bool)ViewBag.AccesoEdit == true)
                        {
                            

#line default
#line hidden
            BeginContext(2047, 109, false);
#line 54 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Empleado\Index.cshtml"
                       Write(Html.ActionLink("Acceso", "Create", "Usuario", new { id = item.IdPersona }, new { @class = "dropdown-item" }));

#line default
#line hidden
            EndContext();
            BeginContext(2187, 111, false);
#line 55 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Empleado\Index.cshtml"
                       Write(Html.ActionLink("Contrato", "Index", "Contrato", new { id = item.IdPersona }, new { @class = "dropdown-item" }));

#line default
#line hidden
            EndContext();
            BeginContext(2329, 120, false);
#line 56 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Empleado\Index.cshtml"
                       Write(Html.ActionLink("Expediente", "Expediente", "Expediente", new { id = item.IdPersona }, new { @class = "dropdown-item" }));

#line default
#line hidden
            EndContext();
            BeginContext(2480, 130, false);
#line 57 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Empleado\Index.cshtml"
                       Write(Html.ActionLink("Ver peridos", "Periodos", "IncidenciaVacacion", new { id = item.NumeroNomina }, new { @class = "dropdown-item" }));

#line default
#line hidden
            EndContext();
#line 57 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Empleado\Index.cshtml"
                                                                                                                                                               
                        }

#line default
#line hidden
            BeginContext(2639, 88, true);
            WriteLiteral("\r\n                    </div>\r\n                </div>\r\n            </td>\r\n        </tr>\r\n");
            EndContext();
#line 64 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Empleado\Index.cshtml"
        }

#line default
#line hidden
            BeginContext(2738, 24, true);
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<GPSInformation.Views.View_empleado>> Html { get; private set; }
    }
}
#pragma warning restore 1591
