#pragma checksum "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Evaluacion\Responder.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f014d158f5813515f0a36e4032b246c328f4792e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Evaluacion_Responder), @"mvc.1.0.view", @"/Views/Evaluacion/Responder.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Evaluacion/Responder.cshtml", typeof(AspNetCore.Views_Evaluacion_Responder))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f014d158f5813515f0a36e4032b246c328f4792e", @"/Views/Evaluacion/Responder.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"44f628e23a2086c1f04f862587f80afdb82e0a32", @"/Views/_ViewImports.cshtml")]
    public class Views_Evaluacion_Responder : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<GPSInformation.Models.Evaluacion>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "MisEvaluaciones", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-sm btn-secondary"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            BeginContext(41, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Evaluacion\Responder.cshtml"
  
    ViewData["Title"] = "Responder";
    GPSInformation.Models.EvaluacionEmpleado Evaluacion = ViewBag.EvaluacionEmpleado;

#line default
#line hidden
            BeginContext(175, 114, true);
            WriteLiteral("\r\n<div class=\"d-sm-flex align-items-center justify-content-between\">\r\n    <div>\r\n        <h2 class=\"mg-b-5\">Tema: ");
            EndContext();
            BeginContext(290, 38, false);
#line 10 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Evaluacion\Responder.cshtml"
                            Write(Html.DisplayFor(model => model.Nombre));

#line default
#line hidden
            EndContext();
            BeginContext(328, 45, true);
            WriteLiteral("</h2>\r\n        <small class=\"tx-uppercase\">\r\n");
            EndContext();
#line 12 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Evaluacion\Responder.cshtml"
             if (Model.IsInterno)
            {
                

#line default
#line hidden
            BeginContext(440, 46, false);
#line 14 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Evaluacion\Responder.cshtml"
           Write(Html.DisplayFor(model => model.PonenteNameExt));

#line default
#line hidden
            EndContext();
#line 14 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Evaluacion\Responder.cshtml"
                                                               
            }
            else
            {
                

#line default
#line hidden
            BeginContext(553, 43, false);
#line 18 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Evaluacion\Responder.cshtml"
           Write(Html.DisplayFor(model => model.PersonaName));

#line default
#line hidden
            EndContext();
#line 18 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Evaluacion\Responder.cshtml"
                                                            
            }

#line default
#line hidden
            BeginContext(613, 56, true);
            WriteLiteral("        </small>\r\n        <p class=\"mg-b-0 tx-color-03\">");
            EndContext();
            BeginContext(670, 42, false);
#line 21 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Evaluacion\Responder.cshtml"
                                 Write(Html.DisplayFor(model => model.InicioHora));

#line default
#line hidden
            EndContext();
            BeginContext(712, 14, true);
            WriteLiteral("<span>-</span>");
            EndContext();
            BeginContext(727, 39, false);
#line 21 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Evaluacion\Responder.cshtml"
                                                                                          Write(Html.DisplayFor(model => model.FinHora));

#line default
#line hidden
            EndContext();
            BeginContext(766, 44, true);
            WriteLiteral("</p>\r\n        <p class=\"mg-b-0 tx-color-03\">");
            EndContext();
            BeginContext(811, 49, false);
#line 22 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Evaluacion\Responder.cshtml"
                                 Write(Html.DisplayNameFor(model => model.ModalidadName));

#line default
#line hidden
            EndContext();
            BeginContext(860, 4, true);
            WriteLiteral(" :  ");
            EndContext();
            BeginContext(865, 45, false);
#line 22 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Evaluacion\Responder.cshtml"
                                                                                       Write(Html.DisplayFor(model => model.ModalidadName));

#line default
#line hidden
            EndContext();
            BeginContext(910, 48, true);
            WriteLiteral("</p>\r\n            <p class=\"mg-b-0 tx-color-03\">");
            EndContext();
            BeginContext(959, 44, false);
#line 23 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Evaluacion\Responder.cshtml"
                                     Write(Html.DisplayNameFor(model => model.Duracion));

#line default
#line hidden
            EndContext();
            BeginContext(1003, 4, true);
            WriteLiteral(" :  ");
            EndContext();
            BeginContext(1008, 40, false);
#line 23 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Evaluacion\Responder.cshtml"
                                                                                      Write(Html.DisplayFor(model => model.Duracion));

#line default
#line hidden
            EndContext();
            BeginContext(1048, 50, true);
            WriteLiteral(" Hrs</p>\r\n        <p class=\"mg-b-0 tx-color-03\">\r\n");
            EndContext();
#line 25 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Evaluacion\Responder.cshtml"
             if (Model.IsInterno)
            {

#line default
#line hidden
            BeginContext(1148, 80, true);
            WriteLiteral("                <span class=\"badge badge-success\">Ponente(s) Externo(s)</span>\r\n");
            EndContext();
#line 28 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Evaluacion\Responder.cshtml"
            }
            else
            {

#line default
#line hidden
            BeginContext(1276, 80, true);
            WriteLiteral("                <span class=\"badge badge-primary\">Ponente(s) Interno(s)</span>\r\n");
            EndContext();
#line 32 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Evaluacion\Responder.cshtml"
            }

#line default
#line hidden
            BeginContext(1371, 219, true);
            WriteLiteral("        </p>\r\n    </div>\r\n    <div class=\"mg-t-20 mg-sm-t-0\">\r\n        <button class=\"btn btn-sm btn-primary mg-l-5\" id=\"btn_refrescar\" onclick=\"window.location.reload()\">Refrescar</button>\r\n    </div>\r\n</div>\r\n<hr />\r\n");
            EndContext();
#line 40 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Evaluacion\Responder.cshtml"
 if (!Evaluacion.Respondio)
{
    

#line default
#line hidden
#line 42 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Evaluacion\Responder.cshtml"
     if (Model.Activa == false)
    {

#line default
#line hidden
            BeginContext(1662, 148, true);
            WriteLiteral("        <div class=\"alert alert-warning\" role=\"alert\">\r\n            <h4 class=\"alert-heading\">Estimado usuario!</h4>\r\n            <p>La evaluación \"");
            EndContext();
            BeginContext(1811, 38, false);
#line 46 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Evaluacion\Responder.cshtml"
                         Write(Html.DisplayFor(model => model.Nombre));

#line default
#line hidden
            EndContext();
            BeginContext(1849, 169, true);
            WriteLiteral("\" ha sido desactivada temporalmente y no puede ser respondida</p>\r\n            <hr>\r\n            <p class=\"mb-0\">Atte: Sistema Gestión de Personal.</p>\r\n        </div>\r\n");
            EndContext();
            BeginContext(2020, 114, true);
            WriteLiteral("        <div class=\"form-group row mg-b-0 mt-5\">\r\n            <div class=\"col-sm-12 text-right\">\r\n                ");
            EndContext();
            BeginContext(2134, 77, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "54cc9c32aa68478fb806415ebef36068", async() => {
                BeginContext(2199, 8, true);
                WriteLiteral("Regresar");
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
            BeginContext(2211, 38, true);
            WriteLiteral("\r\n            </div>\r\n        </div>\r\n");
            EndContext();
#line 56 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Evaluacion\Responder.cshtml"
    }
    else
    {

#line default
#line hidden
            BeginContext(2273, 3127, true);
            WriteLiteral(@"        <div id=""AppEvaluacionRes"" data-label=""Preguntas"" class=""df-example demo-forms"">
            <div class=""alert alert-success mg-b-0 mb-5"" role=""alert"">
                <h4>“Siéntete libre de participar ya que tus respuestas son confidenciales. Son empleadas en la mejora del contenido, la retroalimentación y la logística de los eventos de Formación y Desarrollo”</h4>
            </div>
            <table class=""table table-bordered table-hover"">
                <tr>
                    <th colspan=""1"" style=""width: 60%;""></th>
                    <th colspan=""1"" class=""text-center"">Muy bien</th>
                    <th colspan=""1"" class=""text-center"">Bien</th>
                    <th colspan=""1"" class=""text-center"">Regular</th>
                    <th colspan=""1"" class=""text-center"">Malo</th>
                    <th colspan=""1"" class=""text-center"">No aplica</th>
                </tr>
                <tbody v-for=""(seccion, indexSecccion) in Access"">
                    <tr>
             ");
            WriteLiteral(@"           <td class=""bg-primary-light m-3"" colspan=""6"">{{ seccion.nombre }}</td>
                    </tr>
                    <tr v-for=""(pregunta, indexPregunta) in seccion.preguntas"">
                        <th colspan=""1"" style=""width: 60%;""><div v-html=""span(pregunta.pregunta)"" /><span class=""text-danger field-validation-valid"" v-bind:id=""'validac_'+pregunta.idEvaluacionSeccionPregnts"" data-valmsg-for=""Nombre"" data-valmsg-replace=""true""> </span> </th>
                        <td colspan=""1"" v-if=""pregunta.tipo == 1"" class=""text-center"">
                            <input type=""radio"" v-model=""pregunta.respuesta.respuesta"" value=""1"" title=""Muy bien"" />
                        </td>
                        <td colspan=""1"" v-if=""pregunta.tipo == 1"" class=""text-center"">
                            <input type=""radio"" v-model=""pregunta.respuesta.respuesta"" value=""2"" title=""Bien"" />
                        </td>
                        <td colspan=""1"" v-if=""pregunta.tipo == 1"" class=""text-center"">");
            WriteLiteral(@"
                            <input type=""radio"" v-model=""pregunta.respuesta.respuesta"" value=""3"" title=""Regular"" />
                        </td>
                        <td colspan=""1"" v-if=""pregunta.tipo == 1"" class=""text-center"">
                            <input type=""radio"" v-model=""pregunta.respuesta.respuesta"" value=""4"" title=""Malo"" />
                        </td>
                        <td colspan=""1"" v-if=""pregunta.tipo == 1"" class=""text-center"">
                            <input type=""radio"" v-model=""pregunta.respuesta.respuesta"" value=""5"" title=""Considero que esta pregunta no aplica"" />
                        </td>
                        <td colspan=""5"" v-if=""pregunta.tipo == 2"" class=""text-center"">
                            <textarea class=""form-control"" v-model=""pregunta.respuesta.respuesta""></textarea>
                        </td>
                    </tr>
                </tbody>
            </table>
            <div class=""form-group row mg-b-0 mt-5"">
                <");
            WriteLiteral("div class=\"col-sm-12 text-right\">\r\n                    ");
            EndContext();
            BeginContext(5400, 77, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "391f856d62744627a193dec5dafe5653", async() => {
                BeginContext(5465, 8, true);
                WriteLiteral("Cancelar");
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
            BeginContext(5477, 184, true);
            WriteLiteral("\r\n                    <button type=\"button\" v-on:click=\"Save()\" class=\"btn btn-sm btn-primary\">Guardar evaluación</button>\r\n                </div>\r\n            </div>\r\n        </div>\r\n");
            EndContext();
            DefineSection("Scripts", async() => {
                BeginContext(5687, 564, true);
                WriteLiteral(@"

            <script>
                $(document).ready(function () {

                });
            </script>
            <script>
        var AppEvaluacionRes = new Vue({
            el: ""#AppEvaluacionRes"",
            data: {
                Access: null

            },
            mounted() {
                this.Details();
            },
            methods: {
                span(text) {
                    return `<span> ${text} </span>`
                },
                Details: function () {
                    axios.get('");
                EndContext();
                BeginContext(6252, 73, false);
#line 128 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Evaluacion\Responder.cshtml"
                          Write(Url.Action("DataResponder","Evaluacion", new { id = Model.IdEvaluacion }));

#line default
#line hidden
                EndContext();
                BeginContext(6325, 660, true);
                WriteLiteral(@"', null, null).then(response => {
                        console.log(response.data)
                        this.Access = response.data;
                    }).catch(error => {
                        if (error.response) {
                            if (error.response.status === 400) {

                            }
                        }
                        console.error(error)
                        ShowMessageErrorShort(""error al extraer información"", ""error"")
                    }).finally()
                },
                Save: async function () {
                    let datos = {
                        IdEvaluacion : ");
                EndContext();
                BeginContext(6986, 18, false);
#line 143 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Evaluacion\Responder.cshtml"
                                  Write(Model.IdEvaluacion);

#line default
#line hidden
                EndContext();
                BeginContext(7004, 346, true);
                WriteLiteral(@",
                        list : this.Access
                    }

                    let validate = await this.validar()
                    if (validate == false) {
                        ShowMessageErrorShort(""Por favor responde todas las preguntas"", ""error"")
                    } else {
                         await axios.post('");
                EndContext();
                BeginContext(7351, 42, false);
#line 151 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Evaluacion\Responder.cshtml"
                                      Write(Url.Action("DataResponders", "Evaluacion"));

#line default
#line hidden
                EndContext();
                BeginContext(7393, 1822, true);
                WriteLiteral(@"', datos, null).then(response => {
                            console.log(response.data)
                            //this.Access = response.data;
                            document.getElementById(""btn_refrescar"").click()
                        }).catch(error => {
                            if (error.response) {
                                if (error.response.status === 400) {
                                    ShowMessageErrorShort(error.response.data, ""error"")
                                }
                                if (error.response.status === 404) {
                                    ShowMessageErrorShort(error.response.data, ""error"")
                                }
                            }
                            console.error(error)

                        }).finally()
                    }
                },
                validar: async function () {
                    var valido = true;
                    await this.Access.forEach(async (es, is)");
                WriteLiteral(@" => {
                        //console.log(es)
                        await es.preguntas.forEach((ep, ip) => {
                            if (ep.respuesta.respuesta == null && ep.tipo == 1) {
                                document.getElementById('validac_' + ep.idEvaluacionSeccionPregnts).innerHTML = ""<br />Por favor responde está pregunta ""
                                valido = false
                            } else {
                                document.getElementById('validac_' + ep.idEvaluacionSeccionPregnts).innerHTML = """"
                            }

                        });
                    });
                    console.log(valido)
                    return valido;
                }
            }
        });
            </script>
        ");
                EndContext();
            }
            );
#line 189 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Evaluacion\Responder.cshtml"
         
    }

#line default
#line hidden
#line 190 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Evaluacion\Responder.cshtml"
     
}
else
{

#line default
#line hidden
            BeginContext(9237, 757, true);
            WriteLiteral(@"    <div class=""content content-fixed content-auth-alt"">
        <div class=""container ht-100p tx-center"">
            <div class=""ht-100p d-flex flex-column align-items-center justify-content-center"">
                <div class=""wd-70p wd-sm-250 wd-lg-300 mg-b-15""><img src=""https://image.freepik.com/vector-gratis/empresario-sosteniendo-documento_1325-411.jpg"" class=""img-fluid"" alt=""""></div>
                <h1 class=""tx-color-01 tx-24 tx-sm-32 tx-lg-36 mg-xl-b-5"">Formación y Desarrollo agradece tu tiempo y participación, estamos trabajando para ti</h1>
                <h4 class=""tx-16 tx-sm-18 tx-lg-20 tx-normal mg-b-20"">Esta evaluación ya fue respondida</h4>
            </div>
        </div><!-- container -->
    </div><!-- content -->
");
            EndContext();
#line 203 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Evaluacion\Responder.cshtml"

}

#line default
#line hidden
            BeginContext(9999, 2, true);
            WriteLiteral("\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<GPSInformation.Models.Evaluacion> Html { get; private set; }
    }
}
#pragma warning restore 1591
