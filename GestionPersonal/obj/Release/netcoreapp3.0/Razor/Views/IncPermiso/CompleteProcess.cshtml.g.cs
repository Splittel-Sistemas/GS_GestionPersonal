#pragma checksum "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\IncPermiso\CompleteProcess.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ee84ad6c9ca413aa23477de87caecb4836def335"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_IncPermiso_CompleteProcess), @"mvc.1.0.view", @"/Views/IncPermiso/CompleteProcess.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ee84ad6c9ca413aa23477de87caecb4836def335", @"/Views/IncPermiso/CompleteProcess.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"44f628e23a2086c1f04f862587f80afdb82e0a32", @"/Views/_ViewImports.cshtml")]
    public class Views_IncPermiso_CompleteProcess : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<GPSInformation.Models.IncidenciaPermiso>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\IncPermiso\CompleteProcess.cshtml"
 if (ViewBag.status == "Creada")
{

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<div class=""content content-fixed content-auth-alt mt-5"">
    <div class=""container ht-100p tx-center mt-5"">
        <div class=""ht-100p d-flex flex-column align-items-center justify-content-center"">
            <h1 class=""tx-color-01 tx-24 tx-sm-32 tx-lg-36 mg-xl-b-5"">Gestión de personal</h1>
            <div class=""wd-70p wd-sm-250 wd-lg-300 mg-b-15""><img src=""https://img.icons8.com/color/96/000000/ok--v2.png"" class=""img-fluid""");
            BeginWriteAttribute("alt", " alt=\"", 515, "\"", 521, 0);
            EndWriteAttribute();
            WriteLiteral("></div>\n            <h1 class=\"tx-color-01 tx-24 tx-sm-32 tx-lg-36 mg-xl-b-5\">");
#nullable restore
#line 9 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\IncPermiso\CompleteProcess.cshtml"
                                                                 Write(Model.Folio);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\n            <h5 class=\"tx-16 tx-sm-18 tx-lg-20 tx-normal mg-b-20\">Se ha creado exitosamente tu solicitud de permiso </h5>\n            <p class=\"tx-color-03 mg-b-30\">Fecha de la solicitud: ");
#nullable restore
#line 11 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\IncPermiso\CompleteProcess.cshtml"
                                                             Write(Model.Creado.ToString("F"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\n            <div class=\"mg-b-40\">\n                <a");
            BeginWriteAttribute("href", " href=\"", 890, "\"", 908, 1);
#nullable restore
#line 13 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\IncPermiso\CompleteProcess.cshtml"
WriteAttributeValue("", 897, Model.Link, 897, 11, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-white bd-2 pd-x-30\">Mas detalles</a>\n                <a");
            BeginWriteAttribute("href", " href=\"", 980, "\"", 1001, 1);
#nullable restore
#line 14 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\IncPermiso\CompleteProcess.cshtml"
WriteAttributeValue("", 987, ViewBag.link2, 987, 14, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-white bd-2 pd-x-30\">");
#nullable restore
#line 14 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\IncPermiso\CompleteProcess.cshtml"
                                                                       Write(ViewBag.link2Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\n            </div>\n        </div>\n    </div><!-- container -->\n</div><!-- content --> ");
#nullable restore
#line 18 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\IncPermiso\CompleteProcess.cshtml"
                       }
else if (ViewBag.status == "Cancelada")
{

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<div class=""content content-fixed content-auth-alt mt-5"">
    <div class=""container ht-100p tx-center mt-5"">
        <div class=""ht-100p d-flex flex-column align-items-center justify-content-center"">
            <h1 class=""tx-color-01 tx-24 tx-sm-32 tx-lg-36 mg-xl-b-5"">Gestión de personal</h1>
            <div class=""wd-70p wd-sm-250 wd-lg-300 mg-b-15""><img src=""https://img.icons8.com/fluency/50/000000/info.png"" class=""img-fluid""");
            BeginWriteAttribute("alt", " alt=\"", 1624, "\"", 1630, 0);
            EndWriteAttribute();
            WriteLiteral("></div>\n            <h1 class=\"tx-color-01 tx-24 tx-sm-32 tx-lg-36 mg-xl-b-5\">");
#nullable restore
#line 26 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\IncPermiso\CompleteProcess.cshtml"
                                                                 Write(Model.Folio);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\n            <h5 class=\"tx-16 tx-sm-18 tx-lg-20 tx-normal mg-b-20\">Se ha cancelado exitosamente tu solicitud de permiso </h5>\n            <p class=\"tx-color-03 mg-b-30\">Fecha de la solicitud: ");
#nullable restore
#line 28 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\IncPermiso\CompleteProcess.cshtml"
                                                             Write(Model.Editado.ToString("F"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\n            <div class=\"mg-b-40\">\n                <a");
            BeginWriteAttribute("href", " href=\"", 2003, "\"", 2021, 1);
#nullable restore
#line 30 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\IncPermiso\CompleteProcess.cshtml"
WriteAttributeValue("", 2010, Model.Link, 2010, 11, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-white bd-2 pd-x-30\">Mas detalles</a>\n                <a");
            BeginWriteAttribute("href", " href=\"", 2093, "\"", 2114, 1);
#nullable restore
#line 31 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\IncPermiso\CompleteProcess.cshtml"
WriteAttributeValue("", 2100, ViewBag.link2, 2100, 14, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-white bd-2 pd-x-30\">");
#nullable restore
#line 31 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\IncPermiso\CompleteProcess.cshtml"
                                                                       Write(ViewBag.link2Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\n            </div>\n        </div>\n    </div><!-- container -->\n</div><!-- content -->");
#nullable restore
#line 35 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\IncPermiso\CompleteProcess.cshtml"
                      }

else if (ViewBag.status == "Autorizada")
{

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<div class=""content content-fixed content-auth-alt mt-5"">
    <div class=""container ht-100p tx-center mt-5"">
        <div class=""ht-100p d-flex flex-column align-items-center justify-content-center"">
            <h1 class=""tx-color-01 tx-24 tx-sm-32 tx-lg-36 mg-xl-b-5"">Gestión de personal</h1>
            <div class=""wd-70p wd-sm-250 wd-lg-300 mg-b-15""><img src=""https://img.icons8.com/color/96/000000/ok--v2.png"" class=""img-fluid""");
            BeginWriteAttribute("alt", " alt=\"", 2738, "\"", 2744, 0);
            EndWriteAttribute();
            WriteLiteral("></div>\n            <h1 class=\"tx-color-01 tx-24 tx-sm-32 tx-lg-36 mg-xl-b-5\">");
#nullable restore
#line 44 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\IncPermiso\CompleteProcess.cshtml"
                                                                 Write(Model.Folio);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\n            <h5 class=\"tx-16 tx-sm-18 tx-lg-20 tx-normal mg-b-20\">Gracias por procesar esta solicitud de permiso</h5>\n            <div class=\"mg-b-40\">\n                <a");
            BeginWriteAttribute("href", " href=\"", 3011, "\"", 3031, 1);
#nullable restore
#line 47 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\IncPermiso\CompleteProcess.cshtml"
WriteAttributeValue("", 3018, ViewBag.link, 3018, 13, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-white bd-2 pd-x-30\">Mas detalles de autorización</a>\n                <a");
            BeginWriteAttribute("href", " href=\"", 3119, "\"", 3140, 1);
#nullable restore
#line 48 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\IncPermiso\CompleteProcess.cshtml"
WriteAttributeValue("", 3126, ViewBag.link2, 3126, 14, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-white bd-2 pd-x-30\">");
#nullable restore
#line 48 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\IncPermiso\CompleteProcess.cshtml"
                                                                       Write(ViewBag.link2Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\n            </div>\n        </div>\n    </div><!-- container -->\n</div><!-- content -->");
#nullable restore
#line 52 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\IncPermiso\CompleteProcess.cshtml"
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<GPSInformation.Models.IncidenciaPermiso> Html { get; private set; }
    }
}
#pragma warning restore 1591
