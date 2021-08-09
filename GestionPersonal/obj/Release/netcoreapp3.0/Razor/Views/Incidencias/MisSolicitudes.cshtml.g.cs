#pragma checksum "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Incidencias\MisSolicitudes.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8c4c86973cbe87e20551982779a8e7327528e4a5"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Incidencias_MisSolicitudes), @"mvc.1.0.view", @"/Views/Incidencias/MisSolicitudes.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8c4c86973cbe87e20551982779a8e7327528e4a5", @"/Views/Incidencias/MisSolicitudes.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"44f628e23a2086c1f04f862587f80afdb82e0a32", @"/Views/_ViewImports.cshtml")]
    public class Views_Incidencias_MisSolicitudes : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Incidencias\MisSolicitudes.cshtml"
  
    ViewData["Title"] = "Mis Solicitudes";
    List<GPSInformation.Models.IncidenciaPermiso> Permisos = ViewBag.Permisos;
    List<GPSInformation.Models.IncidenciaVacacion> Vacaciones = ViewBag.Vacaciones;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 7 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Incidencias\MisSolicitudes.cshtml"
 if ((bool)ViewBag.isPartial == false)
{
    

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
#line 14 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Incidencias\MisSolicitudes.cshtml"
                                                                          Write(ViewData["Title"]);

#line default
#line hidden
#nullable disable
                WriteLiteral("</li>\r\n                    </ol>\r\n                </nav>\r\n                <h4 class=\"mg-b-0 tx-spacing--1\">");
#nullable restore
#line 17 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Incidencias\MisSolicitudes.cshtml"
                                            Write(ViewData["Title"]);

#line default
#line hidden
#nullable disable
                WriteLiteral("</h4>\r\n            </div>\r\n            <div class=\"d-none d-md-block\">\r\n                <a");
                BeginWriteAttribute("href", " href=\"", 839, "\"", 939, 1);
#nullable restore
#line 20 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Incidencias\MisSolicitudes.cshtml"
WriteAttributeValue("", 846, Url.Action("Create","IncVacacion",new { idPersona_ = ViewBag.IdPersona, isPartial = false }), 846, 93, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" class=\"btn btn-sm pd-x-15 btn-white btn-uppercaser\"><i data-feather=\"plus\" class=\"wd-10 mg-r-5\"></i>Crear solicitud de vacaciones</a>\r\n                <a");
                BeginWriteAttribute("href", " href=\"", 1094, "\"", 1193, 1);
#nullable restore
#line 21 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Incidencias\MisSolicitudes.cshtml"
WriteAttributeValue("", 1101, Url.Action("Create","IncPermiso",new { idPersona_ = ViewBag.IdPersona, isPartial = false }), 1101, 92, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" class=\"btn btn-sm pd-x-15 btn-white btn-uppercaser\"><i data-feather=\"plus\" class=\"wd-10 mg-r-5\"></i>Crear solicitud de permisos</a>\r\n            </div>\r\n        </div>\r\n    ");
            }
            );
#nullable restore
#line 24 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Incidencias\MisSolicitudes.cshtml"
     
}
else
{

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    <div class=""d-sm-flex align-items-center justify-content-between mg-b-20 mg-lg-b-25 mg-xl-b-30"">
        <div>
            <nav aria-label=""breadcrumb"">
                <ol class=""breadcrumb breadcrumb-style1 mg-b-10"">
                    <li class=""breadcrumb-item active"" aria-current=""page"">");
#nullable restore
#line 32 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Incidencias\MisSolicitudes.cshtml"
                                                                      Write(ViewData["Title"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n                </ol>\r\n            </nav>\r\n            <h4 class=\"mg-b-0 tx-spacing--1\">");
#nullable restore
#line 35 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Incidencias\MisSolicitudes.cshtml"
                                        Write(ViewData["Title"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\r\n        </div>\r\n        <div class=\"d-none d-md-block\">\r\n            <a href=\"#\" data-rute=\"");
#nullable restore
#line 38 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Incidencias\MisSolicitudes.cshtml"
                              Write(Url.Action("Create","IncVacacion", new { idPersona_ = ViewBag.IdPersona, isPartial = true }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\" data-mode=\"form\" onclick=\"GetViewAccess(this)\" class=\"btn btn-sm pd-x-15 btn-white btn-uppercaser\"><i data-feather=\"plus\" class=\"wd-10 mg-r-5\"></i>Crear solicitud de vacaciones</a>\r\n            <a href=\"#\" data-rute=\"");
#nullable restore
#line 39 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Incidencias\MisSolicitudes.cshtml"
                              Write(Url.Action("Create","IncPermiso", new { idPersona_ = ViewBag.IdPersona, isPartial = true }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\" data-mode=\"form\" onclick=\"GetViewAccess(this)\" class=\"btn btn-sm pd-x-15 btn-white btn-uppercaser\"><i data-feather=\"plus\" class=\"wd-10 mg-r-5\"></i>Crear solicitud de Permisos</a>\r\n            <a href=\"#\" data-rute=\"");
#nullable restore
#line 40 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Incidencias\MisSolicitudes.cshtml"
                              Write(Url.Action("MisSolicitudes","Incidencias", new { id = ViewBag.IdPersona, isPartial = true }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\" onclick=\"GetViewAccess(this)\" class=\"btn btn-sm pd-x-15 btn-white btn-uppercaser\"><i data-feather=\"plus\" class=\"wd-10 mg-r-5\"></i>Refrescar</a>\r\n        </div>\r\n    </div>\r\n");
#nullable restore
#line 43 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Incidencias\MisSolicitudes.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n\r\n\r\n\r\n<ul class=\"nav nav-tabs\" id=\"myTab\" role=\"tablist\">\r\n    <li class=\"nav-item\">\r\n        <a");
            BeginWriteAttribute("class", " class=\"", 2907, "\"", 2978, 2);
            WriteAttributeValue("", 2915, "nav-link", 2915, 8, true);
#nullable restore
#line 51 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Incidencias\MisSolicitudes.cshtml"
WriteAttributeValue(" ", 2923, Html.Raw(ViewBag.Tab == "Vacaciones" ? "active" : ""), 2924, 54, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" id=\"home-tab\" data-toggle=\"tab\" href=\"#home\" role=\"tab\" aria-controls=\"home\" aria-selected=\"true\">Vacaciones</a>\r\n    </li>\r\n    <li class=\"nav-item\">\r\n        <a");
            BeginWriteAttribute("class", " class=\"", 3142, "\"", 3211, 2);
            WriteAttributeValue("", 3150, "nav-link", 3150, 8, true);
#nullable restore
#line 54 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Incidencias\MisSolicitudes.cshtml"
WriteAttributeValue(" ", 3158, Html.Raw(ViewBag.Tab == "Permisos" ? "active" : ""), 3159, 52, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" id=\"profile-tab\" data-toggle=\"tab\" href=\"#profile\" role=\"tab\" aria-controls=\"profile\" aria-selected=\"false\">Permisos</a>\r\n    </li>\r\n\r\n</ul>\r\n<div class=\"tab-content bd bd-gray-300 bd-t-0 pd-20\" id=\"myTabContent\">\r\n    <div");
            BeginWriteAttribute("class", " class=\"", 3436, "\"", 3517, 3);
            WriteAttributeValue("", 3444, "tab-pane", 3444, 8, true);
            WriteAttributeValue(" ", 3452, "fade", 3453, 5, true);
#nullable restore
#line 59 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Incidencias\MisSolicitudes.cshtml"
WriteAttributeValue(" ", 3457, Html.Raw(ViewBag.Tab == "Vacaciones" ? "show active" : ""), 3458, 59, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" id=""home"" role=""tabpanel"" aria-labelledby=""home-tab"">
        <table class=""table table-condensed table-hover display compact commontable"" id=""lista_misSolicitudesVaca"">
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
                        Creada por
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
#line 88 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Incidencias\MisSolicitudes.cshtml"
                 foreach (var item in Vacaciones)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n                    <td>\r\n                        ");
#nullable restore
#line 92 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Incidencias\MisSolicitudes.cshtml"
                   Write(Html.DisplayFor(modelItem => item.Folio));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 95 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Incidencias\MisSolicitudes.cshtml"
                   Write(Html.DisplayFor(modelItem => item.EmpleadoNombre));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 98 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Incidencias\MisSolicitudes.cshtml"
                   Write(Html.DisplayFor(modelItem => item.NoDias));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 101 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Incidencias\MisSolicitudes.cshtml"
                   Write(Html.DisplayFor(modelItem => item.Inicio));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 104 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Incidencias\MisSolicitudes.cshtml"
                   Write(Html.DisplayFor(modelItem => item.Fin));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        <span");
            BeginWriteAttribute("class", " class=\"", 5193, "\"", 5269, 3);
            WriteAttributeValue("", 5201, "badge", 5201, 5, true);
            WriteAttributeValue(" ", 5206, "badge-", 5207, 7, true);
#nullable restore
#line 107 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Incidencias\MisSolicitudes.cshtml"
WriteAttributeValue("", 5213, Html.Raw(item.CreadoPor == "A" ? "success" : "primary"), 5213, 56, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 107 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Incidencias\MisSolicitudes.cshtml"
                                                                                                      Write(Html.Raw(item.CreadoPor == "A" ? "GPS" : "Empleado"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 110 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Incidencias\MisSolicitudes.cshtml"
                   Write(Html.DisplayFor(modelItem => item.EstatusDescricion));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n");
#nullable restore
#line 113 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Incidencias\MisSolicitudes.cshtml"
                         if ((bool)ViewBag.isPartial == false)
                        {
                            

#line default
#line hidden
#nullable disable
#nullable restore
#line 115 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Incidencias\MisSolicitudes.cshtml"
                       Write(Html.ActionLink("Detalle", "Details", "IncVacacion", new { id = item.IdIncidenciaVacacion, isPartial = false }));

#line default
#line hidden
#nullable disable
#nullable restore
#line 115 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Incidencias\MisSolicitudes.cshtml"
                                                                                                                                            
                        }
                        else
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <a href=\"#\" data-rute=\"");
#nullable restore
#line 119 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Incidencias\MisSolicitudes.cshtml"
                                              Write(Url.Action("Details","IncVacacion", new { id = item.IdIncidenciaVacacion, isPartial = true }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\" onclick=\"GetViewAccess(this)\">Detalle</a>\r\n");
#nullable restore
#line 120 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Incidencias\MisSolicitudes.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n                    </td>\r\n                </tr>\r\n");
#nullable restore
#line 125 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Incidencias\MisSolicitudes.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </tbody>\r\n        </table>\r\n    </div>\r\n    <div");
            BeginWriteAttribute("class", " class=\"", 6185, "\"", 6264, 3);
            WriteAttributeValue("", 6193, "tab-pane", 6193, 8, true);
            WriteAttributeValue(" ", 6201, "fade", 6202, 5, true);
#nullable restore
#line 129 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Incidencias\MisSolicitudes.cshtml"
WriteAttributeValue(" ", 6206, Html.Raw(ViewBag.Tab == "Permisos" ? "show active" : ""), 6207, 57, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" id=""profile"" role=""tabpanel"" aria-labelledby=""profile-tab"">
        <table class=""table table-condensed table-hover display compact commontable"" id=""lista_misSolicitudes"">
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
                        Creada por
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
#line 158 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Incidencias\MisSolicitudes.cshtml"
                 foreach (var item in Permisos)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n                    <td>\r\n                        ");
#nullable restore
#line 162 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Incidencias\MisSolicitudes.cshtml"
                   Write(Html.DisplayFor(modelItem => item.Folio));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 165 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Incidencias\MisSolicitudes.cshtml"
                   Write(Html.DisplayFor(modelItem => item.EmpleadoNombre));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 168 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Incidencias\MisSolicitudes.cshtml"
                   Write(Html.DisplayFor(modelItem => item.Fecha));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 171 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Incidencias\MisSolicitudes.cshtml"
                   Write(Html.DisplayFor(modelItem => item.Inicio));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 174 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Incidencias\MisSolicitudes.cshtml"
                   Write(Html.DisplayFor(modelItem => item.Fin));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        <span");
            BeginWriteAttribute("class", " class=\"", 7949, "\"", 8025, 3);
            WriteAttributeValue("", 7957, "badge", 7957, 5, true);
            WriteAttributeValue(" ", 7962, "badge-", 7963, 7, true);
#nullable restore
#line 177 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Incidencias\MisSolicitudes.cshtml"
WriteAttributeValue("", 7969, Html.Raw(item.CreadoPor == "A" ? "success" : "primary"), 7969, 56, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 177 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Incidencias\MisSolicitudes.cshtml"
                                                                                                      Write(Html.Raw(item.CreadoPor == "A" ? "GPS" : "Empleado"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 180 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Incidencias\MisSolicitudes.cshtml"
                   Write(Html.DisplayFor(modelItem => item.EstatusDescricion));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n");
#nullable restore
#line 183 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Incidencias\MisSolicitudes.cshtml"
                         if ((bool)ViewBag.isPartial == false)
                        {
                            

#line default
#line hidden
#nullable disable
#nullable restore
#line 185 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Incidencias\MisSolicitudes.cshtml"
                       Write(Html.ActionLink("Detalle", "Details", "IncPermiso", new { id = item.IdIncidenciaPermiso }));

#line default
#line hidden
#nullable disable
#nullable restore
#line 185 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Incidencias\MisSolicitudes.cshtml"
                                                                                                                       
                        }
                        else
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <a href=\"#\" data-rute=\"");
#nullable restore
#line 189 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Incidencias\MisSolicitudes.cshtml"
                                              Write(Url.Action("Details","IncPermiso", new { id = item.IdIncidenciaPermiso, isPartial = true }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\" onclick=\"GetViewAccess(this)\">Detalle</a>\r\n");
#nullable restore
#line 190 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Incidencias\MisSolicitudes.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n                    </td>\r\n                </tr>\r\n");
#nullable restore
#line 195 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Incidencias\MisSolicitudes.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </tbody>\r\n        </table>\r\n    </div>\r\n</div>\r\n");
#nullable restore
#line 200 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Incidencias\MisSolicitudes.cshtml"
 if ((bool)ViewBag.isPartial == false)
{

}
else
{
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n");
#nullable restore
#line 209 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Incidencias\MisSolicitudes.cshtml"
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
