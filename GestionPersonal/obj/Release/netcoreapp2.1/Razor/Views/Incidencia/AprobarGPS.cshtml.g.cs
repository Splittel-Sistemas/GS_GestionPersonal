#pragma checksum "C:\Luis Martinez backup\Personal\Developments\NET\GrupoSplittel\GrupoSplittel\GestionPersonal\Views\Incidencia\AprobarGPS.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "477e5a0d109c39f6168b81d61f6cedaab0fbcb92"
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"477e5a0d109c39f6168b81d61f6cedaab0fbcb92", @"/Views/Incidencia/AprobarGPS.cshtml")]
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
            BeginContext(114, 90, true);
            WriteLiteral("<div class=\"d-flex align-items-center justify-content-between mg-b-30\">\r\n    <h2 class=\"\">");
            EndContext();
            BeginContext(205, 17, false);
#line 7 "C:\Luis Martinez backup\Personal\Developments\NET\GrupoSplittel\GrupoSplittel\GestionPersonal\Views\Incidencia\AprobarGPS.cshtml"
            Write(ViewData["Title"]);

#line default
#line hidden
            EndContext();
            BeginContext(222, 76, true);
            WriteLiteral("</h2>\r\n    <div class=\"btn-group\" role=\"group\" aria-label=\"Basic example\">\r\n");
            EndContext();
            BeginContext(467, 476, true);
            WriteLiteral(@"    </div>
</div>
<hr />
<div class=""alert alert-success"" role=""alert"">
    <h4 class=""alert-heading"">Hola!</h4>
    <p>Gracias por utilizar GPS, en esta sección podrás autorizar las solicitudes de vacaciones y permisos a nivel <strong>Gestión de Personal</strong></p>
    <hr>
    <p class=""mb-0"">Sistema Gestión de Personal</p>
</div>
<div id=""app_incidencias"">
    <ul class=""nav nav-tabs"" id=""myTab"" role=""tablist"">
        <li class=""nav-item"">
            <a");
            EndContext();
            BeginWriteAttribute("class", " class=\"", 943, "\"", 1013, 3);
            WriteAttributeValue("", 951, "nav-link", 951, 8, true);
#line 22 "C:\Luis Martinez backup\Personal\Developments\NET\GrupoSplittel\GrupoSplittel\GestionPersonal\Views\Incidencia\AprobarGPS.cshtml"
WriteAttributeValue(" ", 959, Html.Raw(ViewBag.tab == "Permisos" ? "active" : ""), 960, 52, false);

#line default
#line hidden
            WriteAttributeValue(" ", 1012, "", 1013, 1, true);
            EndWriteAttribute();
            BeginContext(1014, 173, true);
            WriteLiteral(" id=\"home-tab\" data-toggle=\"tab\" href=\"#home\" role=\"tab\" aria-controls=\"home\" aria-selected=\"true\">Permisos</a>\r\n        </li>\r\n        <li class=\"nav-item\">\r\n            <a");
            EndContext();
            BeginWriteAttribute("class", " class=\"", 1187, "\"", 1258, 2);
            WriteAttributeValue("", 1195, "nav-link", 1195, 8, true);
#line 25 "C:\Luis Martinez backup\Personal\Developments\NET\GrupoSplittel\GrupoSplittel\GestionPersonal\Views\Incidencia\AprobarGPS.cshtml"
WriteAttributeValue(" ", 1203, Html.Raw(ViewBag.tab == "Vacaciones" ? "active" : ""), 1204, 54, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1259, 240, true);
            WriteLiteral(" id=\"profile-tab\" data-toggle=\"tab\" href=\"#profile\" role=\"tab\" aria-controls=\"profile\" aria-selected=\"false\">Vacaciones</a>\r\n        </li>\r\n    </ul>\r\n    <div class=\"tab-content bd bd-gray-300 bd-t-0 pd-20\" id=\"myTabContent\">\r\n        <div");
            EndContext();
            BeginWriteAttribute("class", " class=\"", 1499, "\"", 1578, 3);
            WriteAttributeValue("", 1507, "tab-pane", 1507, 8, true);
            WriteAttributeValue(" ", 1515, "fade", 1516, 5, true);
#line 29 "C:\Luis Martinez backup\Personal\Developments\NET\GrupoSplittel\GrupoSplittel\GestionPersonal\Views\Incidencia\AprobarGPS.cshtml"
WriteAttributeValue(" ", 1520, Html.Raw(ViewBag.tab == "Permisos" ? "show active" : ""), 1521, 57, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1579, 372, true);
            WriteLiteral(@" id=""home"" role=""tabpanel"" aria-labelledby=""home-tab"">
            <div id=""contactLogs"" class=""tab-pane pd-20 pd-xl-25 active"">
                <div class=""d-flex align-items-center justify-content-between mg-b-30"">
                    <h4 class=""tx-15 mg-b-0"">Lista de permisos</h4>
                </div>
            </div>
            <div id=""table-permisos"">
");
            EndContext();
#line 36 "C:\Luis Martinez backup\Personal\Developments\NET\GrupoSplittel\GrupoSplittel\GestionPersonal\Views\Incidencia\AprobarGPS.cshtml"
                 if (Model.permisos.Count() == 0)
                {

#line default
#line hidden
            BeginContext(2021, 156, true);
            WriteLiteral("                    <div class=\"alert alert-primary mg-b-0\" role=\"alert\">\r\n                        Sin solicitudes de permisos\r\n                    </div>\r\n");
            EndContext();
#line 41 "C:\Luis Martinez backup\Personal\Developments\NET\GrupoSplittel\GrupoSplittel\GestionPersonal\Views\Incidencia\AprobarGPS.cshtml"
                }
                else
                {

#line default
#line hidden
            BeginContext(2237, 1105, true);
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
                                <th>
                                    Revisada
                                </th>
                                <th></th>
                     ");
            WriteLiteral("       </tr>\r\n                        </thead>\r\n                        <tbody>\r\n");
            EndContext();
#line 72 "C:\Luis Martinez backup\Personal\Developments\NET\GrupoSplittel\GrupoSplittel\GestionPersonal\Views\Incidencia\AprobarGPS.cshtml"
                             foreach (var item in Model.permisos)
                            {
                                var nive2 = item.Proceso.Find(a => a.Nivel == 3);

#line default
#line hidden
            BeginContext(3523, 120, true);
            WriteLiteral("                                <tr>\r\n                                    <td>\r\n                                        ");
            EndContext();
            BeginContext(3644, 40, false);
#line 77 "C:\Luis Martinez backup\Personal\Developments\NET\GrupoSplittel\GrupoSplittel\GestionPersonal\Views\Incidencia\AprobarGPS.cshtml"
                                   Write(Html.DisplayFor(modelItem => item.Folio));

#line default
#line hidden
            EndContext();
            BeginContext(3684, 127, true);
            WriteLiteral("\r\n                                    </td>\r\n                                    <td>\r\n                                        ");
            EndContext();
            BeginContext(3812, 49, false);
#line 80 "C:\Luis Martinez backup\Personal\Developments\NET\GrupoSplittel\GrupoSplittel\GestionPersonal\Views\Incidencia\AprobarGPS.cshtml"
                                   Write(Html.DisplayFor(modelItem => item.EmpleadoNombre));

#line default
#line hidden
            EndContext();
            BeginContext(3861, 127, true);
            WriteLiteral("\r\n                                    </td>\r\n                                    <td>\r\n                                        ");
            EndContext();
            BeginContext(3989, 40, false);
#line 83 "C:\Luis Martinez backup\Personal\Developments\NET\GrupoSplittel\GrupoSplittel\GestionPersonal\Views\Incidencia\AprobarGPS.cshtml"
                                   Write(Html.DisplayFor(modelItem => item.Fecha));

#line default
#line hidden
            EndContext();
            BeginContext(4029, 127, true);
            WriteLiteral("\r\n                                    </td>\r\n                                    <td>\r\n                                        ");
            EndContext();
            BeginContext(4157, 41, false);
#line 86 "C:\Luis Martinez backup\Personal\Developments\NET\GrupoSplittel\GrupoSplittel\GestionPersonal\Views\Incidencia\AprobarGPS.cshtml"
                                   Write(Html.DisplayFor(modelItem => item.Inicio));

#line default
#line hidden
            EndContext();
            BeginContext(4198, 127, true);
            WriteLiteral("\r\n                                    </td>\r\n                                    <td>\r\n                                        ");
            EndContext();
            BeginContext(4326, 38, false);
#line 89 "C:\Luis Martinez backup\Personal\Developments\NET\GrupoSplittel\GrupoSplittel\GestionPersonal\Views\Incidencia\AprobarGPS.cshtml"
                                   Write(Html.DisplayFor(modelItem => item.Fin));

#line default
#line hidden
            EndContext();
            BeginContext(4364, 87, true);
            WriteLiteral("\r\n                                    </td>\r\n                                    <td>\r\n");
            EndContext();
#line 92 "C:\Luis Martinez backup\Personal\Developments\NET\GrupoSplittel\GrupoSplittel\GestionPersonal\Views\Incidencia\AprobarGPS.cshtml"
                                         if (item.Estatus == 1)
                                        {

#line default
#line hidden
            BeginContext(4559, 97, true);
            WriteLiteral("                                            <span class=\"badge badge-primary\">En proceso</span>\r\n");
            EndContext();
#line 95 "C:\Luis Martinez backup\Personal\Developments\NET\GrupoSplittel\GrupoSplittel\GestionPersonal\Views\Incidencia\AprobarGPS.cshtml"
                                        }
                                        else if (item.Estatus == 2)
                                        {

#line default
#line hidden
            BeginContext(4811, 95, true);
            WriteLiteral("                                            <span class=\"badge badge-danger\">Cancelada</span>\r\n");
            EndContext();
#line 99 "C:\Luis Martinez backup\Personal\Developments\NET\GrupoSplittel\GrupoSplittel\GestionPersonal\Views\Incidencia\AprobarGPS.cshtml"
                                        }
                                        else
                                        {

#line default
#line hidden
            BeginContext(5038, 97, true);
            WriteLiteral("                                            <span class=\"badge badge-primary\">Completada</span>\r\n");
            EndContext();
#line 103 "C:\Luis Martinez backup\Personal\Developments\NET\GrupoSplittel\GrupoSplittel\GestionPersonal\Views\Incidencia\AprobarGPS.cshtml"
                                        }

#line default
#line hidden
            BeginContext(5178, 85, true);
            WriteLiteral("                                    </td>\r\n                                    <td>\r\n");
            EndContext();
#line 106 "C:\Luis Martinez backup\Personal\Developments\NET\GrupoSplittel\GrupoSplittel\GestionPersonal\Views\Incidencia\AprobarGPS.cshtml"
                                         if (item.Estatus == 1 && nive2 != null && nive2.Revisada == false)
                                        {

#line default
#line hidden
            BeginContext(5415, 98, true);
            WriteLiteral("                                            <span class=\"badge badge-warning\">Sin revisar</span>\r\n");
            EndContext();
#line 109 "C:\Luis Martinez backup\Personal\Developments\NET\GrupoSplittel\GrupoSplittel\GestionPersonal\Views\Incidencia\AprobarGPS.cshtml"
                                        }
                                        else
                                        {

#line default
#line hidden
            BeginContext(5645, 89, true);
            WriteLiteral("                                            <span class=\"badge badge-success\">Ok</span>\r\n");
            EndContext();
#line 113 "C:\Luis Martinez backup\Personal\Developments\NET\GrupoSplittel\GrupoSplittel\GestionPersonal\Views\Incidencia\AprobarGPS.cshtml"
                                        }

#line default
#line hidden
            BeginContext(5777, 699, true);
            WriteLiteral(@"                                    </td>
                                    <td>
                                        
                                        <div class=""dropdown"">
                                            <button class=""btn btn-outline-primary btn-sm dropdown-toggle"" type=""button"" id=""dropleftMenuButton"" data-toggle=""dropdown"" aria-haspopup=""true"" aria-expanded=""false"">
                                                Opciones
                                            </button>
                                            <div class=""dropdown-menu"" aria-labelledby=""dropleftMenuButton"">
                                                <a class=""dropdown-item""");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 6476, "\"", 6565, 1);
#line 122 "C:\Luis Martinez backup\Personal\Developments\NET\GrupoSplittel\GrupoSplittel\GestionPersonal\Views\Incidencia\AprobarGPS.cshtml"
WriteAttributeValue("", 6483, Url.Action("Details", "IncidenciaPermiso", new { id = item.IdIncidenciaPermiso }), 6483, 82, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(6566, 14, true);
            WriteLiteral(">Detalle</a>\r\n");
            EndContext();
#line 123 "C:\Luis Martinez backup\Personal\Developments\NET\GrupoSplittel\GrupoSplittel\GestionPersonal\Views\Incidencia\AprobarGPS.cshtml"
                                                 if (item.Estatus == 1 && nive2 != null && nive2.Revisada == false)
                                                {

#line default
#line hidden
            BeginContext(6748, 76, true);
            WriteLiteral("                                                    <a class=\"dropdown-item\"");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 6824, "\"", 6923, 1);
#line 125 "C:\Luis Martinez backup\Personal\Developments\NET\GrupoSplittel\GrupoSplittel\GestionPersonal\Views\Incidencia\AprobarGPS.cshtml"
WriteAttributeValue("", 6831, Url.Action("Aprobar", "IncidenciaPermiso", new { id = item.IdIncidenciaPermiso, Mode = 2 }), 6831, 92, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(6924, 14, true);
            WriteLiteral(">Aprobar</a>\r\n");
            EndContext();
#line 126 "C:\Luis Martinez backup\Personal\Developments\NET\GrupoSplittel\GrupoSplittel\GestionPersonal\Views\Incidencia\AprobarGPS.cshtml"
                                                                                                                                                                                                  
                                                }

#line default
#line hidden
            BeginContext(7185, 123, true);
            WriteLiteral("                                                <a class=\"dropdown-item\" href=\"#modalActividadPermisos\" data-toggle=\"modal\"");
            EndContext();
            BeginWriteAttribute("onclick", " onclick=\"", 7308, "\"", 7378, 3);
            WriteAttributeValue("", 7318, "app_incidencias.ActividadPermisos(", 7318, 34, true);
#line 128 "C:\Luis Martinez backup\Personal\Developments\NET\GrupoSplittel\GrupoSplittel\GestionPersonal\Views\Incidencia\AprobarGPS.cshtml"
WriteAttributeValue("", 7352, item.IdIncidenciaPermiso, 7352, 25, false);

#line default
#line hidden
            WriteAttributeValue("", 7377, ")", 7377, 1, true);
            EndWriteAttribute();
            BeginContext(7379, 198, true);
            WriteLiteral(">Actividad</a>\r\n                                            </div>\r\n                                        </div>\r\n                                    </td>\r\n                                </tr>\r\n");
            EndContext();
#line 133 "C:\Luis Martinez backup\Personal\Developments\NET\GrupoSplittel\GrupoSplittel\GestionPersonal\Views\Incidencia\AprobarGPS.cshtml"
                            }

#line default
#line hidden
            BeginContext(7608, 64, true);
            WriteLiteral("                        </tbody>\r\n                    </table>\r\n");
            EndContext();
#line 136 "C:\Luis Martinez backup\Personal\Developments\NET\GrupoSplittel\GrupoSplittel\GestionPersonal\Views\Incidencia\AprobarGPS.cshtml"
                }

#line default
#line hidden
            BeginContext(7691, 48, true);
            WriteLiteral("            </div>\r\n        </div>\r\n        <div");
            EndContext();
            BeginWriteAttribute("class", " class=\"", 7739, "\"", 7820, 3);
            WriteAttributeValue("", 7747, "tab-pane", 7747, 8, true);
            WriteAttributeValue(" ", 7755, "fade", 7756, 5, true);
#line 139 "C:\Luis Martinez backup\Personal\Developments\NET\GrupoSplittel\GrupoSplittel\GestionPersonal\Views\Incidencia\AprobarGPS.cshtml"
WriteAttributeValue(" ", 7760, Html.Raw(ViewBag.tab == "Vacaciones" ? "show active" : ""), 7761, 59, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(7821, 380, true);
            WriteLiteral(@" id=""profile"" role=""tabpanel"" aria-labelledby=""profile-tab"">
            <div id=""contactLogs"" class=""tab-pane pd-20 pd-xl-25 active"">
                <div class=""d-flex align-items-center justify-content-between mg-b-30"">
                    <h4 class=""tx-15 mg-b-0"">Lista de vacaciones</h4>
                </div>
            </div>
            <div id=""table-permisos"">
");
            EndContext();
#line 146 "C:\Luis Martinez backup\Personal\Developments\NET\GrupoSplittel\GrupoSplittel\GestionPersonal\Views\Incidencia\AprobarGPS.cshtml"
                 if (Model.vacaciones.Count() == 0)
                {

#line default
#line hidden
            BeginContext(8273, 158, true);
            WriteLiteral("                    <div class=\"alert alert-primary mg-b-0\" role=\"alert\">\r\n                        Sin solicitudes de vacaciones\r\n                    </div>\r\n");
            EndContext();
#line 151 "C:\Luis Martinez backup\Personal\Developments\NET\GrupoSplittel\GrupoSplittel\GestionPersonal\Views\Incidencia\AprobarGPS.cshtml"
                }
                else
                {

#line default
#line hidden
            BeginContext(8491, 1014, true);
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
#line 179 "C:\Luis Martinez backup\Personal\Developments\NET\GrupoSplittel\GrupoSplittel\GestionPersonal\Views\Incidencia\AprobarGPS.cshtml"
                             foreach (var item in Model.vacaciones)
                            {

#line default
#line hidden
            BeginContext(9605, 120, true);
            WriteLiteral("                                <tr>\r\n                                    <td>\r\n                                        ");
            EndContext();
            BeginContext(9726, 40, false);
#line 183 "C:\Luis Martinez backup\Personal\Developments\NET\GrupoSplittel\GrupoSplittel\GestionPersonal\Views\Incidencia\AprobarGPS.cshtml"
                                   Write(Html.DisplayFor(modelItem => item.Folio));

#line default
#line hidden
            EndContext();
            BeginContext(9766, 127, true);
            WriteLiteral("\r\n                                    </td>\r\n                                    <td>\r\n                                        ");
            EndContext();
            BeginContext(9894, 49, false);
#line 186 "C:\Luis Martinez backup\Personal\Developments\NET\GrupoSplittel\GrupoSplittel\GestionPersonal\Views\Incidencia\AprobarGPS.cshtml"
                                   Write(Html.DisplayFor(modelItem => item.EmpleadoNombre));

#line default
#line hidden
            EndContext();
            BeginContext(9943, 127, true);
            WriteLiteral("\r\n                                    </td>\r\n                                    <td>\r\n                                        ");
            EndContext();
            BeginContext(10071, 41, false);
#line 189 "C:\Luis Martinez backup\Personal\Developments\NET\GrupoSplittel\GrupoSplittel\GestionPersonal\Views\Incidencia\AprobarGPS.cshtml"
                                   Write(Html.DisplayFor(modelItem => item.Inicio));

#line default
#line hidden
            EndContext();
            BeginContext(10112, 127, true);
            WriteLiteral("\r\n                                    </td>\r\n                                    <td>\r\n                                        ");
            EndContext();
            BeginContext(10240, 38, false);
#line 192 "C:\Luis Martinez backup\Personal\Developments\NET\GrupoSplittel\GrupoSplittel\GestionPersonal\Views\Incidencia\AprobarGPS.cshtml"
                                   Write(Html.DisplayFor(modelItem => item.Fin));

#line default
#line hidden
            EndContext();
            BeginContext(10278, 127, true);
            WriteLiteral("\r\n                                    </td>\r\n                                    <td>\r\n                                        ");
            EndContext();
            BeginContext(10406, 41, false);
#line 195 "C:\Luis Martinez backup\Personal\Developments\NET\GrupoSplittel\GrupoSplittel\GestionPersonal\Views\Incidencia\AprobarGPS.cshtml"
                                   Write(Html.DisplayFor(modelItem => item.NoDias));

#line default
#line hidden
            EndContext();
            BeginContext(10447, 87, true);
            WriteLiteral("\r\n                                    </td>\r\n                                    <td>\r\n");
            EndContext();
#line 198 "C:\Luis Martinez backup\Personal\Developments\NET\GrupoSplittel\GrupoSplittel\GestionPersonal\Views\Incidencia\AprobarGPS.cshtml"
                                         if (item.Estatus == 1)
                                        {

#line default
#line hidden
            BeginContext(10642, 97, true);
            WriteLiteral("                                            <span class=\"badge badge-primary\">En proceso</span>\r\n");
            EndContext();
#line 201 "C:\Luis Martinez backup\Personal\Developments\NET\GrupoSplittel\GrupoSplittel\GestionPersonal\Views\Incidencia\AprobarGPS.cshtml"
                                        }
                                        else if (item.Estatus == 2)
                                        {

#line default
#line hidden
            BeginContext(10894, 95, true);
            WriteLiteral("                                            <span class=\"badge badge-danger\">Cancelada</span>\r\n");
            EndContext();
#line 205 "C:\Luis Martinez backup\Personal\Developments\NET\GrupoSplittel\GrupoSplittel\GestionPersonal\Views\Incidencia\AprobarGPS.cshtml"
                                        }
                                        else
                                        {

#line default
#line hidden
            BeginContext(11121, 97, true);
            WriteLiteral("                                            <span class=\"badge badge-primary\">Completada</span>\r\n");
            EndContext();
#line 209 "C:\Luis Martinez backup\Personal\Developments\NET\GrupoSplittel\GrupoSplittel\GestionPersonal\Views\Incidencia\AprobarGPS.cshtml"
                                        }

#line default
#line hidden
            BeginContext(11261, 85, true);
            WriteLiteral("                                    </td>\r\n                                    <td>\r\n");
            EndContext();
#line 212 "C:\Luis Martinez backup\Personal\Developments\NET\GrupoSplittel\GrupoSplittel\GestionPersonal\Views\Incidencia\AprobarGPS.cshtml"
                                          
                                            var nive2 = item.Proceso.Find(a => a.Nivel == 3);
                                        

#line default
#line hidden
            BeginContext(11528, 562, true);
            WriteLiteral(@"                                        <div class=""dropdown"">
                                            <button class=""btn btn-light btn-sm dropdown-toggle"" type=""button"" id=""dropleftMenuButton"" data-toggle=""dropdown"" aria-haspopup=""true"" aria-expanded=""false"">
                                                Opciones
                                            </button>
                                            <div class=""dropdown-menu"" aria-labelledby=""dropleftMenuButton"">
                                                <a class=""dropdown-item""");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 12090, "\"", 12181, 1);
#line 220 "C:\Luis Martinez backup\Personal\Developments\NET\GrupoSplittel\GrupoSplittel\GestionPersonal\Views\Incidencia\AprobarGPS.cshtml"
WriteAttributeValue("", 12097, Url.Action("Details", "IncidenciaVacacion", new { id = item.IdIncidenciaVacacion }), 12097, 84, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(12182, 14, true);
            WriteLiteral(">Detalle</a>\r\n");
            EndContext();
#line 221 "C:\Luis Martinez backup\Personal\Developments\NET\GrupoSplittel\GrupoSplittel\GestionPersonal\Views\Incidencia\AprobarGPS.cshtml"
                                                 if (item.Estatus == 1 && nive2 != null && nive2.Revisada == false)
                                                {

#line default
#line hidden
            BeginContext(12364, 76, true);
            WriteLiteral("                                                    <a class=\"dropdown-item\"");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 12440, "\"", 12541, 1);
#line 223 "C:\Luis Martinez backup\Personal\Developments\NET\GrupoSplittel\GrupoSplittel\GestionPersonal\Views\Incidencia\AprobarGPS.cshtml"
WriteAttributeValue("", 12447, Url.Action("Aprobar", "IncidenciaVacacion", new { id = item.IdIncidenciaVacacion, Mode = 2 }), 12447, 94, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(12542, 90, true);
            WriteLiteral(">Aprobar</a>\r\n                                                    <a class=\"dropdown-item\"");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 12632, "\"", 12734, 1);
#line 224 "C:\Luis Martinez backup\Personal\Developments\NET\GrupoSplittel\GrupoSplittel\GestionPersonal\Views\Incidencia\AprobarGPS.cshtml"
WriteAttributeValue("", 12639, Url.Action("Rechazar", "IncidenciaVacacion", new { id = item.IdIncidenciaVacacion, Mode = 2 }), 12639, 95, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(12735, 15, true);
            WriteLiteral(">Rechazar</a>\r\n");
            EndContext();
#line 225 "C:\Luis Martinez backup\Personal\Developments\NET\GrupoSplittel\GrupoSplittel\GestionPersonal\Views\Incidencia\AprobarGPS.cshtml"
                                                }

#line default
#line hidden
            BeginContext(12801, 125, true);
            WriteLiteral("                                                <a class=\"dropdown-item\" href=\"#modalActividadVacaciones\" data-toggle=\"modal\"");
            EndContext();
            BeginWriteAttribute("onclick", " onclick=\"", 12926, "\"", 12997, 3);
            WriteAttributeValue("", 12936, "app_incidencias.ActividadVacacion(", 12936, 34, true);
#line 226 "C:\Luis Martinez backup\Personal\Developments\NET\GrupoSplittel\GrupoSplittel\GestionPersonal\Views\Incidencia\AprobarGPS.cshtml"
WriteAttributeValue("", 12970, item.IdIncidenciaVacacion, 12970, 26, false);

#line default
#line hidden
            WriteAttributeValue("", 12996, ")", 12996, 1, true);
            EndWriteAttribute();
            BeginContext(12998, 198, true);
            WriteLiteral(">Actividad</a>\r\n                                            </div>\r\n                                        </div>\r\n                                    </td>\r\n                                </tr>\r\n");
            EndContext();
#line 231 "C:\Luis Martinez backup\Personal\Developments\NET\GrupoSplittel\GrupoSplittel\GestionPersonal\Views\Incidencia\AprobarGPS.cshtml"
                            }

#line default
#line hidden
            BeginContext(13227, 64, true);
            WriteLiteral("                        </tbody>\r\n                    </table>\r\n");
            EndContext();
#line 234 "C:\Luis Martinez backup\Personal\Developments\NET\GrupoSplittel\GrupoSplittel\GestionPersonal\Views\Incidencia\AprobarGPS.cshtml"
                }

#line default
#line hidden
            BeginContext(13310, 2117, true);
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
                BeginContext(15445, 350, true);
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
                BeginContext(15796, 44, false);
#line 283 "C:\Luis Martinez backup\Personal\Developments\NET\GrupoSplittel\GrupoSplittel\GestionPersonal\Views\Incidencia\AprobarGPS.cshtml"
                           Write(Url.Action("Actividad","IncidenciaVacacion"));

#line default
#line hidden
                EndContext();
                BeginContext(15840, 747, true);
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
                BeginContext(16588, 43, false);
#line 298 "C:\Luis Martinez backup\Personal\Developments\NET\GrupoSplittel\GrupoSplittel\GestionPersonal\Views\Incidencia\AprobarGPS.cshtml"
                           Write(Url.Action("Actividad","IncidenciaPermiso"));

#line default
#line hidden
                EndContext();
                BeginContext(16631, 768, true);
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
