#pragma checksum "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\ColaboradorSplittel\EmpContEmergenciaDetails.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "59f934073ee4d50ae4bb65d4cb39578dac1bdaa9"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_ColaboradorSplittel_EmpContEmergenciaDetails), @"mvc.1.0.view", @"/Views/ColaboradorSplittel/EmpContEmergenciaDetails.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"59f934073ee4d50ae4bb65d4cb39578dac1bdaa9", @"/Views/ColaboradorSplittel/EmpContEmergenciaDetails.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"44f628e23a2086c1f04f862587f80afdb82e0a32", @"/Views/_ViewImports.cshtml")]
    public class Views_ColaboradorSplittel_EmpContEmergenciaDetails : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<GPSInformation.Models.PersonaContacto>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"
<div>
    <div class=""d-sm-flex align-items-center justify-content-between mg-b-20 mg-lg-b-25 mg-xl-b-30"">
        <div>
            <h4 class=""mg-b-0 tx-spacing--1"">Información Contacto de emergencia</h4>
        </div>
        <div class=""d-none d-md-block"">
            <a href=""#"" class=""btn btn-sm pd-x-15 btn-white btn-uppercaser"" data-rute=""");
#nullable restore
#line 9 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\ColaboradorSplittel\EmpContEmergenciaDetails.cshtml"
                                                                                  Write(Url.Action("EmpContEmergenciaDetails","ColaboradorSplittel", new  { id = Model.IdPersonaContacto }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\" onclick=\"GetViewAccess(this)\">\r\n                <i data-feather=\"refresh\" class=\"wd-10 mg-r-5\"></i>Refrescar\r\n            </a>\r\n            <a href=\"#\" class=\"btn btn-sm pd-x-15 btn-white btn-uppercaser\" data-rute=\"");
#nullable restore
#line 12 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\ColaboradorSplittel\EmpContEmergenciaDetails.cshtml"
                                                                                  Write(Url.Action("EmpContEmergenciaEdit","ColaboradorSplittel", new  { id = Model.IdPersonaContacto }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\" data-mode=\"form\" onclick=\"GetViewAccess(this)\"><i data-feather=\"refresh\" class=\"wd-10 mg-r-5\"></i>Editar</a>\r\n        </div>\r\n    </div>\r\n    <hr />\r\n    <dl class=\"row\">\r\n        <dt class=\"col-lg-2 col-form-label\">\r\n            ");
#nullable restore
#line 18 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\ColaboradorSplittel\EmpContEmergenciaDetails.cshtml"
       Write(Html.DisplayNameFor(model => model.NombreCompleto));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-lg-4 col-form-label bg-light mb-1\">\r\n            ");
#nullable restore
#line 21 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\ColaboradorSplittel\EmpContEmergenciaDetails.cshtml"
       Write(Html.DisplayFor(model => model.NombreCompleto));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-lg-2 col-form-label\">\r\n            ");
#nullable restore
#line 24 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\ColaboradorSplittel\EmpContEmergenciaDetails.cshtml"
       Write(Html.DisplayNameFor(model => model.IdParentezco));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-lg-4 col-form-label bg-light mb-1\">\r\n            ");
#nullable restore
#line 27 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\ColaboradorSplittel\EmpContEmergenciaDetails.cshtml"
       Write(Html.DisplayFor(model => model.Cat_Parentezcos.Label));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-lg-2 col-form-label\">\r\n            ");
#nullable restore
#line 30 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\ColaboradorSplittel\EmpContEmergenciaDetails.cshtml"
       Write(Html.DisplayNameFor(model => model.Telefono));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-lg-4 col-form-label bg-light mb-1\">\r\n            ");
#nullable restore
#line 33 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\ColaboradorSplittel\EmpContEmergenciaDetails.cshtml"
       Write(Html.DisplayFor(model => model.Telefono));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-lg-2 col-form-label\">\r\n            ");
#nullable restore
#line 36 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\ColaboradorSplittel\EmpContEmergenciaDetails.cshtml"
       Write(Html.DisplayNameFor(model => model.CodigoPostal));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-lg-4 col-form-label bg-light mb-1\">\r\n            ");
#nullable restore
#line 39 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\ColaboradorSplittel\EmpContEmergenciaDetails.cshtml"
       Write(Html.DisplayFor(model => model.CodigoPostal));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-lg-2 col-form-label\">\r\n            ");
#nullable restore
#line 42 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\ColaboradorSplittel\EmpContEmergenciaDetails.cshtml"
       Write(Html.DisplayNameFor(model => model.Direccion));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-lg-4 col-form-label bg-light mb-1\">\r\n            ");
#nullable restore
#line 45 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\ColaboradorSplittel\EmpContEmergenciaDetails.cshtml"
       Write(Html.DisplayFor(model => model.Direccion));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-lg-2 col-form-label\">\r\n            ");
#nullable restore
#line 48 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\ColaboradorSplittel\EmpContEmergenciaDetails.cshtml"
       Write(Html.DisplayNameFor(model => model.Creado));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-lg-4 col-form-label bg-light mb-1\">\r\n            ");
#nullable restore
#line 51 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\ColaboradorSplittel\EmpContEmergenciaDetails.cshtml"
       Write(Html.DisplayFor(model => model.Creado));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-lg-2 col-form-label\">\r\n            ");
#nullable restore
#line 54 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\ColaboradorSplittel\EmpContEmergenciaDetails.cshtml"
       Write(Html.DisplayNameFor(model => model.Editado));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-lg-4 col-form-label bg-light mb-1\">\r\n            ");
#nullable restore
#line 57 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\ColaboradorSplittel\EmpContEmergenciaDetails.cshtml"
       Write(Html.DisplayFor(model => model.Editado));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n    </dl>\r\n</div>\r\n<div>\r\n    <a href=\"#\" class=\"btn btn-sm pd-x-15 btn-white btn-uppercaser\" data-rute=\"");
#nullable restore
#line 62 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\ColaboradorSplittel\EmpContEmergenciaDetails.cshtml"
                                                                          Write(Url.Action("EmpContEmergenciaList","ColaboradorSplittel", new  { id = Model.IdPersona }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\" onclick=\"GetViewAccess(this)\">Lista de contactos de emergencia</a>\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<GPSInformation.Models.PersonaContacto> Html { get; private set; }
    }
}
#pragma warning restore 1591
