#pragma checksum "C:\Luis Martinez backup\Personal\Developments\NET\GrupoSplittel\GrupoSplittel\GestionPersonal\Views\Incidencia\AprobarGPS.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b8f7a4c6a20247ab33cff35b2910386dedcddca1"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Incidencia_AprobarGPS), @"mvc.1.0.view", @"/Views/Incidencia/AprobarGPS.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Incidencia/AprobarGPS.cshtml", typeof(AspNetCore.Views_Incidencia_AprobarGPS))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b8f7a4c6a20247ab33cff35b2910386dedcddca1", @"/Views/Incidencia/AprobarGPS.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"44f628e23a2086c1f04f862587f80afdb82e0a32", @"/Views/_ViewImports.cshtml")]
    public class Views_Incidencia_AprobarGPS : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<GestionPersonal.Models.Incidencias>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(43, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Luis Martinez backup\Personal\Developments\NET\GrupoSplittel\GrupoSplittel\GestionPersonal\Views\Incidencia\AprobarGPS.cshtml"
  
    ViewData["Title"] = "Aprobación de solictudes nivel 2 ";

#line default
#line hidden
            BeginContext(114, 4, true);
            WriteLiteral("<h2>");
            EndContext();
            BeginContext(119, 17, false);
#line 6 "C:\Luis Martinez backup\Personal\Developments\NET\GrupoSplittel\GrupoSplittel\GestionPersonal\Views\Incidencia\AprobarGPS.cshtml"
Write(ViewData["Title"]);

#line default
#line hidden
            EndContext();
            BeginContext(136, 145, true);
            WriteLiteral("</h2>\r\n<hr />\r\n<div id=\"app_incidencias\">\r\n    <ul class=\"nav nav-tabs\" id=\"myTab\" role=\"tablist\">\r\n        <li class=\"nav-item\">\r\n            <a");
            EndContext();
            BeginWriteAttribute("class", " class=\"", 281, "\"", 351, 3);
            WriteAttributeValue("", 289, "nav-link", 289, 8, true);
#line 11 "C:\Luis Martinez backup\Personal\Developments\NET\GrupoSplittel\GrupoSplittel\GestionPersonal\Views\Incidencia\AprobarGPS.cshtml"
WriteAttributeValue(" ", 297, Html.Raw(ViewBag.tab == "Permisos" ? "active" : ""), 298, 52, false);

#line default
#line hidden
            WriteAttributeValue(" ", 350, "", 351, 1, true);
            EndWriteAttribute();
            BeginContext(352, 173, true);
            WriteLiteral(" id=\"home-tab\" data-toggle=\"tab\" href=\"#home\" role=\"tab\" aria-controls=\"home\" aria-selected=\"true\">Permisos</a>\r\n        </li>\r\n        <li class=\"nav-item\">\r\n            <a");
            EndContext();
            BeginWriteAttribute("class", " class=\"", 525, "\"", 596, 2);
            WriteAttributeValue("", 533, "nav-link", 533, 8, true);
#line 14 "C:\Luis Martinez backup\Personal\Developments\NET\GrupoSplittel\GrupoSplittel\GestionPersonal\Views\Incidencia\AprobarGPS.cshtml"
WriteAttributeValue(" ", 541, Html.Raw(ViewBag.tab == "Vacaciones" ? "active" : ""), 542, 54, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(597, 240, true);
            WriteLiteral(" id=\"profile-tab\" data-toggle=\"tab\" href=\"#profile\" role=\"tab\" aria-controls=\"profile\" aria-selected=\"false\">Vacaciones</a>\r\n        </li>\r\n    </ul>\r\n    <div class=\"tab-content bd bd-gray-300 bd-t-0 pd-20\" id=\"myTabContent\">\r\n        <div");
            EndContext();
            BeginWriteAttribute("class", " class=\"", 837, "\"", 916, 3);
            WriteAttributeValue("", 845, "tab-pane", 845, 8, true);
            WriteAttributeValue(" ", 853, "fade", 854, 5, true);
#line 18 "C:\Luis Martinez backup\Personal\Developments\NET\GrupoSplittel\GrupoSplittel\GestionPersonal\Views\Incidencia\AprobarGPS.cshtml"
WriteAttributeValue(" ", 858, Html.Raw(ViewBag.tab == "Permisos" ? "show active" : ""), 859, 57, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(917, 372, true);
            WriteLiteral(@" id=""home"" role=""tabpanel"" aria-labelledby=""home-tab"">
            <div id=""contactLogs"" class=""tab-pane pd-20 pd-xl-25 active"">
                <div class=""d-flex align-items-center justify-content-between mg-b-30"">
                    <h4 class=""tx-15 mg-b-0"">Lista de permisos</h4>
                </div>
            </div>
            <div id=""table-permisos"">
");
            EndContext();
#line 25 "C:\Luis Martinez backup\Personal\Developments\NET\GrupoSplittel\GrupoSplittel\GestionPersonal\Views\Incidencia\AprobarGPS.cshtml"
                 if (Model.permisos.Count() == 0)
                {

#line default
#line hidden
            BeginContext(1359, 156, true);
            WriteLiteral("                    <div class=\"alert alert-primary mg-b-0\" role=\"alert\">\r\n                        Sin solicitudes de permisos\r\n                    </div>\r\n");
            EndContext();
#line 30 "C:\Luis Martinez backup\Personal\Developments\NET\GrupoSplittel\GrupoSplittel\GestionPersonal\Views\Incidencia\AprobarGPS.cshtml"
                }
                else
                {

#line default
#line hidden
            BeginContext(1575, 982, true);
            WriteLiteral(@"                    <table class=""table"">
                        <thead>
                            <tr>
                                <th>
                                    Folio
                                </th>
                                <th>
                                    Solicitante
                                </th>
                                <th>
                                    Fecha
                                </th>
                                <th>
                                    Inicio
                                </th>
                                <th>
                                    Fin
                                </th>
                                <th>
                                    Estatus
                                </th>
                                <th></th>
                            </tr>
                        </thead>
                        <tbody>
");
            EndContext();
#line 58 "C:\Luis Martinez backup\Personal\Developments\NET\GrupoSplittel\GrupoSplittel\GestionPersonal\Views\Incidencia\AprobarGPS.cshtml"
                             foreach (var item in Model.permisos)
                            {

#line default
#line hidden
            BeginContext(2655, 120, true);
            WriteLiteral("                                <tr>\r\n                                    <td>\r\n                                        ");
            EndContext();
            BeginContext(2776, 40, false);
#line 62 "C:\Luis Martinez backup\Personal\Developments\NET\GrupoSplittel\GrupoSplittel\GestionPersonal\Views\Incidencia\AprobarGPS.cshtml"
                                   Write(Html.DisplayFor(modelItem => item.Folio));

#line default
#line hidden
            EndContext();
            BeginContext(2816, 127, true);
            WriteLiteral("\r\n                                    </td>\r\n                                    <td>\r\n                                        ");
            EndContext();
            BeginContext(2944, 49, false);
#line 65 "C:\Luis Martinez backup\Personal\Developments\NET\GrupoSplittel\GrupoSplittel\GestionPersonal\Views\Incidencia\AprobarGPS.cshtml"
                                   Write(Html.DisplayFor(modelItem => item.EmpleadoNombre));

#line default
#line hidden
            EndContext();
            BeginContext(2993, 127, true);
            WriteLiteral("\r\n                                    </td>\r\n                                    <td>\r\n                                        ");
            EndContext();
            BeginContext(3121, 40, false);
#line 68 "C:\Luis Martinez backup\Personal\Developments\NET\GrupoSplittel\GrupoSplittel\GestionPersonal\Views\Incidencia\AprobarGPS.cshtml"
                                   Write(Html.DisplayFor(modelItem => item.Fecha));

#line default
#line hidden
            EndContext();
            BeginContext(3161, 127, true);
            WriteLiteral("\r\n                                    </td>\r\n                                    <td>\r\n                                        ");
            EndContext();
            BeginContext(3289, 41, false);
#line 71 "C:\Luis Martinez backup\Personal\Developments\NET\GrupoSplittel\GrupoSplittel\GestionPersonal\Views\Incidencia\AprobarGPS.cshtml"
                                   Write(Html.DisplayFor(modelItem => item.Inicio));

#line default
#line hidden
            EndContext();
            BeginContext(3330, 127, true);
            WriteLiteral("\r\n                                    </td>\r\n                                    <td>\r\n                                        ");
            EndContext();
            BeginContext(3458, 38, false);
#line 74 "C:\Luis Martinez backup\Personal\Developments\NET\GrupoSplittel\GrupoSplittel\GestionPersonal\Views\Incidencia\AprobarGPS.cshtml"
                                   Write(Html.DisplayFor(modelItem => item.Fin));

#line default
#line hidden
            EndContext();
            BeginContext(3496, 87, true);
            WriteLiteral("\r\n                                    </td>\r\n                                    <td>\r\n");
            EndContext();
#line 77 "C:\Luis Martinez backup\Personal\Developments\NET\GrupoSplittel\GrupoSplittel\GestionPersonal\Views\Incidencia\AprobarGPS.cshtml"
                                         if (item.Estatus == 1)
                                        {

#line default
#line hidden
            BeginContext(3691, 97, true);
            WriteLiteral("                                            <span class=\"badge badge-primary\">En proceso</span>\r\n");
            EndContext();
#line 80 "C:\Luis Martinez backup\Personal\Developments\NET\GrupoSplittel\GrupoSplittel\GestionPersonal\Views\Incidencia\AprobarGPS.cshtml"
                                        }
                                        else if (item.Estatus == 2)
                                        {

#line default
#line hidden
            BeginContext(3943, 95, true);
            WriteLiteral("                                            <span class=\"badge badge-danger\">Cancelada</span>\r\n");
            EndContext();
#line 84 "C:\Luis Martinez backup\Personal\Developments\NET\GrupoSplittel\GrupoSplittel\GestionPersonal\Views\Incidencia\AprobarGPS.cshtml"
                                        }
                                        else
                                        {

#line default
#line hidden
            BeginContext(4170, 97, true);
            WriteLiteral("                                            <span class=\"badge badge-primary\">Completada</span>\r\n");
            EndContext();
#line 88 "C:\Luis Martinez backup\Personal\Developments\NET\GrupoSplittel\GrupoSplittel\GestionPersonal\Views\Incidencia\AprobarGPS.cshtml"
                                        }

#line default
#line hidden
            BeginContext(4310, 85, true);
            WriteLiteral("                                    </td>\r\n                                    <td>\r\n");
            EndContext();
#line 91 "C:\Luis Martinez backup\Personal\Developments\NET\GrupoSplittel\GrupoSplittel\GestionPersonal\Views\Incidencia\AprobarGPS.cshtml"
                                          
                                            var nive2 = item.Proceso.Find(a => a.Nivel == 3);

                                        

#line default
#line hidden
            BeginContext(4579, 40, true);
            WriteLiteral("                                        ");
            EndContext();
            BeginContext(4620, 97, false);
#line 95 "C:\Luis Martinez backup\Personal\Developments\NET\GrupoSplittel\GrupoSplittel\GestionPersonal\Views\Incidencia\AprobarGPS.cshtml"
                                   Write(Html.ActionLink("Details", "Details", "IncidenciaPermiso", new { id = item.IdIncidenciaPermiso }));

#line default
#line hidden
            EndContext();
            BeginContext(4717, 4, true);
            WriteLiteral(" |\r\n");
            EndContext();
#line 96 "C:\Luis Martinez backup\Personal\Developments\NET\GrupoSplittel\GrupoSplittel\GestionPersonal\Views\Incidencia\AprobarGPS.cshtml"
                                         if (item.Estatus == 1 && nive2 != null && nive2.Revisada == false)
                                        {
                                            

#line default
#line hidden
            BeginContext(4918, 107, false);
#line 98 "C:\Luis Martinez backup\Personal\Developments\NET\GrupoSplittel\GrupoSplittel\GestionPersonal\Views\Incidencia\AprobarGPS.cshtml"
                                       Write(Html.ActionLink("Aprobar", "Aprobar", "IncidenciaPermiso", new { id = item.IdIncidenciaPermiso, Mode = 2 }));

#line default
#line hidden
            EndContext();
            BeginContext(5025, 16, true);
            WriteLiteral("<span>|</span>\r\n");
            EndContext();
#line 99 "C:\Luis Martinez backup\Personal\Developments\NET\GrupoSplittel\GrupoSplittel\GestionPersonal\Views\Incidencia\AprobarGPS.cshtml"
                                        }

#line default
#line hidden
            BeginContext(5084, 93, true);
            WriteLiteral("                                        <a href=\"#modalActividadPermisos\" data-toggle=\"modal\"");
            EndContext();
            BeginWriteAttribute("onclick", " onclick=\"", 5177, "\"", 5247, 3);
            WriteAttributeValue("", 5187, "app_incidencias.ActividadPermisos(", 5187, 34, true);
#line 100 "C:\Luis Martinez backup\Personal\Developments\NET\GrupoSplittel\GrupoSplittel\GestionPersonal\Views\Incidencia\AprobarGPS.cshtml"
WriteAttributeValue("", 5221, item.IdIncidenciaPermiso, 5221, 25, false);

#line default
#line hidden
            WriteAttributeValue("", 5246, ")", 5246, 1, true);
            EndWriteAttribute();
            BeginContext(5248, 98, true);
            WriteLiteral(">Actividad</a>\r\n                                    </td>\r\n                                </tr>\r\n");
            EndContext();
#line 103 "C:\Luis Martinez backup\Personal\Developments\NET\GrupoSplittel\GrupoSplittel\GestionPersonal\Views\Incidencia\AprobarGPS.cshtml"
                            }

#line default
#line hidden
            BeginContext(5377, 64, true);
            WriteLiteral("                        </tbody>\r\n                    </table>\r\n");
            EndContext();
#line 106 "C:\Luis Martinez backup\Personal\Developments\NET\GrupoSplittel\GrupoSplittel\GestionPersonal\Views\Incidencia\AprobarGPS.cshtml"
                }

#line default
#line hidden
            BeginContext(5460, 48, true);
            WriteLiteral("            </div>\r\n        </div>\r\n        <div");
            EndContext();
            BeginWriteAttribute("class", " class=\"", 5508, "\"", 5589, 3);
            WriteAttributeValue("", 5516, "tab-pane", 5516, 8, true);
            WriteAttributeValue(" ", 5524, "fade", 5525, 5, true);
#line 109 "C:\Luis Martinez backup\Personal\Developments\NET\GrupoSplittel\GrupoSplittel\GestionPersonal\Views\Incidencia\AprobarGPS.cshtml"
WriteAttributeValue(" ", 5529, Html.Raw(ViewBag.tab == "Vacaciones" ? "show active" : ""), 5530, 59, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(5590, 380, true);
            WriteLiteral(@" id=""profile"" role=""tabpanel"" aria-labelledby=""profile-tab"">
            <div id=""contactLogs"" class=""tab-pane pd-20 pd-xl-25 active"">
                <div class=""d-flex align-items-center justify-content-between mg-b-30"">
                    <h4 class=""tx-15 mg-b-0"">Lista de vacaciones</h4>
                </div>
            </div>
            <div id=""table-permisos"">
");
            EndContext();
#line 116 "C:\Luis Martinez backup\Personal\Developments\NET\GrupoSplittel\GrupoSplittel\GestionPersonal\Views\Incidencia\AprobarGPS.cshtml"
                 if (Model.vacaciones.Count() == 0)
                {

#line default
#line hidden
            BeginContext(6042, 158, true);
            WriteLiteral("                    <div class=\"alert alert-primary mg-b-0\" role=\"alert\">\r\n                        Sin solicitudes de vacaciones\r\n                    </div>\r\n");
            EndContext();
#line 121 "C:\Luis Martinez backup\Personal\Developments\NET\GrupoSplittel\GrupoSplittel\GestionPersonal\Views\Incidencia\AprobarGPS.cshtml"
                }
                else
                {

#line default
#line hidden
            BeginContext(6260, 1014, true);
            WriteLiteral(@"                    <table class=""table table-condensed table-sm"">
                        <thead>
                            <tr>
                                <th>
                                    Folio
                                </th>
                                <th>
                                    Solicitante
                                </th>
                                <th>
                                    Inicio
                                </th>
                                <th>
                                    Fin
                                </th>
                                <th>
                                    No.D&#xED;as
                                </th>
                                <th>
                                    Estatus
                                </th>
                                <th></th>
                            </tr>
                        </thead>
                        <tbody>
");
            EndContext();
#line 149 "C:\Luis Martinez backup\Personal\Developments\NET\GrupoSplittel\GrupoSplittel\GestionPersonal\Views\Incidencia\AprobarGPS.cshtml"
                             foreach (var item in Model.vacaciones)
                            {

#line default
#line hidden
            BeginContext(7374, 120, true);
            WriteLiteral("                                <tr>\r\n                                    <td>\r\n                                        ");
            EndContext();
            BeginContext(7495, 40, false);
#line 153 "C:\Luis Martinez backup\Personal\Developments\NET\GrupoSplittel\GrupoSplittel\GestionPersonal\Views\Incidencia\AprobarGPS.cshtml"
                                   Write(Html.DisplayFor(modelItem => item.Folio));

#line default
#line hidden
            EndContext();
            BeginContext(7535, 127, true);
            WriteLiteral("\r\n                                    </td>\r\n                                    <td>\r\n                                        ");
            EndContext();
            BeginContext(7663, 44, false);
#line 156 "C:\Luis Martinez backup\Personal\Developments\NET\GrupoSplittel\GrupoSplittel\GestionPersonal\Views\Incidencia\AprobarGPS.cshtml"
                                   Write(Html.DisplayFor(modelItem => item.IdPersona));

#line default
#line hidden
            EndContext();
            BeginContext(7707, 127, true);
            WriteLiteral("\r\n                                    </td>\r\n                                    <td>\r\n                                        ");
            EndContext();
            BeginContext(7835, 41, false);
#line 159 "C:\Luis Martinez backup\Personal\Developments\NET\GrupoSplittel\GrupoSplittel\GestionPersonal\Views\Incidencia\AprobarGPS.cshtml"
                                   Write(Html.DisplayFor(modelItem => item.Inicio));

#line default
#line hidden
            EndContext();
            BeginContext(7876, 127, true);
            WriteLiteral("\r\n                                    </td>\r\n                                    <td>\r\n                                        ");
            EndContext();
            BeginContext(8004, 38, false);
#line 162 "C:\Luis Martinez backup\Personal\Developments\NET\GrupoSplittel\GrupoSplittel\GestionPersonal\Views\Incidencia\AprobarGPS.cshtml"
                                   Write(Html.DisplayFor(modelItem => item.Fin));

#line default
#line hidden
            EndContext();
            BeginContext(8042, 127, true);
            WriteLiteral("\r\n                                    </td>\r\n                                    <td>\r\n                                        ");
            EndContext();
            BeginContext(8170, 41, false);
#line 165 "C:\Luis Martinez backup\Personal\Developments\NET\GrupoSplittel\GrupoSplittel\GestionPersonal\Views\Incidencia\AprobarGPS.cshtml"
                                   Write(Html.DisplayFor(modelItem => item.NoDias));

#line default
#line hidden
            EndContext();
            BeginContext(8211, 87, true);
            WriteLiteral("\r\n                                    </td>\r\n                                    <td>\r\n");
            EndContext();
#line 168 "C:\Luis Martinez backup\Personal\Developments\NET\GrupoSplittel\GrupoSplittel\GestionPersonal\Views\Incidencia\AprobarGPS.cshtml"
                                         if (item.Estatus == 1)
                                        {

#line default
#line hidden
            BeginContext(8406, 97, true);
            WriteLiteral("                                            <span class=\"badge badge-primary\">En proceso</span>\r\n");
            EndContext();
#line 171 "C:\Luis Martinez backup\Personal\Developments\NET\GrupoSplittel\GrupoSplittel\GestionPersonal\Views\Incidencia\AprobarGPS.cshtml"
                                        }
                                        else if (item.Estatus == 2)
                                        {

#line default
#line hidden
            BeginContext(8658, 95, true);
            WriteLiteral("                                            <span class=\"badge badge-danger\">Cancelada</span>\r\n");
            EndContext();
#line 175 "C:\Luis Martinez backup\Personal\Developments\NET\GrupoSplittel\GrupoSplittel\GestionPersonal\Views\Incidencia\AprobarGPS.cshtml"
                                        }
                                        else
                                        {

#line default
#line hidden
            BeginContext(8885, 97, true);
            WriteLiteral("                                            <span class=\"badge badge-primary\">Completada</span>\r\n");
            EndContext();
#line 179 "C:\Luis Martinez backup\Personal\Developments\NET\GrupoSplittel\GrupoSplittel\GestionPersonal\Views\Incidencia\AprobarGPS.cshtml"
                                        }

#line default
#line hidden
            BeginContext(9025, 85, true);
            WriteLiteral("                                    </td>\r\n                                    <td>\r\n");
            EndContext();
#line 182 "C:\Luis Martinez backup\Personal\Developments\NET\GrupoSplittel\GrupoSplittel\GestionPersonal\Views\Incidencia\AprobarGPS.cshtml"
                                          
                                                var nive2 = item.Proceso.Find(a => a.Nivel == 3);
                                            

#line default
#line hidden
            BeginContext(9300, 44, true);
            WriteLiteral("                                            ");
            EndContext();
            BeginContext(9345, 99, false);
#line 185 "C:\Luis Martinez backup\Personal\Developments\NET\GrupoSplittel\GrupoSplittel\GestionPersonal\Views\Incidencia\AprobarGPS.cshtml"
                                       Write(Html.ActionLink("Details", "Details", "IncidenciaVacacion", new { id = item.IdIncidenciaVacacion }));

#line default
#line hidden
            EndContext();
            BeginContext(9444, 3, true);
            WriteLiteral("|\r\n");
            EndContext();
#line 186 "C:\Luis Martinez backup\Personal\Developments\NET\GrupoSplittel\GrupoSplittel\GestionPersonal\Views\Incidencia\AprobarGPS.cshtml"
                                             if (item.Estatus == 1 && nive2 != null && nive2.Revisada == false)
                                            {
                                                

#line default
#line hidden
            BeginContext(9656, 109, false);
#line 188 "C:\Luis Martinez backup\Personal\Developments\NET\GrupoSplittel\GrupoSplittel\GestionPersonal\Views\Incidencia\AprobarGPS.cshtml"
                                           Write(Html.ActionLink("Aprobar", "Aprobar", "IncidenciaVacacion", new { id = item.IdIncidenciaVacacion, Mode = 2 }));

#line default
#line hidden
            EndContext();
            BeginContext(9765, 16, true);
            WriteLiteral("<span>|</span>\r\n");
            EndContext();
#line 189 "C:\Luis Martinez backup\Personal\Developments\NET\GrupoSplittel\GrupoSplittel\GestionPersonal\Views\Incidencia\AprobarGPS.cshtml"
                                            }

#line default
#line hidden
            BeginContext(9828, 95, true);
            WriteLiteral("                                        <a href=\"#modalActividadVacaciones\" data-toggle=\"modal\"");
            EndContext();
            BeginWriteAttribute("onclick", " onclick=\"", 9923, "\"", 9994, 3);
            WriteAttributeValue("", 9933, "app_incidencias.ActividadVacacion(", 9933, 34, true);
#line 190 "C:\Luis Martinez backup\Personal\Developments\NET\GrupoSplittel\GrupoSplittel\GestionPersonal\Views\Incidencia\AprobarGPS.cshtml"
WriteAttributeValue("", 9967, item.IdIncidenciaVacacion, 9967, 26, false);

#line default
#line hidden
            WriteAttributeValue("", 9993, ")", 9993, 1, true);
            EndWriteAttribute();
            BeginContext(9995, 98, true);
            WriteLiteral(">Actividad</a>\r\n                                    </td>\r\n                                </tr>\r\n");
            EndContext();
#line 193 "C:\Luis Martinez backup\Personal\Developments\NET\GrupoSplittel\GrupoSplittel\GestionPersonal\Views\Incidencia\AprobarGPS.cshtml"
                            }

#line default
#line hidden
            BeginContext(10124, 64, true);
            WriteLiteral("                        </tbody>\r\n                    </table>\r\n");
            EndContext();
#line 196 "C:\Luis Martinez backup\Personal\Developments\NET\GrupoSplittel\GrupoSplittel\GestionPersonal\Views\Incidencia\AprobarGPS.cshtml"
                }

#line default
#line hidden
            BeginContext(10207, 2117, true);
            WriteLiteral(@"            </div>
        </div>
    </div>
    <div class=""modal calendar-modal-create fade effect-scale"" id=""modalActividadVacaciones"" role=""dialog"" data-backdrop=""false"" aria-hidden=""true"">
        <div class=""modal-dialog modal-dialog-centered"" role=""document"">
            <div class=""modal-content"">
                <div class=""modal-body pd-20 pd-sm-30"">
                    <button type=""button"" class=""close pos-absolute t-20 r-20"" data-dismiss=""modal"" aria-label=""Close"">
                        <span aria-hidden=""true""><i data-feather=""x""></i></span>
                    </button>
                    <h5 class=""tx-18 tx-sm-20 mg-b-20 mg-sm-b-30"">Actividad</h5>

                    <div id=""content_vacacionesAcitivit""></div>
                </div><!-- modal-body -->
                <div class=""modal-footer"">
                    <a href="""" class=""btn btn-secondary"" data-dismiss=""modal"">Cerrar</a>
                </div><!-- modal-footer -->
            </div><!-- modal-content -->
       ");
            WriteLiteral(@" </div><!-- modal-dialog -->
    </div><!-- modal -->

    <div class=""modal calendar-modal-create fade effect-scale"" id=""modalActividadPermisos"" role=""dialog"" data-backdrop=""false"" aria-hidden=""true"">
        <div class=""modal-dialog modal-dialog-centered"" role=""document"">
            <div class=""modal-content"">
                <div class=""modal-body pd-20 pd-sm-30"">
                    <button type=""button"" class=""close pos-absolute t-20 r-20"" data-dismiss=""modal"" aria-label=""Close"">
                        <span aria-hidden=""true""><i data-feather=""x""></i></span>
                    </button>
                    <h5 class=""tx-18 tx-sm-20 mg-b-20 mg-sm-b-30"">Actividad</h5>

                    <div id=""content_permisoAcitivit""></div>
                </div><!-- modal-body -->
                <div class=""modal-footer"">
                    <a href="""" class=""btn btn-secondary"" data-dismiss=""modal"">Cerrar</a>
                </div><!-- modal-footer -->
            </div><!-- modal-content -->
  ");
            WriteLiteral("      </div><!-- modal-dialog -->\r\n    </div><!-- modal -->\r\n</div>\r\n");
            EndContext();
            DefineSection("Scripts", async() => {
                BeginContext(12342, 350, true);
                WriteLiteral(@"
    <script>
        var app_incidencias = new Vue({
            el: ""#app_incidencias"",
            data: {},
            mounted() { },
            methods: {
                ActividadVacacion: async function (id) {
                    document.getElementById(""content_vacacionesAcitivit"").innerHTML = """";
                    axios.post('");
                EndContext();
                BeginContext(12693, 44, false);
#line 245 "C:\Luis Martinez backup\Personal\Developments\NET\GrupoSplittel\GrupoSplittel\GestionPersonal\Views\Incidencia\AprobarGPS.cshtml"
                           Write(Url.Action("Actividad","IncidenciaVacacion"));

#line default
#line hidden
                EndContext();
                BeginContext(12737, 747, true);
                WriteLiteral(@"/' + id, null, null).then(response => {
                        document.getElementById(""content_vacacionesAcitivit"").innerHTML = response.data;
                    }).catch(error => {
                        if (error.response) {
                            if (error.response.status === 400) {

                            }
                        }
                        console.error(error);
                        ShowMessageErrorShort(""Error al obtener la actividad de este permiso"", ""error"")
                    }).finally()

                },
                ActividadPermisos: async function (id) {
                    document.getElementById(""content_permisoAcitivit"").innerHTML = """";
                    axios.post('");
                EndContext();
                BeginContext(13485, 43, false);
#line 260 "C:\Luis Martinez backup\Personal\Developments\NET\GrupoSplittel\GrupoSplittel\GestionPersonal\Views\Incidencia\AprobarGPS.cshtml"
                           Write(Url.Action("Actividad","IncidenciaPermiso"));

#line default
#line hidden
                EndContext();
                BeginContext(13528, 768, true);
                WriteLiteral(@"/' + id, null, null).then(response => {
                        //bootbox.alert(response.data);
                        document.getElementById(""content_permisoAcitivit"").innerHTML = response.data;
                        //ShowMessageErrorShort(""Datos del personales empleado guardados"", ""success"")
                    }).catch(error => {
                        if (error.response) {
                            if (error.response.status === 400) {

                            }
                        }
                        console.error(error);
                        ShowMessageErrorShort(""Error al obtener la actividad de este permiso"", ""error"")
                    }).finally()

                }
            }
        });
    </script>
");
                EndContext();
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<GestionPersonal.Models.Incidencias> Html { get; private set; }
    }
}
#pragma warning restore 1591