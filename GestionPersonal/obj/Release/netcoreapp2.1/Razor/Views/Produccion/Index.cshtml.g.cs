#pragma checksum "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Produccion\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "69457463c775c3edab9479b62ff18256f5668c34"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Produccion_Index), @"mvc.1.0.view", @"/Views/Produccion/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Produccion/Index.cshtml", typeof(AspNetCore.Views_Produccion_Index))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"69457463c775c3edab9479b62ff18256f5668c34", @"/Views/Produccion/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"44f628e23a2086c1f04f862587f80afdb82e0a32", @"/Views/_ViewImports.cshtml")]
    public class Views_Produccion_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<GPSInformation.Views.View_empleadoEnsamble>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/template/lib/fullcalendar/fullcalendar.min.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/template/assets/css/dashforge.calendar.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/template/assets/css/dashforge.contacts.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/template/lib/moment/min/moment.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/template/lib/fullcalendar/fullcalendar.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/template/assets/js/calendar-events.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            BeginContext(64, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Produccion\Index.cshtml"
  
    ViewData["Title"] = "Asignacion de turnos";

#line default
#line hidden
            BeginContext(122, 79, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "dc5a1ee61aad4cc4ba4704fa816c2b82", async() => {
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
            BeginContext(201, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(203, 75, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "173c4bd8695447bcb59fde84cc0c008e", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(278, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(280, 75, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "ea1441d2a19d4759ae5b5d368f698c75", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(355, 166, true);
            WriteLiteral("\r\n<div id=\"app_turnos\">\r\n    <table class=\"table table-sm table-condensed table-hover\">\r\n        <thead>\r\n            <tr>\r\n                <th>\r\n                    ");
            EndContext();
            BeginContext(522, 48, false);
#line 14 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Produccion\Index.cshtml"
               Write(Html.DisplayNameFor(model => model.NumeroNomina));

#line default
#line hidden
            EndContext();
            BeginContext(570, 67, true);
            WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
            EndContext();
            BeginContext(638, 50, false);
#line 17 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Produccion\Index.cshtml"
               Write(Html.DisplayNameFor(model => model.NombreCompleto));

#line default
#line hidden
            EndContext();
            BeginContext(688, 67, true);
            WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
            EndContext();
            BeginContext(756, 48, false);
#line 20 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Produccion\Index.cshtml"
               Write(Html.DisplayNameFor(model => model.PuestoNombre));

#line default
#line hidden
            EndContext();
            BeginContext(804, 67, true);
            WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
            EndContext();
            BeginContext(872, 52, false);
#line 23 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Produccion\Index.cshtml"
               Write(Html.DisplayNameFor(model => model.DescripcionTurno));

#line default
#line hidden
            EndContext();
            BeginContext(924, 67, true);
            WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
            EndContext();
            BeginContext(992, 49, false);
#line 26 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Produccion\Index.cshtml"
               Write(Html.DisplayNameFor(model => model.FechaFinturno));

#line default
#line hidden
            EndContext();
            BeginContext(1041, 106, true);
            WriteLiteral("\r\n                </th>\r\n                <th></th>\r\n            </tr>\r\n        </thead>\r\n        <tbody>\r\n");
            EndContext();
#line 32 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Produccion\Index.cshtml"
             foreach (var item in Model)
            {

#line default
#line hidden
            BeginContext(1204, 72, true);
            WriteLiteral("                <tr>\r\n                    <td>\r\n                        ");
            EndContext();
            BeginContext(1277, 47, false);
#line 36 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Produccion\Index.cshtml"
                   Write(Html.DisplayFor(modelItem => item.NumeroNomina));

#line default
#line hidden
            EndContext();
            BeginContext(1324, 79, true);
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
            EndContext();
            BeginContext(1404, 49, false);
#line 39 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Produccion\Index.cshtml"
                   Write(Html.DisplayFor(modelItem => item.NombreCompleto));

#line default
#line hidden
            EndContext();
            BeginContext(1453, 79, true);
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
            EndContext();
            BeginContext(1533, 47, false);
#line 42 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Produccion\Index.cshtml"
                   Write(Html.DisplayFor(modelItem => item.PuestoNombre));

#line default
#line hidden
            EndContext();
            BeginContext(1580, 55, true);
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n");
            EndContext();
#line 45 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Produccion\Index.cshtml"
                         if (item.IdTurnosProduccion == 0)
                        {

#line default
#line hidden
            BeginContext(1722, 79, true);
            WriteLiteral("                            <span class=\"badge badge-danger\">Sin turno</span>\r\n");
            EndContext();
#line 48 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Produccion\Index.cshtml"
                        }
                        else
                        {
                            if (item.IdTurnosProduccion == 1)
                            {

#line default
#line hidden
            BeginContext(1979, 66, true);
            WriteLiteral("                                <span class=\"badge badge-primary\">");
            EndContext();
            BeginContext(2046, 51, false);
#line 53 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Produccion\Index.cshtml"
                                                             Write(Html.DisplayFor(modelItem => item.DescripcionTurno));

#line default
#line hidden
            EndContext();
            BeginContext(2097, 9, true);
            WriteLiteral("</span>\r\n");
            EndContext();
#line 54 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Produccion\Index.cshtml"
                            }
                            else if (item.IdTurnosProduccion == 2)
                            {

#line default
#line hidden
            BeginContext(2236, 66, true);
            WriteLiteral("                                <span class=\"badge badge-success\">");
            EndContext();
            BeginContext(2303, 51, false);
#line 57 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Produccion\Index.cshtml"
                                                             Write(Html.DisplayFor(modelItem => item.DescripcionTurno));

#line default
#line hidden
            EndContext();
            BeginContext(2354, 9, true);
            WriteLiteral("</span>\r\n");
            EndContext();
#line 58 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Produccion\Index.cshtml"
                            }
                        }

#line default
#line hidden
            BeginContext(2421, 55, true);
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n");
            EndContext();
#line 63 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Produccion\Index.cshtml"
                         if (item.IdTurnosProduccion != 0)
                        {
                            

#line default
#line hidden
            BeginContext(2592, 48, false);
#line 65 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Produccion\Index.cshtml"
                       Write(Html.DisplayFor(modelItem => item.FechaFinturno));

#line default
#line hidden
            EndContext();
#line 65 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Produccion\Index.cshtml"
                                                                             
                        }

#line default
#line hidden
            BeginContext(2669, 140, true);
            WriteLiteral("                    </td>\r\n                    <td>\r\n                        <a href=\"#modalActividadVacacionesPeriodos\" data-toggle=\"modal\"");
            EndContext();
            BeginWriteAttribute("v-on:click", " v-on:click=\"", 2809, "\"", 2849, 3);
            WriteAttributeValue("", 2822, "Getturno(\'", 2822, 10, true);
#line 69 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Produccion\Index.cshtml"
WriteAttributeValue("", 2832, item.IdPersona, 2832, 15, false);

#line default
#line hidden
            WriteAttributeValue("", 2847, "\')", 2847, 2, true);
            EndWriteAttribute();
            BeginContext(2850, 70, true);
            WriteLiteral(">Cambiar turno</a>\r\n                    </td>\r\n                </tr>\r\n");
            EndContext();
#line 72 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Produccion\Index.cshtml"
            }

#line default
#line hidden
            BeginContext(2935, 1264, true);
            WriteLiteral(@"        </tbody>
    </table>
    <div class=""modal calendar-modal-create fade effect-scale"" id=""modalActividadVacacionesPeriodos"" role=""dialog"" data-backdrop=""false"" aria-hidden=""true"">
        <div class=""modal-dialog modal-dialog-centered modal-xl"" role=""document"">
            <div class=""modal-content"">
                <div class=""modal-body pd-20 pd-sm-30"">
                    <button type=""button"" class=""close pos-absolute t-20 r-20"" data-dismiss=""modal"" aria-label=""Close"">
                        <span aria-hidden=""true""><i data-feather=""x""></i></span>
                    </button>
                    <h5 class=""tx-18 tx-sm-20 mg-b-20 mg-sm-b-30"">Cambio de turno</h5>
                    <div class=""row"">
                        <div class=""col-lg-8"">
                            <div class="""">
                                <div id=""calendar"" class=""calendar-content-body""></div>
                            </div><!-- calendar-content -->
                        </div>
                  ");
            WriteLiteral("      <div class=\"col-lg-4\" id=\"cambioResult\"></div>\r\n                    </div>\r\n                </div><!-- modal-body -->\r\n            </div><!-- modal-content -->\r\n        </div><!-- modal-dialog -->\r\n    </div><!-- modal -->\r\n</div>\r\n\r\n");
            EndContext();
            DefineSection("Scripts", async() => {
                BeginContext(4217, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(4223, 63, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "46d4b6f339094754916c358c89169e06", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(4286, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(4292, 71, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "6b16819e365f4f2f8ad174401605cc0d", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(4363, 264, true);
                WriteLiteral(@"
    <script src=""https://cdnjs.cloudflare.com/ajax/libs/bootstrap-datepicker/1.9.0/js/bootstrap-datepicker.min.js"" integrity=""sha512-T/tUfKSV1bihCnd+MxKD0Hm1uBBroVYBOYSk1knyvQ9VyZJpc/ALb4P0r6ubwVPSGB2GvjeoMAJJImBG12TiaQ=="" crossorigin=""anonymous""></script>
    ");
                EndContext();
                BeginContext(4627, 63, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "4cc252acd17a4dd0a63b1d8e0cc3f881", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(4690, 435, true);
                WriteLiteral(@"
    <script>
        $(document).ready(function () {

        });
    </script>
    <script>
        var app_turnos = new Vue({
            el: ""#app_turnos"",
            data: {
                Reservaciones: [],
                ReservacionesB: [],
            },
            async mounted() {

            },
            methods: {
                Send: async function (id) {
                    await axios.post('");
                EndContext();
                BeginContext(5126, 40, false);
#line 119 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Produccion\Index.cshtml"
                                 Write(Url.Action("AsignarTurno", "Produccion"));

#line default
#line hidden
                EndContext();
                BeginContext(5166, 949, true);
                WriteLiteral(@"', $('#formAsignarturno').serialize(), null).then(response => {
                        document.getElementById(""cambioResult"").innerHTML = """";
                        document.getElementById(""cambioResult"").innerHTML = response.data;
                    }).catch(error => {
                        if (error.response) {
                            if (error.response.status === 400) {
                                document.getElementById(""cambioResult"").innerHTML = """";
                                document.getElementById(""cambioResult"").innerHTML = response.data;
                            }
                        }
                    }).finally()

                    await this.GetReservaciones(id);
                    this.StartCalendar();
                },
                Getturno: async function (id) {
                    document.getElementById(""cambioResult"").innerHTML = """";
                    axios.get('");
                EndContext();
                BeginContext(6116, 40, false);
#line 136 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Produccion\Index.cshtml"
                          Write(Url.Action("AsignarTurno", "Produccion"));

#line default
#line hidden
                EndContext();
                BeginContext(6156, 860, true);
                WriteLiteral(@"/'+id,null, null).then(response => {
                        document.getElementById(""cambioResult"").innerHTML = """";
                        document.getElementById(""cambioResult"").innerHTML = response.data;
                    }).catch(error => {
                        if (error.response) {
                            if (error.response.status === 400) {
                                document.getElementById(""cambioResult"").innerHTML = """";
                                document.getElementById(""cambioResult"").innerHTML = response.data;
                            }
                        }
                    }).finally()

                    await this.GetReservaciones(id);
                    this.StartCalendar();
                },
                GetReservaciones: async function (id) {
                    await axios.post('");
                EndContext();
                BeginContext(7017, 45, false);
#line 152 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Produccion\Index.cshtml"
                                 Write(Url.Action("GetTunosHistorico", "Produccion"));

#line default
#line hidden
                EndContext();
                BeginContext(7062, 7249, true);
                WriteLiteral(@"/'+id, null, null).then(response => {
                        ShowMessageErrorShort(""Eventos obtenidos, procesando..."", ""success"")
                        console.log(response.data);
                        var Reservacion_que = {
                            id: 1,
                            backgroundColor: 'rgba(1,104,250, .15)',
                            borderColor: '#0168fa',
                            events: []
                        }
                        response.data.turno_1.forEach((e, i) => {
                            var reservacion = {
                                id: e.idTurnoEmpleado,
                                start: e.fecha.substring(0,10)+""T00:00:00"",
                                end: e.fecha.substring(0, 10) +""T23:59:00"",
                                title: e.descripcionTurno,
                                description: """"
                            }
                            Reservacion_que.events.push(reservacion);
                        })");
                WriteLiteral(@"
                        this.Reservaciones = Reservacion_que;

                        var Reservacion_queb = {
                            id: 2,
                            backgroundColor: 'rgba(16,183,89, .25)',
                            borderColor: '#10b759',
                            events: []
                        }
                        response.data.turno_b.forEach((e, i) => {
                            var reservacion = {
                                id: e.idTurnoEmpleado,
                                start: e.fecha.substring(0, 10) + ""T00:00:00"",
                                end: e.fecha.substring(0, 10) + ""T23:59:00"",
                                title: e.descripcionTurno,
                                description: """"
                            }
                            Reservacion_queb.events.push(reservacion);
                        })
                        this.ReservacionesB = Reservacion_queb;
                        console.log(this.Reser");
                WriteLiteral(@"vacionesB)
                    }).catch(error => {
                        if (error.response) {
                            if (error.response.status === 400) {
                                ShowMessageErrorShort(error.response.data,""error"")
                            }
                        }
                    }).finally()
                },
                StartCalendar: function () {
                    $('#calendar').fullCalendar('destroy');
                    $('#calendar').fullCalendar('render');
                    $('#calendar').fullCalendar({
                        header: {
                          left: 'prev,next today',
                          center: 'title',
                          right: 'month,agendaWeek,agendaDay,listWeek'
                        },
                        navLinks: true,
                        selectable: true,
                        selectLongPressDelay: 100,
                        editable: true,
                        nowIndicator");
                WriteLiteral(@": true,
                        defaultView: 'listMonth',
                        views: {
                          agenda: {
                            columnHeaderHtml: function(mom) {
                              return '<span>' + mom.format('ddd') + '</span>' +
                                     '<span>' + mom.format('DD') + '</span>';
                            }
                          },
                          day: { columnHeader: false },
                          listMonth: {
                            listDayFormat: 'ddd DD',
                            listDayAltFormat: false
                          },
                          listWeek: {
                            listDayFormat: 'ddd DD',
                            listDayAltFormat: false
                          },
                          agendaThreeDay: {
                            type: 'agenda',
                            duration: { days: 3 },
                            titleFormat: 'MMMM YYYY'
   ");
                WriteLiteral(@"                       }
                        },

                        eventSources: [this.Reservaciones, this.ReservacionesB],
                        eventAfterAllRender: function(view) {
                          if(view.name === 'listMonth' || view.name === 'listWeek') {
                            var dates = view.el.find('.fc-list-heading-main');
                            dates.each(function(){
                              var text = $(this).text().split(' ');
                              var now = moment().format('DD');

                              $(this).html(text[0]+'<span>'+text[1]+'</span>');
                              if(now === text[1]) { $(this).addClass('now'); }
                            });
                          }

                          //console.log(view.el);
                        },
                        eventRender: function(event, element) {

                          if(event.description) {
                            element.find('.fc-l");
                WriteLiteral(@"ist-item-title').append('<span class=""fc-desc"">' + event.description + '</span>');
                            element.find('.fc-content').append('<span class=""fc-desc"">' + event.description + '</span>');
                          }

                          var eBorderColor = (event.source.borderColor)? event.source.borderColor : event.borderColor;
                          element.find('.fc-list-item-time').css({
                            color: eBorderColor,
                            borderColor: eBorderColor
                          });

                          element.find('.fc-list-item-title').css({
                            borderColor: eBorderColor
                          });

                          element.css('borderLeftColor', eBorderColor);
                        },
                    });
                    var calendar = $('#calendar').fullCalendar('getCalendar');

                    // change view to week when in tablet
                    if(window.matchM");
                WriteLiteral(@"edia('(min-width: 576px)').matches) {
                        calendar.changeView('agendaWeek');
                    }

                    // change view to month when in desktop
                    if(window.matchMedia('(min-width: 992px)').matches) {
                        calendar.changeView('month');
                    }

                    // change view based in viewport width when resize is detected
                    calendar.option('windowResize', function(view) {
                        if(view.name === 'listWeek') {
                            if(window.matchMedia('(min-width: 992px)').matches) {
                            calendar.changeView('month');
                            } else {
                            calendar.changeView('listWeek');
                            }
                        }
                    });
                    // Display calendar event modal
                    calendar.on('eventClick', function(calEvent, jsEvent, view){



        ");
                WriteLiteral("            });\r\n                }\r\n\r\n            }\r\n        });\r\n    </script>\r\n");
                EndContext();
            }
            );
            BeginContext(14314, 2, true);
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<GPSInformation.Views.View_empleadoEnsamble>> Html { get; private set; }
    }
}
#pragma warning restore 1591
