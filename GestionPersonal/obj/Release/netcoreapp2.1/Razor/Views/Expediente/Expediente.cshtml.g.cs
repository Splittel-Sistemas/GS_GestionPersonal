#pragma checksum "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Expediente\Expediente.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "89a25b6f83be2c39f6719b54d4f2e75dbbd51619"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Expediente_Expediente), @"mvc.1.0.view", @"/Views/Expediente/Expediente.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Expediente/Expediente.cshtml", typeof(AspNetCore.Views_Expediente_Expediente))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"89a25b6f83be2c39f6719b54d4f2e75dbbd51619", @"/Views/Expediente/Expediente.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"44f628e23a2086c1f04f862587f80afdb82e0a32", @"/Views/_ViewImports.cshtml")]
    public class Views_Expediente_Expediente : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<GPSInformation.Views.View_EmpleadoExpediente>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/template/assets/css/dashforge.filemgr.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "0", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "IdExpedienteArchivo", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-control"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "CreateAsync", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("enctype", new global::Microsoft.AspNetCore.Html.HtmlString("multipart/form-data"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.SelectTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(66, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Expediente\Expediente.cshtml"
  
    ViewData["Title"] = "Expediente";

#line default
#line hidden
            BeginContext(114, 74, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "e52641a9991d478585b5d7e1978b94c4", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
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
            BeginContext(188, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(191, 87, false);
#line 7 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Expediente\Expediente.cshtml"
Write(await Component.InvokeAsync("ValidPuestoEnOrganigrama", new { id = ViewBag.IdPersona }));

#line default
#line hidden
            EndContext();
            BeginContext(278, 112, true);
            WriteLiteral("\r\n<hr />\r\n<div class=\"d-flex align-items-center justify-content-between mg-b-30\">\r\n    <h4 class=\"tx-15 mg-b-0\">");
            EndContext();
            BeginContext(391, 17, false);
#line 10 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Expediente\Expediente.cshtml"
                        Write(ViewData["Title"]);

#line default
#line hidden
            EndContext();
            BeginContext(408, 351, true);
            WriteLiteral(@"</h4>
    <div class=""btn-group"" role=""group"" aria-label=""Basic example"">
        <h2 class=""tx-15 mg-b-0""></h2>
        <a href=""#modalActividadVacacionesPeriodos"" data-toggle=""modal"" class=""btn btn-sm btn-white d-flex align-items-center""><i class=""icon ion-md-time mg-r-5 tx-16 lh--9""></i>Agregar nuevo documento</a>
    </div>
</div>
<hr />
");
            EndContext();
#line 17 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Expediente\Expediente.cshtml"
 if(Model.ToList().Count == 0)
{

#line default
#line hidden
            BeginContext(794, 138, true);
            WriteLiteral("    <div class=\"alert alert-primary mg-b-0\" role=\"alert\">\r\n        No se encontró ningun documento dentro de este expediente\r\n    </div>\r\n");
            EndContext();
#line 22 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Expediente\Expediente.cshtml"
}

#line default
#line hidden
            BeginContext(935, 19, true);
            WriteLiteral("<div class=\"row\">\r\n");
            EndContext();
#line 24 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Expediente\Expediente.cshtml"
     foreach (var item in Model)
	{

#line default
#line hidden
            BeginContext(992, 1269, true);
            WriteLiteral(@"        <div class=""col-lg-2"">
            <div class=""card card-file"">
                <div class=""dropdown-file"">
                    <a href="""" class=""dropdown-link"" data-toggle=""dropdown"" aria-expanded=""false""><svg xmlns=""http://www.w3.org/2000/svg"" width=""24"" height=""24"" viewBox=""0 0 24 24"" fill=""none"" stroke=""currentColor"" stroke-width=""2"" stroke-linecap=""round"" stroke-linejoin=""round"" class=""feather feather-more-vertical""><circle cx=""12"" cy=""12"" r=""1""></circle><circle cx=""12"" cy=""5"" r=""1""></circle><circle cx=""12"" cy=""19"" r=""1""></circle></svg></a>
                    <div class=""dropdown-menu dropdown-menu-right"" x-placement=""bottom-end"" style=""position: absolute; will-change: transform; top: 0px; left: 0px; transform: translate3d(-142px, 18px, 0px);"">
                        <a href=""#modalShare"" data-toggle=""modal"" class=""dropdown-item share""><svg xmlns=""http://www.w3.org/2000/svg"" width=""24"" height=""24"" viewBox=""0 0 24 24"" fill=""none"" stroke=""currentColor"" stroke-width=""2"" stroke-linecap=""round""");
            WriteLiteral(" stroke-linejoin=\"round\" class=\"feather feather-share\"><path d=\"M4 12v8a2 2 0 0 0 2 2h12a2 2 0 0 0 2-2v-8\"></path><polyline points=\"16 6 12 2 8 6\"></polyline><line x1=\"12\" y1=\"2\" x2=\"12\" y2=\"15\"></line></svg>Subir</a>\r\n                        <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 2261, "\"", 2389, 1);
#line 32 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Expediente\Expediente.cshtml"
WriteAttributeValue("", 2268, Url.Action("Dowload","Expediente", new {IdPersona = ViewBag.IdPersona, IdExpedienteArchivo = item.IdExpedienteArchivo }), 2268, 121, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2390, 711, true);
            WriteLiteral(@" class=""dropdown-item download""><svg xmlns=""http://www.w3.org/2000/svg"" width=""24"" height=""24"" viewBox=""0 0 24 24"" fill=""none"" stroke=""currentColor"" stroke-width=""2"" stroke-linecap=""round"" stroke-linejoin=""round"" class=""feather feather-download""><path d=""M21 15v4a2 2 0 0 1-2 2H5a2 2 0 0 1-2-2v-4""></path><polyline points=""7 10 12 15 17 10""></polyline><line x1=""12"" y1=""15"" x2=""12"" y2=""3""></line></svg>Download</a>
                    </div>
                </div><!-- dropdown -->
                <div class=""card-file-thumb tx-danger"">
                    <i class=""far fa-file-pdf""></i>
                </div>
                <div class=""card-body"">
                    <h6><a href="""" class=""link-02"">");
            EndContext();
            BeginContext(3102, 11, false);
#line 39 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Expediente\Expediente.cshtml"
                                              Write(item.Nombre);

#line default
#line hidden
            EndContext();
            BeginContext(3113, 37, true);
            WriteLiteral("</a></h6>\r\n                    <span>");
            EndContext();
            BeginContext(3151, 9, false);
#line 40 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Expediente\Expediente.cshtml"
                     Write(item.Ruta);

#line default
#line hidden
            EndContext();
            BeginContext(3160, 123, true);
            WriteLiteral("</span>\r\n                </div>\r\n                <div class=\"card-footer\"><span class=\"d-none d-sm-inline\">Updated: </span>");
            EndContext();
            BeginContext(3284, 16, false);
#line 42 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Expediente\Expediente.cshtml"
                                                                                     Write(item.Actualizado);

#line default
#line hidden
            EndContext();
            BeginContext(3300, 44, true);
            WriteLiteral("</div>\r\n            </div>\r\n        </div>\r\n");
            EndContext();
#line 45 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Expediente\Expediente.cshtml"
	}

#line default
#line hidden
            BeginContext(3348, 718, true);
            WriteLiteral(@"    
</div>
<div class=""modal calendar-modal-create fade effect-scale"" id=""modalActividadVacacionesPeriodos"" role=""dialog"" data-backdrop=""false"" aria-hidden=""true"">
    <div class=""modal-dialog modal-dialog-centered"" role=""document"">
        <div class=""modal-content"">
            <div class=""modal-body pd-20 pd-sm-30"">
                <button type=""button"" class=""close pos-absolute t-20 r-20"" data-dismiss=""modal"" aria-label=""Close"">
                    <span aria-hidden=""true""><i data-feather=""x""></i></span>
                </button>
                <h5 class=""tx-18 tx-sm-20 mg-b-20 mg-sm-b-30"">Periodos de vacaciones</h5>

                <div id=""content_vacacionesAcitivit"">
                    ");
            EndContext();
            BeginContext(4066, 1198, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9ce69f8ed7544c1f9e825a70d06094d1", async() => {
                BeginContext(4128, 176, true);
                WriteLiteral("\r\n                        <div class=\"form-group\">\r\n                            <label>Tipo Documento</label>\r\n                            <input type=\"hidden\" name=\"IdPersona\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 4304, "\"", 4330, 1);
#line 61 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Expediente\Expediente.cshtml"
WriteAttributeValue("", 4312, ViewBag.IdPersona, 4312, 18, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(4331, 33, true);
                WriteLiteral(" />\r\n                            ");
                EndContext();
                BeginContext(4364, 208, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("select", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9dac07e495954e68b884c1ee3ac4e549", async() => {
                    BeginContext(4451, 34, true);
                    WriteLiteral("\r\n                                ");
                    EndContext();
                    BeginContext(4485, 48, false);
                    __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c2c62a16e7284f8987934bda49a1107d", async() => {
                        BeginContext(4503, 21, true);
                        WriteLiteral("Selecciona una opción");
                        EndContext();
                    }
                    );
                    __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                    __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                    __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_2.Value;
                    __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
                    await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                    if (!__tagHelperExecutionContext.Output.IsContentModified)
                    {
                        await __tagHelperExecutionContext.SetOutputContentAsync();
                    }
                    Write(__tagHelperExecutionContext.Output);
                    __tagHelperExecutionContext = __tagHelperScopeManager.End();
                    EndContext();
                    BeginContext(4533, 30, true);
                    WriteLiteral("\r\n                            ");
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.SelectTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.Name = (string)__tagHelperAttribute_3.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
#line 62 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Expediente\Expediente.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.Items = ViewBag.Documentos;

#line default
#line hidden
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-items", __Microsoft_AspNetCore_Mvc_TagHelpers_SelectTagHelper.Items, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(4572, 685, true);
                WriteLiteral(@"
                        </div>
                        <div class=""form-group"">
                            <label>Documento</label>
                            <input type=""file"" name=""Archivo"" class=""form-control"" value="""" />
                        </div>
                        <div class=""form-group row mg-b-0"">
                            <div class=""col-sm-12 text-right"">
                                <a data-dismiss=""modal"" class=""btn btn-sm btn-secondary"">Cancelar</a>
                                <button type=""submit"" class=""btn btn-sm btn-primary"">Agregar</button>
                            </div>
                        </div>
                    ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(5264, 158, true);
            WriteLiteral("\r\n                </div>\r\n            </div><!-- modal-body -->\r\n        </div><!-- modal-content -->\r\n    </div><!-- modal-dialog -->\r\n</div><!-- modal -->\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<GPSInformation.Views.View_EmpleadoExpediente>> Html { get; private set; }
    }
}
#pragma warning restore 1591
