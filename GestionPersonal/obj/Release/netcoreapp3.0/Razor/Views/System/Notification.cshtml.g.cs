#pragma checksum "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\System\Notification.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c530292d8fddf1b11cde7766e58ac387946bc311"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_System_Notification), @"mvc.1.0.view", @"/Views/System/Notification.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c530292d8fddf1b11cde7766e58ac387946bc311", @"/Views/System/Notification.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"44f628e23a2086c1f04f862587f80afdb82e0a32", @"/Views/_ViewImports.cshtml")]
    public class Views_System_Notification : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<GPSInformation.Views.View_notificacionEmp>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\System\Notification.cshtml"
 if (ViewBag.ViewMode == "NavBar")
{
    if (Model.Count() != 0)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <a");
            BeginWriteAttribute("href", " href=\"", 150, "\"", 157, 0);
            EndWriteAttribute();
            WriteLiteral(" class=\"dropdown-link new-indicator\" data-toggle=\"dropdown\">\r\n            <img src=\"https://img.icons8.com/fluency/48/000000/bell.png\" style=\"width: 24px;\" />\r\n            <span>");
#nullable restore
#line 9 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\System\Notification.cshtml"
             Write(Model.Count());

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n        </a>\r\n        <div class=\"dropdown-menu dropdown-menu-right\" style=\"height: 500px; overflow-y: scroll;\">\r\n            <div class=\"dropdown-header\">Notificaciones</div>\r\n");
#nullable restore
#line 13 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\System\Notification.cshtml"
             foreach (var item in Model)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <a");
            BeginWriteAttribute("href", " href=\"", 611, "\"", 751, 1);
#nullable restore
#line 15 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\System\Notification.cshtml"
WriteAttributeValue("", 618, Url.Action("CheckAsReaded", "System", new { IdPersona = item.IdPersona, IdNotificacion = item.IdNotificacion, URL_next = item.URL }), 618, 133, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" target=\"_blank\"");
            BeginWriteAttribute("class", " class=\"", 768, "\"", 833, 2);
            WriteAttributeValue("", 776, "dropdown-item", 776, 13, true);
#nullable restore
#line 15 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\System\Notification.cshtml"
WriteAttributeValue(" ", 789, Html.Raw(!item.Revisado ? "bg-light" : ""), 790, 43, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                    <div class=\"media\">\r\n                        <div class=\"avatar avatar-sm\"><img src=\"https://img.icons8.com/fluency/48/000000/link.png\" class=\"rounded-circle\"");
            BeginWriteAttribute("alt", " alt=\"", 1015, "\"", 1021, 0);
            EndWriteAttribute();
            WriteLiteral("></div>\r\n                        <div class=\"media-body mg-l-15\">\r\n                            <strong>");
#nullable restore
#line 19 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\System\Notification.cshtml"
                               Write(Html.Raw(item.Titulo));

#line default
#line hidden
#nullable disable
            WriteLiteral("</strong>\r\n                            <p>");
#nullable restore
#line 20 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\System\Notification.cshtml"
                          Write(Html.Raw(item.Descripcion));

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                            <span>");
#nullable restore
#line 21 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\System\Notification.cshtml"
                             Write(item.Creado.ToString("F"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                        </div><!-- media-body -->\r\n                    </div><!-- media -->\r\n                </a>\r\n");
#nullable restore
#line 25 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\System\Notification.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            <div class=\"dropdown-footer\">\r\n                <a href=\"#\" data-rute=\"");
#nullable restore
#line 28 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\System\Notification.cshtml"
                                  Write(Url.Action("Notification","System", new { Mode = "SinLeer",ViewMode=  "NavBar" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\" onclick=\"GetViewAccess(this, false)\">Refrescar</a> |\r\n                <a href=\"#\" data-rute=\"");
#nullable restore
#line 29 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\System\Notification.cshtml"
                                  Write(Url.Action("Notification","System", new { Mode = "",ViewMode=  "ModalList" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\" data-rendermode=\"modal\" onclick=\"GetViewAccess(this, false)\">Ver todas</a>\r\n\r\n            </div>\r\n        </div>\r\n");
#nullable restore
#line 33 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\System\Notification.cshtml"
    }
    else
    {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"        <a href=""#"" class=""dropdown-link new-indicator"" data-toggle=""dropdown"" id=""start_showNot"">
            <img src=""https://img.icons8.com/fluency/48/000000/bell.png"" style=""width: 24px;"" />
            <span>0</span>
        </a>
        <div class=""dropdown-menu dropdown-menu-right"">
            <div class=""dropdown-header"">Notificaciones</div>
            <div class=""container ht-100p tx-center"">
                <div class=""ht-100p d-flex flex-column align-items-center justify-content-center"">
                    <div class=""wd-70p wd-sm-250 wd-lg-300 mg-b-15""><img src=""https://img.icons8.com/fluency/96/000000/matt-paper.png"" class=""img-fluid""");
            BeginWriteAttribute("alt", " alt=\"", 2567, "\"", 2573, 0);
            EndWriteAttribute();
            WriteLiteral("></div>\r\n                    <h5 class=\"tx-color-02 \">Sin notificaciones!</h5>\r\n                </div>\r\n            </div><!-- container -->\r\n            <div class=\"dropdown-footer\">\r\n                <a href=\"#\" data-rute=\"");
#nullable restore
#line 49 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\System\Notification.cshtml"
                                  Write(Url.Action("Notification","System", new { Mode = "SinLeer",ViewMode=  "NavBar" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\" onclick=\"GetViewAccess(this, false)\">Refrescar</a> |\r\n                <a href=\"#\" data-rute=\"");
#nullable restore
#line 50 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\System\Notification.cshtml"
                                  Write(Url.Action("Notification","System", new { Mode = "",ViewMode=  "ModalList" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\" data-rendermode=\"modal\" onclick=\"GetViewAccess(this, false)\">Ver todas</a>\r\n            </div>\r\n        </div>\r\n");
#nullable restore
#line 53 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\System\Notification.cshtml"
    }
}
else
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <a");
            BeginWriteAttribute("href", " href=\"", 3192, "\"", 3199, 0);
            EndWriteAttribute();
            WriteLiteral(@" role=""button"" class=""close pos-absolute t-15 r-15"" data-dismiss=""modal"" aria-label=""Close"">
        <span aria-hidden=""true"">&times;</span>
    </a>
    <div class=""form-group row mg-b-0 col-form-label bg-light"">
        <div class=""col-sm-12 text-right"">
            <button type=""button"" class=""btn btn-sm btn-white"" data-rute=""");
#nullable restore
#line 62 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\System\Notification.cshtml"
                                                                     Write(Url.Action("Notification","System", new { Mode = "",ViewMode=  "ModalList" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\" data-rendermode=\"modal\" onclick=\"GetViewAccess(this)\">\r\n                Refrescar\r\n            </button>\r\n        </div>\r\n    </div>\r\n    <ul class=\"list-unstyled media-list tx-12 tx-sm-13 mg-b-0\">\r\n");
#nullable restore
#line 68 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\System\Notification.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <li");
            BeginWriteAttribute("class", " class=\"", 3879, "\"", 3968, 6);
            WriteAttributeValue("", 3887, "media", 3887, 5, true);
            WriteAttributeValue(" ", 3892, "bg-ui-01", 3893, 9, true);
            WriteAttributeValue(" ", 3901, "pd-y-10", 3902, 8, true);
            WriteAttributeValue(" ", 3909, "pd-x-15", 3910, 8, true);
            WriteAttributeValue(" ", 3917, "mg-t-1", 3918, 7, true);
#nullable restore
#line 70 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\System\Notification.cshtml"
WriteAttributeValue(" ", 3924, Html.Raw(!item.Revisado ? "bg-light" : ""), 3925, 43, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                <div class=\"avatar avatar-sm\"><img src=\"https://img.icons8.com/fluency/48/000000/link.png\" class=\"rounded-circle\"");
            BeginWriteAttribute("alt", " alt=\"", 4101, "\"", 4107, 0);
            EndWriteAttribute();
            WriteLiteral("></div>\r\n                <div class=\"media-body mg-l-15\">\r\n                    <strong>");
#nullable restore
#line 73 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\System\Notification.cshtml"
                       Write(Html.Raw(item.Titulo));

#line default
#line hidden
#nullable disable
            WriteLiteral("</strong>\r\n                    <p>");
#nullable restore
#line 74 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\System\Notification.cshtml"
                  Write(Html.Raw(item.Descripcion));

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                    <span>");
#nullable restore
#line 75 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\System\Notification.cshtml"
                     Write(item.Creado.ToString("F"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n                </div><!-- media-body -->\r\n                <a");
            BeginWriteAttribute("href", " href=\"", 4406, "\"", 4546, 1);
#nullable restore
#line 77 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\System\Notification.cshtml"
WriteAttributeValue("", 4413, Url.Action("CheckAsReaded", "System", new { IdPersona = item.IdPersona, IdNotificacion = item.IdNotificacion, URL_next = item.URL }), 4413, 133, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-white rounded-circle btn-icon mg-l-15\"><i data-feather=\"plus\"></i></a>\r\n            </li><!-- media -->\r\n");
#nullable restore
#line 79 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\System\Notification.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </ul>\r\n");
#nullable restore
#line 81 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\System\Notification.cshtml"

    if (Model.Count() == 0)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"        <div class=""container ht-100p tx-center"">
            <div class=""ht-100p d-flex flex-column align-items-center justify-content-center"">
                <div class=""wd-70p wd-sm-250 wd-lg-300 mg-b-15""><img src=""https://img.icons8.com/fluency/96/000000/matt-paper.png"" class=""img-fluid""");
            BeginWriteAttribute("alt", " alt=\"", 5023, "\"", 5029, 0);
            EndWriteAttribute();
            WriteLiteral("></div>\r\n                <h5 class=\"tx-color-02 \">Sin notificaciones!</h5>\r\n            </div>\r\n        </div><!-- container -->\r\n");
#nullable restore
#line 90 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\System\Notification.cshtml"
    }
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<GPSInformation.Views.View_notificacionEmp>> Html { get; private set; }
    }
}
#pragma warning restore 1591
