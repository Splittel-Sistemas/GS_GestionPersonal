#pragma checksum "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\ErrorPages\Error.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "08c717f5baf783281a4290c54209fb1cf7638e7c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_ErrorPages_Error), @"mvc.1.0.view", @"/Views/ErrorPages/Error.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"08c717f5baf783281a4290c54209fb1cf7638e7c", @"/Views/ErrorPages/Error.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"44f628e23a2086c1f04f862587f80afdb82e0a32", @"/Views/_ViewImports.cshtml")]
    public class Views_ErrorPages_Error : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\ErrorPages\Error.cshtml"
  
    ViewData["Title"] = "Sin acceso a esta sección";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<div class=""content content-fixed content-auth-alt"">
    <div class=""container ht-100p tx-center"">
        <div class=""ht-100p d-flex flex-column align-items-center justify-content-center"">
            <div class=""wd-70p wd-sm-250 wd-lg-300 mg-b-15""><img src=""https://image.freepik.com/free-vector/401-error-unauthorized-concept-illustration_114360-1922.jpg"" class=""img-fluid""");
            BeginWriteAttribute("alt", " alt=\"", 442, "\"", 448, 0);
            EndWriteAttribute();
            WriteLiteral("></div>\r\n            <h1 class=\"tx-color-01 tx-24 tx-sm-32 tx-lg-36 mg-xl-b-5\">Gestión de personal</h1>\r\n            <h5 class=\"tx-16 tx-sm-18 tx-lg-20 tx-normal mg-b-20\">Oopps. </h5>\r\n            <p class=\"tx-color-03 mg-b-30\">");
#nullable restore
#line 11 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\ErrorPages\Error.cshtml"
                                      Write(ViewBag.MessageError);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n        </div>\r\n    </div><!-- container -->\r\n</div><!-- content -->\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
