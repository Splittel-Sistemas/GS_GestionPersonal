#pragma checksum "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Organigrama\Vigente.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6300022c1165c7371320015ca705ea2176c06bf2"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Organigrama_Vigente), @"mvc.1.0.view", @"/Views/Organigrama/Vigente.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Organigrama/Vigente.cshtml", typeof(AspNetCore.Views_Organigrama_Vigente))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6300022c1165c7371320015ca705ea2176c06bf2", @"/Views/Organigrama/Vigente.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"44f628e23a2086c1f04f862587f80afdb82e0a32", @"/Views/_ViewImports.cshtml")]
    public class Views_Organigrama_Vigente : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<GPSInformation.Models.OrganigramaVersion>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/OrgChartCustom.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 2 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Organigrama\Vigente.cshtml"
  
    ViewData["Title"] = "Organigrama Vigente";

#line default
#line hidden
            BeginContext(104, 18, true);
            WriteLiteral("<h2>Vigente</h2>\r\n");
            EndContext();
#line 6 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Organigrama\Vigente.cshtml"
 if (Model != null)
{

#line default
#line hidden
            BeginContext(146, 75, true);
            WriteLiteral("    <div id=\"app_organigrama\">\r\n        <div id=\"tree\"></div>\r\n    </div>\r\n");
            EndContext();
            DefineSection("Scripts", async() => {
                BeginContext(243, 2, true);
                WriteLiteral("\r\n");
                EndContext();
                BeginContext(303, 8, true);
                WriteLiteral("        ");
                EndContext();
                BeginContext(311, 47, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "78e0ccaad53e463c86618a5008420b31", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(358, 938, true);
                WriteLiteral(@"
        <script>
        var app_organigrama = new Vue({
            el: ""#app_organigrama"",
            data: {
                Puestos: [],
                chart: null,
                selected: 0,
                hasmainPosition: true,
                Node: []
            },
            async mounted() {

                await this.GetEstructura();

                await this.StartChartOrg();
                $('.select2').select2({
                    placeholder: 'Choose one',
                    searchInputPlaceholder: 'Search options',
                    dropdownParent: $('#puestosselect')
                });

            },
            methods: {
                GetEstructura: async function () {
                    ShowMessageErrorShort(""Recopilando estructura de la versión"",""success"")
                    let params = new URLSearchParams();
                    params.append('IdVersion', '");
                EndContext();
                BeginContext(1297, 26, false);
#line 40 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Organigrama\Vigente.cshtml"
                                           Write(Model.IdOrganigramaVersion);

#line default
#line hidden
                EndContext();
                BeginContext(1323, 43, true);
                WriteLiteral("\');\r\n                    await axios.post(\'");
                EndContext();
                BeginContext(1367, 36, false);
#line 41 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Organigrama\Vigente.cshtml"
                                 Write(Url.Action("GetNodes","Organigrama"));

#line default
#line hidden
                EndContext();
                BeginContext(1403, 5288, true);
                WriteLiteral(@"', params, null).then(response => {
                        response.data.forEach((e,i) => {
                            var nivel = ""sub level "" + (e.nivel - 1);
                            if (e.idPuestoParent == 0) {
                                this.Node.push({ id: e.idPuesto, Puesto: e.descripcion, DPU: e.dpu, tags: [nivel] });
                            } else {
                                this.Node.push({ id: e.idPuesto, pid: e.idPuestoParent, Puesto: e.descripcion, DPU: e.dpu, tags: [nivel] });
                            }
                        })
                        //this.chart.draw(OrgChart.action.init);
                        console.log(this.Node);
                    }).catch(error => {
                        if (error.response) {
                            if (error.response.status === 400) {
                                console.log(error.response)
                                ShowMessageErrorShort(error.response.data,""error"")
                            ");
                WriteLiteral(@"}
                        }
                    }).finally()
                },
                StartChartOrg: async function () {
                    //this.chart.draw(OrgChart.action.init);
                    // alert(""""+expand_limit)
                    // OrgChart.templates.ula.field_0 =
                    //     '<text class=""field_0"" style=""font-size: 20px;"" fill=""#000000"" x=""125"" y=""30"" text-anchor=""middle"">{val}</text>';
                    // OrgChart.templates.ula.field_1 =
                    //     '<text class=""field_1"" style=""font-size: 14px;"" fill=""#000000"" x=""125"" y=""50"" text-anchor=""middle"">{val}</text>';
                    this.chart = new OrgChart(document.getElementById(""tree""), {
                        template: ""ula"",
                        scaleInitial: 0.8,
                        //mouseScroolBehaviour: BALKANGraph.action.zoom,
                        /*siblingSeparation: 200,
                        subtreeSeparation: 200,*/
                        // mixedHiera");
                WriteLiteral(@"rchyNodesSeparation: 500,
                        // nodeMouseClick: BALKANGraph.action.details,
                        toolbar: true,
                        // exportUrl: ""http://192.168.2.29/gestion_personal/models/export.php"",
                        // enableDragDrop: true,
                        collapse: {
                            level: 3,
                            allChildren: true
                        },
                        expand: {
                            nodes: [3]
                        },
                        nodeBinding: {
                            field_0: ""DPU"",
                            field_1: ""Puesto"",
                        },
                        menu: {
                            pdf: { text: ""Exportar PDF"" },
                            svg: { text: ""Exportar SVG"" },
                            png: { text: ""Exportar PNG"" }
                        },
                        //nodeMenu: {
                        //    //details: { t");
                WriteLiteral(@"ext: ""Detalles"" },
                        //    add: { text: ""Agregar nuevo"", onClick: this.ShowAdd },
                        //    //edit: { text: ""Editar"" },
                        //    remove: { text: ""Remover"", onClick: this.Remove },
                        //},
                        tags: {
                            ""sub level 0"": {
                                subLevels: 0,
                            },
                            ""sub level 1"": {
                                subLevels: 1
                            },
                            ""sub level 2"": {
                                subLevels: 2
                            },
                            ""sub level 3"": {
                                subLevels: 3
                            },
                            ""sub level 4"": {
                                subLevels: 4
                            },
                            ""sub level 5"": { subLevels: 5 },
                            ""su");
                WriteLiteral(@"b level 6"": { subLevels: 6 },
                            ""sub level 7"": { subLevels: 7 },
                            ""sub level 8"": { subLevels: 8 },
                            ""sub level 9"": { subLevels: 9 },
                            ""sub level 10"": { subLevels: 10 },
                            ""no menu"": {
                                template: ""noMenuTemplate""
                            }
                        },
                        nodes: this.Node

                    });

                    OrgChart.templates.ula.field_0 = '<text style=""font-size: 18px; font-weight: bold;"" fill=""#DA4453"" x=""60"" y=""55"">{val}</text>';
                    OrgChart.templates.ula.field_1 = '<text style=""font-size: 12px; font-weight: bold;"" fill=""#626567"" x=""10"" y=""76"">{val}</text>';

                    //this.Node.forEach((e, i) => {
                    //    //console.log(e)
                    //    this.chart.addNode(e);
                    //});

                    //this.chart.dr");
                WriteLiteral("aw(BALKANGraph.action.init);\r\n\r\n\r\n                    ORg_chart = this.chart;\r\n                },\r\n                \r\n            }\r\n        });\r\n        </script>\r\n    ");
                EndContext();
            }
            );
#line 148 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Organigrama\Vigente.cshtml"
     
}
else
{

#line default
#line hidden
            BeginContext(6706, 262, true);
            WriteLiteral(@"    <div class=""alert alert-warning "" role=""alert"">
        <h4 class=""alert-heading"">Advertencia!</h4>
        <p>Gestión de personal no ha definido un organigrama</p>
        <hr>
        <p class=""mb-0"">Esto puede ser un proceso tardado!</p>
    </div>
");
            EndContext();
#line 158 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Organigrama\Vigente.cshtml"
}

#line default
#line hidden
            BeginContext(6971, 6, true);
            WriteLiteral("\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<GPSInformation.Models.OrganigramaVersion> Html { get; private set; }
    }
}
#pragma warning restore 1591
