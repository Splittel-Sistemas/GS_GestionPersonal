#pragma checksum "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Contrato\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7db9343ec2174a30d6276ebbbe640ff2b9ae6990"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Contrato_Index), @"mvc.1.0.view", @"/Views/Contrato/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Contrato/Index.cshtml", typeof(AspNetCore.Views_Contrato_Index))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7db9343ec2174a30d6276ebbbe640ff2b9ae6990", @"/Views/Contrato/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"44f628e23a2086c1f04f862587f80afdb82e0a32", @"/Views/_ViewImports.cshtml")]
    public class Views_Contrato_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<GPSInformation.Models.EmpleadoContrato>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(60, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Contrato\Index.cshtml"
  
    ViewData["Title"] = "Lista de contratos";

#line default
#line hidden
            BeginContext(116, 104, true);
            WriteLiteral("\r\n<div class=\"d-flex align-items-center justify-content-between mg-b-30\">\r\n    <h4 class=\"tx-15 mg-b-0\">");
            EndContext();
            BeginContext(221, 17, false);
#line 8 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Contrato\Index.cshtml"
                        Write(ViewData["Title"]);

#line default
#line hidden
            EndContext();
            BeginContext(238, 126, true);
            WriteLiteral("</h4>\r\n    <div class=\"btn-group\" role=\"group\" aria-label=\"Basic example\">\r\n        <h2 class=\"tx-15 mg-b-0\"></h2>\r\n        <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 364, "\"", 435, 1);
#line 11 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Contrato\Index.cshtml"
WriteAttributeValue("", 371, Url.Action("Create","Contrato", new { id = ViewBag.IdPersona }), 371, 64, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(436, 153, true);
            WriteLiteral("  class=\"btn btn-sm btn-white d-flex align-items-center\"><i class=\"icon ion-md-time mg-r-5 tx-16 lh--9\"></i>Crear nuevo</a>\r\n    </div>\r\n</div>\r\n<hr />\r\n");
            EndContext();
            BeginContext(590, 87, false);
#line 15 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Contrato\Index.cshtml"
Write(await Component.InvokeAsync("ValidPuestoEnOrganigrama", new { id = ViewBag.IdPersona }));

#line default
#line hidden
            EndContext();
            BeginContext(677, 105, true);
            WriteLiteral("\r\n<hr />\r\n<table class=\"table table-sm\">\r\n    <thead>\r\n        <tr>\r\n\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(783, 42, false);
#line 22 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Contrato\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Inicio));

#line default
#line hidden
            EndContext();
            BeginContext(825, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(881, 39, false);
#line 25 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Contrato\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Fin));

#line default
#line hidden
            EndContext();
            BeginContext(920, 57, true);
            WriteLiteral("\r\n            </th>\r\n\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(978, 40, false);
#line 29 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Contrato\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Tipo));

#line default
#line hidden
            EndContext();
            BeginContext(1018, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(1074, 43, false);
#line 32 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Contrato\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Created));

#line default
#line hidden
            EndContext();
            BeginContext(1117, 86, true);
            WriteLiteral("\r\n            </th>\r\n            <th></th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
            EndContext();
#line 38 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Contrato\Index.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
            BeginContext(1252, 40, true);
            WriteLiteral("            <tr>\r\n                <td>\r\n");
            EndContext();
#line 42 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Contrato\Index.cshtml"
                     if (item.Tipo == 1)
                    {
                        

#line default
#line hidden
            BeginContext(1382, 41, false);
#line 44 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Contrato\Index.cshtml"
                   Write(Html.DisplayFor(modelItem => item.Inicio));

#line default
#line hidden
            EndContext();
#line 44 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Contrato\Index.cshtml"
                                                                  
                    }
                    else
                    {

#line default
#line hidden
            BeginContext(1497, 41, true);
            WriteLiteral("                        <span>--</span>\r\n");
            EndContext();
#line 49 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Contrato\Index.cshtml"
                    }

#line default
#line hidden
            BeginContext(1561, 45, true);
            WriteLiteral("                </td>\r\n                <td>\r\n");
            EndContext();
#line 52 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Contrato\Index.cshtml"
                     if (item.Tipo == 1)
                    {
                        

#line default
#line hidden
            BeginContext(1696, 38, false);
#line 54 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Contrato\Index.cshtml"
                   Write(Html.DisplayFor(modelItem => item.Fin));

#line default
#line hidden
            EndContext();
#line 54 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Contrato\Index.cshtml"
                                                               
                    }
                    else
                    {

#line default
#line hidden
            BeginContext(1808, 41, true);
            WriteLiteral("                        <span>--</span>\r\n");
            EndContext();
#line 59 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Contrato\Index.cshtml"
                    }

#line default
#line hidden
            BeginContext(1872, 45, true);
            WriteLiteral("                </td>\r\n                <td>\r\n");
            EndContext();
#line 62 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Contrato\Index.cshtml"
                     if (item.Tipo == 1)
                    {

#line default
#line hidden
            BeginContext(1982, 50, true);
            WriteLiteral("                        <span>Determinado</span>\r\n");
            EndContext();
#line 65 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Contrato\Index.cshtml"
                    }
                    else
                    {

#line default
#line hidden
            BeginContext(2104, 52, true);
            WriteLiteral("                        <span>Indeterminado</span>\r\n");
            EndContext();
#line 69 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Contrato\Index.cshtml"
                    }

#line default
#line hidden
            BeginContext(2179, 65, true);
            WriteLiteral("                </td>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(2245, 42, false);
#line 72 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Contrato\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.Created));

#line default
#line hidden
            EndContext();
            BeginContext(2287, 47, true);
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n");
            EndContext();
#line 75 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Contrato\Index.cshtml"
                     if (item.Tipo == 1)
                    {
                        

#line default
#line hidden
            BeginContext(2424, 132, false);
#line 77 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Contrato\Index.cshtml"
                   Write(Html.ActionLink("Ver", "Determinado", new { id=item.IdEmpleadoContrato  }, new { title = "Ver PDF del contrato" , target= "_blank"}));

#line default
#line hidden
            EndContext();
#line 77 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Contrato\Index.cshtml"
                                                                                                                                                             
                    }
                    else
                    {
                        

#line default
#line hidden
            BeginContext(2655, 134, false);
#line 81 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Contrato\Index.cshtml"
                   Write(Html.ActionLink("Ver", "Indeterminado", new { id=item.IdEmpleadoContrato }, new { title = "Ver PDF del contrato", target = "_blank" }));

#line default
#line hidden
            EndContext();
#line 81 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Contrato\Index.cshtml"
                                                                                                                                                               
                    }

#line default
#line hidden
            BeginContext(2814, 44, true);
            WriteLiteral("\r\n                </td>\r\n            </tr>\r\n");
            EndContext();
#line 86 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Contrato\Index.cshtml"
        }

#line default
#line hidden
            BeginContext(2869, 24, true);
            WriteLiteral("    </tbody>\r\n</table>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<GPSInformation.Models.EmpleadoContrato>> Html { get; private set; }
    }
}
#pragma warning restore 1591