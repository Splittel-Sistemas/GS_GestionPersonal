#pragma checksum "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Produccion\OpeTurno.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "70159ce4f1563e84fc3e82066ff4768a25cc72fd"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Produccion_OpeTurno), @"mvc.1.0.view", @"/Views/Produccion/OpeTurno.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Produccion/OpeTurno.cshtml", typeof(AspNetCore.Views_Produccion_OpeTurno))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"70159ce4f1563e84fc3e82066ff4768a25cc72fd", @"/Views/Produccion/OpeTurno.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"44f628e23a2086c1f04f862587f80afdb82e0a32", @"/Views/_ViewImports.cshtml")]
    public class Views_Produccion_OpeTurno : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<GPSInformation.Reportes.EmpleadogrupoProd>>
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
            BeginContext(63, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Produccion\OpeTurno.cshtml"
  
    ViewData["Title"] = "Gestión de grupos de producción";

#line default
#line hidden
            BeginContext(132, 79, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "d8f2744e79a24067bd4df403c09e0e2d", async() => {
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
            BeginContext(211, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(213, 75, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "c2158c5c839a4e6db29bb63ca4f1e487", async() => {
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
            BeginContext(288, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(290, 75, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "02e47d2dfb6d4d13ac1d0b9609e5784a", async() => {
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
            BeginContext(365, 131, true);
            WriteLiteral("\r\n<div id=\"app_turnos\">\r\n    <div class=\"d-sm-flex align-items-center justify-content-between mg-b-20 mg-lg-b-30\">\r\n        <div>\r\n");
            EndContext();
            BeginContext(854, 45, true);
            WriteLiteral("            <h4 class=\"mg-b-0 tx-spacing--1\">");
            EndContext();
            BeginContext(900, 17, false);
#line 18 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Produccion\OpeTurno.cshtml"
                                        Write(ViewData["Title"]);

#line default
#line hidden
            EndContext();
            BeginContext(917, 350, true);
            WriteLiteral(@"</h4>
        </div>
        <div class=""d-none d-md-block"">
            <button class=""btn btn-sm pd-x-15 btn-primary btn-uppercase mg-l-5""><i data-feather=""plus"" class=""wd-10 mg-r-5""></i> Asignar varios</button>
        </div>
    </div>
    <table class=""table"">
        <thead>
            <tr>
                <th>
                    ");
            EndContext();
            BeginContext(1268, 48, false);
#line 28 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Produccion\OpeTurno.cshtml"
               Write(Html.DisplayNameFor(model => model.NumeroNomina));

#line default
#line hidden
            EndContext();
            BeginContext(1316, 67, true);
            WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
            EndContext();
            BeginContext(1384, 50, false);
#line 31 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Produccion\OpeTurno.cshtml"
               Write(Html.DisplayNameFor(model => model.NombreCompleto));

#line default
#line hidden
            EndContext();
            BeginContext(1434, 67, true);
            WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
            EndContext();
            BeginContext(1502, 42, false);
#line 34 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Produccion\OpeTurno.cshtml"
               Write(Html.DisplayNameFor(model => model.Puesto));

#line default
#line hidden
            EndContext();
            BeginContext(1544, 67, true);
            WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
            EndContext();
            BeginContext(1612, 43, false);
#line 37 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Produccion\OpeTurno.cshtml"
               Write(Html.DisplayNameFor(model => model.Ingreso));

#line default
#line hidden
            EndContext();
            BeginContext(1655, 67, true);
            WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
            EndContext();
            BeginContext(1723, 41, false);
#line 40 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Produccion\OpeTurno.cshtml"
               Write(Html.DisplayNameFor(model => model.Turno));

#line default
#line hidden
            EndContext();
            BeginContext(1764, 106, true);
            WriteLiteral("\r\n                </th>\r\n                <th></th>\r\n            </tr>\r\n        </thead>\r\n        <tbody>\r\n");
            EndContext();
#line 46 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Produccion\OpeTurno.cshtml"
             foreach (var item in Model)
            {

#line default
#line hidden
            BeginContext(1927, 72, true);
            WriteLiteral("                <tr>\r\n                    <td>\r\n                        ");
            EndContext();
            BeginContext(2000, 47, false);
#line 50 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Produccion\OpeTurno.cshtml"
                   Write(Html.DisplayFor(modelItem => item.NumeroNomina));

#line default
#line hidden
            EndContext();
            BeginContext(2047, 79, true);
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
            EndContext();
            BeginContext(2127, 49, false);
#line 53 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Produccion\OpeTurno.cshtml"
                   Write(Html.DisplayFor(modelItem => item.NombreCompleto));

#line default
#line hidden
            EndContext();
            BeginContext(2176, 79, true);
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
            EndContext();
            BeginContext(2256, 41, false);
#line 56 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Produccion\OpeTurno.cshtml"
                   Write(Html.DisplayFor(modelItem => item.Puesto));

#line default
#line hidden
            EndContext();
            BeginContext(2297, 79, true);
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
            EndContext();
            BeginContext(2377, 42, false);
#line 59 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Produccion\OpeTurno.cshtml"
                   Write(Html.DisplayFor(modelItem => item.Ingreso));

#line default
#line hidden
            EndContext();
            BeginContext(2419, 55, true);
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n");
            EndContext();
#line 62 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Produccion\OpeTurno.cshtml"
                         if (item.Turno == "Gris")
                        {

#line default
#line hidden
            BeginContext(2553, 64, true);
            WriteLiteral("                            <span class=\"badge badge-secondary\">");
            EndContext();
            BeginContext(2618, 40, false);
#line 64 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Produccion\OpeTurno.cshtml"
                                                           Write(Html.DisplayFor(modelItem => item.Turno));

#line default
#line hidden
            EndContext();
            BeginContext(2658, 9, true);
            WriteLiteral("</span>\r\n");
            EndContext();
#line 65 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Produccion\OpeTurno.cshtml"
                        }
                        else if (item.Turno == "Rojo")
                        {

#line default
#line hidden
            BeginContext(2777, 61, true);
            WriteLiteral("                            <span class=\"badge badge-danger\">");
            EndContext();
            BeginContext(2839, 40, false);
#line 68 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Produccion\OpeTurno.cshtml"
                                                        Write(Html.DisplayFor(modelItem => item.Turno));

#line default
#line hidden
            EndContext();
            BeginContext(2879, 9, true);
            WriteLiteral("</span>\r\n");
            EndContext();
#line 69 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Produccion\OpeTurno.cshtml"
                        }
                        else if (item.Turno == "Verde")
                        {

#line default
#line hidden
            BeginContext(2999, 62, true);
            WriteLiteral("                            <span class=\"badge badge-success\">");
            EndContext();
            BeginContext(3062, 40, false);
#line 72 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Produccion\OpeTurno.cshtml"
                                                         Write(Html.DisplayFor(modelItem => item.Turno));

#line default
#line hidden
            EndContext();
            BeginContext(3102, 9, true);
            WriteLiteral("</span>\r\n");
            EndContext();
#line 73 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Produccion\OpeTurno.cshtml"
                        }
                        else
                        {

#line default
#line hidden
            BeginContext(3195, 80, true);
            WriteLiteral("                            <span class=\"badge badge-warning\">Sin turno</span>\r\n");
            EndContext();
#line 77 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Produccion\OpeTurno.cshtml"
                        }

#line default
#line hidden
            BeginContext(3302, 144, true);
            WriteLiteral("\r\n\r\n                    </td>\r\n                    <td>\r\n                        <a href=\"#modalActividadVacacionesPeriodos\" data-toggle=\"modal\"");
            EndContext();
            BeginWriteAttribute("v-on:click", " v-on:click=\"", 3446, "\"", 3522, 3);
            WriteAttributeValue("", 3459, "GetDataDetails(\'", 3459, 16, true);
#line 82 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Produccion\OpeTurno.cshtml"
WriteAttributeValue("", 3475, Html.DisplayFor(modelItem => item.IdPersona), 3475, 45, false);

#line default
#line hidden
            WriteAttributeValue("", 3520, "\')", 3520, 2, true);
            EndWriteAttribute();
            BeginContext(3523, 70, true);
            WriteLiteral(">Cambiar grupo</a>\r\n                    </td>\r\n                </tr>\r\n");
            EndContext();
#line 85 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Produccion\OpeTurno.cshtml"
            }

#line default
#line hidden
            BeginContext(3608, 906, true);
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

                    <div id=""cambioResult""></div>
                </div><!-- modal-body -->
            </div><!-- modal-content -->
        </div><!-- modal-dialog -->
    </div><!-- modal -->
</div>

");
            EndContext();
            DefineSection("Scripts", async() => {
                BeginContext(4532, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(4538, 63, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ae55d3fda801473d96004eff6cd3121f", async() => {
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
                BeginContext(4601, 6, true);
                WriteLiteral("\r\n    ");
                EndContext();
                BeginContext(4607, 71, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9752230297434d63953a556e15a1b238", async() => {
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
                BeginContext(4678, 264, true);
                WriteLiteral(@"
    <script src=""https://cdnjs.cloudflare.com/ajax/libs/bootstrap-datepicker/1.9.0/js/bootstrap-datepicker.min.js"" integrity=""sha512-T/tUfKSV1bihCnd+MxKD0Hm1uBBroVYBOYSk1knyvQ9VyZJpc/ALb4P0r6ubwVPSGB2GvjeoMAJJImBG12TiaQ=="" crossorigin=""anonymous""></script>
    ");
                EndContext();
                BeginContext(4942, 63, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "3516f55d54f94a4bb6b50fc7aa947e09", async() => {
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
                BeginContext(5005, 1009, true);
                WriteLiteral(@"
    <script>
        $(document).ready(function () {

        });
    </script>
    <script>
        var app_turnos = new Vue({
            el: ""#app_turnos"",
            data: {
                Gp_gris: {
                    id: 1,
                    backgroundColor: 'rgba(49, 48, 48, 0.47)',
                    borderColor: '#000000',
                    events: []
                },
                Gp_rojo: {
                    id: 2,
                    backgroundColor: 'rgba(255, 0, 0, 0.47)',
                    borderColor: '#fa4141',
                    events: []
                },
                Gp_verde: {
                    id: 3,
                    backgroundColor: 'rgba(16,183,89, .25)',
                    borderColor: '#10b759',
                    events: []
                },
            },
            async mounted() {

            },
            methods: {
                Save: async function () {
                    await axios.post('");
                EndContext();
                BeginContext(6015, 40, false);
#line 143 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Produccion\OpeTurno.cshtml"
                                 Write(Url.Action("Asignargrupo", "Produccion"));

#line default
#line hidden
                EndContext();
                BeginContext(6055, 1098, true);
                WriteLiteral(@"', $('#formAsignargrupo').serialize(), null).then(response => {
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
                    await this.GetDataDetails(document.getElementById(""IdPersona"").value);
                },
                GetDataDetails: async function (id) {
                    this.Gp_gris.events = [];
                    this.Gp_rojo.events = [];
                    this.Gp_verde.events = [];

                    document.getElementB");
                WriteLiteral("yId(\"cambioResult\").innerHTML = \"\";\r\n                    await axios.get(\'");
                EndContext();
                BeginContext(7154, 40, false);
#line 162 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Produccion\OpeTurno.cshtml"
                                Write(Url.Action("Asignargrupo", "Produccion"));

#line default
#line hidden
                EndContext();
                BeginContext(7194, 780, true);
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
                    if (document.getElementById(""calendar"") != null) {

                    }
                    await axios.get('");
                EndContext();
                BeginContext(7975, 47, false);
#line 176 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Produccion\OpeTurno.cshtml"
                                Write(Url.Action("EmpleadoGrupoDetais", "Produccion"));

#line default
#line hidden
                EndContext();
                BeginContext(8022, 7357, true);
                WriteLiteral(@"/'+id,null, null).then(response => {
                        response.data.forEach((e, i) => {

                            //Reservacion_queb.events.push(reservacion);
                            if (e.idGrupo == 86) {
                                this.Gp_gris.events.push({
                                    id: e.idGrupoProduccion,
                                    start: e.fecha.substring(0, 10) + ""T00:00:00"",
                                    end: e.fecha.substring(0, 10) + ""T23:59:00"",
                                    title: ""Gris"",
                                    description: e.comentarios
                                });
                            }
                            else if (e.idGrupo == 87) {
                                this.Gp_rojo.events.push({
                                    id: e.idGrupoProduccion,
                                    start: e.fecha.substring(0, 10) + ""T00:00:00"",
                                    end: e.fecha.substring(0, 10");
                WriteLiteral(@") + ""T23:59:00"",
                                    title: ""Rojo"",
                                    description: e.comentarios
                                });
                            }
                            else if (e.idGrupo == 88) {
                                this.Gp_verde.events.push({
                                    id: e.idGrupoProduccion,
                                    start: e.fecha.substring(0, 10) + ""T00:00:00"",
                                    end: e.fecha.substring(0, 10) + ""T23:59:00"",
                                    title: ""Verde"",
                                    description: e.comentarios
                                });
                            }
                            else {

                            }
                        })
                    }).catch(error => {
                        if (error.response) {
                            if (error.response.status === 400) {
                                ShowMess");
                WriteLiteral(@"ageErrorShort(error.response.data, ""error"")
                            }
                        }
                    }).finally()
                    console.log(this.Gp_verde);
                    await this.StartCalendar();
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
                        firstDay: 1,
                        navLinks: true,
                        selectable: true,
                        selectLongPressDelay: 100,
                        editable: true,
                        nowIndicator: true,
                        defaultView: 'listMonth',
   ");
                WriteLiteral(@"                     views: {
                            agenda: {
                                columnHeaderHtml: function (mom) {
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
                WriteLiteral(@"                        }
                        },

                        eventSources: [this.Gp_gris, this.Gp_rojo, this.Gp_verde],
                        eventAfterAllRender: function (view) {
                            if (view.name === 'listMonth' || view.name === 'listWeek') {
                                var dates = view.el.find('.fc-list-heading-main');
                                dates.each(function () {
                                    var text = $(this).text().split(' ');
                                    var now = moment().format('DD');

                                    $(this).html(text[0] + '<span>' + text[1] + '</span>');
                                    if (now === text[1]) { $(this).addClass('now'); }
                                });
                            }

                            //console.log(view.el);
                        },
                        eventRender: function (event, element) {

                            if (event.des");
                WriteLiteral(@"cription) {
                                element.find('.fc-list-item-title').append('<span class=""fc-desc"">' + event.description + '</span>');
                                element.find('.fc-content').append('<span class=""fc-desc"">' + event.description + '</span>');
                            }

                            var eBorderColor = (event.source.borderColor) ? event.source.borderColor : event.borderColor;
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

");
                WriteLiteral(@"                    // change view to week when in tablet
                    if (window.matchMedia('(min-width: 576px)').matches) {
                        calendar.changeView('agendaWeek');
                    }

                    // change view to month when in desktop
                    if (window.matchMedia('(min-width: 992px)').matches) {
                        calendar.changeView('month');
                    }

                    // change view based in viewport width when resize is detected
                    calendar.option('windowResize', function (view) {
                        if (view.name === 'listWeek') {
                            if (window.matchMedia('(min-width: 992px)').matches) {
                                calendar.changeView('month');
                            } else {
                                calendar.changeView('listWeek');
                            }
                        }
                    });
                    // Display calendar e");
                WriteLiteral("vent modal\r\n                    calendar.on(\'eventClick\', function (calEvent, jsEvent, view) {\r\n\r\n\r\n\r\n                    });\r\n                }\r\n            }\r\n        });\r\n    </script>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<GPSInformation.Reportes.EmpleadogrupoProd>> Html { get; private set; }
    }
}
#pragma warning restore 1591
