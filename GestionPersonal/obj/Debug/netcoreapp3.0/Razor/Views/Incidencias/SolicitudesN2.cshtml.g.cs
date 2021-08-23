#pragma checksum "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Incidencias\SolicitudesN2.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "12bd37fdb4ffe65f74a10acb6418ef3e620bdb2b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Incidencias_SolicitudesN2), @"mvc.1.0.view", @"/Views/Incidencias/SolicitudesN2.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"12bd37fdb4ffe65f74a10acb6418ef3e620bdb2b", @"/Views/Incidencias/SolicitudesN2.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"44f628e23a2086c1f04f862587f80afdb82e0a32", @"/Views/_ViewImports.cshtml")]
    public class Views_Incidencias_SolicitudesN2 : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Incidencias\SolicitudesN2.cshtml"
  
    ViewData["Title"] = "Solicitudes pendientes de aprobación N2";
    List<GPSInformation.Models.IncidenciaPermiso> Permisos = ViewBag.Permisos;
    List<GPSInformation.Models.IncidenciaVacacion> Vacaciones = ViewBag.Vacaciones;

#line default
#line hidden
#nullable disable
            DefineSection("MenuTop", async() => {
                WriteLiteral(@"
    <div class=""d-sm-flex align-items-center justify-content-between mg-b-20 mg-lg-b-25 mg-xl-b-30"">
        <div>
            <nav aria-label=""breadcrumb"">
                <ol class=""breadcrumb breadcrumb-style1 mg-b-10"">
                    <li class=""breadcrumb-item active"" aria-current=""page"">");
#nullable restore
#line 11 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Incidencias\SolicitudesN2.cshtml"
                                                                      Write(ViewData["Title"]);

#line default
#line hidden
#nullable disable
                WriteLiteral("</li>\r\n                </ol>\r\n            </nav>\r\n            <h4 class=\"mg-b-0 tx-spacing--1\">");
#nullable restore
#line 14 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Incidencias\SolicitudesN2.cshtml"
                                        Write(ViewData["Title"]);

#line default
#line hidden
#nullable disable
                WriteLiteral("</h4>\r\n        </div>\r\n        <div class=\"d-none d-md-block\">\r\n        </div>\r\n    </div>\r\n");
            }
            );
            WriteLiteral("\r\n<ul class=\"nav nav-tabs\" id=\"myTab\" role=\"tablist\">\r\n    <li class=\"nav-item\">\r\n        <a");
            BeginWriteAttribute("class", " class=\"", 879, "\"", 950, 2);
            WriteAttributeValue("", 887, "nav-link", 887, 8, true);
#nullable restore
#line 23 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Incidencias\SolicitudesN2.cshtml"
WriteAttributeValue(" ", 895, Html.Raw(ViewBag.Tab == "Vacaciones" ? "active" : ""), 896, 54, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" id=\"home-tab\" data-toggle=\"tab\" href=\"#home\" role=\"tab\" aria-controls=\"home\" aria-selected=\"true\">Vacaciones</a>\r\n    </li>\r\n    <li class=\"nav-item\">\r\n        <a");
            BeginWriteAttribute("class", " class=\"", 1114, "\"", 1183, 2);
            WriteAttributeValue("", 1122, "nav-link", 1122, 8, true);
#nullable restore
#line 26 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Incidencias\SolicitudesN2.cshtml"
WriteAttributeValue(" ", 1130, Html.Raw(ViewBag.Tab == "Permisos" ? "active" : ""), 1131, 52, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" id=\"profile-tab\" data-toggle=\"tab\" href=\"#profile\" role=\"tab\" aria-controls=\"profile\" aria-selected=\"false\">Permisos</a>\r\n    </li>\r\n\r\n</ul>\r\n<div class=\"tab-content bd bd-gray-300 bd-t-0 pd-20\" id=\"myTabContent\">\r\n    <div");
            BeginWriteAttribute("class", " class=\"", 1408, "\"", 1489, 3);
            WriteAttributeValue("", 1416, "tab-pane", 1416, 8, true);
            WriteAttributeValue(" ", 1424, "fade", 1425, 5, true);
#nullable restore
#line 31 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Incidencias\SolicitudesN2.cshtml"
WriteAttributeValue(" ", 1429, Html.Raw(ViewBag.Tab == "Vacaciones" ? "show active" : ""), 1430, 59, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" id=""home"" role=""tabpanel"" aria-labelledby=""home-tab"">
        <table class=""table table-condensed table-hover display compact"" id=""lista_misSolicitudesVaca"">
            <thead>
                <tr>
                    <th>
                        Folio
                    </th>
                    <th>
                        Empleado
                    </th>
                    <th>
                        No.Dias
                    </th>
                    <th>
                        Salida
                    </th>
                    <th>
                        ultimo día
                    </th>
                    <th>
                        Estatus
                    </th>
                    <th></th>
                </tr>
            </thead>
            <tbody>
");
#nullable restore
#line 57 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Incidencias\SolicitudesN2.cshtml"
                 foreach (var item in Vacaciones)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <tr>\r\n                        <td>\r\n                            ");
#nullable restore
#line 61 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Incidencias\SolicitudesN2.cshtml"
                       Write(Html.DisplayFor(modelItem => item.Folio));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
#nullable restore
#line 64 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Incidencias\SolicitudesN2.cshtml"
                       Write(Html.DisplayFor(modelItem => item.EmpleadoNombre));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
#nullable restore
#line 67 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Incidencias\SolicitudesN2.cshtml"
                       Write(Html.DisplayFor(modelItem => item.NoDias));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
#nullable restore
#line 70 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Incidencias\SolicitudesN2.cshtml"
                       Write(Html.DisplayFor(modelItem => item.Inicio));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
#nullable restore
#line 73 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Incidencias\SolicitudesN2.cshtml"
                       Write(Html.DisplayFor(modelItem => item.Fin));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            <span");
            BeginWriteAttribute("class", " class=\"", 3136, "\"", 3215, 4);
            WriteAttributeValue("", 3144, "badge", 3144, 5, true);
            WriteAttributeValue(" ", 3149, "badge-pill", 3150, 11, true);
            WriteAttributeValue(" ", 3160, "badge-", 3161, 7, true);
#nullable restore
#line 76 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Incidencias\SolicitudesN2.cshtml"
WriteAttributeValue("", 3167, Html.DisplayFor(modelItem => item.EstatusColor), 3167, 48, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 76 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Incidencias\SolicitudesN2.cshtml"
                                                                                                             Write(Html.DisplayFor(modelItem => item.EstatusDescricion));

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                        </td>\r\n                        <td>\r\n                            ");
#nullable restore
#line 79 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Incidencias\SolicitudesN2.cshtml"
                       Write(Html.ActionLink("Autorizar", "Autorizar", "IncVacacion", new { id = item.EncriptId, Mode = GPSInformation.Tools.EncryptData.Encrypt("3") }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                    </tr>\r\n");
#nullable restore
#line 82 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Incidencias\SolicitudesN2.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </tbody>\r\n        </table>\r\n    </div>\r\n    <div");
            BeginWriteAttribute("class", " class=\"", 3647, "\"", 3726, 3);
            WriteAttributeValue("", 3655, "tab-pane", 3655, 8, true);
            WriteAttributeValue(" ", 3663, "fade", 3664, 5, true);
#nullable restore
#line 86 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Incidencias\SolicitudesN2.cshtml"
WriteAttributeValue(" ", 3668, Html.Raw(ViewBag.Tab == "Permisos" ? "show active" : ""), 3669, 57, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" id=""profile"" role=""tabpanel"" aria-labelledby=""profile-tab"">
        <table class=""table table-condensed table-hover display compact"" id=""lista_misSolicitudes"">
            <thead>
                <tr>
                    <th>
                        Folio
                    </th>
                    <th>
                        Empleado
                    </th>
                    <th>
                        Fe.Permiso
                    </th>
                    <th>
                        Hora.Salida
                    </th>
                    <th>
                        Hora.Regreso
                    </th>
                    <th>
                        Estatus
                    </th>
                    <th></th>
                </tr>
            </thead>
            <tbody>
");
#nullable restore
#line 112 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Incidencias\SolicitudesN2.cshtml"
                 foreach (var item in Permisos)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <tr>\r\n                        <td>\r\n                            ");
#nullable restore
#line 116 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Incidencias\SolicitudesN2.cshtml"
                       Write(Html.DisplayFor(modelItem => item.Folio));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
#nullable restore
#line 119 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Incidencias\SolicitudesN2.cshtml"
                       Write(Html.DisplayFor(modelItem => item.EmpleadoNombre));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
#nullable restore
#line 122 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Incidencias\SolicitudesN2.cshtml"
                       Write(Html.DisplayFor(modelItem => item.Fecha));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
#nullable restore
#line 125 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Incidencias\SolicitudesN2.cshtml"
                       Write(Html.DisplayFor(modelItem => item.Inicio));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
#nullable restore
#line 128 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Incidencias\SolicitudesN2.cshtml"
                       Write(Html.DisplayFor(modelItem => item.Fin));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            <span");
            BeginWriteAttribute("class", " class=\"", 5382, "\"", 5461, 4);
            WriteAttributeValue("", 5390, "badge", 5390, 5, true);
            WriteAttributeValue(" ", 5395, "badge-pill", 5396, 11, true);
            WriteAttributeValue(" ", 5406, "badge-", 5407, 7, true);
#nullable restore
#line 131 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Incidencias\SolicitudesN2.cshtml"
WriteAttributeValue("", 5413, Html.DisplayFor(modelItem => item.EstatusColor), 5413, 48, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 131 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Incidencias\SolicitudesN2.cshtml"
                                                                                                             Write(Html.DisplayFor(modelItem => item.EstatusDescricion));

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                        </td>\r\n                        <td>\r\n                            ");
#nullable restore
#line 134 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Incidencias\SolicitudesN2.cshtml"
                       Write(Html.ActionLink("Autorizar", "Autorizar", "IncPermiso", new { id = item.EncriptId, Mode = GPSInformation.Tools.EncryptData.Encrypt("3") }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        </td>\r\n                    </tr>\r\n");
#nullable restore
#line 137 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Incidencias\SolicitudesN2.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </tbody>\r\n        </table>\r\n    </div>\r\n</div>\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n");
#nullable restore
#line 143 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Incidencias\SolicitudesN2.cshtml"
      await Html.RenderPartialAsync("_ValidationScriptsPartial");

#line default
#line hidden
#nullable disable
                WriteLiteral(@"    <script>
        $(function () {
            'use strict'

            $('#lista_misSolicitudes').DataTable({
                //responsive:true,
                language: {
                    searchPlaceholder: 'Search...',
                    sSearch: '',
                    lengthMenu: '_MENU_ items/page',
                },
                ordering: false
            });
            $('#lista_misSolicitudesVaca').DataTable({
                //responsive:true,
                language: {
                    searchPlaceholder: 'Search...',
                    sSearch: '',
                    lengthMenu: '_MENU_ items/page',
                },
                ordering: false
            });

        });
    </script>
");
            }
            );
            WriteLiteral("\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
