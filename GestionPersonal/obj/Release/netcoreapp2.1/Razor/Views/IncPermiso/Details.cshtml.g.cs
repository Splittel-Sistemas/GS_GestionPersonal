#pragma checksum "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\IncPermiso\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "375d59c9d5fcea445072be8a74fe7766294f4094"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_IncPermiso_Details), @"mvc.1.0.view", @"/Views/IncPermiso/Details.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/IncPermiso/Details.cshtml", typeof(AspNetCore.Views_IncPermiso_Details))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"375d59c9d5fcea445072be8a74fe7766294f4094", @"/Views/IncPermiso/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"44f628e23a2086c1f04f862587f80afdb82e0a32", @"/Views/_ViewImports.cshtml")]
    public class Views_IncPermiso_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<GPSInformation.Models.IncidenciaPermiso>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\IncPermiso\Details.cshtml"
  
    ViewData["Title"] = "Detalle de solicitud: " + Model.Folio;

#line default
#line hidden
            DefineSection("MenuTop", async() => {
                BeginContext(137, 304, true);
                WriteLiteral(@"
    <div class=""d-sm-flex align-items-center justify-content-between mg-b-20 mg-lg-b-25 mg-xl-b-30"">
        <div>
            <nav aria-label=""breadcrumb"">
                <ol class=""breadcrumb breadcrumb-style1 mg-b-10"">
                    <li class=""breadcrumb-item active"" aria-current=""page"">");
                EndContext();
                BeginContext(442, 17, false);
#line 10 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\IncPermiso\Details.cshtml"
                                                                      Write(ViewData["Title"]);

#line default
#line hidden
                EndContext();
                BeginContext(459, 95, true);
                WriteLiteral("</li>\r\n                </ol>\r\n            </nav>\r\n            <h4 class=\"mg-b-0 tx-spacing--1\">");
                EndContext();
                BeginContext(555, 17, false);
#line 13 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\IncPermiso\Details.cshtml"
                                        Write(ViewData["Title"]);

#line default
#line hidden
                EndContext();
                BeginContext(572, 64, true);
                WriteLiteral("</h4>\r\n        </div>\r\n        <div class=\"d-none d-md-block\">\r\n");
                EndContext();
#line 16 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\IncPermiso\Details.cshtml"
             if ((bool)ViewBag.ShowEdit && Model.Estatus == 2)
            {

#line default
#line hidden
                BeginContext(715, 18, true);
                WriteLiteral("                <a");
                EndContext();
                BeginWriteAttribute("href", " href=\"", 733, "\"", 812, 1);
#line 18 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\IncPermiso\Details.cshtml"
WriteAttributeValue("", 740, Url.Action("Edit","IncPermiso", new { id = Model.IdIncidenciaPermiso }), 740, 72, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(813, 113, true);
                WriteLiteral(" class=\"btn btn-sm pd-x-15 btn-white btn-uppercaser\"><i data-feather=\"edit\" class=\"wd-10 mg-r-5\"></i>Editar</a>\r\n");
                EndContext();
#line 19 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\IncPermiso\Details.cshtml"
            }

#line default
#line hidden
                BeginContext(941, 12, true);
                WriteLiteral("            ");
                EndContext();
#line 20 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\IncPermiso\Details.cshtml"
             if ((bool)ViewBag.ShowCancel && Model.Estatus <= 4 && Model.Fecha <= DateTime.Parse(DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd")))
            {

#line default
#line hidden
                BeginContext(1104, 10, true);
                WriteLiteral("        <a");
                EndContext();
                BeginWriteAttribute("href", " href=\"", 1114, "\"", 1197, 1);
#line 22 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\IncPermiso\Details.cshtml"
WriteAttributeValue("", 1121, Url.Action("Cancelar","IncPermiso", new { id = Model.IdIncidenciaPermiso }), 1121, 76, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(1198, 110, true);
                WriteLiteral(" class=\"btn btn-sm pd-x-15 btn-white btn-uppercaser\"><i data-feather=\"x\" class=\"wd-10 mg-r-5\"></i>Cancel</a>\r\n");
                EndContext();
#line 23 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\IncPermiso\Details.cshtml"
            }

#line default
#line hidden
                BeginContext(1323, 12, true);
                WriteLiteral("            ");
                EndContext();
#line 24 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\IncPermiso\Details.cshtml"
             if ((bool)ViewBag.ShowDelete)
            {

#line default
#line hidden
                BeginContext(1382, 10, true);
                WriteLiteral("        <a");
                EndContext();
                BeginWriteAttribute("href", " href=\"", 1392, "\"", 1473, 1);
#line 26 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\IncPermiso\Details.cshtml"
WriteAttributeValue("", 1399, Url.Action("Delete","IncPermiso", new { id = Model.IdIncidenciaPermiso }), 1399, 74, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(1474, 116, true);
                WriteLiteral(" class=\"btn btn-sm pd-x-15 btn-white btn-uppercaser\"><i data-feather=\"trash\" class=\"wd-10 mg-r-5\"></i>Eliminar</a>\r\n");
                EndContext();
#line 27 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\IncPermiso\Details.cshtml"
            }

#line default
#line hidden
                BeginContext(1605, 56, true);
                WriteLiteral("            \r\n            \r\n        </div>\r\n    </div>\r\n");
                EndContext();
            }
            );
#line 33 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\IncPermiso\Details.cshtml"
 if (ViewBag.MessageSuccess != null)
{

#line default
#line hidden
            BeginContext(1705, 123, true);
            WriteLiteral("    <div class=\"alert alert-success alert-dismissible fade show\" role=\"alert\">\r\n        <strong>Estimado usuario!</strong> ");
            EndContext();
            BeginContext(1829, 22, false);
#line 36 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\IncPermiso\Details.cshtml"
                                      Write(ViewBag.MessageSuccess);

#line default
#line hidden
            EndContext();
            BeginContext(1851, 166, true);
            WriteLiteral("\r\n        <button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\">\r\n            <span aria-hidden=\"true\">×</span>\r\n        </button>\r\n    </div>\r\n");
            EndContext();
#line 41 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\IncPermiso\Details.cshtml"
}

#line default
#line hidden
            BeginContext(2020, 155, true);
            WriteLiteral("<div data-label=\"Crear Nuevo Permiso\" class=\"df-example demo-forms\" id=\"app_createPermiso\">\r\n    <h4 class=\"bg-light\">I. Solicitante</h4>\r\n    <hr />\r\n    ");
            EndContext();
            BeginContext(2176, 85, false);
#line 45 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\IncPermiso\Details.cshtml"
Write(await Component.InvokeAsync("ValidPuestoEnOrganigrama", new { id = Model.IdPersona }));

#line default
#line hidden
            EndContext();
            BeginContext(2261, 149, true);
            WriteLiteral("\r\n    <h4 class=\"bg-light\">II. Detalle de solicitud</h4>\r\n    <hr />\r\n    <dl class=\"dl-horizontal row\">\r\n        <dt class=\"col-md-2\">\r\n            ");
            EndContext();
            BeginContext(2411, 41, false);
#line 50 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\IncPermiso\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Folio));

#line default
#line hidden
            EndContext();
            BeginContext(2452, 67, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-md-4 border\">\r\n            ");
            EndContext();
            BeginContext(2520, 37, false);
#line 53 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\IncPermiso\Details.cshtml"
       Write(Html.DisplayFor(model => model.Folio));

#line default
#line hidden
            EndContext();
            BeginContext(2557, 60, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-md-2\">\r\n            ");
            EndContext();
            BeginContext(2618, 41, false);
#line 56 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\IncPermiso\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Fecha));

#line default
#line hidden
            EndContext();
            BeginContext(2659, 67, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-md-4 border\">\r\n            ");
            EndContext();
            BeginContext(2727, 25, false);
#line 59 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\IncPermiso\Details.cshtml"
       Write(Model.Fecha.ToString("F"));

#line default
#line hidden
            EndContext();
            BeginContext(2752, 60, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-md-2\">\r\n            ");
            EndContext();
            BeginContext(2813, 42, false);
#line 62 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\IncPermiso\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Inicio));

#line default
#line hidden
            EndContext();
            BeginContext(2855, 67, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-md-4 border\">\r\n            ");
            EndContext();
            BeginContext(2923, 38, false);
#line 65 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\IncPermiso\Details.cshtml"
       Write(Html.DisplayFor(model => model.Inicio));

#line default
#line hidden
            EndContext();
            BeginContext(2961, 60, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-md-2\">\r\n            ");
            EndContext();
            BeginContext(3022, 39, false);
#line 68 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\IncPermiso\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Fin));

#line default
#line hidden
            EndContext();
            BeginContext(3061, 67, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-md-4 border\">\r\n            ");
            EndContext();
            BeginContext(3129, 35, false);
#line 71 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\IncPermiso\Details.cshtml"
       Write(Html.DisplayFor(model => model.Fin));

#line default
#line hidden
            EndContext();
            BeginContext(3164, 60, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-md-2\">\r\n            ");
            EndContext();
            BeginContext(3225, 51, false);
#line 74 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\IncPermiso\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.DEscripcionTipo));

#line default
#line hidden
            EndContext();
            BeginContext(3276, 67, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-md-4 border\">\r\n            ");
            EndContext();
            BeginContext(3344, 47, false);
#line 77 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\IncPermiso\Details.cshtml"
       Write(Html.DisplayFor(model => model.DEscripcionTipo));

#line default
#line hidden
            EndContext();
            BeginContext(3391, 153, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-md-2\">\r\n        </dt>\r\n        <dd class=\"col-md-4 \">\r\n        </dd>\r\n        <dt class=\"col-md-2\">\r\n            ");
            EndContext();
            BeginContext(3545, 53, false);
#line 84 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\IncPermiso\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.DescripcionAsunto));

#line default
#line hidden
            EndContext();
            BeginContext(3598, 68, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-md-10 border\">\r\n            ");
            EndContext();
            BeginContext(3667, 49, false);
#line 87 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\IncPermiso\Details.cshtml"
       Write(Html.DisplayFor(model => model.DescripcionAsunto));

#line default
#line hidden
            EndContext();
            BeginContext(3716, 17, true);
            WriteLiteral("\r\n        </dd>\r\n");
            EndContext();
#line 89 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\IncPermiso\Details.cshtml"
         if (Model.IdAsunto == 36)
        {

#line default
#line hidden
            BeginContext(3780, 51, true);
            WriteLiteral("            <dt class=\"col-md-2\">\r\n                ");
            EndContext();
            BeginContext(3832, 51, false);
#line 92 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\IncPermiso\Details.cshtml"
           Write(Html.DisplayNameFor(model => model.PagoPermisoDesc));

#line default
#line hidden
            EndContext();
            BeginContext(3883, 79, true);
            WriteLiteral("\r\n            </dt>\r\n            <dd class=\"col-md-4 border\">\r\n                ");
            EndContext();
            BeginContext(3963, 47, false);
#line 95 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\IncPermiso\Details.cshtml"
           Write(Html.DisplayFor(model => model.PagoPermisoDesc));

#line default
#line hidden
            EndContext();
            BeginContext(4010, 21, true);
            WriteLiteral("\r\n            </dd>\r\n");
            EndContext();
#line 97 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\IncPermiso\Details.cshtml"
        }

#line default
#line hidden
            BeginContext(4042, 130, true);
            WriteLiteral("    </dl>\r\n    <h4 class=\"bg-light\">III. Seguimiento</h4>\r\n    <hr />\r\n    <ul class=\"steps steps-sm steps-lg steps-justified \">\r\n");
            EndContext();
#line 102 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\IncPermiso\Details.cshtml"
         foreach (var item in Model.Proceso)
        {


            

#line default
#line hidden
#line 106 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\IncPermiso\Details.cshtml"
             if (item.Revisada)
            {

#line default
#line hidden
            BeginContext(4281, 268, true);
            WriteLiteral(@"                <li class=""step-item complete"">
                    <a href="""" class=""step-link"">
                        <span class=""step-icon""><i data-feather=""user""></i></span>
                        <div>
                            <span class=""step-title"">");
            EndContext();
            BeginContext(4550, 11, false);
#line 112 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\IncPermiso\Details.cshtml"
                                                Write(item.Titulo);

#line default
#line hidden
            EndContext();
            BeginContext(4561, 61, true);
            WriteLiteral("</span>\r\n                            <span class=\"step-desc\">");
            EndContext();
            BeginContext(4623, 19, false);
#line 113 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\IncPermiso\Details.cshtml"
                                               Write(item.NombreEmpleado);

#line default
#line hidden
            EndContext();
            BeginContext(4642, 42, true);
            WriteLiteral("</span>\r\n                            <span");
            EndContext();
            BeginWriteAttribute("class", " class=\"", 4684, "\"", 4761, 2);
            WriteAttributeValue("", 4692, "step-desc", 4692, 9, true);
#line 114 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\IncPermiso\Details.cshtml"
WriteAttributeValue(" ", 4701, Html.Raw(item.Autorizada ? "text-success" : "text-danger"), 4702, 59, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(4762, 1, true);
            WriteLiteral(">");
            EndContext();
            BeginContext(4764, 52, false);
#line 114 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\IncPermiso\Details.cshtml"
                                                                                                           Write(Html.Raw(item.Autorizada ? "Aceptada" : "Rechazada"));

#line default
#line hidden
            EndContext();
            BeginContext(4816, 61, true);
            WriteLiteral("</span>\r\n                            <span class=\"step-desc\">");
            EndContext();
            BeginContext(4878, 34, false);
#line 115 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\IncPermiso\Details.cshtml"
                                               Write(string.Format("{0:F}", item.Fecha));

#line default
#line hidden
            EndContext();
            BeginContext(4912, 90, true);
            WriteLiteral("</span>\r\n                        </div>\r\n                    </a>\r\n                </li>\r\n");
            EndContext();
#line 119 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\IncPermiso\Details.cshtml"
            }
            else if (!item.Revisada && item.Nivel == Model.Estatus)
            {

#line default
#line hidden
            BeginContext(5101, 266, true);
            WriteLiteral(@"                <li class=""step-item active"">
                    <a href="""" class=""step-link"">
                        <span class=""step-icon""><i data-feather=""user""></i></span>
                        <div>
                            <span class=""step-title"">");
            EndContext();
            BeginContext(5368, 11, false);
#line 126 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\IncPermiso\Details.cshtml"
                                                Write(item.Titulo);

#line default
#line hidden
            EndContext();
            BeginContext(5379, 90, true);
            WriteLiteral("</span>\r\n                        </div>\r\n                    </a>\r\n                </li>\r\n");
            EndContext();
#line 130 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\IncPermiso\Details.cshtml"
            }
            else
            {

#line default
#line hidden
            BeginContext(5517, 268, true);
            WriteLiteral(@"                <li class=""step-item disabled"">
                    <a href="""" class=""step-link"">
                        <span class=""step-icon""><i data-feather=""user""></i></span>
                        <div>
                            <span class=""step-title"">");
            EndContext();
            BeginContext(5786, 11, false);
#line 137 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\IncPermiso\Details.cshtml"
                                                Write(item.Titulo);

#line default
#line hidden
            EndContext();
            BeginContext(5797, 90, true);
            WriteLiteral("</span>\r\n                        </div>\r\n                    </a>\r\n                </li>\r\n");
            EndContext();
#line 141 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\IncPermiso\Details.cshtml"
            }

#line default
#line hidden
#line 141 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\IncPermiso\Details.cshtml"
             
        }

#line default
#line hidden
            BeginContext(5913, 13, true);
            WriteLiteral("\r\n    </ul>\r\n");
            EndContext();
            BeginContext(7746, 8, true);
            WriteLiteral("    \r\n\r\n");
            EndContext();
#line 190 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\IncPermiso\Details.cshtml"
     if (Model.Estatus >= 4)
    {

#line default
#line hidden
            BeginContext(7791, 12, true);
            WriteLiteral("        <div");
            EndContext();
            BeginWriteAttribute("class", " class=\"", 7803, "\"", 7854, 5);
            WriteAttributeValue("", 7811, "alert", 7811, 5, true);
            WriteAttributeValue(" ", 7816, "alert-", 7817, 7, true);
#line 192 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\IncPermiso\Details.cshtml"
WriteAttributeValue("", 7823, Model.EstatusColor, 7823, 19, false);

#line default
#line hidden
            WriteAttributeValue(" ", 7842, "mt-4", 7843, 5, true);
            WriteAttributeValue(" ", 7847, "mg-b-0", 7848, 7, true);
            EndWriteAttribute();
            BeginContext(7855, 91, true);
            WriteLiteral(" role=\"alert\">\r\n            Estimado usuario, la solcitud se encuentra con estatus <strong>");
            EndContext();
            BeginContext(7947, 23, false);
#line 193 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\IncPermiso\Details.cshtml"
                                                                      Write(Model.EstatusDescricion);

#line default
#line hidden
            EndContext();
            BeginContext(7970, 27, true);
            WriteLiteral("</strong>\r\n        </div>\r\n");
            EndContext();
#line 195 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\IncPermiso\Details.cshtml"
    }

#line default
#line hidden
            BeginContext(8004, 6, true);
            WriteLiteral("</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<GPSInformation.Models.IncidenciaPermiso> Html { get; private set; }
    }
}
#pragma warning restore 1591
