#pragma checksum "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Shared\Components\ValidPuestoEnOrganigrama\ValidPuestoEnOrganigrama.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e8c9695870903257000ed5fd488f3b1ee3569417"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_ValidPuestoEnOrganigrama_ValidPuestoEnOrganigrama), @"mvc.1.0.view", @"/Views/Shared/Components/ValidPuestoEnOrganigrama/ValidPuestoEnOrganigrama.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e8c9695870903257000ed5fd488f3b1ee3569417", @"/Views/Shared/Components/ValidPuestoEnOrganigrama/ValidPuestoEnOrganigrama.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"44f628e23a2086c1f04f862587f80afdb82e0a32", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_ValidPuestoEnOrganigrama_ValidPuestoEnOrganigrama : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<GestionPersonal.Models.EmpleadoInfor2>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Shared\Components\ValidPuestoEnOrganigrama\ValidPuestoEnOrganigrama.cshtml"
  

    string Jefes = "";
    if(Model.personaBoos != null)
    {
        Model.personaBoos.ForEach(a => Jefes += string.Format("{0} {1} {2},",a.Nombre,a.ApellidoPaterno,a.ApellidoMaterno));
    }
    

#line default
#line hidden
#nullable disable
            WriteLiteral(@"

<div class=""card-body pd-25"">
    <div class=""media"">
        <div class=""wd-80 ht-80 bg-ui-04 rounded d-flex align-items-center justify-content-center"">
            <svg xmlns=""http://www.w3.org/2000/svg"" width=""24"" height=""24"" viewBox=""0 0 24 24"" fill=""none"" stroke=""currentColor"" stroke-width=""2"" stroke-linecap=""round"" stroke-linejoin=""round"" class=""feather feather-book-open tx-white-7 wd-40 ht-40""><path d=""M2 3h6a4 4 0 0 1 4 4v14a3 3 0 0 0-3-3H2z""></path><path d=""M22 3h-6a4 4 0 0 0-4 4v14a3 3 0 0 1 3-3h7z""></path></svg>
        </div>
        <div class=""media-body pd-l-25"">
            <h5 class=""mg-b-5""><span class=""d-block tx-13 tx-color-03"">");
#nullable restore
#line 19 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Shared\Components\ValidPuestoEnOrganigrama\ValidPuestoEnOrganigrama.cshtml"
                                                                  Write(Html.DisplayFor(model => Model.View_empleado.NumeroNomina));

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>");
#nullable restore
#line 19 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Shared\Components\ValidPuestoEnOrganigrama\ValidPuestoEnOrganigrama.cshtml"
                                                                                                                                    Write(Model.View_empleado.NombreCompleto);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h5>\r\n            <p class=\"mg-b-3\"><span class=\"tx-medium tx-color-02\"></span>");
#nullable restore
#line 20 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Shared\Components\ValidPuestoEnOrganigrama\ValidPuestoEnOrganigrama.cshtml"
                                                                    Write(Model.View_empleado.PuestoNombre);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n\r\n            Reporta a: ");
#nullable restore
#line 22 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Shared\Components\ValidPuestoEnOrganigrama\ValidPuestoEnOrganigrama.cshtml"
                  Write(Jefes);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            \r\n        </div>\r\n    </div><!-- media -->\r\n</div>\r\n");
#nullable restore
#line 27 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Shared\Components\ValidPuestoEnOrganigrama\ValidPuestoEnOrganigrama.cshtml"
 if (Model.IsActiveVersionOgg == false)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("<div class=\"alert alert-primary mg-b-0\" role=\"alert\">\r\n    No fue encontrada ninguna estructura organizacional activa, por favor contacta a Gestión de personal\r\n</div>\r\n");
#nullable restore
#line 32 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Shared\Components\ValidPuestoEnOrganigrama\ValidPuestoEnOrganigrama.cshtml"
}

#line default
#line hidden
#nullable disable
#nullable restore
#line 33 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Shared\Components\ValidPuestoEnOrganigrama\ValidPuestoEnOrganigrama.cshtml"
 if (Model.IsPuestoOrg == false)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("<div class=\"alert alert-warning mg-b-0\" role=\"alert\">\r\n    El puesto <strong>");
#nullable restore
#line 36 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Shared\Components\ValidPuestoEnOrganigrama\ValidPuestoEnOrganigrama.cshtml"
                 Write(Model.View_empleado.PuestoNombre);

#line default
#line hidden
#nullable disable
            WriteLiteral("</strong> no se encontró en la estructura organizacional actual, por favor contacta a Gestión de personal\r\n</div>\r\n");
#nullable restore
#line 38 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Shared\Components\ValidPuestoEnOrganigrama\ValidPuestoEnOrganigrama.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<GestionPersonal.Models.EmpleadoInfor2> Html { get; private set; }
    }
}
#pragma warning restore 1591