#pragma checksum "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\ColaboradorSplittel\EmpPersonalDetails.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "10cb3198ba81fea55c99116336723f3af947d605"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_ColaboradorSplittel_EmpPersonalDetails), @"mvc.1.0.view", @"/Views/ColaboradorSplittel/EmpPersonalDetails.cshtml")]
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
#nullable restore
#line 2 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\ColaboradorSplittel\EmpPersonalDetails.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"10cb3198ba81fea55c99116336723f3af947d605", @"/Views/ColaboradorSplittel/EmpPersonalDetails.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"44f628e23a2086c1f04f862587f80afdb82e0a32", @"/Views/_ViewImports.cshtml")]
    public class Views_ColaboradorSplittel_EmpPersonalDetails : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<GPSInformation.Models.Persona>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 5 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\ColaboradorSplittel\EmpPersonalDetails.cshtml"
  
    ViewData["Title"] = "Información personal";
    var Accesos = (Dictionary<string, GPSInformation.Controllers.AccesosUs>)ViewBag.Accesos;

#line default
#line hidden
#nullable disable
            WriteLiteral("<div>\r\n    <div class=\"d-sm-flex align-items-center justify-content-between mg-b-20 mg-lg-b-25 mg-xl-b-30\">\r\n        <div>\r\n            <h4 class=\"mg-b-0 tx-spacing--1\">");
#nullable restore
#line 12 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\ColaboradorSplittel\EmpPersonalDetails.cshtml"
                                        Write(ViewData["Title"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h4>\r\n        </div>\r\n        <div class=\"d-none d-md-block\">\r\n            <a href=\"#\" class=\"btn btn-sm pd-x-15 btn-white btn-uppercaser\" data-rute=\"");
#nullable restore
#line 15 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\ColaboradorSplittel\EmpPersonalDetails.cshtml"
                                                                                  Write(Url.Action("EmpPersonalDetails","ColaboradorSplittel", new  { id = Model.IdPersona }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\" onclick=\"GetViewAccess(this)\">\r\n                <i class=\"icon ion-md-refresh mg-r-5 tx-16 lh--9\"></i>\r\n            </a>\r\n");
#nullable restore
#line 18 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\ColaboradorSplittel\EmpPersonalDetails.cshtml"
             if (HttpContextAccessor.HttpContext.Session.GetInt32("user_id") == Model.IdPersona || Accesos["AEscrituraEmpleados"].TieneAcceso)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <a href=\"#\" class=\"btn btn-sm pd-x-15 btn-white btn-uppercaser\" data-rute=\"");
#nullable restore
#line 20 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\ColaboradorSplittel\EmpPersonalDetails.cshtml"
                                                                                      Write(Url.Action("EmpPersonaEdit","ColaboradorSplittel", new  { id = Model.IdPersona }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\" data-mode=\"form\" onclick=\"GetViewAccess(this)\">\r\n                <i class=\"icon ion-md-create mg-r-5 tx-16 lh--9\"></i></a>\r\n");
#nullable restore
#line 22 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\ColaboradorSplittel\EmpPersonalDetails.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </div>\r\n    </div>\r\n    <hr />\r\n    <dl class=\"row\">\r\n        <dt class=\"col-lg-2 col-form-label\">\r\n            ");
#nullable restore
#line 28 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\ColaboradorSplittel\EmpPersonalDetails.cshtml"
       Write(Html.DisplayNameFor(model => model.Nombre));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-lg-4 col-form-label bg-light mb-1\">\r\n            ");
#nullable restore
#line 31 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\ColaboradorSplittel\EmpPersonalDetails.cshtml"
       Write(Html.DisplayFor(model => model.Nombre));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-lg-2 col-form-label\">\r\n            ");
#nullable restore
#line 34 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\ColaboradorSplittel\EmpPersonalDetails.cshtml"
       Write(Html.DisplayNameFor(model => model.ApellidoPaterno));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-lg-4 col-form-label bg-light mb-1\">\r\n            ");
#nullable restore
#line 37 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\ColaboradorSplittel\EmpPersonalDetails.cshtml"
       Write(Html.DisplayFor(model => model.ApellidoPaterno));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-lg-2 col-form-label\">\r\n            ");
#nullable restore
#line 40 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\ColaboradorSplittel\EmpPersonalDetails.cshtml"
       Write(Html.DisplayNameFor(model => model.ApellidoMaterno));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-lg-4 col-form-label bg-light mb-1\">\r\n            ");
#nullable restore
#line 43 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\ColaboradorSplittel\EmpPersonalDetails.cshtml"
       Write(Html.DisplayFor(model => model.ApellidoMaterno));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-lg-2 col-form-label\">\r\n            ");
#nullable restore
#line 46 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\ColaboradorSplittel\EmpPersonalDetails.cshtml"
       Write(Html.DisplayNameFor(model => model.Nacimiento));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-lg-4 col-form-label bg-light mb-1\">\r\n            ");
#nullable restore
#line 49 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\ColaboradorSplittel\EmpPersonalDetails.cshtml"
       Write(Html.DisplayFor(model => model.Nacimiento));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-lg-2 col-form-label\">\r\n            ");
#nullable restore
#line 52 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\ColaboradorSplittel\EmpPersonalDetails.cshtml"
       Write(Html.DisplayNameFor(model => model.IdGenero));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-lg-4 col-form-label bg-light mb-1\">\r\n            ");
#nullable restore
#line 55 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\ColaboradorSplittel\EmpPersonalDetails.cshtml"
       Write(Html.DisplayFor(model => model.Cat_Generos.Label));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-lg-2 col-form-label\">\r\n            ");
#nullable restore
#line 58 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\ColaboradorSplittel\EmpPersonalDetails.cshtml"
       Write(Html.DisplayNameFor(model => model.IdEstadoCivil));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-lg-4 col-form-label bg-light mb-1\">\r\n            ");
#nullable restore
#line 61 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\ColaboradorSplittel\EmpPersonalDetails.cshtml"
       Write(Html.DisplayFor(model => model.Cat_EstadosCiviles.Label));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-lg-2 col-form-label\">\r\n            ");
#nullable restore
#line 64 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\ColaboradorSplittel\EmpPersonalDetails.cshtml"
       Write(Html.DisplayNameFor(model => model.RFC));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-lg-4 col-form-label bg-light mb-1\">\r\n            ");
#nullable restore
#line 67 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\ColaboradorSplittel\EmpPersonalDetails.cshtml"
       Write(Html.DisplayFor(model => model.RFC));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-lg-2 col-form-label\">\r\n            ");
#nullable restore
#line 70 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\ColaboradorSplittel\EmpPersonalDetails.cshtml"
       Write(Html.DisplayNameFor(model => model.CURP));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-lg-4 col-form-label bg-light mb-1\">\r\n            ");
#nullable restore
#line 73 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\ColaboradorSplittel\EmpPersonalDetails.cshtml"
       Write(Html.DisplayFor(model => model.CURP));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-lg-2 col-form-label\">\r\n            ");
#nullable restore
#line 76 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\ColaboradorSplittel\EmpPersonalDetails.cshtml"
       Write(Html.DisplayNameFor(model => model.NSS));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-lg-4 col-form-label bg-light mb-1\">\r\n            ");
#nullable restore
#line 79 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\ColaboradorSplittel\EmpPersonalDetails.cshtml"
       Write(Html.DisplayFor(model => model.NSS));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-lg-2 col-form-label\">\r\n            ");
#nullable restore
#line 82 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\ColaboradorSplittel\EmpPersonalDetails.cshtml"
       Write(Html.DisplayNameFor(model => model.Email));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-lg-4 col-form-label bg-light mb-1\">\r\n            ");
#nullable restore
#line 85 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\ColaboradorSplittel\EmpPersonalDetails.cshtml"
       Write(Html.DisplayFor(model => model.Email));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-lg-2 col-form-label\">\r\n            ");
#nullable restore
#line 88 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\ColaboradorSplittel\EmpPersonalDetails.cshtml"
       Write(Html.DisplayNameFor(model => model.TelefonoPersonal));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-lg-4 col-form-label bg-light mb-1\">\r\n            ");
#nullable restore
#line 91 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\ColaboradorSplittel\EmpPersonalDetails.cshtml"
       Write(Html.DisplayFor(model => model.TelefonoPersonal));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-lg-2 col-form-label\">\r\n            ");
#nullable restore
#line 94 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\ColaboradorSplittel\EmpPersonalDetails.cshtml"
       Write(Html.DisplayNameFor(model => model.TelefonoFijo));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-lg-4 col-form-label bg-light mb-1\">\r\n            ");
#nullable restore
#line 97 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\ColaboradorSplittel\EmpPersonalDetails.cshtml"
       Write(Html.DisplayFor(model => model.TelefonoFijo));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-lg-2 col-form-label\">\r\n            ");
#nullable restore
#line 100 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\ColaboradorSplittel\EmpPersonalDetails.cshtml"
       Write(Html.DisplayNameFor(model => model.CodigoPostal));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-lg-4 col-form-label bg-light mb-1\">\r\n            ");
#nullable restore
#line 103 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\ColaboradorSplittel\EmpPersonalDetails.cshtml"
       Write(Html.DisplayFor(model => model.CodigoPostal));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-lg-2 col-form-label\">\r\n            ");
#nullable restore
#line 106 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\ColaboradorSplittel\EmpPersonalDetails.cshtml"
       Write(Html.DisplayNameFor(model => model.Colonia));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-lg-4 col-form-label bg-light mb-1\">\r\n            ");
#nullable restore
#line 109 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\ColaboradorSplittel\EmpPersonalDetails.cshtml"
       Write(Html.DisplayFor(model => model.Colonia));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-lg-2 col-form-label\">\r\n            ");
#nullable restore
#line 112 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\ColaboradorSplittel\EmpPersonalDetails.cshtml"
       Write(Html.DisplayNameFor(model => model.Calle));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-lg-10 col-form-label  bg-light mb-1\">\r\n            ");
#nullable restore
#line 115 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\ColaboradorSplittel\EmpPersonalDetails.cshtml"
       Write(Html.DisplayFor(model => model.Calle));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-lg-2 col-form-label\">\r\n            ");
#nullable restore
#line 118 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\ColaboradorSplittel\EmpPersonalDetails.cshtml"
       Write(Html.DisplayNameFor(model => model.Creado));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-lg-4 col-sm-12 col-form-label bg-light mb-1\">\r\n            ");
#nullable restore
#line 121 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\ColaboradorSplittel\EmpPersonalDetails.cshtml"
       Write(Html.DisplayFor(model => model.Creado));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-lg-2 col-form-label\">\r\n            ");
#nullable restore
#line 124 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\ColaboradorSplittel\EmpPersonalDetails.cshtml"
       Write(Html.DisplayNameFor(model => model.Actualizado));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-lg-4 col-sm-12 col-form-label bg-light mb-1\">\r\n            ");
#nullable restore
#line 127 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\ColaboradorSplittel\EmpPersonalDetails.cshtml"
       Write(Html.DisplayFor(model => model.Actualizado));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n    </dl>\r\n\r\n</div>");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public IHttpContextAccessor HttpContextAccessor { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<GPSInformation.Models.Persona> Html { get; private set; }
    }
}
#pragma warning restore 1591
