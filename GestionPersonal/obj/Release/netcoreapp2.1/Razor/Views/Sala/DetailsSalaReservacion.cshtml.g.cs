#pragma checksum "C:\Luis Martinez backup\Personal\Developments\NET\GrupoSplittel\GrupoSplittel\GestionPersonal\Views\Sala\DetailsSalaReservacion.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3e1b3aa67ba268efb2ef08fba0587f949ea51fb8"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Sala_DetailsSalaReservacion), @"mvc.1.0.view", @"/Views/Sala/DetailsSalaReservacion.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Sala/DetailsSalaReservacion.cshtml", typeof(AspNetCore.Views_Sala_DetailsSalaReservacion))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3e1b3aa67ba268efb2ef08fba0587f949ea51fb8", @"/Views/Sala/DetailsSalaReservacion.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"44f628e23a2086c1f04f862587f80afdb82e0a32", @"/Views/_ViewImports.cshtml")]
    public class Views_Sala_DetailsSalaReservacion : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<GPSInformation.Models.SalaReservacion>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "C:\Luis Martinez backup\Personal\Developments\NET\GrupoSplittel\GrupoSplittel\GestionPersonal\Views\Sala\DetailsSalaReservacion.cshtml"
  
    GPSInformation.Models.Sala Sala = (GPSInformation.Models.Sala)ViewBag.Sala;


#line default
#line hidden
            BeginContext(136, 128, true);
            WriteLiteral("\r\n<div data-label=\"Detalle\" class=\"df-example demo-forms\" id=\"app_createPermiso\">\r\n    <h4>I. Solicitante</h4>\r\n    <hr />\r\n    ");
            EndContext();
            BeginContext(265, 85, false);
#line 10 "C:\Luis Martinez backup\Personal\Developments\NET\GrupoSplittel\GrupoSplittel\GestionPersonal\Views\Sala\DetailsSalaReservacion.cshtml"
Write(await Component.InvokeAsync("ValidPuestoEnOrganigrama", new { id = Model.IdPersona }));

#line default
#line hidden
            EndContext();
            BeginContext(350, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(437, 161, true);
            WriteLiteral("    <h4>II. Detalle de la reservación</h4>\r\n    <hr />\r\n    <dl class=\"dl-horizontal\">\r\n        <dt>\r\n            Sala\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(599, 11, false);
#line 19 "C:\Luis Martinez backup\Personal\Developments\NET\GrupoSplittel\GrupoSplittel\GestionPersonal\Views\Sala\DetailsSalaReservacion.cshtml"
       Write(Sala.Nombre);

#line default
#line hidden
            EndContext();
            BeginContext(610, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(654, 42, false);
#line 22 "C:\Luis Martinez backup\Personal\Developments\NET\GrupoSplittel\GrupoSplittel\GestionPersonal\Views\Sala\DetailsSalaReservacion.cshtml"
       Write(Html.DisplayNameFor(model => model.Motivo));

#line default
#line hidden
            EndContext();
            BeginContext(696, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(740, 38, false);
#line 25 "C:\Luis Martinez backup\Personal\Developments\NET\GrupoSplittel\GrupoSplittel\GestionPersonal\Views\Sala\DetailsSalaReservacion.cshtml"
       Write(Html.DisplayFor(model => model.Motivo));

#line default
#line hidden
            EndContext();
            BeginContext(778, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(822, 47, false);
#line 28 "C:\Luis Martinez backup\Personal\Developments\NET\GrupoSplittel\GrupoSplittel\GestionPersonal\Views\Sala\DetailsSalaReservacion.cshtml"
       Write(Html.DisplayNameFor(model => model.Comentarios));

#line default
#line hidden
            EndContext();
            BeginContext(869, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(913, 43, false);
#line 31 "C:\Luis Martinez backup\Personal\Developments\NET\GrupoSplittel\GrupoSplittel\GestionPersonal\Views\Sala\DetailsSalaReservacion.cshtml"
       Write(Html.DisplayFor(model => model.Comentarios));

#line default
#line hidden
            EndContext();
            BeginContext(956, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(1000, 47, false);
#line 34 "C:\Luis Martinez backup\Personal\Developments\NET\GrupoSplittel\GrupoSplittel\GestionPersonal\Views\Sala\DetailsSalaReservacion.cshtml"
       Write(Html.DisplayNameFor(model => model.FechaInicio));

#line default
#line hidden
            EndContext();
            BeginContext(1047, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(1091, 40, false);
#line 37 "C:\Luis Martinez backup\Personal\Developments\NET\GrupoSplittel\GrupoSplittel\GestionPersonal\Views\Sala\DetailsSalaReservacion.cshtml"
       Write(Model.FechaInicio.ToString("yyyy-MM-dd"));

#line default
#line hidden
            EndContext();
            BeginContext(1131, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(1175, 45, false);
#line 40 "C:\Luis Martinez backup\Personal\Developments\NET\GrupoSplittel\GrupoSplittel\GestionPersonal\Views\Sala\DetailsSalaReservacion.cshtml"
       Write(Html.DisplayNameFor(model => model.HoraIncio));

#line default
#line hidden
            EndContext();
            BeginContext(1220, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(1264, 41, false);
#line 43 "C:\Luis Martinez backup\Personal\Developments\NET\GrupoSplittel\GrupoSplittel\GestionPersonal\Views\Sala\DetailsSalaReservacion.cshtml"
       Write(Html.DisplayFor(model => model.HoraIncio));

#line default
#line hidden
            EndContext();
            BeginContext(1305, 43, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt>\r\n            ");
            EndContext();
            BeginContext(1349, 43, false);
#line 46 "C:\Luis Martinez backup\Personal\Developments\NET\GrupoSplittel\GrupoSplittel\GestionPersonal\Views\Sala\DetailsSalaReservacion.cshtml"
       Write(Html.DisplayNameFor(model => model.HolaFin));

#line default
#line hidden
            EndContext();
            BeginContext(1392, 43, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd>\r\n            ");
            EndContext();
            BeginContext(1436, 39, false);
#line 49 "C:\Luis Martinez backup\Personal\Developments\NET\GrupoSplittel\GrupoSplittel\GestionPersonal\Views\Sala\DetailsSalaReservacion.cshtml"
       Write(Html.DisplayFor(model => model.HolaFin));

#line default
#line hidden
            EndContext();
            BeginContext(1475, 28, true);
            WriteLiteral("\r\n        </dd>\r\n    </dl>\r\n");
            EndContext();
#line 52 "C:\Luis Martinez backup\Personal\Developments\NET\GrupoSplittel\GrupoSplittel\GestionPersonal\Views\Sala\DetailsSalaReservacion.cshtml"
     if ((int)ViewBag.IdPersona == Model.IdPersona)
    {

#line default
#line hidden
            BeginContext(1563, 130, true);
            WriteLiteral("        <div class=\"form-group row mg-b-0\">\r\n            <div class=\"col-sm-12 text-right\">\r\n                <button type=\"button\"");
            EndContext();
            BeginWriteAttribute("onclick", " onclick=\"", 1693, "\"", 1748, 3);
            WriteAttributeValue("", 1703, "App_calendar.Delete(", 1703, 20, true);
#line 56 "C:\Luis Martinez backup\Personal\Developments\NET\GrupoSplittel\GrupoSplittel\GestionPersonal\Views\Sala\DetailsSalaReservacion.cshtml"
WriteAttributeValue("", 1723, Model.IdSalaReservacion, 1723, 24, false);

#line default
#line hidden
            WriteAttributeValue("", 1747, ")", 1747, 1, true);
            EndWriteAttribute();
            BeginContext(1749, 86, true);
            WriteLiteral(" class=\"btn btn-sm btn-danger\">Eliminar</button>\r\n            </div>\r\n        </div>\r\n");
            EndContext();
#line 59 "C:\Luis Martinez backup\Personal\Developments\NET\GrupoSplittel\GrupoSplittel\GestionPersonal\Views\Sala\DetailsSalaReservacion.cshtml"
    }

#line default
#line hidden
            BeginContext(1842, 10, true);
            WriteLiteral("</div>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<GPSInformation.Models.SalaReservacion> Html { get; private set; }
    }
}
#pragma warning restore 1591
