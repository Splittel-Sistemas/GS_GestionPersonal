#pragma checksum "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Departamento\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f82f5b6154c83ee4a82a749451c60cdb7537c3b9"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Departamento_Details), @"mvc.1.0.view", @"/Views/Departamento/Details.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Departamento/Details.cshtml", typeof(AspNetCore.Views_Departamento_Details))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f82f5b6154c83ee4a82a749451c60cdb7537c3b9", @"/Views/Departamento/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"44f628e23a2086c1f04f862587f80afdb82e0a32", @"/Views/_ViewImports.cshtml")]
    public class Views_Departamento_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<GPSInformation.Responses.DepartamentoResp>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-sm pd-x-15 btn-white btn-uppercaser"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-sm btn-secondary"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Departamento\Details.cshtml"
  
    ViewData["Title"] = "Detalle de departamento: " + Model.Departamento.Nombre;

#line default
#line hidden
            DefineSection("MenuTop", async() => {
                BeginContext(156, 299, true);
                WriteLiteral(@"
    <div class=""d-sm-flex align-items-center justify-content-between mg-b-20 mg-lg-b-25 mg-xl-b-30"">
        <div>
            <nav aria-label=""breadcrumb"">
                <ol class=""breadcrumb breadcrumb-style1 mg-b-10"">
                    <li class=""breadcrumb-item"" aria-current=""page""><a");
                EndContext();
                BeginWriteAttribute("href", " href=\"", 455, "\"", 493, 1);
#line 10 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Departamento\Details.cshtml"
WriteAttributeValue("", 462, Url.Action("Index","Sociedad"), 462, 31, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(494, 110, true);
                WriteLiteral(">Lista de departamentos</a> </li>\r\n                    <li class=\"breadcrumb-item active\" aria-current=\"page\">");
                EndContext();
                BeginContext(605, 17, false);
#line 11 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Departamento\Details.cshtml"
                                                                      Write(ViewData["Title"]);

#line default
#line hidden
                EndContext();
                BeginContext(622, 95, true);
                WriteLiteral("</li>\r\n                </ol>\r\n            </nav>\r\n            <h4 class=\"mg-b-0 tx-spacing--1\">");
                EndContext();
                BeginContext(718, 17, false);
#line 14 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Departamento\Details.cshtml"
                                        Write(ViewData["Title"]);

#line default
#line hidden
                EndContext();
                BeginContext(735, 64, true);
                WriteLiteral("</h4>\r\n        </div>\r\n        <div class=\"d-none d-md-block\">\r\n");
                EndContext();
#line 17 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Departamento\Details.cshtml"
             if ((bool)ViewBag.Access15)
            {

#line default
#line hidden
                BeginContext(856, 18, true);
                WriteLiteral("                <a");
                EndContext();
                BeginWriteAttribute("href", " href=\"", 874, "\"", 948, 1);
#line 19 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Departamento\Details.cshtml"
WriteAttributeValue("", 881, Url.Action("Edit", new { id = Model.Departamento.IdDepartamento }), 881, 67, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(949, 129, true);
                WriteLiteral(" class=\"btn btn-sm pd-x-15 btn-white btn-uppercaser\"><i data-feather=\"edit\" class=\"wd-10 mg-r-5\"></i>Editar</a>\r\n                ");
                EndContext();
                BeginContext(1078, 138, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "61a26e23ccf94a79a2207586c4d49188", async() => {
                    BeginContext(1153, 59, true);
                    WriteLiteral("<i data-feather=\"plus\" class=\"wd-10 mg-r-5\"></i>Crear nuevo");
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(1216, 2, true);
                WriteLiteral("\r\n");
                EndContext();
#line 21 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Departamento\Details.cshtml"
            }

#line default
#line hidden
                BeginContext(1233, 30, true);
                WriteLiteral("\r\n        </div>\r\n    </div>\r\n");
                EndContext();
            }
            );
            BeginContext(1266, 127, true);
            WriteLiteral("<div data-label=\"Informacion\" class=\"df-example demo-forms\">\r\n    <dl class=\"row\">\r\n        <dt class=\"col-md-2\">\r\n            ");
            EndContext();
            BeginContext(1394, 63, false);
#line 29 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Departamento\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Departamento.IdDepartamento));

#line default
#line hidden
            EndContext();
            BeginContext(1457, 67, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-md-3 border\">\r\n            ");
            EndContext();
            BeginContext(1525, 59, false);
#line 32 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Departamento\Details.cshtml"
       Write(Html.DisplayFor(model => model.Departamento.IdDepartamento));

#line default
#line hidden
            EndContext();
            BeginContext(1584, 93, true);
            WriteLiteral("\r\n        </dd>\r\n    </dl>\r\n    <dl class=\"row\">\r\n        <dt class=\"col-md-2\">\r\n            ");
            EndContext();
            BeginContext(1678, 55, false);
#line 37 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Departamento\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Departamento.Nombre));

#line default
#line hidden
            EndContext();
            BeginContext(1733, 68, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-md-10 border\">\r\n            ");
            EndContext();
            BeginContext(1802, 51, false);
#line 40 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Departamento\Details.cshtml"
       Write(Html.DisplayFor(model => model.Departamento.Nombre));

#line default
#line hidden
            EndContext();
            BeginContext(1853, 60, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-md-2\">\r\n            ");
            EndContext();
            BeginContext(1914, 45, false);
#line 43 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Departamento\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Direccion));

#line default
#line hidden
            EndContext();
            BeginContext(1959, 68, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-md-10 border\">\r\n            ");
            EndContext();
            BeginContext(2028, 41, false);
#line 46 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Departamento\Details.cshtml"
       Write(Html.DisplayFor(model => model.Direccion));

#line default
#line hidden
            EndContext();
            BeginContext(2069, 60, true);
            WriteLiteral("\r\n        </dd>\r\n        <dt class=\"col-md-2\">\r\n            ");
            EndContext();
            BeginContext(2130, 57, false);
#line 49 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Departamento\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Departamento.ClaveDPU));

#line default
#line hidden
            EndContext();
            BeginContext(2187, 68, true);
            WriteLiteral("\r\n        </dt>\r\n        <dd class=\"col-md-10 border\">\r\n            ");
            EndContext();
            BeginContext(2256, 53, false);
#line 52 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Departamento\Details.cshtml"
       Write(Html.DisplayFor(model => model.Departamento.ClaveDPU));

#line default
#line hidden
            EndContext();
            BeginContext(2309, 76, true);
            WriteLiteral("\r\n        </dd>\r\n    </dl>\r\n    <div class=\"col-sm-12 text-right\">\r\n        ");
            EndContext();
            BeginContext(2385, 73, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b0c1377757ec44ad88e05ff938095064", async() => {
                BeginContext(2440, 14, true);
                WriteLiteral("Volver a lista");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2458, 22, true);
            WriteLiteral("\r\n    </div>\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<GPSInformation.Responses.DepartamentoResp> Html { get; private set; }
    }
}
#pragma warning restore 1591
