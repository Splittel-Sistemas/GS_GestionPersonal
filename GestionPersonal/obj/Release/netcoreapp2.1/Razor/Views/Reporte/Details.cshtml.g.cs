#pragma checksum "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Reporte\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1c5e2cf240eb1397b455e4ed83633d82cf240f7e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Reporte_Details), @"mvc.1.0.view", @"/Views/Reporte/Details.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Reporte/Details.cshtml", typeof(AspNetCore.Views_Reporte_Details))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1c5e2cf240eb1397b455e4ed83633d82cf240f7e", @"/Views/Reporte/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"44f628e23a2086c1f04f862587f80afdb82e0a32", @"/Views/_ViewImports.cshtml")]
    public class Views_Reporte_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<GPSInformation.Models.Reporte>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-control parametroR"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("data-descripcion", new global::Microsoft.AspNetCore.Html.HtmlString("aa"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.SelectTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Reporte\Details.cshtml"
  
    ViewData["Title"] = "Detalle de reporte: " + Model.Descripcion;

#line default
#line hidden
            DefineSection("MenuTop", async() => {
                BeginContext(131, 304, true);
                WriteLiteral(@"
    <div class=""d-sm-flex align-items-center justify-content-between mg-b-20 mg-lg-b-25 mg-xl-b-30"">
        <div>
            <nav aria-label=""breadcrumb"">
                <ol class=""breadcrumb breadcrumb-style1 mg-b-10"">
                    <li class=""breadcrumb-item active"" aria-current=""page"">");
                EndContext();
                BeginContext(436, 17, false);
#line 10 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Reporte\Details.cshtml"
                                                                      Write(ViewData["Title"]);

#line default
#line hidden
                EndContext();
                BeginContext(453, 95, true);
                WriteLiteral("</li>\r\n                </ol>\r\n            </nav>\r\n            <h4 class=\"mg-b-0 tx-spacing--1\">");
                EndContext();
                BeginContext(549, 17, false);
#line 13 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Reporte\Details.cshtml"
                                        Write(ViewData["Title"]);

#line default
#line hidden
                EndContext();
                BeginContext(566, 64, true);
                WriteLiteral("</h4>\r\n        </div>\r\n        <div class=\"d-none d-md-block\">\r\n");
                EndContext();
#line 16 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Reporte\Details.cshtml"
             if ((bool)ViewBag.Acceso1056 || (bool)ViewBag.Acceso1057 && Model.Activo)
            {

#line default
#line hidden
                BeginContext(733, 177, true);
                WriteLiteral("                <a href=\"#moddal_ejecutar\" class=\"btn btn-sm pd-x-15 btn-white btn-uppercaser\" data-toggle=\"modal\"><i data-feather=\"play\" class=\"wd-10 mg-r-5\"></i>Ejecutar</a>\r\n");
                EndContext();
#line 19 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Reporte\Details.cshtml"
            }

#line default
#line hidden
                BeginContext(925, 12, true);
                WriteLiteral("            ");
                EndContext();
#line 20 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Reporte\Details.cshtml"
             if ((bool)ViewBag.Acceso1056)
            {

#line default
#line hidden
                BeginContext(984, 18, true);
                WriteLiteral("                <a");
                EndContext();
                BeginWriteAttribute("href", " href=\"", 1002, "\"", 1068, 1);
#line 22 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Reporte\Details.cshtml"
WriteAttributeValue("", 1009, Url.Action("Edit","Reporte", new { id = Model.IdReporte }), 1009, 59, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(1069, 113, true);
                WriteLiteral(" class=\"btn btn-sm pd-x-15 btn-white btn-uppercaser\"><i data-feather=\"edit\" class=\"wd-10 mg-r-5\"></i>Editar</a>\r\n");
                EndContext();
#line 23 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Reporte\Details.cshtml"
            }

#line default
#line hidden
                BeginContext(1197, 28, true);
                WriteLiteral("        </div>\r\n    </div>\r\n");
                EndContext();
            }
            );
            BeginContext(1228, 189, true);
            WriteLiteral("<div id=\"app_reporteAplication\">\r\n    <div data-label=\"Informacion del reporte\" class=\"df-example demo-forms\">\r\n        <dl class=\"row\">\r\n            <dt class=\"col-lg-2\">\r\n                ");
            EndContext();
            BeginContext(1418, 45, false);
#line 31 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Reporte\Details.cshtml"
           Write(Html.DisplayNameFor(model => model.IdReporte));

#line default
#line hidden
            EndContext();
            BeginContext(1463, 80, true);
            WriteLiteral("\r\n            </dt>\r\n            <dd class=\"col-md-10 border\">\r\n                ");
            EndContext();
            BeginContext(1544, 41, false);
#line 34 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Reporte\Details.cshtml"
           Write(Html.DisplayFor(model => model.IdReporte));

#line default
#line hidden
            EndContext();
            BeginContext(1585, 72, true);
            WriteLiteral("\r\n            </dd>\r\n            <dt class=\"col-lg-2\">\r\n                ");
            EndContext();
            BeginContext(1658, 47, false);
#line 37 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Reporte\Details.cshtml"
           Write(Html.DisplayNameFor(model => model.Descripcion));

#line default
#line hidden
            EndContext();
            BeginContext(1705, 80, true);
            WriteLiteral("\r\n            </dt>\r\n            <dd class=\"col-lg-10 border\">\r\n                ");
            EndContext();
            BeginContext(1786, 43, false);
#line 40 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Reporte\Details.cshtml"
           Write(Html.DisplayFor(model => model.Descripcion));

#line default
#line hidden
            EndContext();
            BeginContext(1829, 72, true);
            WriteLiteral("\r\n            </dd>\r\n            <dt class=\"col-lg-2\">\r\n                ");
            EndContext();
            BeginContext(1902, 42, false);
#line 43 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Reporte\Details.cshtml"
           Write(Html.DisplayNameFor(model => model.Activo));

#line default
#line hidden
            EndContext();
            BeginContext(1944, 79, true);
            WriteLiteral("\r\n            </dt>\r\n            <dd class=\"col-lg-4 border\">\r\n                ");
            EndContext();
            BeginContext(2024, 38, false);
#line 46 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Reporte\Details.cshtml"
           Write(Html.DisplayFor(model => model.Activo));

#line default
#line hidden
            EndContext();
            BeginContext(2062, 72, true);
            WriteLiteral("\r\n            </dd>\r\n            <dt class=\"col-lg-2\">\r\n                ");
            EndContext();
            BeginContext(2135, 43, false);
#line 49 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Reporte\Details.cshtml"
           Write(Html.DisplayNameFor(model => model.Editado));

#line default
#line hidden
            EndContext();
            BeginContext(2178, 79, true);
            WriteLiteral("\r\n            </dt>\r\n            <dd class=\"col-lg-4 border\">\r\n                ");
            EndContext();
            BeginContext(2258, 39, false);
#line 52 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Reporte\Details.cshtml"
           Write(Html.DisplayFor(model => model.Editado));

#line default
#line hidden
            EndContext();
            BeginContext(2297, 48, true);
            WriteLiteral("\r\n            </dd>\r\n        </dl>\r\n    </div>\r\n");
            EndContext();
#line 56 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Reporte\Details.cshtml"
     if ((bool)ViewBag.Acceso1056 || (bool)ViewBag.Acceso1057 && Model.Activo)
    {

#line default
#line hidden
            BeginContext(2432, 833, true);
            WriteLiteral(@"        <div data-label=""Reporte"" class=""df-example demo-forms mt-4 table-responsive table-responsive-md table-responsive-lg"" id=""result_reporte"">

        </div>
        <div class=""modal fade"" id=""moddal_ejecutar"" tabindex=""-1"" role=""dialog"" aria-labelledby=""exampleModalLabel"" aria-hidden=""true"">
            <div class=""modal-dialog"" role=""document"">
                <div class=""modal-content tx-14"">
                    <div class=""modal-header"">
                        <h6 class=""modal-title"" id=""exampleModalLabel"">Ejecutar reporte</h6>
                        <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
                            <span aria-hidden=""true"">&times;</span>
                        </button>
                    </div>
                    <div class=""modal-body"">
");
            EndContext();
#line 71 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Reporte\Details.cshtml"
                         if (Model.ParametrosD.Count > 0)
                        {
                            

#line default
#line hidden
#line 73 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Reporte\Details.cshtml"
                             foreach (var item in Model.ParametrosD)
                            {

#line default
#line hidden
            BeginContext(3452, 101, true);
            WriteLiteral("                                <div class=\"form-group\">\r\n                                    <label>");
            EndContext();
            BeginContext(3554, 16, false);
#line 76 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Reporte\Details.cshtml"
                                      Write(item.Descripcion);

#line default
#line hidden
            EndContext();
            BeginContext(3570, 10, true);
            WriteLiteral("</label>\r\n");
            EndContext();
#line 77 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Reporte\Details.cshtml"
                                     if (item.Tipo == "DateTime")
                                    {

#line default
#line hidden
            BeginContext(3686, 94, true);
            WriteLiteral("                                        <input type=\"datetime\" class=\"form-control parametroR\"");
            EndContext();
            BeginWriteAttribute("placeholder", " placeholder=\"", 3780, "\"", 3811, 1);
#line 79 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Reporte\Details.cshtml"
WriteAttributeValue("", 3794, item.Descripcion, 3794, 17, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginWriteAttribute("name", " name=\"", 3812, "\"", 3837, 2);
            WriteAttributeValue("", 3819, "inp_", 3819, 4, true);
#line 79 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Reporte\Details.cshtml"
WriteAttributeValue("", 3823, item.Variable, 3823, 14, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(3838, 16, true);
            WriteLiteral(" data-variable=\"");
            EndContext();
            BeginContext(3855, 13, false);
#line 79 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Reporte\Details.cshtml"
                                                                                                                                                                   Write(item.Variable);

#line default
#line hidden
            EndContext();
            BeginContext(3868, 13, true);
            WriteLiteral("\" data-tipo=\"");
            EndContext();
            BeginContext(3882, 9, false);
#line 79 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Reporte\Details.cshtml"
                                                                                                                                                                                              Write(item.Tipo);

#line default
#line hidden
            EndContext();
            BeginContext(3891, 28, true);
            WriteLiteral("\" data-descripcion=\"aa\" />\r\n");
            EndContext();
#line 80 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Reporte\Details.cshtml"
                                    }
                                    else if (item.Tipo == "Date")
                                    {

#line default
#line hidden
            BeginContext(4064, 90, true);
            WriteLiteral("                                        <input type=\"date\" class=\"form-control parametroR\"");
            EndContext();
            BeginWriteAttribute("placeholder", " placeholder=\"", 4154, "\"", 4185, 1);
#line 83 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Reporte\Details.cshtml"
WriteAttributeValue("", 4168, item.Descripcion, 4168, 17, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginWriteAttribute("name", " name=\"", 4186, "\"", 4211, 2);
            WriteAttributeValue("", 4193, "inp_", 4193, 4, true);
#line 83 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Reporte\Details.cshtml"
WriteAttributeValue("", 4197, item.Variable, 4197, 14, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(4212, 16, true);
            WriteLiteral(" data-variable=\"");
            EndContext();
            BeginContext(4229, 13, false);
#line 83 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Reporte\Details.cshtml"
                                                                                                                                                               Write(item.Variable);

#line default
#line hidden
            EndContext();
            BeginContext(4242, 13, true);
            WriteLiteral("\" data-tipo=\"");
            EndContext();
            BeginContext(4256, 9, false);
#line 83 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Reporte\Details.cshtml"
                                                                                                                                                                                          Write(item.Tipo);

#line default
#line hidden
            EndContext();
            BeginContext(4265, 28, true);
            WriteLiteral("\" data-descripcion=\"aa\" />\r\n");
            EndContext();
#line 84 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Reporte\Details.cshtml"
                                    }

                                    else
                                    {
                                        

#line default
#line hidden
#line 88 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Reporte\Details.cshtml"
                                         if (item.Multiple == 1)
                                        {
                                            System.Collections.Generic.IEnumerable<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem> datos = (System.Collections.Generic.IEnumerable<Microsoft.AspNetCore.Mvc.Rendering.SelectListItem>)ViewData[item.Variable];

#line default
#line hidden
            BeginContext(4783, 44, true);
            WriteLiteral("                                            ");
            EndContext();
            BeginContext(4827, 322, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("select", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4d441ce11c8e438fa5580737cceb3098", async() => {
                BeginContext(4987, 50, true);
                WriteLiteral("\r\n                                                ");
                EndContext();
                BeginContext(5037, 57, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "66308ffcf1924dafb8388322c9b46730", async() => {
                    BeginContext(5054, 14, true);
                    WriteLiteral("Selecciona un ");
                    EndContext();
                    BeginContext(5069, 16, false);
#line 92 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Reporte\Details.cshtml"
                                                                          Write(item.Descripcion);

#line default
#line hidden
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(5094, 46, true);
                WriteLiteral("\r\n                                            ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.SelectTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper);
#line 91 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Reporte\Details.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.Items = datos;

#line default
#line hidden
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-items", __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.Items, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            BeginWriteTagHelperAttribute();
            WriteLiteral("inp_");
#line 91 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Reporte\Details.cshtml"
                                                                                                    WriteLiteral(item.Variable);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.Name = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("name", __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.Name, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            BeginWriteTagHelperAttribute();
#line 91 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Reporte\Details.cshtml"
                                                                                                                                          Write(item.Variable);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __tagHelperExecutionContext.AddHtmlAttribute("data-variable", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            BeginWriteTagHelperAttribute();
#line 91 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Reporte\Details.cshtml"
                                                                                                                                                                     Write(item.Tipo);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __tagHelperExecutionContext.AddHtmlAttribute("data-tipo", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(5149, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 94 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Reporte\Details.cshtml"
                                        }

                                        else
                                        {

#line default
#line hidden
            BeginContext(5285, 94, true);
            WriteLiteral("                                            <input type=\"text\" class=\"form-control parametroR\"");
            EndContext();
            BeginWriteAttribute("placeholder", " placeholder=\"", 5379, "\"", 5410, 1);
#line 98 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Reporte\Details.cshtml"
WriteAttributeValue("", 5393, item.Descripcion, 5393, 17, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginWriteAttribute("name", " name=\"", 5411, "\"", 5436, 2);
            WriteAttributeValue("", 5418, "inp_", 5418, 4, true);
#line 98 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Reporte\Details.cshtml"
WriteAttributeValue("", 5422, item.Variable, 5422, 14, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(5437, 16, true);
            WriteLiteral(" data-variable=\"");
            EndContext();
            BeginContext(5454, 13, false);
#line 98 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Reporte\Details.cshtml"
                                                                                                                                                                   Write(item.Variable);

#line default
#line hidden
            EndContext();
            BeginContext(5467, 13, true);
            WriteLiteral("\" data-tipo=\"");
            EndContext();
            BeginContext(5481, 9, false);
#line 98 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Reporte\Details.cshtml"
                                                                                                                                                                                              Write(item.Tipo);

#line default
#line hidden
            EndContext();
            BeginContext(5490, 28, true);
            WriteLiteral("\" data-descripcion=\"aa\" />\r\n");
            EndContext();
#line 99 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Reporte\Details.cshtml"
                                        }

#line default
#line hidden
#line 99 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Reporte\Details.cshtml"
                                         

                                    }

#line default
#line hidden
            BeginContext(5602, 40, true);
            WriteLiteral("                                </div>\r\n");
            EndContext();
#line 103 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Reporte\Details.cshtml"
                            }

#line default
#line hidden
#line 103 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Reporte\Details.cshtml"
                             
                        }
                        else
                        {

#line default
#line hidden
            BeginContext(5757, 285, true);
            WriteLiteral(@"                            <div class=""alert alert-primary mg-b-0"" role=""alert"">
                                estimado usuario este reporte no requiere parameros, por favor da clic en <strong>Ejecutar</strong> para poder visualizar el reporte
                            </div>
");
            EndContext();
#line 110 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Reporte\Details.cshtml"
                        }

#line default
#line hidden
            BeginContext(6069, 56, true);
            WriteLiteral("                        <h4>Columnas para mostrar</h4>\r\n");
            EndContext();
#line 112 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Reporte\Details.cshtml"
                          
                            int conteo = 0;         
                        

#line default
#line hidden
            BeginContext(6234, 24, true);
            WriteLiteral("                        ");
            EndContext();
#line 115 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Reporte\Details.cshtml"
                         foreach (var item in Model.ColumnasD)
                        {

#line default
#line hidden
            BeginContext(6325, 171, true);
            WriteLiteral("                            <div class=\"custom-control custom-checkbox col-12\">\r\n                                <input type=\"checkbox\" class=\"custom-control-input ColumR\"");
            EndContext();
            BeginWriteAttribute("id", " id=\"", 6496, "\"", 6516, 2);
            WriteAttributeValue("", 6501, "_ColumR_", 6501, 8, true);
#line 118 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Reporte\Details.cshtml"
WriteAttributeValue("", 6509, conteo, 6509, 7, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(6517, 15, true);
            WriteLiteral(" data-columna=\"");
            EndContext();
            BeginContext(6533, 4, false);
#line 118 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Reporte\Details.cshtml"
                                                                                                                         Write(item);

#line default
#line hidden
            EndContext();
            BeginContext(6537, 89, true);
            WriteLiteral("\" checked=\"checked\">\r\n                                <label class=\"custom-control-label\"");
            EndContext();
            BeginWriteAttribute("for", " for=\"", 6626, "\"", 6647, 2);
            WriteAttributeValue("", 6632, "_ColumR_", 6632, 8, true);
#line 119 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Reporte\Details.cshtml"
WriteAttributeValue("", 6640, conteo, 6640, 7, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(6648, 1, true);
            WriteLiteral(">");
            EndContext();
            BeginContext(6650, 4, false);
#line 119 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Reporte\Details.cshtml"
                                                                                     Write(item);

#line default
#line hidden
            EndContext();
            BeginContext(6654, 46, true);
            WriteLiteral("</label>\r\n                            </div>\r\n");
            EndContext();
#line 121 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Reporte\Details.cshtml"
                            conteo++;
                        }

#line default
#line hidden
            BeginContext(6766, 441, true);
            WriteLiteral(@"
                    </div>
                    <div class=""modal-footer"">
                        <button type=""button"" class=""btn btn-secondary tx-13"" data-dismiss=""modal"" id=""CerrarEjecutar"">Cerrar</button>
                        <button type=""button"" class=""btn btn-primary tx-13"" onclick=""app_reporteAplication.RunReport()"">Ejecutar</button>
                    </div>
                </div>
            </div>
        </div>
");
            EndContext();
            DefineSection("Scripts", async() => {
                BeginContext(7235, 213, true);
                WriteLiteral("\r\n            <script>\r\n        var app_reporteAplication = new Vue({\r\n            el: \"#app_reporteAplication\",\r\n                data: {\r\n                    ReqReporteRun: {\r\n                        IdReporte: \'");
                EndContext();
                BeginContext(7449, 15, false);
#line 139 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Reporte\Details.cshtml"
                               Write(Model.IdReporte);

#line default
#line hidden
                EndContext();
                BeginContext(7464, 1980, true);
                WriteLiteral(@"',
                        OmitCols: [""IdPersona"",""IdGenero""],
                        Parametros: []
                    }
                },
                mounted() {

                },
                methods: {
                    RunReport: async function () {
                        document.getElementById(""result_reporte"").innerHTML = '<div class=""alert alert-success border-0 text-center"" role=""alert""><div class=""spinner-border"" role=""status""><span class=""sr-only"">Loading...</span></div></div>'
                        var parametros = document.getElementsByClassName(""parametroR"");
                        var columnas = document.getElementsByClassName(""ColumR"");
                        this.ReqReporteRun.Parametros = []
                        if (parametros != null && parametros.length > 0) {
                            for (var i = 0; i < parametros.length; i++) {
                                this.ReqReporteRun.Parametros.push({
                                    ""Descripcion"":");
                WriteLiteral(@" parametros[i].dataset[""descripcion""],
                                    ""Variable"": parametros[i].dataset[""variable""],
                                    ""Tipo"": parametros[i].dataset[""tipo""],
                                    ""Valor"": parametros[i].value,
                                });
                            }
                        }
                        var columnas = document.getElementsByClassName(""ColumR"");
                        this.ReqReporteRun.OmitCols = []
                        if (columnas != null && columnas.length > 0) {
                            for (var i = 0; i < columnas.length; i++) {
                                if (columnas[i].checked == false) {
                                    this.ReqReporteRun.OmitCols.push(columnas[i].dataset[""columna""])
                                }

                            }
                        }
                        await axios.post('");
                EndContext();
                BeginContext(9445, 42, false);
#line 173 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Reporte\Details.cshtml"
                                     Write(Url.Action("EjecutarExistente", "Reporte"));

#line default
#line hidden
                EndContext();
                BeginContext(9487, 1130, true);
                WriteLiteral(@"', this.ReqReporteRun, null).then(response => {
                            document.getElementById(""result_reporte"").innerHTML = response.data
                            $('#reportdata_app').DataTable({
                                responsive: true,
                                language: {
                                    searchPlaceholder: 'Search...',
                                    sSearch: '',
                                    lengthMenu: '_MENU_ items/page',
                                },
                                ordering: true,
                                dom: 'Bfrtip',
                                buttons: [
                                    'excel', 'pdf'
                                ]
                            });
                            document.getElementById(""CerrarEjecutar"").click()
                        }).catch(error => {
                            GlobalValidAxios(error);
                        }).finally(() => {
            ");
                WriteLiteral("            })\r\n                    }\r\n                }\r\n            });\r\n            </script>\r\n        ");
                EndContext();
            }
            );
#line 197 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Reporte\Details.cshtml"
         
    }
    else
    {

#line default
#line hidden
            BeginContext(10644, 488, true);
            WriteLiteral(@"        <div class=""alert alert-warning alert-dismissible fade show"" role=""alert"">
            <strong>Estimado usuario!</strong> este reporte no puede ser ejecutado porque ha sido desactivado por los administradores del sitio
            <hr>
            <p class=""mb-0"">Sistema Gestión de Personal</p>
            <button type=""button"" class=""close"" data-dismiss=""alert"" aria-label=""Close"">
                <span aria-hidden=""true"">×</span>
            </button>
        </div>
");
            EndContext();
#line 209 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Reporte\Details.cshtml"
    }

#line default
#line hidden
            BeginContext(11139, 6, true);
            WriteLiteral("</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<GPSInformation.Models.Reporte> Html { get; private set; }
    }
}
#pragma warning restore 1591