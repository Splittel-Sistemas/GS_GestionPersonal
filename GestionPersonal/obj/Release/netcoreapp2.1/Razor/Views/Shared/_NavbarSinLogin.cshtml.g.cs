#pragma checksum "C:\Luis Martinez backup\Personal\Developments\NET\GrupoSplittel\GrupoSplittel\GestionPersonal\Views\Shared\_NavbarSinLogin.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "2de6e82000bb4381e27ab4729e8e193cc0c43505"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__NavbarSinLogin), @"mvc.1.0.view", @"/Views/Shared/_NavbarSinLogin.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/_NavbarSinLogin.cshtml", typeof(AspNetCore.Views_Shared__NavbarSinLogin))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2de6e82000bb4381e27ab4729e8e193cc0c43505", @"/Views/Shared/_NavbarSinLogin.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"44f628e23a2086c1f04f862587f80afdb82e0a32", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__NavbarSinLogin : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(0, 101, true);
            WriteLiteral("<header class=\"navbar navbar-header navbar-header-fixed\">\r\n    <div class=\"navbar-brand\">\r\n        <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 101, "\"", 135, 1);
#line 3 "C:\Luis Martinez backup\Personal\Developments\NET\GrupoSplittel\GrupoSplittel\GestionPersonal\Views\Shared\_NavbarSinLogin.cshtml"
WriteAttributeValue("", 108, Url.Action("Index","Home"), 108, 27, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(136, 195, true);
            WriteLiteral(" class=\"df-logo\">Gestion<span>Personal</span></a>\r\n    </div><!-- navbar-brand -->\r\n    <div id=\"navbarMenu\" class=\"navbar-menu-wrapper\">\r\n        <div class=\"navbar-menu-header\">\r\n            <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 331, "\"", 365, 1);
#line 7 "C:\Luis Martinez backup\Personal\Developments\NET\GrupoSplittel\GrupoSplittel\GestionPersonal\Views\Shared\_NavbarSinLogin.cshtml"
WriteAttributeValue("", 338, Url.Action("Index","Home"), 338, 27, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(366, 218, true);
            WriteLiteral(" class=\"df-logo\">Gestion<span>Persona</span></a>\r\n        </div><!-- navbar-menu-header -->\r\n        <ul class=\"nav navbar-menu\">\r\n        </ul>\r\n    </div><!-- navbar-menu-wrapper -->\r\n    <div class=\"navbar-right\">\r\n");
            EndContext();
            BeginContext(713, 42, true);
            WriteLiteral("    </div><!-- navbar-right -->\r\n</header>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
