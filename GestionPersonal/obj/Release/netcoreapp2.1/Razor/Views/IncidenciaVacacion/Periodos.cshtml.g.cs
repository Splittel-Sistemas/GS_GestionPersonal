#pragma checksum "C:\Luis Martinez backup\Personal\Developments\NET\GrupoSplittel\GrupoSplittel\GestionPersonal\Views\IncidenciaVacacion\Periodos.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f3a908c4a55112131d73a62604244b8199d1fdf0"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_IncidenciaVacacion_Periodos), @"mvc.1.0.view", @"/Views/IncidenciaVacacion/Periodos.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/IncidenciaVacacion/Periodos.cshtml", typeof(AspNetCore.Views_IncidenciaVacacion_Periodos))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f3a908c4a55112131d73a62604244b8199d1fdf0", @"/Views/IncidenciaVacacion/Periodos.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"44f628e23a2086c1f04f862587f80afdb82e0a32", @"/Views/_ViewImports.cshtml")]
    public class Views_IncidenciaVacacion_Periodos : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<GPSInformation.Models.VacionesPeriodo>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "periodos", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            BeginContext(59, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Luis Martinez backup\Personal\Developments\NET\GrupoSplittel\GrupoSplittel\GestionPersonal\Views\IncidenciaVacacion\Periodos.cshtml"
  
    ViewData["Title"] = (string)ViewBag.Modo == "Formulario" ? "Busqueda de periodos" : "Ver periodos";

#line default
#line hidden
            BeginContext(173, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 7 "C:\Luis Martinez backup\Personal\Developments\NET\GrupoSplittel\GrupoSplittel\GestionPersonal\Views\IncidenciaVacacion\Periodos.cshtml"
 if ((string)ViewBag.Modo == "Formulario")
{

#line default
#line hidden
            BeginContext(222, 107, true);
            WriteLiteral("    <div id=\"app_periodosBus\" class=\"col-lg-4\">\r\n        <h2>Buscar periodos</h2>\r\n        <hr />\r\n        ");
            EndContext();
            BeginContext(329, 1377, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e879ec3be65d4560a3bccbc12c2b3dd6", async() => {
                BeginContext(357, 648, true);
                WriteLiteral(@"
            <div class=""input-group input-group-sm "">
                <input type=""text"" class=""form-control form-control-sm"" v-on:keyup=""Save()"" id=""id"" name=""id"" value="""" placeholder=""Buscar"" aria-label=""Recipient's username"" aria-describedby=""button-addon2"">
                <div class=""input-group-append"">
                    <button class=""btn btn-sm btn-outline-light"" v-on:click="""" title=""Actualizar dias gastados"" type=""submit"" id=""button-addon2"">Ver periodos</button>
                </div>
            </div>
            <div class=""list-group"" v-if=""empleados.length > 0"" v-for=""(item, index) in  empleados"">
                <a");
                EndContext();
                BeginWriteAttribute("v-bind:href", " v-bind:href=\"", 1005, "\"", 1091, 3);
                WriteAttributeValue("", 1019, "\'", 1019, 1, true);
#line 20 "C:\Luis Martinez backup\Personal\Developments\NET\GrupoSplittel\GrupoSplittel\GestionPersonal\Views\IncidenciaVacacion\Periodos.cshtml"
WriteAttributeValue("", 1020, Url.Action("Periodos","IncidenciaVacacion"), 1020, 44, false);

#line default
#line hidden
                WriteAttributeValue("", 1064, "\'+\'/?id=\'+item.numeroNomina", 1064, 27, true);
                EndWriteAttribute();
                BeginContext(1092, 607, true);
                WriteLiteral(@"
                   v-bind:title=""'Ver peridos de '+item.nombreCompleto""
                   target=""_blank""
                   class = ""list-group-item d-flex align-items-center"">
                    <div>
                        <h6 class=""tx-13 tx-inverse tx-semibold mg-b-0"">{{ item.nombreCompleto }} - {{item.numeroNomina}}</h6>
                        <span class=""d-block tx-11 text-muted"">{{ item.puestoNombre }}<span v-if=""item.idEstatus == 20"" class=""badge badge-danger"">{{item.estatusDescripcion}}</span></span>
                    </div>
                </a>
            </div>
        ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1706, 14, true);
            WriteLiteral("\r\n    </div>\r\n");
            EndContext();
            DefineSection("Scripts", async() => {
                BeginContext(1742, 557, true);
                WriteLiteral(@"

        <script>
            $(document).ready(function () {

            });
        </script>
        <script>
        var app_periodos = new Vue({
            el: ""#app_periodosBus"",
            data: {
                empleados: []
            },
            mounted() {
            },
            methods: {
                Save: function (id) {
                    const NoNomina = document.getElementById(""id"")
                    const params = new URLSearchParams([['patron', NoNomina.value]]);
                    axios.post('");
                EndContext();
                BeginContext(2300, 34, false);
#line 51 "C:\Luis Martinez backup\Personal\Developments\NET\GrupoSplittel\GrupoSplittel\GestionPersonal\Views\IncidenciaVacacion\Periodos.cshtml"
                           Write(Url.Action("Buscador", "Empleado"));

#line default
#line hidden
                EndContext();
                BeginContext(2334, 549, true);
                WriteLiteral(@"', params, null).then(response => {
                        this.empleados = response.data;
                        console.log(this.empleados)
                    }).catch(error => {
                        if (error.response) {
                            if (error.response.status === 400) {
                                ShowMessageErrorShort(error.response.data, ""error"")
                            }
                        }
                    }).finally()
                },
            }
        });
        </script>
    ");
                EndContext();
            }
            );
#line 65 "C:\Luis Martinez backup\Personal\Developments\NET\GrupoSplittel\GrupoSplittel\GestionPersonal\Views\IncidenciaVacacion\Periodos.cshtml"
     
}
else
{


#line default
#line hidden
            BeginContext(2900, 35, true);
            WriteLiteral("    <h2>Periodos</h2>\r\n    <hr />\r\n");
            EndContext();
            BeginContext(2940, 87, false);
#line 72 "C:\Luis Martinez backup\Personal\Developments\NET\GrupoSplittel\GrupoSplittel\GestionPersonal\Views\IncidenciaVacacion\Periodos.cshtml"
Write(await Component.InvokeAsync("ValidPuestoEnOrganigrama", new { id = ViewBag.IdPersona }));

#line default
#line hidden
            EndContext();
            BeginContext(3029, 174, true);
            WriteLiteral("    <hr />\r\n    <div id=\"app_periodos\">\r\n        <table class=\"table table-sm\">\r\n            <thead>\r\n                <tr>\r\n                    <th>\r\n                        ");
            EndContext();
            BeginContext(3204, 49, false);
#line 79 "C:\Luis Martinez backup\Personal\Developments\NET\GrupoSplittel\GrupoSplittel\GestionPersonal\Views\IncidenciaVacacion\Periodos.cshtml"
                   Write(Html.DisplayNameFor(model => model.NumeroPeriodo));

#line default
#line hidden
            EndContext();
            BeginContext(3253, 79, true);
            WriteLiteral("\r\n                    </th>\r\n                    <th>\r\n                        ");
            EndContext();
            BeginContext(3333, 50, false);
#line 82 "C:\Luis Martinez backup\Personal\Developments\NET\GrupoSplittel\GrupoSplittel\GestionPersonal\Views\IncidenciaVacacion\Periodos.cshtml"
                   Write(Html.DisplayNameFor(model => model.DiasAprobadors));

#line default
#line hidden
            EndContext();
            BeginContext(3383, 79, true);
            WriteLiteral("\r\n                    </th>\r\n                    <th>\r\n                        ");
            EndContext();
            BeginContext(3463, 46, false);
#line 85 "C:\Luis Martinez backup\Personal\Developments\NET\GrupoSplittel\GrupoSplittel\GestionPersonal\Views\IncidenciaVacacion\Periodos.cshtml"
                   Write(Html.DisplayNameFor(model => model.DiasUsados));

#line default
#line hidden
            EndContext();
            BeginContext(3509, 79, true);
            WriteLiteral("\r\n                    </th>\r\n                    <th>\r\n                        ");
            EndContext();
            BeginContext(3589, 44, false);
#line 88 "C:\Luis Martinez backup\Personal\Developments\NET\GrupoSplittel\GrupoSplittel\GestionPersonal\Views\IncidenciaVacacion\Periodos.cshtml"
                   Write(Html.DisplayNameFor(model => model.Completo));

#line default
#line hidden
            EndContext();
            BeginContext(3633, 79, true);
            WriteLiteral("\r\n                    </th>\r\n                    <th>\r\n                        ");
            EndContext();
            BeginContext(3713, 47, false);
#line 91 "C:\Luis Martinez backup\Personal\Developments\NET\GrupoSplittel\GrupoSplittel\GestionPersonal\Views\IncidenciaVacacion\Periodos.cshtml"
                   Write(Html.DisplayNameFor(model => model.Actualizado));

#line default
#line hidden
            EndContext();
            BeginContext(3760, 126, true);
            WriteLiteral("\r\n                    </th>\r\n                    <th></th>\r\n                </tr>\r\n            </thead>\r\n            <tbody>\r\n");
            EndContext();
#line 97 "C:\Luis Martinez backup\Personal\Developments\NET\GrupoSplittel\GrupoSplittel\GestionPersonal\Views\IncidenciaVacacion\Periodos.cshtml"
                 foreach (var item in Model)
                {

#line default
#line hidden
            BeginContext(3951, 84, true);
            WriteLiteral("                    <tr>\r\n                        <td>\r\n                            ");
            EndContext();
            BeginContext(4036, 48, false);
#line 101 "C:\Luis Martinez backup\Personal\Developments\NET\GrupoSplittel\GrupoSplittel\GestionPersonal\Views\IncidenciaVacacion\Periodos.cshtml"
                       Write(Html.DisplayFor(modelItem => item.NumeroPeriodo));

#line default
#line hidden
            EndContext();
            BeginContext(4084, 91, true);
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
            EndContext();
            BeginContext(4176, 49, false);
#line 104 "C:\Luis Martinez backup\Personal\Developments\NET\GrupoSplittel\GrupoSplittel\GestionPersonal\Views\IncidenciaVacacion\Periodos.cshtml"
                       Write(Html.DisplayFor(modelItem => item.DiasAprobadors));

#line default
#line hidden
            EndContext();
            BeginContext(4225, 222, true);
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            <div class=\"input-group input-group-sm\">\r\n                                <input type=\"number\" class=\"form-control form-control-sm\"");
            EndContext();
            BeginWriteAttribute("id", " id=\"", 4447, "\"", 4485, 2);
            WriteAttributeValue("", 4452, "inp_Usado_", 4452, 10, true);
#line 108 "C:\Luis Martinez backup\Personal\Developments\NET\GrupoSplittel\GrupoSplittel\GestionPersonal\Views\IncidenciaVacacion\Periodos.cshtml"
WriteAttributeValue("", 4462, item.IdVacionesPeriodo, 4462, 23, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginWriteAttribute("value", " value=\"", 4486, "\"", 4540, 1);
#line 108 "C:\Luis Martinez backup\Personal\Developments\NET\GrupoSplittel\GrupoSplittel\GestionPersonal\Views\IncidenciaVacacion\Periodos.cshtml"
WriteAttributeValue("", 4494, Html.DisplayFor(modelItem => item.DiasUsados), 4494, 46, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(4541, 251, true);
            WriteLiteral(" placeholder=\"No. de dias gastados\" aria-label=\"Recipient\'s username\" aria-describedby=\"button-addon2\">\r\n                                <div class=\"input-group-append\">\r\n                                    <button class=\"btn btn-sm btn-outline-light\"");
            EndContext();
            BeginWriteAttribute("v-on:click", " v-on:click=\"", 4792, "\"", 4836, 3);
            WriteAttributeValue("", 4805, "Save(\'", 4805, 6, true);
#line 110 "C:\Luis Martinez backup\Personal\Developments\NET\GrupoSplittel\GrupoSplittel\GestionPersonal\Views\IncidenciaVacacion\Periodos.cshtml"
WriteAttributeValue("", 4811, item.IdVacionesPeriodo, 4811, 23, false);

#line default
#line hidden
            WriteAttributeValue("", 4834, "\')", 4834, 2, true);
            EndWriteAttribute();
            BeginContext(4837, 194, true);
            WriteLiteral(" title=\"Actualizar dias gastados\" type=\"button\" id=\"button-addon2\">Cambiar</button>\r\n                                </div>\r\n                            </div>\r\n                            <span");
            EndContext();
            BeginWriteAttribute("id", " id=\"", 5031, "\"", 5070, 2);
            WriteAttributeValue("", 5036, "span_Usado_", 5036, 11, true);
#line 113 "C:\Luis Martinez backup\Personal\Developments\NET\GrupoSplittel\GrupoSplittel\GestionPersonal\Views\IncidenciaVacacion\Periodos.cshtml"
WriteAttributeValue("", 5047, item.IdVacionesPeriodo, 5047, 23, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(5071, 119, true);
            WriteLiteral(" class=\"text-danger\"></span>\r\n                        </td>\r\n                        <td>\r\n                            ");
            EndContext();
            BeginContext(5191, 43, false);
#line 116 "C:\Luis Martinez backup\Personal\Developments\NET\GrupoSplittel\GrupoSplittel\GestionPersonal\Views\IncidenciaVacacion\Periodos.cshtml"
                       Write(Html.DisplayFor(modelItem => item.Completo));

#line default
#line hidden
            EndContext();
            BeginContext(5234, 91, true);
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
            EndContext();
            BeginContext(5326, 46, false);
#line 119 "C:\Luis Martinez backup\Personal\Developments\NET\GrupoSplittel\GrupoSplittel\GestionPersonal\Views\IncidenciaVacacion\Periodos.cshtml"
                       Write(Html.DisplayFor(modelItem => item.Actualizado));

#line default
#line hidden
            EndContext();
            BeginContext(5372, 121, true);
            WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                        </td>\r\n                    </tr>\r\n");
            EndContext();
#line 124 "C:\Luis Martinez backup\Personal\Developments\NET\GrupoSplittel\GrupoSplittel\GestionPersonal\Views\IncidenciaVacacion\Periodos.cshtml"
                }

#line default
#line hidden
            BeginContext(5512, 52, true);
            WriteLiteral("            </tbody>\r\n        </table>\r\n    </div>\r\n");
            EndContext();
            DefineSection("Scripts", async() => {
                BeginContext(5586, 558, true);
                WriteLiteral(@"

        <script>
            $(document).ready(function () {

            });
        </script>
        <script>
        var app_periodos = new Vue({
            el: ""#app_periodos"",
            data: {
                Access: null
            },
            mounted() {
            },
            methods: {
                Save: function (id) {
                    const inp_dias = document.getElementById(""inp_Usado_"" + id)

                    const params = new URLSearchParams([['id', id], ['dias', inp_dias.value], ['idPersona', '");
                EndContext();
                BeginContext(6145, 17, false);
#line 147 "C:\Luis Martinez backup\Personal\Developments\NET\GrupoSplittel\GrupoSplittel\GestionPersonal\Views\IncidenciaVacacion\Periodos.cshtml"
                                                                                                        Write(ViewBag.IdPersona);

#line default
#line hidden
                EndContext();
                BeginContext(6162, 39, true);
                WriteLiteral("\']]);\r\n                    axios.post(\'");
                EndContext();
                BeginContext(6202, 49, false);
#line 148 "C:\Luis Martinez backup\Personal\Developments\NET\GrupoSplittel\GrupoSplittel\GestionPersonal\Views\IncidenciaVacacion\Periodos.cshtml"
                           Write(Url.Action("UpdatePeriodo", "IncidenciaVacacion"));

#line default
#line hidden
                EndContext();
                BeginContext(6251, 729, true);
                WriteLiteral(@"', params, null).then(response => {
                        console.log(response.data)
                        //this.Access = response.data;
                        ShowMessageErrorShort(response.data, ""success"")
                    }).catch(error => {
                        if (error.response) {
                            if (error.response.status === 400) {
                                ShowMessageErrorShort(error.response.data, ""error"")
                                document.getElementById(""span_Usado_"" + id).innerHTML = error.response.data
                            }
                        }
                    }).finally()
                },
            }
        });
        </script>
    ");
                EndContext();
            }
            );
#line 164 "C:\Luis Martinez backup\Personal\Developments\NET\GrupoSplittel\GrupoSplittel\GestionPersonal\Views\IncidenciaVacacion\Periodos.cshtml"
     

}

#line default
#line hidden
            BeginContext(6988, 4, true);
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<GPSInformation.Models.VacionesPeriodo>> Html { get; private set; }
    }
}
#pragma warning restore 1591
