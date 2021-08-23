#pragma checksum "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\IncidenciaVacacion\Actividad.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "895fb597453cb90ae91699e8fa27083bdc354590"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_IncidenciaVacacion_Actividad), @"mvc.1.0.view", @"/Views/IncidenciaVacacion/Actividad.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"895fb597453cb90ae91699e8fa27083bdc354590", @"/Views/IncidenciaVacacion/Actividad.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"44f628e23a2086c1f04f862587f80afdb82e0a32", @"/Views/_ViewImports.cshtml")]
    public class Views_IncidenciaVacacion_Actividad : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<GPSInformation.Models.IncidenciaProcess>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\IncidenciaVacacion\Actividad.cshtml"
  
    ViewData["Title"] = "Actividad";
    GPSInformation.Models.IncidenciaVacacion IncidenciaVacacion = null;
    if (ViewBag.Incidencia != null)
    {
        IncidenciaVacacion = (GPSInformation.Models.IncidenciaVacacion)ViewBag.Incidencia;
    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\IncidenciaVacacion\Actividad.cshtml"
 if (IncidenciaVacacion != null && IncidenciaVacacion.Estatus == 2)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"alert alert-warning mg-b-0\" role=\"alert\">\r\n        Esta solicitud fue cancelada por el solicitante\r\n    </div>\r\n");
#nullable restore
#line 16 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\IncidenciaVacacion\Actividad.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("<ul class=\"activity  px-4 py-3\">\r\n");
#nullable restore
#line 18 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\IncidenciaVacacion\Actividad.cshtml"
     foreach (var item in Model)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <li class=\"activity-item\">\r\n\r\n");
#nullable restore
#line 22 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\IncidenciaVacacion\Actividad.cshtml"
             if (!item.Revisada)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                <div class=""activity-icon bg-primary-light tx-primary"">
                    <svg xmlns=""http://www.w3.org/2000/svg"" width=""24"" height=""24"" viewBox=""0 0 24 24"" fill=""none"" stroke=""currentColor"" stroke-width=""2"" stroke-linecap=""round"" stroke-linejoin=""round"" class=""feather feather-clock""><circle cx=""12"" cy=""12"" r=""10""></circle><polyline points=""12 6 12 12 16 14""></polyline></svg>
                </div>
");
#nullable restore
#line 27 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\IncidenciaVacacion\Actividad.cshtml"
            }
            else
            {
                

#line default
#line hidden
#nullable disable
#nullable restore
#line 30 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\IncidenciaVacacion\Actividad.cshtml"
                 if (item.Autorizada)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                    <div class=""activity-icon bg-success-light tx-success"">
                        <svg xmlns=""http://www.w3.org/2000/svg"" width=""24"" height=""24"" viewBox=""0 0 24 24"" fill=""none"" stroke=""currentColor"" stroke-width=""2"" stroke-linecap=""round"" stroke-linejoin=""round"" class=""feather feather-clock""><circle cx=""12"" cy=""12"" r=""10""></circle><polyline points=""12 6 12 12 16 14""></polyline></svg>
                    </div>
");
#nullable restore
#line 35 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\IncidenciaVacacion\Actividad.cshtml"
                }
                else
                {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                    <div class=""activity-icon bg-pink-light tx-pink"">
                        <svg xmlns=""http://www.w3.org/2000/svg"" width=""24"" height=""24"" viewBox=""0 0 24 24"" fill=""none"" stroke=""currentColor"" stroke-width=""2"" stroke-linecap=""round"" stroke-linejoin=""round"" class=""feather feather-clock""><circle cx=""12"" cy=""12"" r=""10""></circle><polyline points=""12 6 12 12 16 14""></polyline></svg>
                    </div>
");
#nullable restore
#line 41 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\IncidenciaVacacion\Actividad.cshtml"
                }

#line default
#line hidden
#nullable disable
#nullable restore
#line 41 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\IncidenciaVacacion\Actividad.cshtml"
                 
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div class=\"activity-body\">\r\n                <p class=\"mg-b-2\">\r\n                    <h4 class=\"tx-19 mg-b-2\">");
#nullable restore
#line 45 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\IncidenciaVacacion\Actividad.cshtml"
                                        Write(Html.DisplayFor(modelItem => item.Titulo));

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\r\n                    ");
#nullable restore
#line 46 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\IncidenciaVacacion\Actividad.cshtml"
               Write(Html.DisplayFor(modelItem => item.NombreEmpleado));

#line default
#line hidden
#nullable disable
            WriteLiteral(" <br />\r\n                    ");
#nullable restore
#line 47 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\IncidenciaVacacion\Actividad.cshtml"
               Write(Html.DisplayFor(modelItem => item.Comentarios));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </p>\r\n                <small class=\"tx-color-03\">\r\n");
#nullable restore
#line 50 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\IncidenciaVacacion\Actividad.cshtml"
                     if (item.Fecha != null)
                    {
                        

#line default
#line hidden
#nullable disable
#nullable restore
#line 52 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\IncidenciaVacacion\Actividad.cshtml"
                   Write(Html.Raw(GPSInformation.Herramientas.RelativeTime((DateTime)item.Fecha)));

#line default
#line hidden
#nullable disable
#nullable restore
#line 52 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\IncidenciaVacacion\Actividad.cshtml"
                                                                                                 
                    }
                    else
                    {

                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </small>\r\n            </div><!-- activity-body -->\r\n        </li>\r\n        <!-- activity-item -->\r\n");
#nullable restore
#line 62 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\IncidenciaVacacion\Actividad.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n</ul>\r\n");
#nullable restore
#line 65 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\IncidenciaVacacion\Actividad.cshtml"
 if (Model.Where(a => a.Autorizada == false && a.Revisada == true).ToList().Count > 0)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <div class=\"alert alert-warning mg-b-0\" role=\"alert\">\r\n        Esta solicitud fue rechazda por alguno de los involucrados\r\n    </div>\r\n");
#nullable restore
#line 70 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\IncidenciaVacacion\Actividad.cshtml"
}

#line default
#line hidden
#nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<GPSInformation.Models.IncidenciaProcess>> Html { get; private set; }
    }
}
#pragma warning restore 1591
