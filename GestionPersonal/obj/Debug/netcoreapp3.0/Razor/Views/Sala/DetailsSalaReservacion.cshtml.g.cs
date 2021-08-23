#pragma checksum "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Sala\DetailsSalaReservacion.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5742285fd38fdcd251fc217337c5cd168fad2692"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Sala_DetailsSalaReservacion), @"mvc.1.0.view", @"/Views/Sala/DetailsSalaReservacion.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5742285fd38fdcd251fc217337c5cd168fad2692", @"/Views/Sala/DetailsSalaReservacion.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"44f628e23a2086c1f04f862587f80afdb82e0a32", @"/Views/_ViewImports.cshtml")]
    public class Views_Sala_DetailsSalaReservacion : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<GPSInformation.Models.SalaReservacion>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Sala\DetailsSalaReservacion.cshtml"
  
    GPSInformation.Models.Sala Sala = (GPSInformation.Models.Sala)ViewBag.Sala;
    DateTime dateTime = DateTime.Parse(Model.FechaInicio.ToString("yyyy-MM-dd 00:00:00"));

    dateTime = dateTime.Date + Model.HoraIncio;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<div data-label=\"Detalle\" class=\"df-example demo-forms\" id=\"app_createPermiso\">\r\n    <h4>I. Solicitante</h4>\r\n    <hr />\r\n    ");
#nullable restore
#line 12 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Sala\DetailsSalaReservacion.cshtml"
Write(await Component.InvokeAsync("ValidPuestoEnOrganigrama", new { id = Model.IdPersona }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            WriteLiteral("    <h4>II. Detalle de la reservación ");
#nullable restore
#line 14 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Sala\DetailsSalaReservacion.cshtml"
                                 Write(dateTime);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\r\n    <hr />\r\n    <dl class=\"dl-horizontal\">\r\n        <dt>\r\n            Sala\r\n        </dt>\r\n        <dd>\r\n            ");
#nullable restore
#line 21 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Sala\DetailsSalaReservacion.cshtml"
       Write(Sala.Nombre);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
#nullable restore
#line 24 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Sala\DetailsSalaReservacion.cshtml"
       Write(Html.DisplayNameFor(model => model.Motivo));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
#nullable restore
#line 27 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Sala\DetailsSalaReservacion.cshtml"
       Write(Html.DisplayFor(model => model.Motivo));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
#nullable restore
#line 30 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Sala\DetailsSalaReservacion.cshtml"
       Write(Html.DisplayNameFor(model => model.Comentarios));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
#nullable restore
#line 33 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Sala\DetailsSalaReservacion.cshtml"
       Write(Html.DisplayFor(model => model.Comentarios));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
#nullable restore
#line 36 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Sala\DetailsSalaReservacion.cshtml"
       Write(Html.DisplayNameFor(model => model.FechaInicio));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
#nullable restore
#line 39 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Sala\DetailsSalaReservacion.cshtml"
       Write(Model.FechaInicio.ToString("yyyy-MM-dd"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
#nullable restore
#line 42 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Sala\DetailsSalaReservacion.cshtml"
       Write(Html.DisplayNameFor(model => model.HoraIncio));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
#nullable restore
#line 45 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Sala\DetailsSalaReservacion.cshtml"
       Write(Html.DisplayFor(model => model.HoraIncio));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
#nullable restore
#line 48 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Sala\DetailsSalaReservacion.cshtml"
       Write(Html.DisplayNameFor(model => model.HolaFin));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
#nullable restore
#line 51 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Sala\DetailsSalaReservacion.cshtml"
       Write(Html.DisplayFor(model => model.HolaFin));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n    </dl>\r\n");
#nullable restore
#line 54 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Sala\DetailsSalaReservacion.cshtml"
     if ((int)ViewBag.IdPersona == Model.IdPersona)
    {
        

#line default
#line hidden
#nullable disable
#nullable restore
#line 56 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Sala\DetailsSalaReservacion.cshtml"
         if (DateTime.Now < dateTime)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div class=\"form-group row mg-b-0\">\r\n                <div class=\"col-sm-12 text-right\">\r\n                    <button type=\"button\"");
            BeginWriteAttribute("onclick", " onclick=\"", 1906, "\"", 1970, 3);
            WriteAttributeValue("", 1916, "App_calendar.EditReservacion(", 1916, 29, true);
#nullable restore
#line 60 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Sala\DetailsSalaReservacion.cshtml"
WriteAttributeValue("", 1945, Model.IdSalaReservacion, 1945, 24, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1969, ")", 1969, 1, true);
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-sm btn-primary\">Editar</button>\r\n                    <button type=\"button\"");
            BeginWriteAttribute("onclick", " onclick=\"", 2061, "\"", 2116, 3);
            WriteAttributeValue("", 2071, "App_calendar.Delete(", 2071, 20, true);
#nullable restore
#line 61 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Sala\DetailsSalaReservacion.cshtml"
WriteAttributeValue("", 2091, Model.IdSalaReservacion, 2091, 24, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 2115, ")", 2115, 1, true);
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-sm btn-danger\">Eliminar</button>\r\n                </div>\r\n            </div>\r\n");
#nullable restore
#line 64 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Sala\DetailsSalaReservacion.cshtml"
        }
        else
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div class=\"alert  alert-warning col-12\" role=\"alert\">\r\n                <p>Solo lectura, la reservación ha comenzado o ha finalizado</p>\r\n            </div>\r\n");
#nullable restore
#line 70 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Sala\DetailsSalaReservacion.cshtml"
        }

#line default
#line hidden
#nullable disable
#nullable restore
#line 70 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Sala\DetailsSalaReservacion.cshtml"
         

    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<GPSInformation.Models.SalaReservacion> Html { get; private set; }
    }
}
#pragma warning restore 1591
