#pragma checksum "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\AccesoSistema\Edit.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e15fc17d81e46f31b383235f44a1c966412d0598"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_AccesoSistema_Edit), @"mvc.1.0.view", @"/Views/AccesoSistema/Edit.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/AccesoSistema/Edit.cshtml", typeof(AspNetCore.Views_AccesoSistema_Edit))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e15fc17d81e46f31b383235f44a1c966412d0598", @"/Views/AccesoSistema/Edit.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"44f628e23a2086c1f04f862587f80afdb82e0a32", @"/Views/_ViewImports.cshtml")]
    public class Views_AccesoSistema_Edit : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<GestionPersonal.Models.UsuarioPermisos>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("col-sm-12 row"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("v-if", new global::Microsoft.AspNetCore.Html.HtmlString("Access != null"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            BeginContext(47, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\AccesoSistema\Edit.cshtml"
  
    ViewData["Title"] = "Editar permisos";

#line default
#line hidden
            BeginContext(100, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(103, 85, false);
#line 7 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\AccesoSistema\Edit.cshtml"
Write(await Component.InvokeAsync("ValidPuestoEnOrganigrama", new { id = Model.IdPersona }));

#line default
#line hidden
            EndContext();
            BeginContext(188, 56, true);
            WriteLiteral("\r\n<div class=\"row col-lg-12\" id=\"app_accessystem\">\r\n    ");
            EndContext();
            BeginContext(244, 861, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "19a66fddd5ee41819ee7fd4260791391", async() => {
                BeginContext(294, 804, true);
                WriteLiteral(@"
        <div v-bind:data-label=""item.nombre"" class=""df-example col-lg-3"" v-for=""(item, index) in Access.modulos"">
            <div class=""custom-control custom-checkbox"" v-for=""(item2, index2) in item.subModulos"">
                <input type=""checkbox"" class=""custom-control-input"" v-model=""item2.accesosSistema.tieneAcceso"" v-bind:id=""'id_' + item2.idSubModulo"">
                <label class=""custom-control-label"" v-bind:for=""'id_' + item2.idSubModulo"">{{item2.idSubModulo}}.-{{ item2.descripcion }}</label>
            </div>
        </div>
        <div class=""col-sm-12 text-right"">
            <button type=""reset"" class=""btn btn-sm btn-secondary"">Cancelar</button>
            <button type=""button"" v-on:click=""Save()"" class=""btn btn-sm btn-primary"">Guardar</button>
        </div>
    ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
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
            BeginContext(1105, 12, true);
            WriteLiteral("\r\n</div>\r\n\r\n");
            EndContext();
            DefineSection("Scripts", async() => {
                BeginContext(1135, 420, true);
                WriteLiteral(@"

    <script>
        $(document).ready(function () {

        });
    </script>
    <script>
        var app_accessystem = new Vue({
            el: ""#app_accessystem"",
            data: {
                Access: null

            },
            mounted() {
                this.Details();
            },
            methods: {
                Details: function () {
                    axios.post('");
                EndContext();
                BeginContext(1556, 67, false);
#line 42 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\AccesoSistema\Edit.cshtml"
                           Write(Url.Action("Details","AccesoSistema", new { id = Model.IdPersona }));

#line default
#line hidden
                EndContext();
                BeginContext(1623, 724, true);
                WriteLiteral(@"', null, null).then(response => {
                        console.log(response.data)
                        this.Access = response.data;
                        ShowMessageErrorShort(""Permisos obtenidos"", ""success"")
                    }).catch(error => {
                        if (error.response) {
                            if (error.response.status === 400) {
                                
                            }
                        }
                        console.error(error)
                        ShowMessageErrorShort(""error al extraer información"", ""error"")
                    }).finally()
                },
                Save: function () {
                    axios.post('");
                EndContext();
                BeginContext(2348, 45, false);
#line 57 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\AccesoSistema\Edit.cshtml"
                           Write(Url.Action("EditPermissions","AccesoSistema"));

#line default
#line hidden
                EndContext();
                BeginContext(2393, 689, true);
                WriteLiteral(@"', this.Access, null).then(response => {
                        console.log(response.data)
                        //this.Access = response.data;
                        ShowMessageErrorShort(response.data, ""success"")
                    }).catch(error => {
                        if (error.response) {
                            if (error.response.status === 400) {
                                ShowMessageErrorShort(error.response.data, ""error"")
                            }
                        }
                        console.error(error)
                        
                    }).finally()
                },
            }
        });
    </script>
");
                EndContext();
            }
            );
            BeginContext(3085, 4, true);
            WriteLiteral("\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<GestionPersonal.Models.UsuarioPermisos> Html { get; private set; }
    }
}
#pragma warning restore 1591
