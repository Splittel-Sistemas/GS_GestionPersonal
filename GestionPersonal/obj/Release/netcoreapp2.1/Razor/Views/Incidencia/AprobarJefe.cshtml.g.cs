#pragma checksum "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Incidencia\AprobarJefe.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d962d65294e1b3b0dd37aa00383dca8627c8fd47"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Incidencia_AprobarJefe), @"mvc.1.0.view", @"/Views/Incidencia/AprobarJefe.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Incidencia/AprobarJefe.cshtml", typeof(AspNetCore.Views_Incidencia_AprobarJefe))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d962d65294e1b3b0dd37aa00383dca8627c8fd47", @"/Views/Incidencia/AprobarJefe.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"44f628e23a2086c1f04f862587f80afdb82e0a32", @"/Views/_ViewImports.cshtml")]
    public class Views_Incidencia_AprobarJefe : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<GestionPersonal.Models.Incidencias>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(43, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Incidencia\AprobarJefe.cshtml"
  
    ViewData["Title"] = "Aprobación de solictudes nivel 1";

#line default
#line hidden
            BeginContext(113, 90, true);
            WriteLiteral("<div class=\"d-flex align-items-center justify-content-between mg-b-30\">\r\n    <h2 class=\"\">");
            EndContext();
            BeginContext(204, 17, false);
#line 7 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Incidencia\AprobarJefe.cshtml"
            Write(ViewData["Title"]);

#line default
#line hidden
            EndContext();
            BeginContext(221, 76, true);
            WriteLiteral("</h2>\r\n    <div class=\"btn-group\" role=\"group\" aria-label=\"Basic example\">\r\n");
            EndContext();
            BeginContext(466, 518, true);
            WriteLiteral(@"    </div>
</div>
    <hr />
    <div class=""alert alert-success"" role=""alert"">
        <h4 class=""alert-heading"">Hola!</h4>
        <p>Gracias por utilizar GPS, en esta sección podrás autorizar las solicitudes de vacaciones y permisos de las personas que estén a tu cargo</p>
        <hr>
        <p class=""mb-0"">Sistema Gestión de Personal</p>
    </div>
    
    <div id=""app_incidencias"">
        <ul class=""nav nav-tabs"" id=""myTab"" role=""tablist"">
            <li class=""nav-item"">
                <a");
            EndContext();
            BeginWriteAttribute("class", " class=\"", 984, "\"", 1054, 3);
            WriteAttributeValue("", 992, "nav-link", 992, 8, true);
#line 23 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Incidencia\AprobarJefe.cshtml"
WriteAttributeValue(" ", 1000, Html.Raw(ViewBag.tab == "Permisos" ? "active" : ""), 1001, 52, false);

#line default
#line hidden
            WriteAttributeValue(" ", 1053, "", 1054, 1, true);
            EndWriteAttribute();
            BeginContext(1055, 185, true);
            WriteLiteral(" id=\"home-tab\" data-toggle=\"tab\" href=\"#home\" role=\"tab\" aria-controls=\"home\" aria-selected=\"true\">Permisos</a>\r\n            </li>\r\n            <li class=\"nav-item\">\r\n                <a");
            EndContext();
            BeginWriteAttribute("class", " class=\"", 1240, "\"", 1311, 2);
            WriteAttributeValue("", 1248, "nav-link", 1248, 8, true);
#line 26 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Incidencia\AprobarJefe.cshtml"
WriteAttributeValue(" ", 1256, Html.Raw(ViewBag.tab == "Vacaciones" ? "active" : ""), 1257, 54, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1312, 256, true);
            WriteLiteral(@" id=""profile-tab"" data-toggle=""tab"" href=""#profile"" role=""tab"" aria-controls=""profile"" aria-selected=""false"">Vacaciones</a>
            </li>
        </ul>
        <div class=""tab-content bd bd-gray-300 bd-t-0 pd-20"" id=""myTabContent"">
            <div");
            EndContext();
            BeginWriteAttribute("class", " class=\"", 1568, "\"", 1647, 3);
            WriteAttributeValue("", 1576, "tab-pane", 1576, 8, true);
            WriteAttributeValue(" ", 1584, "fade", 1585, 5, true);
#line 30 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Incidencia\AprobarJefe.cshtml"
WriteAttributeValue(" ", 1589, Html.Raw(ViewBag.tab == "Permisos" ? "show active" : ""), 1590, 57, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1648, 396, true);
            WriteLiteral(@" id=""home"" role=""tabpanel"" aria-labelledby=""home-tab"">
                <div id=""contactLogs"" class=""tab-pane pd-20 pd-xl-25 active"">
                    <div class=""d-flex align-items-center justify-content-between mg-b-30"">
                        <h4 class=""tx-15 mg-b-0"">Lista de permisos</h4>
                    </div>
                </div>
                <div id=""table-permisos"">
");
            EndContext();
#line 37 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Incidencia\AprobarJefe.cshtml"
                     if (Model.permisos.Count() == 0)
                    {

#line default
#line hidden
            BeginContext(2122, 168, true);
            WriteLiteral("                        <div class=\"alert alert-primary mg-b-0\" role=\"alert\">\r\n                            Sin solicitudes de permisos\r\n                        </div>\r\n");
            EndContext();
#line 42 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Incidencia\AprobarJefe.cshtml"
                    }
                    else
                    {

#line default
#line hidden
            BeginContext(2362, 1217, true);
            WriteLiteral(@"                        <table class=""table"">
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
           ");
            WriteLiteral("                         </th>\r\n                                    <th></th>\r\n                                </tr>\r\n                            </thead>\r\n                            <tbody>\r\n");
            EndContext();
#line 73 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Incidencia\AprobarJefe.cshtml"
                                 foreach (var item in Model.permisos)
                                {
                                    var nive2 = item.Proceso.Find(a => a.Nivel == 2);

#line default
#line hidden
            BeginContext(3772, 132, true);
            WriteLiteral("                                    <tr>\r\n                                        <td>\r\n                                            ");
            EndContext();
            BeginContext(3905, 40, false);
#line 78 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Incidencia\AprobarJefe.cshtml"
                                       Write(Html.DisplayFor(modelItem => item.Folio));

#line default
#line hidden
            EndContext();
            BeginContext(3945, 139, true);
            WriteLiteral("\r\n                                        </td>\r\n                                        <td>\r\n                                            ");
            EndContext();
            BeginContext(4085, 49, false);
#line 81 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Incidencia\AprobarJefe.cshtml"
                                       Write(Html.DisplayFor(modelItem => item.EmpleadoNombre));

#line default
#line hidden
            EndContext();
            BeginContext(4134, 139, true);
            WriteLiteral("\r\n                                        </td>\r\n                                        <td>\r\n                                            ");
            EndContext();
            BeginContext(4274, 40, false);
#line 84 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Incidencia\AprobarJefe.cshtml"
                                       Write(Html.DisplayFor(modelItem => item.Fecha));

#line default
#line hidden
            EndContext();
            BeginContext(4314, 139, true);
            WriteLiteral("\r\n                                        </td>\r\n                                        <td>\r\n                                            ");
            EndContext();
            BeginContext(4454, 41, false);
#line 87 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Incidencia\AprobarJefe.cshtml"
                                       Write(Html.DisplayFor(modelItem => item.Inicio));

#line default
#line hidden
            EndContext();
            BeginContext(4495, 139, true);
            WriteLiteral("\r\n                                        </td>\r\n                                        <td>\r\n                                            ");
            EndContext();
            BeginContext(4635, 38, false);
#line 90 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Incidencia\AprobarJefe.cshtml"
                                       Write(Html.DisplayFor(modelItem => item.Fin));

#line default
#line hidden
            EndContext();
            BeginContext(4673, 95, true);
            WriteLiteral("\r\n                                        </td>\r\n                                        <td>\r\n");
            EndContext();
#line 93 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Incidencia\AprobarJefe.cshtml"
                                             if (item.Estatus == 1)
                                            {

#line default
#line hidden
            BeginContext(4884, 101, true);
            WriteLiteral("                                                <span class=\"badge badge-primary\">En proceso</span>\r\n");
            EndContext();
#line 96 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Incidencia\AprobarJefe.cshtml"
                                            }
                                            else if (item.Estatus == 2)
                                            {

#line default
#line hidden
            BeginContext(5152, 99, true);
            WriteLiteral("                                                <span class=\"badge badge-danger\">Cancelada</span>\r\n");
            EndContext();
#line 100 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Incidencia\AprobarJefe.cshtml"
                                            }
                                            else
                                            {

#line default
#line hidden
            BeginContext(5395, 101, true);
            WriteLiteral("                                                <span class=\"badge badge-primary\">Completada</span>\r\n");
            EndContext();
#line 104 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Incidencia\AprobarJefe.cshtml"
                                            }

#line default
#line hidden
            BeginContext(5543, 93, true);
            WriteLiteral("                                        </td>\r\n                                        <td>\r\n");
            EndContext();
#line 107 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Incidencia\AprobarJefe.cshtml"
                                             if (item.Estatus == 1 && nive2 != null && nive2.Revisada == false)
                                            {

#line default
#line hidden
            BeginContext(5796, 102, true);
            WriteLiteral("                                                <span class=\"badge badge-warning\">Sin revisar</span>\r\n");
            EndContext();
#line 110 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Incidencia\AprobarJefe.cshtml"
                                            }
                                            else
                                            {

#line default
#line hidden
            BeginContext(6042, 93, true);
            WriteLiteral("                                                <span class=\"badge badge-success\">Ok</span>\r\n");
            EndContext();
#line 114 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Incidencia\AprobarJefe.cshtml"
                                            }

#line default
#line hidden
            BeginContext(6182, 681, true);
            WriteLiteral(@"                                        </td>
                                        <td>

                                            <div class=""dropdown"">
                                                <button class=""btn btn-light btn-sm dropdown-toggle"" type=""button"" id=""dropleftMenuButton"" data-toggle=""dropdown"" aria-haspopup=""true"" aria-expanded=""false"">
                                                    Opciones
                                                </button>
                                                <div class=""dropdown-menu"" aria-labelledby=""dropleftMenuButton"">
                                                    <a class=""dropdown-item""");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 6863, "\"", 6952, 1);
#line 123 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Incidencia\AprobarJefe.cshtml"
WriteAttributeValue("", 6870, Url.Action("Details", "IncidenciaPermiso", new { id = item.IdIncidenciaPermiso }), 6870, 82, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(6953, 14, true);
            WriteLiteral(">Detalle</a>\r\n");
            EndContext();
#line 124 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Incidencia\AprobarJefe.cshtml"
                                                     if (item.Estatus == 1 && nive2 != null && nive2.Revisada == false)
                                                    {

#line default
#line hidden
            BeginContext(7143, 80, true);
            WriteLiteral("                                                        <a class=\"dropdown-item\"");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 7223, "\"", 7322, 1);
#line 126 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Incidencia\AprobarJefe.cshtml"
WriteAttributeValue("", 7230, Url.Action("Aprobar", "IncidenciaPermiso", new { id = item.IdIncidenciaPermiso, Mode = 1 }), 7230, 92, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(7323, 14, true);
            WriteLiteral(">Aprobar</a>\r\n");
            EndContext();
#line 127 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Incidencia\AprobarJefe.cshtml"
                                                                                                                                                                                                      
                                                    }

#line default
#line hidden
            BeginContext(7592, 127, true);
            WriteLiteral("                                                    <a class=\"dropdown-item\" href=\"#modalActividadPermisos\" data-toggle=\"modal\"");
            EndContext();
            BeginWriteAttribute("onclick", " onclick=\"", 7719, "\"", 7789, 3);
            WriteAttributeValue("", 7729, "app_incidencias.ActividadPermisos(", 7729, 34, true);
#line 129 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Incidencia\AprobarJefe.cshtml"
WriteAttributeValue("", 7763, item.IdIncidenciaPermiso, 7763, 25, false);

#line default
#line hidden
            WriteAttributeValue("", 7788, ")", 7788, 1, true);
            EndWriteAttribute();
            BeginContext(7790, 214, true);
            WriteLiteral(">Actividad</a>\r\n                                                </div>\r\n                                            </div>\r\n                                        </td>\r\n                                    </tr>\r\n");
            EndContext();
#line 134 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Incidencia\AprobarJefe.cshtml"
                                }

#line default
#line hidden
            BeginContext(8039, 72, true);
            WriteLiteral("                            </tbody>\r\n                        </table>\r\n");
            EndContext();
#line 137 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Incidencia\AprobarJefe.cshtml"
                    }

#line default
#line hidden
            BeginContext(8134, 60, true);
            WriteLiteral("                </div>\r\n            </div>\r\n            <div");
            EndContext();
            BeginWriteAttribute("class", " class=\"", 8194, "\"", 8275, 3);
            WriteAttributeValue("", 8202, "tab-pane", 8202, 8, true);
            WriteAttributeValue(" ", 8210, "fade", 8211, 5, true);
#line 140 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Incidencia\AprobarJefe.cshtml"
WriteAttributeValue(" ", 8215, Html.Raw(ViewBag.tab == "Vacaciones" ? "show active" : ""), 8216, 59, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(8276, 404, true);
            WriteLiteral(@" id=""profile"" role=""tabpanel"" aria-labelledby=""profile-tab"">
                <div id=""contactLogs"" class=""tab-pane pd-20 pd-xl-25 active"">
                    <div class=""d-flex align-items-center justify-content-between mg-b-30"">
                        <h4 class=""tx-15 mg-b-0"">Lista de vacaciones</h4>
                    </div>
                </div>
                <div id=""table-permisos"">
");
            EndContext();
#line 147 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Incidencia\AprobarJefe.cshtml"
                     if (Model.vacaciones.Count() == 0)
                    {

#line default
#line hidden
            BeginContext(8760, 170, true);
            WriteLiteral("                        <div class=\"alert alert-primary mg-b-0\" role=\"alert\">\r\n                            Sin solicitudes de vacaciones\r\n                        </div>\r\n");
            EndContext();
#line 152 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Incidencia\AprobarJefe.cshtml"
                    }
                    else
                    {

#line default
#line hidden
            BeginContext(9002, 1114, true);
            WriteLiteral(@"                        <table class=""table table-condensed table-sm"">
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
                        ");
            WriteLiteral("        </tr>\r\n                            </thead>\r\n                            <tbody>\r\n");
            EndContext();
#line 180 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Incidencia\AprobarJefe.cshtml"
                                 foreach (var item in Model.vacaciones)
                                {

#line default
#line hidden
            BeginContext(10224, 132, true);
            WriteLiteral("                                    <tr>\r\n                                        <td>\r\n                                            ");
            EndContext();
            BeginContext(10357, 40, false);
#line 184 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Incidencia\AprobarJefe.cshtml"
                                       Write(Html.DisplayFor(modelItem => item.Folio));

#line default
#line hidden
            EndContext();
            BeginContext(10397, 139, true);
            WriteLiteral("\r\n                                        </td>\r\n                                        <td>\r\n                                            ");
            EndContext();
            BeginContext(10537, 49, false);
#line 187 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Incidencia\AprobarJefe.cshtml"
                                       Write(Html.DisplayFor(modelItem => item.EmpleadoNombre));

#line default
#line hidden
            EndContext();
            BeginContext(10586, 139, true);
            WriteLiteral("\r\n                                        </td>\r\n                                        <td>\r\n                                            ");
            EndContext();
            BeginContext(10726, 41, false);
#line 190 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Incidencia\AprobarJefe.cshtml"
                                       Write(Html.DisplayFor(modelItem => item.Inicio));

#line default
#line hidden
            EndContext();
            BeginContext(10767, 139, true);
            WriteLiteral("\r\n                                        </td>\r\n                                        <td>\r\n                                            ");
            EndContext();
            BeginContext(10907, 38, false);
#line 193 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Incidencia\AprobarJefe.cshtml"
                                       Write(Html.DisplayFor(modelItem => item.Fin));

#line default
#line hidden
            EndContext();
            BeginContext(10945, 139, true);
            WriteLiteral("\r\n                                        </td>\r\n                                        <td>\r\n                                            ");
            EndContext();
            BeginContext(11085, 41, false);
#line 196 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Incidencia\AprobarJefe.cshtml"
                                       Write(Html.DisplayFor(modelItem => item.NoDias));

#line default
#line hidden
            EndContext();
            BeginContext(11126, 95, true);
            WriteLiteral("\r\n                                        </td>\r\n                                        <td>\r\n");
            EndContext();
#line 199 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Incidencia\AprobarJefe.cshtml"
                                             if (item.Estatus == 1)
                                            {

#line default
#line hidden
            BeginContext(11337, 101, true);
            WriteLiteral("                                                <span class=\"badge badge-primary\">En proceso</span>\r\n");
            EndContext();
#line 202 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Incidencia\AprobarJefe.cshtml"
                                            }
                                            else if (item.Estatus == 2)
                                            {

#line default
#line hidden
            BeginContext(11605, 99, true);
            WriteLiteral("                                                <span class=\"badge badge-danger\">Cancelada</span>\r\n");
            EndContext();
#line 206 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Incidencia\AprobarJefe.cshtml"
                                            }
                                            else
                                            {

#line default
#line hidden
            BeginContext(11848, 101, true);
            WriteLiteral("                                                <span class=\"badge badge-primary\">Completada</span>\r\n");
            EndContext();
#line 210 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Incidencia\AprobarJefe.cshtml"
                                            }

#line default
#line hidden
            BeginContext(11996, 93, true);
            WriteLiteral("                                        </td>\r\n                                        <td>\r\n");
            EndContext();
#line 213 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Incidencia\AprobarJefe.cshtml"
                                              
                                                var nive2 = item.Proceso.Find(a => a.Nivel == 2);
                                            

#line default
#line hidden
            BeginContext(12283, 586, true);
            WriteLiteral(@"                                            <div class=""dropdown"">
                                                <button class=""btn btn-light btn-sm dropdown-toggle"" type=""button"" id=""dropleftMenuButton"" data-toggle=""dropdown"" aria-haspopup=""true"" aria-expanded=""false"">
                                                    Opciones
                                                </button>
                                                <div class=""dropdown-menu"" aria-labelledby=""dropleftMenuButton"">
                                                    <a class=""dropdown-item""");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 12869, "\"", 12960, 1);
#line 221 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Incidencia\AprobarJefe.cshtml"
WriteAttributeValue("", 12876, Url.Action("Details", "IncidenciaVacacion", new { id = item.IdIncidenciaVacacion }), 12876, 84, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(12961, 14, true);
            WriteLiteral(">Detalle</a>\r\n");
            EndContext();
#line 222 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Incidencia\AprobarJefe.cshtml"
                                                     if (item.Estatus == 1 && nive2 != null && nive2.Revisada == false)
                                                    {

#line default
#line hidden
            BeginContext(13151, 80, true);
            WriteLiteral("                                                        <a class=\"dropdown-item\"");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 13231, "\"", 13332, 1);
#line 224 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Incidencia\AprobarJefe.cshtml"
WriteAttributeValue("", 13238, Url.Action("Aprobar", "IncidenciaVacacion", new { id = item.IdIncidenciaVacacion, Mode = 1 }), 13238, 94, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(13333, 94, true);
            WriteLiteral(">Aprobar</a>\r\n                                                        <a class=\"dropdown-item\"");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 13427, "\"", 13529, 1);
#line 225 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Incidencia\AprobarJefe.cshtml"
WriteAttributeValue("", 13434, Url.Action("Rechazar", "IncidenciaVacacion", new { id = item.IdIncidenciaVacacion, Mode = 1 }), 13434, 95, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(13530, 15, true);
            WriteLiteral(">Rechazar</a>\r\n");
            EndContext();
#line 226 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Incidencia\AprobarJefe.cshtml"
                                                    }

#line default
#line hidden
            BeginContext(13600, 129, true);
            WriteLiteral("                                                    <a class=\"dropdown-item\" href=\"#modalActividadVacaciones\" data-toggle=\"modal\"");
            EndContext();
            BeginWriteAttribute("onclick", " onclick=\"", 13729, "\"", 13800, 3);
            WriteAttributeValue("", 13739, "app_incidencias.ActividadVacacion(", 13739, 34, true);
#line 227 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Incidencia\AprobarJefe.cshtml"
WriteAttributeValue("", 13773, item.IdIncidenciaVacacion, 13773, 26, false);

#line default
#line hidden
            WriteAttributeValue("", 13799, ")", 13799, 1, true);
            EndWriteAttribute();
            BeginContext(13801, 214, true);
            WriteLiteral(">Actividad</a>\r\n                                                </div>\r\n                                            </div>\r\n                                        </td>\r\n                                    </tr>\r\n");
            EndContext();
#line 232 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Incidencia\AprobarJefe.cshtml"
                                }

#line default
#line hidden
            BeginContext(14050, 72, true);
            WriteLiteral("                            </tbody>\r\n                        </table>\r\n");
            EndContext();
#line 235 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Incidencia\AprobarJefe.cshtml"
                    }

#line default
#line hidden
            BeginContext(14145, 2261, true);
            WriteLiteral(@"                </div>
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
                    </div><!-- mod");
            WriteLiteral(@"al-footer -->
                </div><!-- modal-content -->
            </div><!-- modal-dialog -->
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
                        <a href="""" class=""btn btn-secondary");
            WriteLiteral("\" data-dismiss=\"modal\">Cerrar</a>\r\n                    </div><!-- modal-footer -->\r\n                </div><!-- modal-content -->\r\n            </div><!-- modal-dialog -->\r\n        </div><!-- modal -->\r\n    </div>\r\n");
            EndContext();
            DefineSection("Scripts", async() => {
                BeginContext(16424, 350, true);
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
                BeginContext(16775, 44, false);
#line 284 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Incidencia\AprobarJefe.cshtml"
                           Write(Url.Action("Actividad","IncidenciaVacacion"));

#line default
#line hidden
                EndContext();
                BeginContext(16819, 779, true);
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
                BeginContext(17599, 43, false);
#line 299 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Incidencia\AprobarJefe.cshtml"
                           Write(Url.Action("Actividad","IncidenciaPermiso"));

#line default
#line hidden
                EndContext();
                BeginContext(17642, 800, true);
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
