#pragma checksum "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\IncPermiso\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5d0dc763a33010d018cdd2e195e4dfe8ac732e67"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_IncPermiso_Details), @"mvc.1.0.view", @"/Views/IncPermiso/Details.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5d0dc763a33010d018cdd2e195e4dfe8ac732e67", @"/Views/IncPermiso/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"44f628e23a2086c1f04f862587f80afdb82e0a32", @"/Views/_ViewImports.cshtml")]
    public class Views_IncPermiso_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<GPSInformation.Models.IncidenciaPermiso>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\IncPermiso\Details.cshtml"
  
    ViewData["Title"] = "Detalle de solicitud: " + Model.Folio;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\IncPermiso\Details.cshtml"
 if ((bool)ViewBag.isPartial == true)
{

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    <div class=""d-sm-flex align-items-center justify-content-between mg-b-20 mg-lg-b-25 mg-xl-b-30"">
        <div>
            <nav aria-label=""breadcrumb"">
                <ol class=""breadcrumb breadcrumb-style1 mg-b-10"">
                    <li class=""breadcrumb-item"" aria-current=""page""><a href=""#"" data-rute=""");
#nullable restore
#line 11 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\IncPermiso\Details.cshtml"
                                                                                      Write(Url.Action("MisSolicitudes","Incidencias", new { id = Model.IdPersona, isPartial = true, Tab = "Vacaciones" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\" onclick=\"GetViewAccess(this)\">Lista de solicitudes</a> </li>\r\n                    <li class=\"breadcrumb-item active\" aria-current=\"page\">");
#nullable restore
#line 12 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\IncPermiso\Details.cshtml"
                                                                      Write(ViewData["Title"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n                </ol>\r\n            </nav>\r\n            <h4 class=\"mg-b-0 tx-spacing--1\">");
#nullable restore
#line 15 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\IncPermiso\Details.cshtml"
                                        Write(ViewData["Title"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\r\n        </div>\r\n        <div class=\"d-none d-md-block\">\r\n            <a class=\"btn btn-sm pd-x-15 btn-white btn-uppercaser\" onclick=\"GetViewAccess(this)\" href=\"#\" data-rute=\"");
#nullable restore
#line 18 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\IncPermiso\Details.cshtml"
                                                                                                                Write(Url.Action("Details","IncPermiso", new  { id = Model.IdIncidenciaPermiso, isPartial = true }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\" data-mode=\"form\">\r\n                <i data-feather=\"refresh\" class=\"wd-10 mg-r-5\"></i>Refrescar\r\n            </a>\r\n\r\n");
#nullable restore
#line 26 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\IncPermiso\Details.cshtml"
             if ((bool)ViewBag.ShowCancel && Model.Estatus <= 4 && Model.Fecha <= DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd")))
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <a onclick=\"ValidViewActionAccess(this,\'Cancelar esta solicitud\')\" href=\"#\" data-rute=\"");
#nullable restore
#line 28 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\IncPermiso\Details.cshtml"
                                                                                                  Write(Url.Action("Cancelar","IncPermiso", new { id = Model.IdIncidenciaPermiso, isPartial = true }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\" class=\"btn btn-sm pd-x-15 btn-white btn-uppercaser\"><i data-feather=\"x\" class=\"wd-10 mg-r-5\"></i>Cancel</a>\r\n");
#nullable restore
#line 29 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\IncPermiso\Details.cshtml"
            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 30 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\IncPermiso\Details.cshtml"
             if ((bool)ViewBag.ShowDelete)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <a onclick=\"ValidViewActionAccess(this,\'Eliminar esta solicitud\')\" href=\"#\" data-rute=\"");
#nullable restore
#line 32 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\IncPermiso\Details.cshtml"
                                                                                                  Write(Url.Action("Delete","IncPermiso", new { id = Model.IdIncidenciaPermiso, isPartial = true }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\" class=\"btn btn-sm pd-x-15 btn-white btn-uppercaser\"><i data-feather=\"trash\" class=\"wd-10 mg-r-5\"></i>Eliminar</a>\r\n");
#nullable restore
#line 33 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\IncPermiso\Details.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </div>\r\n    </div>\r\n");
#nullable restore
#line 36 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\IncPermiso\Details.cshtml"
}
else
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
#line 44 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\IncPermiso\Details.cshtml"
                                                                          Write(ViewData["Title"]);

#line default
#line hidden
#nullable disable
                WriteLiteral("</li>\r\n                    </ol>\r\n                </nav>\r\n                <h4 class=\"mg-b-0 tx-spacing--1\">");
#nullable restore
#line 47 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\IncPermiso\Details.cshtml"
                                            Write(ViewData["Title"]);

#line default
#line hidden
#nullable disable
                WriteLiteral("</h4>\r\n            </div>\r\n            <div class=\"d-none d-md-block\">\r\n");
#nullable restore
#line 54 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\IncPermiso\Details.cshtml"
                 if ((bool)ViewBag.ShowCancel && Model.Estatus <= 4)
                {

#line default
#line hidden
#nullable disable
                WriteLiteral("                <a");
                BeginWriteAttribute("href", " href=\"", 3500, "\"", 3583, 1);
#nullable restore
#line 56 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\IncPermiso\Details.cshtml"
WriteAttributeValue("", 3507, Url.Action("Cancelar","IncPermiso", new { id = Model.IdIncidenciaPermiso }), 3507, 76, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" class=\"btn btn-sm pd-x-15 btn-white btn-uppercaser\"><i data-feather=\"x\" class=\"wd-10 mg-r-5\"></i>Cancelar</a>\r\n");
#nullable restore
#line 57 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\IncPermiso\Details.cshtml"
                }
                

#line default
#line hidden
#nullable disable
                WriteLiteral("            </div>\r\n        </div>\r\n    ");
            }
            );
#nullable restore
#line 64 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\IncPermiso\Details.cshtml"
     
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 67 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\IncPermiso\Details.cshtml"
 if (ViewBag.MessageSuccess != null)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"alert alert-success alert-dismissible fade show\" role=\"alert\">\r\n        <strong>Estimado usuario!</strong> ");
#nullable restore
#line 70 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\IncPermiso\Details.cshtml"
                                      Write(ViewBag.MessageSuccess);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        <button type=\"button\" class=\"close\" data-dismiss=\"alert\" aria-label=\"Close\">\r\n            <span aria-hidden=\"true\">×</span>\r\n        </button>\r\n    </div>\r\n");
#nullable restore
#line 75 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\IncPermiso\Details.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("<div data-label=\"Crear Nuevo Permiso\" class=\"df-example demo-forms\" id=\"app_createPermiso\">\r\n    <h4 class=\"bg-light\">I. Solicitante</h4>\r\n    ");
#nullable restore
#line 78 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\IncPermiso\Details.cshtml"
Write(await Component.InvokeAsync("ValidPuestoEnOrganigrama", new { id = Model.IdPersona }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    <h4 class=\"bg-light\">II. Detalle de solicitud</h4>\r\n    <dl class=\"row m-1\">\r\n        <dt class=\"col-lg-2 col-form-label\">\r\n            ");
#nullable restore
#line 82 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\IncPermiso\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Folio));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-lg-4 col-form-label bg-light mb-1\">\r\n            ");
#nullable restore
#line 85 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\IncPermiso\Details.cshtml"
       Write(Html.DisplayFor(model => model.Folio));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-lg-2 col-form-label\">\r\n            ");
#nullable restore
#line 88 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\IncPermiso\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Fecha));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-lg-4 col-form-label bg-light mb-1\">\r\n            ");
#nullable restore
#line 91 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\IncPermiso\Details.cshtml"
       Write(Model.Fecha.ToString("F"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-lg-2 col-form-label\">\r\n            ");
#nullable restore
#line 94 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\IncPermiso\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Inicio));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-lg-4 col-form-label bg-light mb-1\">\r\n            ");
#nullable restore
#line 97 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\IncPermiso\Details.cshtml"
       Write(Html.DisplayFor(model => model.Inicio));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-lg-2 col-form-label\">\r\n            ");
#nullable restore
#line 100 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\IncPermiso\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Fin));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-lg-4 col-form-label bg-light mb-1\">\r\n            ");
#nullable restore
#line 103 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\IncPermiso\Details.cshtml"
       Write(Html.DisplayFor(model => model.Fin));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-lg-2 col-form-label\">\r\n            ");
#nullable restore
#line 106 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\IncPermiso\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.DEscripcionTipo));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-lg-4 col-form-label bg-light mb-1\">\r\n            ");
#nullable restore
#line 109 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\IncPermiso\Details.cshtml"
       Write(Html.DisplayFor(model => model.DEscripcionTipo));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-lg-2 col-form-label\">\r\n        </dt>\r\n        <dd class=\"col-lg-4 col-form-label\">\r\n        </dd>\r\n        <dt class=\"col-lg-2 col-form-label\">\r\n            ");
#nullable restore
#line 116 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\IncPermiso\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.DescripcionAsunto));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-lg-10 col-form-label bg-light mb-1\">\r\n            ");
#nullable restore
#line 119 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\IncPermiso\Details.cshtml"
       Write(Html.DisplayFor(model => model.DescripcionAsunto));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n");
#nullable restore
#line 121 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\IncPermiso\Details.cshtml"
         if (Model.IdAsunto == 36)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <dt class=\"col-lg-2 col-form-label\">\r\n                ");
#nullable restore
#line 124 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\IncPermiso\Details.cshtml"
           Write(Html.DisplayNameFor(model => model.PagoPermisoDesc));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </dt>\r\n            <dd class=\"col-lg-4 col-form-label bg-light mb-1\">\r\n                ");
#nullable restore
#line 127 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\IncPermiso\Details.cshtml"
           Write(Html.DisplayFor(model => model.PagoPermisoDesc));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </dd>\r\n");
#nullable restore
#line 129 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\IncPermiso\Details.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </dl>\r\n");
#nullable restore
#line 131 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\IncPermiso\Details.cshtml"
     if (Model.Estatus >= 4)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div");
            BeginWriteAttribute("class", " class=\"", 6765, "\"", 6816, 5);
            WriteAttributeValue("", 6773, "alert", 6773, 5, true);
            WriteAttributeValue(" ", 6778, "alert-", 6779, 7, true);
#nullable restore
#line 133 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\IncPermiso\Details.cshtml"
WriteAttributeValue("", 6785, Model.EstatusColor, 6785, 19, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue(" ", 6804, "mt-4", 6805, 5, true);
            WriteAttributeValue(" ", 6809, "mg-b-0", 6810, 7, true);
            EndWriteAttribute();
            WriteLiteral(" role=\"alert\">\r\n            Estimado usuario, la solcitud se encuentra con estatus <strong>");
#nullable restore
#line 134 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\IncPermiso\Details.cshtml"
                                                                      Write(Model.EstatusDescricion);

#line default
#line hidden
#nullable disable
            WriteLiteral("</strong>\r\n        </div>\r\n");
#nullable restore
#line 136 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\IncPermiso\Details.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("    <h4 class=\"bg-light mt-3\">III. Seguimiento</h4>\r\n    <ul class=\"steps steps-sm steps-justified d-none d-lg-block\">\r\n");
#nullable restore
#line 139 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\IncPermiso\Details.cshtml"
         foreach (var item in Model.Proceso)
        {
            

#line default
#line hidden
#nullable disable
#nullable restore
#line 141 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\IncPermiso\Details.cshtml"
             if (item.Revisada)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <li class=\"step-item complete\">\r\n                    <a");
            BeginWriteAttribute("href", " href=\"", 7262, "\"", 7269, 0);
            EndWriteAttribute();
            WriteLiteral(" class=\"step-link\">\r\n                        <span class=\"step-icon\"><i data-feather=\"user\"></i></span>\r\n                        <div>\r\n                            <span class=\"step-title\">");
#nullable restore
#line 147 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\IncPermiso\Details.cshtml"
                                                Write(item.Titulo);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                            <span class=\"step-desc\">");
#nullable restore
#line 148 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\IncPermiso\Details.cshtml"
                                               Write(item.NombreEmpleado);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                            <span");
            BeginWriteAttribute("class", " class=\"", 7594, "\"", 7671, 2);
            WriteAttributeValue("", 7602, "step-desc", 7602, 9, true);
#nullable restore
#line 149 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\IncPermiso\Details.cshtml"
WriteAttributeValue(" ", 7611, Html.Raw(item.Autorizada ? "text-success" : "text-danger"), 7612, 59, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 149 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\IncPermiso\Details.cshtml"
                                                                                                           Write(Html.Raw(item.Autorizada ? "Aceptada" : "Rechazada"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                            <span class=\"step-desc\">");
#nullable restore
#line 150 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\IncPermiso\Details.cshtml"
                                               Write(string.Format("{0:F}", item.Fecha));

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                        </div>\r\n                    </a>\r\n                </li>\r\n");
#nullable restore
#line 154 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\IncPermiso\Details.cshtml"
            }
            else if (!item.Revisada && item.Nivel == Model.Estatus)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <li class=\"step-item active\">\r\n                    <a");
            BeginWriteAttribute("href", " href=\"", 8080, "\"", 8087, 0);
            EndWriteAttribute();
            WriteLiteral(" class=\"step-link\">\r\n                        <span class=\"step-icon\"><i data-feather=\"user\"></i></span>\r\n                        <div>\r\n                            <span class=\"step-title\">");
#nullable restore
#line 161 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\IncPermiso\Details.cshtml"
                                                Write(item.Titulo);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                        </div>\r\n                    </a>\r\n                </li>\r\n");
#nullable restore
#line 165 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\IncPermiso\Details.cshtml"
            }
            else
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <li class=\"step-item disabled\">\r\n                    <a");
            BeginWriteAttribute("href", " href=\"", 8498, "\"", 8505, 0);
            EndWriteAttribute();
            WriteLiteral(" class=\"step-link\">\r\n                        <span class=\"step-icon\"><i data-feather=\"user\"></i></span>\r\n                        <div>\r\n                            <span class=\"step-title\">");
#nullable restore
#line 172 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\IncPermiso\Details.cshtml"
                                                Write(item.Titulo);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                        </div>\r\n                    </a>\r\n                </li>\r\n");
#nullable restore
#line 176 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\IncPermiso\Details.cshtml"
            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 176 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\IncPermiso\Details.cshtml"
             
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </ul>\r\n    <ul class=\"steps step-sm steps-vertical col-12 d-block d-lg-none\">\r\n");
#nullable restore
#line 181 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\IncPermiso\Details.cshtml"
             foreach (var item in Model.Proceso)
            {


                

#line default
#line hidden
#nullable disable
#nullable restore
#line 185 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\IncPermiso\Details.cshtml"
                 if (item.Revisada)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <li class=\"step-item complete\">\r\n                        <a");
            BeginWriteAttribute("href", " href=\"", 9112, "\"", 9119, 0);
            EndWriteAttribute();
            WriteLiteral(" class=\"step-link\">\r\n                            <span class=\"step-icon\"><i data-feather=\"user\"></i></span>\r\n                            <div>\r\n                                <span class=\"step-title\">");
#nullable restore
#line 191 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\IncPermiso\Details.cshtml"
                                                    Write(item.Titulo);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                                <span class=\"step-desc\">");
#nullable restore
#line 192 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\IncPermiso\Details.cshtml"
                                                   Write(item.NombreEmpleado);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                                <span");
            BeginWriteAttribute("class", " class=\"", 9464, "\"", 9541, 2);
            WriteAttributeValue("", 9472, "step-desc", 9472, 9, true);
#nullable restore
#line 193 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\IncPermiso\Details.cshtml"
WriteAttributeValue(" ", 9481, Html.Raw(item.Autorizada ? "text-success" : "text-danger"), 9482, 59, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">");
#nullable restore
#line 193 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\IncPermiso\Details.cshtml"
                                                                                                               Write(Html.Raw(item.Autorizada ? "Aceptada" : "Rechazada"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                                <span class=\"step-desc\">");
#nullable restore
#line 194 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\IncPermiso\Details.cshtml"
                                                   Write(string.Format("{0:F}", item.Fecha));

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                            </div>\r\n                        </a>\r\n                    </li>\r\n");
#nullable restore
#line 198 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\IncPermiso\Details.cshtml"
                }
                else if (!item.Revisada && item.Nivel == Model.Estatus)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <li class=\"step-item active\">\r\n                        <a");
            BeginWriteAttribute("href", " href=\"", 9986, "\"", 9993, 0);
            EndWriteAttribute();
            WriteLiteral(" class=\"step-link\">\r\n                            <span class=\"step-icon\"><i data-feather=\"user\"></i></span>\r\n                            <div>\r\n                                <span class=\"step-title\">");
#nullable restore
#line 205 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\IncPermiso\Details.cshtml"
                                                    Write(item.Titulo);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                            </div>\r\n                        </a>\r\n                    </li>\r\n");
#nullable restore
#line 209 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\IncPermiso\Details.cshtml"
                }
                else
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <li class=\"step-item disabled\">\r\n                        <a");
            BeginWriteAttribute("href", " href=\"", 10448, "\"", 10455, 0);
            EndWriteAttribute();
            WriteLiteral(" class=\"step-link\">\r\n                            <span class=\"step-icon\"><i data-feather=\"user\"></i></span>\r\n                            <div>\r\n                                <span class=\"step-title\">");
#nullable restore
#line 216 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\IncPermiso\Details.cshtml"
                                                    Write(item.Titulo);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                            </div>\r\n                        </a>\r\n                    </li>\r\n");
#nullable restore
#line 220 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\IncPermiso\Details.cshtml"
                }

#line default
#line hidden
#nullable disable
#nullable restore
#line 220 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\IncPermiso\Details.cshtml"
                 
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </ul>\r\n\r\n\r\n\r\n</div>");
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
