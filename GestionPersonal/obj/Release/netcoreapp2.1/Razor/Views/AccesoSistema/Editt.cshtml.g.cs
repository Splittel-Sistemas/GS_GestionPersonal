#pragma checksum "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\AccesoSistema\Editt.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "332303149809a9f83e3d1b793135320527c1b6ca"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_AccesoSistema_Editt), @"mvc.1.0.view", @"/Views/AccesoSistema/Editt.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/AccesoSistema/Editt.cshtml", typeof(AspNetCore.Views_AccesoSistema_Editt))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"332303149809a9f83e3d1b793135320527c1b6ca", @"/Views/AccesoSistema/Editt.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"44f628e23a2086c1f04f862587f80afdb82e0a32", @"/Views/_ViewImports.cshtml")]
    public class Views_AccesoSistema_Editt : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<GPSInformation.Models.Modulo>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString("/"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(50, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\AccesoSistema\Editt.cshtml"
  
    ViewData["Title"] = "Edit";
    int Iteration = 0;
    List<GPSInformation.Models.Modulo> Modulos = Model.ToList();

#line default
#line hidden
            BeginContext(183, 126, false);
#line 8 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\AccesoSistema\Editt.cshtml"
Write(await Component.InvokeAsync("ValidPuestoEnOrganigrama", new { id = (GPSInformation.Models.Usuario)ViewBag.Persona.IdPersona }));

#line default
#line hidden
            EndContext();
            BeginContext(309, 25, true);
            WriteLiteral("\r\n<div class=\"row\">\r\n    ");
            EndContext();
            BeginContext(334, 793, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9ba591d8ccd747ff91b6b650c4cf0b97", async() => {
                BeginContext(365, 2, true);
                WriteLiteral("\r\n");
                EndContext();
#line 11 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\AccesoSistema\Editt.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
                BeginContext(416, 29, true);
                WriteLiteral("            <div data-label=\"");
                EndContext();
                BeginContext(446, 25, false);
#line 13 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\AccesoSistema\Editt.cshtml"
                        Write(Modulos[Iteration].Nombre);

#line default
#line hidden
                EndContext();
                BeginContext(471, 32, true);
                WriteLiteral("\" class=\"df-example col-lg-3\">\r\n");
                EndContext();
#line 15 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\AccesoSistema\Editt.cshtml"
                 foreach (var sub in item.SubModulos)
                {

#line default
#line hidden
                BeginContext(658, 141, true);
                WriteLiteral("                    <div class=\"custom-control custom-checkbox\">\r\n                        <input type=\"checkbox\" class=\"custom-control-input\"");
                EndContext();
                BeginWriteAttribute("id", " id=\"", 799, "\"", 823, 2);
                WriteAttributeValue("", 804, "id_", 804, 3, true);
#line 18 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\AccesoSistema\Editt.cshtml"
WriteAttributeValue("", 807, sub.IdSubModulo, 807, 16, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(824, 62, true);
                WriteLiteral(">\r\n                        <label class=\"custom-control-label\"");
                EndContext();
                BeginWriteAttribute("for", " for=\"", 886, "\"", 911, 2);
                WriteAttributeValue("", 892, "id_", 892, 3, true);
#line 19 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\AccesoSistema\Editt.cshtml"
WriteAttributeValue("", 895, sub.IdSubModulo, 895, 16, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(912, 7, true);
                WriteLiteral("><span>");
                EndContext();
                BeginContext(920, 15, false);
#line 19 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\AccesoSistema\Editt.cshtml"
                                                                                       Write(sub.IdSubModulo);

#line default
#line hidden
                EndContext();
                BeginContext(935, 9, true);
                WriteLiteral("</span>  ");
                EndContext();
                BeginContext(945, 15, false);
#line 19 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\AccesoSistema\Editt.cshtml"
                                                                                                                Write(sub.Descripcion);

#line default
#line hidden
                EndContext();
                BeginContext(960, 6, true);
                WriteLiteral("<span>");
                EndContext();
                BeginContext(967, 28, false);
#line 19 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\AccesoSistema\Editt.cshtml"
                                                                                                                                      Write(sub.AccesosSistema.IdUsuario);

#line default
#line hidden
                EndContext();
                BeginContext(995, 45, true);
                WriteLiteral("</span></label>\r\n                    </div>\r\n");
                EndContext();
#line 21 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\AccesoSistema\Editt.cshtml"
                }

#line default
#line hidden
                BeginContext(1059, 20, true);
                WriteLiteral("            </div>\r\n");
                EndContext();
#line 23 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\AccesoSistema\Editt.cshtml"
            Iteration++;
        }

#line default
#line hidden
                BeginContext(1116, 4, true);
                WriteLiteral("    ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1127, 12, true);
            WriteLiteral("\r\n</div>\r\n\r\n");
            EndContext();
            DefineSection("Scripts", async() => {
                BeginContext(1157, 101, true);
                WriteLiteral("\r\n\r\n    <script>\r\n        $(document).ready(function () {\r\n            \r\n        });\r\n    </script>\r\n");
                EndContext();
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<GPSInformation.Models.Modulo>> Html { get; private set; }
    }
}
#pragma warning restore 1591
