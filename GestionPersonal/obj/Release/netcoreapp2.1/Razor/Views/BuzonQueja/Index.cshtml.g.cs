#pragma checksum "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\BuzonQueja\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7de6348a06004bb39ffc369804f4f68cbe0579ed"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_BuzonQueja_Index), @"mvc.1.0.view", @"/Views/BuzonQueja/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/BuzonQueja/Index.cshtml", typeof(AspNetCore.Views_BuzonQueja_Index))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7de6348a06004bb39ffc369804f4f68cbe0579ed", @"/Views/BuzonQueja/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"44f628e23a2086c1f04f862587f80afdb82e0a32", @"/Views/_ViewImports.cshtml")]
    public class Views_BuzonQueja_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<GPSInformation.Models.BuzonQueja>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(54, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\BuzonQueja\Index.cshtml"
  
    ViewData["Title"] = "Buzón de quejas o sugerencias";

#line default
#line hidden
            BeginContext(121, 106, true);
            WriteLiteral("\r\n\r\n<div class=\"d-flex align-items-center justify-content-between mg-b-30\">\r\n    <h4 class=\"tx-15 mg-b-0\">");
            EndContext();
            BeginContext(228, 17, false);
#line 9 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\BuzonQueja\Index.cshtml"
                        Write(ViewData["Title"]);

#line default
#line hidden
            EndContext();
            BeginContext(245, 116, true);
            WriteLiteral("</h4>\r\n    <div class=\"btn-group\" role=\"group\" aria-label=\"Basic example\">\r\n        <h2 class=\"tx-15 mg-b-0\"></h2>\r\n");
            EndContext();
            BeginContext(519, 128, true);
            WriteLiteral("    </div>\r\n</div>\r\n<hr />\r\n<table class=\"table display compact\">\r\n    <thead>\r\n        <tr>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(648, 48, false);
#line 20 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\BuzonQueja\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.IdBuzonQueja));

#line default
#line hidden
            EndContext();
            BeginContext(696, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(752, 46, false);
#line 23 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\BuzonQueja\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Comentario));

#line default
#line hidden
            EndContext();
            BeginContext(798, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(854, 44, false);
#line 26 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\BuzonQueja\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Creacion));

#line default
#line hidden
            EndContext();
            BeginContext(898, 86, true);
            WriteLiteral("\r\n            </th>\r\n            <th></th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
            EndContext();
#line 32 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\BuzonQueja\Index.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
            BeginContext(1033, 60, true);
            WriteLiteral("            <tr>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(1094, 47, false);
#line 36 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\BuzonQueja\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.IdBuzonQueja));

#line default
#line hidden
            EndContext();
            BeginContext(1141, 67, true);
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(1209, 45, false);
#line 39 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\BuzonQueja\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.Comentario));

#line default
#line hidden
            EndContext();
            BeginContext(1254, 67, true);
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(1322, 43, false);
#line 42 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\BuzonQueja\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.Creacion));

#line default
#line hidden
            EndContext();
            BeginContext(1365, 47, true);
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n");
            EndContext();
            BeginContext(1694, 42, true);
            WriteLiteral("                </td>\r\n            </tr>\r\n");
            EndContext();
#line 50 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\BuzonQueja\Index.cshtml"
        }

#line default
#line hidden
            BeginContext(1747, 22, true);
            WriteLiteral("    </tbody>\r\n</table>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<GPSInformation.Models.BuzonQueja>> Html { get; private set; }
    }
}
#pragma warning restore 1591