#pragma checksum "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\ColaboradorSplittel\EmpPersonalDetails.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5250a0edac408e9f5e16a9ded5458d1c53dd32e2"
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5250a0edac408e9f5e16a9ded5458d1c53dd32e2", @"/Views/ColaboradorSplittel/EmpPersonalDetails.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"44f628e23a2086c1f04f862587f80afdb82e0a32", @"/Views/_ViewImports.cshtml")]
    public class Views_ColaboradorSplittel_EmpPersonalDetails : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<GPSInformation.Models.Persona>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"
<div >
    <div class=""d-sm-flex align-items-center justify-content-between mg-b-20 mg-lg-b-25 mg-xl-b-30"">
        <div>
            <h4 class=""mg-b-0 tx-spacing--1"">Información Personal</h4>
        </div>
        <div class=""d-none d-md-block"">
            <a href=""#"" class=""btn btn-sm pd-x-15 btn-white btn-uppercaser"" data-rute=""");
#nullable restore
#line 9 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\ColaboradorSplittel\EmpPersonalDetails.cshtml"
                                                                                  Write(Url.Action("EmpPersonalDetails","ColaboradorSplittel", new  { id = Model.IdPersona }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\" onclick=\"GetViewAccess(this)\">\r\n                <i data-feather=\"refresh\" class=\"wd-10 mg-r-5\"></i>Refrescar\r\n            </a>\r\n            <a href=\"#\" class=\"btn btn-sm pd-x-15 btn-white btn-uppercaser\" data-rute=\"");
#nullable restore
#line 12 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\ColaboradorSplittel\EmpPersonalDetails.cshtml"
                                                                                  Write(Url.Action("EmpPersonaEdit","ColaboradorSplittel", new  { id = Model.IdPersona }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\" data-mode=\"form\" onclick=\"GetViewAccess(this)\"><i data-feather=\"refresh\" class=\"wd-10 mg-r-5\"></i>Editar</a>\r\n        </div>\r\n    </div>\r\n    <hr />\r\n    <dl class=\"row\">\r\n        <dt class=\"col-lg-2 col-form-label\">\r\n            ");
#nullable restore
#line 18 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\ColaboradorSplittel\EmpPersonalDetails.cshtml"
       Write(Html.DisplayNameFor(model => model.Nombre));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-lg-4 col-form-label bg-light mb-1\">\r\n            ");
#nullable restore
#line 21 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\ColaboradorSplittel\EmpPersonalDetails.cshtml"
       Write(Html.DisplayFor(model => model.Nombre));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-lg-2 col-form-label\">\r\n            ");
#nullable restore
#line 24 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\ColaboradorSplittel\EmpPersonalDetails.cshtml"
       Write(Html.DisplayNameFor(model => model.ApellidoPaterno));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-lg-4 col-form-label bg-light mb-1\">\r\n            ");
#nullable restore
#line 27 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\ColaboradorSplittel\EmpPersonalDetails.cshtml"
       Write(Html.DisplayFor(model => model.ApellidoPaterno));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-lg-2 col-form-label\">\r\n            ");
#nullable restore
#line 30 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\ColaboradorSplittel\EmpPersonalDetails.cshtml"
       Write(Html.DisplayNameFor(model => model.ApellidoMaterno));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-lg-4 col-form-label bg-light mb-1\">\r\n            ");
#nullable restore
#line 33 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\ColaboradorSplittel\EmpPersonalDetails.cshtml"
       Write(Html.DisplayFor(model => model.ApellidoMaterno));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-lg-2 col-form-label\">\r\n            ");
#nullable restore
#line 36 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\ColaboradorSplittel\EmpPersonalDetails.cshtml"
       Write(Html.DisplayNameFor(model => model.Nacimiento));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-lg-4 col-form-label bg-light mb-1\">\r\n            ");
#nullable restore
#line 39 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\ColaboradorSplittel\EmpPersonalDetails.cshtml"
       Write(Html.DisplayFor(model => model.Nacimiento));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-lg-2 col-form-label\">\r\n            ");
#nullable restore
#line 42 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\ColaboradorSplittel\EmpPersonalDetails.cshtml"
       Write(Html.DisplayNameFor(model => model.IdGenero));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-lg-4 col-form-label bg-light mb-1\">\r\n            ");
#nullable restore
#line 45 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\ColaboradorSplittel\EmpPersonalDetails.cshtml"
       Write(Html.DisplayFor(model => model.Cat_Generos.Label));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-lg-2 col-form-label\">\r\n            ");
#nullable restore
#line 48 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\ColaboradorSplittel\EmpPersonalDetails.cshtml"
       Write(Html.DisplayNameFor(model => model.IdEstadoCivil));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-lg-4 col-form-label bg-light mb-1\">\r\n            ");
#nullable restore
#line 51 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\ColaboradorSplittel\EmpPersonalDetails.cshtml"
       Write(Html.DisplayFor(model => model.Cat_EstadosCiviles.Label));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-lg-2 col-form-label\">\r\n            ");
#nullable restore
#line 54 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\ColaboradorSplittel\EmpPersonalDetails.cshtml"
       Write(Html.DisplayNameFor(model => model.RFC));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-lg-4 col-form-label bg-light mb-1\">\r\n            ");
#nullable restore
#line 57 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\ColaboradorSplittel\EmpPersonalDetails.cshtml"
       Write(Html.DisplayFor(model => model.RFC));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-lg-2 col-form-label\">\r\n            ");
#nullable restore
#line 60 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\ColaboradorSplittel\EmpPersonalDetails.cshtml"
       Write(Html.DisplayNameFor(model => model.CURP));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-lg-4 col-form-label bg-light mb-1\">\r\n            ");
#nullable restore
#line 63 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\ColaboradorSplittel\EmpPersonalDetails.cshtml"
       Write(Html.DisplayFor(model => model.CURP));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-lg-2 col-form-label\">\r\n            ");
#nullable restore
#line 66 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\ColaboradorSplittel\EmpPersonalDetails.cshtml"
       Write(Html.DisplayNameFor(model => model.NSS));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-lg-4 col-form-label bg-light mb-1\">\r\n            ");
#nullable restore
#line 69 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\ColaboradorSplittel\EmpPersonalDetails.cshtml"
       Write(Html.DisplayFor(model => model.NSS));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-lg-2 col-form-label\">\r\n            ");
#nullable restore
#line 72 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\ColaboradorSplittel\EmpPersonalDetails.cshtml"
       Write(Html.DisplayNameFor(model => model.Email));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-lg-4 col-form-label bg-light mb-1\">\r\n            ");
#nullable restore
#line 75 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\ColaboradorSplittel\EmpPersonalDetails.cshtml"
       Write(Html.DisplayFor(model => model.Email));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-lg-2 col-form-label\">\r\n            ");
#nullable restore
#line 78 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\ColaboradorSplittel\EmpPersonalDetails.cshtml"
       Write(Html.DisplayNameFor(model => model.TelefonoPersonal));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-lg-4 col-form-label bg-light mb-1\">\r\n            ");
#nullable restore
#line 81 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\ColaboradorSplittel\EmpPersonalDetails.cshtml"
       Write(Html.DisplayFor(model => model.TelefonoPersonal));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-lg-2 col-form-label\">\r\n            ");
#nullable restore
#line 84 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\ColaboradorSplittel\EmpPersonalDetails.cshtml"
       Write(Html.DisplayNameFor(model => model.TelefonoFijo));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-lg-4 col-form-label bg-light mb-1\">\r\n            ");
#nullable restore
#line 87 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\ColaboradorSplittel\EmpPersonalDetails.cshtml"
       Write(Html.DisplayFor(model => model.TelefonoFijo));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-lg-2 col-form-label\">\r\n            ");
#nullable restore
#line 90 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\ColaboradorSplittel\EmpPersonalDetails.cshtml"
       Write(Html.DisplayNameFor(model => model.CodigoPostal));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-lg-4 col-form-label bg-light mb-1\">\r\n            ");
#nullable restore
#line 93 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\ColaboradorSplittel\EmpPersonalDetails.cshtml"
       Write(Html.DisplayFor(model => model.CodigoPostal));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-lg-2 col-form-label\">\r\n            ");
#nullable restore
#line 96 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\ColaboradorSplittel\EmpPersonalDetails.cshtml"
       Write(Html.DisplayNameFor(model => model.Colonia));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-lg-4 col-form-label bg-light mb-1\">\r\n            ");
#nullable restore
#line 99 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\ColaboradorSplittel\EmpPersonalDetails.cshtml"
       Write(Html.DisplayFor(model => model.Colonia));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-lg-2 col-form-label\">\r\n            ");
#nullable restore
#line 102 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\ColaboradorSplittel\EmpPersonalDetails.cshtml"
       Write(Html.DisplayNameFor(model => model.Calle));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-lg-10 col-form-label  bg-light mb-1\">\r\n            ");
#nullable restore
#line 105 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\ColaboradorSplittel\EmpPersonalDetails.cshtml"
       Write(Html.DisplayFor(model => model.Calle));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-lg-2 col-form-label\">\r\n            ");
#nullable restore
#line 108 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\ColaboradorSplittel\EmpPersonalDetails.cshtml"
       Write(Html.DisplayNameFor(model => model.Creado));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-lg-4 col-sm-12 col-form-label bg-light mb-1\">\r\n            ");
#nullable restore
#line 111 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\ColaboradorSplittel\EmpPersonalDetails.cshtml"
       Write(Html.DisplayFor(model => model.Creado));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-lg-2 col-form-label\">\r\n            ");
#nullable restore
#line 114 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\ColaboradorSplittel\EmpPersonalDetails.cshtml"
       Write(Html.DisplayNameFor(model => model.Actualizado));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-lg-4 col-sm-12 col-form-label bg-light mb-1\">\r\n            ");
#nullable restore
#line 117 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\ColaboradorSplittel\EmpPersonalDetails.cshtml"
       Write(Html.DisplayFor(model => model.Actualizado));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n    </dl>\r\n\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<GPSInformation.Models.Persona> Html { get; private set; }
    }
}
#pragma warning restore 1591
