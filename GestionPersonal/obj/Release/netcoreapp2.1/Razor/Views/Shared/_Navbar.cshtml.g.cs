#pragma checksum "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Shared\_Navbar.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d5e2283b29b728091d5c19f09a75359daee9efb3"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__Navbar), @"mvc.1.0.view", @"/Views/Shared/_Navbar.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Shared/_Navbar.cshtml", typeof(AspNetCore.Views_Shared__Navbar))]
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
#line 1 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\_ViewImports.cshtml"
using GestionPersonal;

#line default
#line hidden
#line 2 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\_ViewImports.cshtml"
using GestionPersonal.Models;

#line default
#line hidden
#line 1 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Shared\_Navbar.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d5e2283b29b728091d5c19f09a75359daee9efb3", @"/Views/Shared/_Navbar.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"44f628e23a2086c1f04f862587f80afdb82e0a32", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__Navbar : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("rounded-circle"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString(""), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(139, 477, true);
            WriteLiteral(@"
<header class=""navbar navbar-header navbar-header-fixed"">
    <a href="""" id=""sidebarMenuOpen"" class=""burger-menu""><svg xmlns=""http://www.w3.org/2000/svg"" width=""24"" height=""24"" viewBox=""0 0 24 24"" fill=""none"" stroke=""currentColor"" stroke-width=""2"" stroke-linecap=""round"" stroke-linejoin=""round"" class=""feather feather-arrow-left""><line x1=""19"" y1=""12"" x2=""5"" y2=""12""></line><polyline points=""12 19 5 12 12 5""></polyline></svg></a>
    <div class=""navbar-brand"">
        <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 616, "\"", 650, 1);
#line 8 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Shared\_Navbar.cshtml"
WriteAttributeValue("", 623, Url.Action("Index","Home"), 623, 27, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(651, 195, true);
            WriteLiteral(" class=\"df-logo\">Gestion<span>Personal</span></a>\r\n    </div><!-- navbar-brand -->\r\n    <div id=\"navbarMenu\" class=\"navbar-menu-wrapper\">\r\n        <div class=\"navbar-menu-header\">\r\n            <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 846, "\"", 880, 1);
#line 12 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Shared\_Navbar.cshtml"
WriteAttributeValue("", 853, Url.Action("Index","Home"), 853, 27, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(881, 218, true);
            WriteLiteral(" class=\"df-logo\">Gestion<span>Persona</span></a>\r\n        </div><!-- navbar-menu-header -->\r\n        <ul class=\"nav navbar-menu\">\r\n        </ul>\r\n    </div><!-- navbar-menu-wrapper -->\r\n    <div class=\"navbar-right\">\r\n");
            EndContext();
            BeginContext(1228, 209, true);
            WriteLiteral("        <div class=\"dropdown dropdown-profile \">\r\n            <a href=\"\" class=\"dropdown-link\" data-toggle=\"dropdown\" data-display=\"static\" aria-expanded=\"true\">\r\n                <div class=\"avatar avatar-sm\">");
            EndContext();
            BeginContext(1437, 122, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "8a8934a8c04d4e02a8aff083b0fe5e60", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 1447, "~/Perfil/", 1447, 9, true);
#line 23 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Shared\_Navbar.cshtml"
AddHtmlAttributeValue("", 1456, HttpContextAccessor.HttpContext.Session.GetString("user_imagenPerfil"), 1456, 71, false);

#line default
#line hidden
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1559, 163, true);
            WriteLiteral("</div>\r\n            </a><!-- dropdown-link -->\r\n            <div class=\"dropdown-menu dropdown-menu-right tx-13 \">\r\n                <h6 class=\"tx-semibold mg-b-5\">");
            EndContext();
            BeginContext(1723, 62, false);
#line 26 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Shared\_Navbar.cshtml"
                                          Write(HttpContextAccessor.HttpContext.Session.GetString("user_name"));

#line default
#line hidden
            EndContext();
            BeginContext(1785, 1, true);
            WriteLiteral(" ");
            EndContext();
            BeginContext(1787, 62, false);
#line 26 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Shared\_Navbar.cshtml"
                                                                                                          Write(HttpContextAccessor.HttpContext.Session.GetString("user_appP"));

#line default
#line hidden
            EndContext();
            BeginContext(1849, 60, true);
            WriteLiteral("</h6>\r\n                <p class=\"mg-b-25 tx-12 tx-color-03\">");
            EndContext();
            BeginContext(1910, 64, false);
#line 27 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Shared\_Navbar.cshtml"
                                                Write(HttpContextAccessor.HttpContext.Session.GetString("user_puesto"));

#line default
#line hidden
            EndContext();
            BeginContext(1974, 26, true);
            WriteLiteral("</p>\r\n\r\n                <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 2000, "\"", 2038, 1);
#line 29 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Shared\_Navbar.cshtml"
WriteAttributeValue("", 2007, Url.Action("Perfil","Usuario"), 2007, 31, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2039, 435, true);
            WriteLiteral(@" class=""dropdown-item""><svg xmlns=""http://www.w3.org/2000/svg"" width=""24"" height=""24"" viewBox=""0 0 24 24"" fill=""none"" stroke=""currentColor"" stroke-width=""2"" stroke-linecap=""round"" stroke-linejoin=""round"" class=""feather feather-edit-3""><polygon points=""14 2 18 6 7 17 3 17 3 13 14 2""></polygon><line x1=""3"" y1=""22"" x2=""21"" y2=""22""></line></svg> Editar perfil</a>
                <div class=""dropdown-divider""></div>
                <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 2474, "\"", 2510, 1);
#line 31 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Shared\_Navbar.cshtml"
WriteAttributeValue("", 2481, Url.Action("Logout","Login"), 2481, 29, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2511, 501, true);
            WriteLiteral(@" class=""dropdown-item""><svg xmlns=""http://www.w3.org/2000/svg"" width=""24"" height=""24"" viewBox=""0 0 24 24"" fill=""none"" stroke=""currentColor"" stroke-width=""2"" stroke-linecap=""round"" stroke-linejoin=""round"" class=""feather feather-log-out""><path d=""M9 21H5a2 2 0 0 1-2-2V5a2 2 0 0 1 2-2h4""></path><polyline points=""16 17 21 12 16 7""></polyline><line x1=""21"" y1=""12"" x2=""9"" y2=""12""></line></svg>Salir</a>
            </div><!-- dropdown-menu -->
        </div>
    </div><!-- navbar-right -->
</header>");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
