#pragma checksum "C:\Luis Martinez backup\Personal\Developments\NET\GrupoSplittel\GrupoSplittel\GestionPersonal\Views\Incidencia\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1bf43d035bea150e119d1c877398b8f1afbf82b1"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Incidencia_Index), @"mvc.1.0.view", @"/Views/Incidencia/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Incidencia/Index.cshtml", typeof(AspNetCore.Views_Incidencia_Index))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1bf43d035bea150e119d1c877398b8f1afbf82b1", @"/Views/Incidencia/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"44f628e23a2086c1f04f862587f80afdb82e0a32", @"/Views/_ViewImports.cshtml")]
    public class Views_Incidencia_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<GestionPersonal.Models.Incidencias>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "../IncidenciaPermiso/Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("name", "../IncidenciaVacacion/Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "C:\Luis Martinez backup\Personal\Developments\NET\GrupoSplittel\GrupoSplittel\GestionPersonal\Views\Incidencia\Index.cshtml"
  
    ViewData["Title"] = "Mis solicitudes";

    List<GPSInformation.Models.VacionesPeriodo> periodos = ViewBag.Periodos;

#line default
#line hidden
            BeginContext(174, 96, true);
            WriteLiteral("\r\n<!--<div class=\"d-flex align-items-center justify-content-between mg-b-30\">\r\n    <h2 class=\"\">");
            EndContext();
            BeginContext(271, 17, false);
#line 9 "C:\Luis Martinez backup\Personal\Developments\NET\GrupoSplittel\GrupoSplittel\GestionPersonal\Views\Incidencia\Index.cshtml"
            Write(ViewData["Title"]);

#line default
#line hidden
            EndContext();
            BeginContext(288, 79, true);
            WriteLiteral("</h2>\r\n    <div class=\"btn-group\" role=\"group\" aria-label=\"Basic example\">-->\r\n");
            EndContext();
            BeginContext(536, 444, true);
            WriteLiteral(@"    <!--</div>
</div>
<hr />-->
<div class=""alert alert-success"" role=""alert"">
    <h4 class=""alert-heading"">Hola!</h4>
    <p>Gracias por utilizar GPS, en esta sección podrás solicitar permisos y vacaciones, recuerda que tu solicitud pasará por un proceso de autorización por tu <strong>jefe inmediato</strong> y el área de <strong>Gestión de Personal</strong> </p>
    <hr>
    <p class=""mb-0"">Sistema Gestión de Personal</p>
</div>
");
            EndContext();
            BeginContext(981, 93, false);
#line 21 "C:\Luis Martinez backup\Personal\Developments\NET\GrupoSplittel\GrupoSplittel\GestionPersonal\Views\Incidencia\Index.cshtml"
Write(await Component.InvokeAsync("ValidPuestoEnOrganigrama", new { id = Model.persona.IdPersona }));

#line default
#line hidden
            EndContext();
            BeginContext(1074, 939, true);
            WriteLiteral(@"
<hr />
<div id=""app_incidencias"">
    <ul class=""nav nav-tabs"" id=""myTab"" role=""tablist"">
        <li class=""nav-item"">
            <a class=""nav-link active"" id=""home-tab"" data-toggle=""tab"" href=""#home"" role=""tab"" aria-controls=""home"" aria-selected=""true"">Permisos</a>
        </li>
        <li class=""nav-item"">
            <a class=""nav-link"" id=""profile-tab"" data-toggle=""tab"" href=""#profile"" role=""tab"" aria-controls=""profile"" aria-selected=""false"">Vacaciones</a>
        </li>
    </ul>
    <div class=""tab-content bd bd-gray-300 bd-t-0 pd-20"" id=""myTabContent"">
        <div class=""tab-pane fade show active"" id=""home"" role=""tabpanel"" aria-labelledby=""home-tab"">
            <div id=""contactLogs"" class=""tab-pane pd-20 pd-xl-25 active"">
                <div class=""d-flex align-items-center justify-content-between mg-b-30"">
                    <h4 class=""tx-15 mg-b-0"">Lista de permisos</h4>
                    <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 2013, "\"", 2099, 1);
#line 37 "C:\Luis Martinez backup\Personal\Developments\NET\GrupoSplittel\GrupoSplittel\GestionPersonal\Views\Incidencia\Index.cshtml"
WriteAttributeValue("", 2020, Url.Action("Create","IncidenciaPermiso", new { id = Model.persona.IdPersona }), 2020, 79, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2100, 233, true);
            WriteLiteral(" class=\"btn btn-outline-primary btn-sm d-flex align-items-center\"><i class=\"icon ion-md-time mg-r-5 tx-16 lh--9\"></i>Crear nuevo</a>\r\n                </div>\r\n            </div>\r\n            <div id=\"table-permisos\">\r\n                ");
            EndContext();
            BeginContext(2333, 68, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "94911623e8c84e1484f8992fcdba5138", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
#line 41 "C:\Luis Martinez backup\Personal\Developments\NET\GrupoSplittel\GrupoSplittel\GestionPersonal\Views\Incidencia\Index.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Model = Model.permisos;

#line default
#line hidden
            __tagHelperExecutionContext.AddTagHelperAttribute("model", __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Model, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(2401, 702, true);
            WriteLiteral(@"
            </div>
        </div>
        <div class=""tab-pane fade"" id=""profile"" role=""tabpanel"" aria-labelledby=""profile-tab"">
            <div id=""contactLogs"" class=""tab-pane pd-20 pd-xl-25 active"">
                <div class=""d-flex align-items-center justify-content-between mg-b-30"">
                    <h4 class=""tx-15 mg-b-0"">Lista de vacaciones</h4>
                    <div class=""btn-group"" role=""group"" aria-label=""Basic example"">
                        <a href=""#modalActividadVacacionesPeriodos"" data-toggle=""modal"" class=""btn btn-outline-primary btn-sm d-flex align-items-center""><i class=""icon ion-md-time mg-r-5 tx-16 lh--9""></i>ver periodos</a>
                        <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 3103, "\"", 3190, 1);
#line 50 "C:\Luis Martinez backup\Personal\Developments\NET\GrupoSplittel\GrupoSplittel\GestionPersonal\Views\Incidencia\Index.cshtml"
WriteAttributeValue("", 3110, Url.Action("Create","IncidenciaVacacion", new { id = Model.persona.IdPersona }), 3110, 80, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(3191, 261, true);
            WriteLiteral(@" class=""btn btn-outline-primary btn-sm d-flex align-items-center""><i class=""icon ion-md-time mg-r-5 tx-16 lh--9""></i>Crear nuevo</a>
                    </div>
                </div>
            </div>
            <div id=""table-permisos"">
                ");
            EndContext();
            BeginContext(3452, 71, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("partial", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "adaf686658e04b8f9bd95eb7093bb6d5", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.PartialTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Name = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
#line 55 "C:\Luis Martinez backup\Personal\Developments\NET\GrupoSplittel\GrupoSplittel\GestionPersonal\Views\Incidencia\Index.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Model = Model.vacaciones;

#line default
#line hidden
            __tagHelperExecutionContext.AddTagHelperAttribute("model", __Microsoft_AspNetCore_Mvc_TagHelpers_PartialTagHelper.Model, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(3523, 1121, true);
            WriteLiteral(@"
            </div>
        </div>
    </div>
    <div class=""modal calendar-modal-create fade effect-scale"" id=""modalActividadVacacionesPeriodos"" role=""dialog"" data-backdrop=""false"" aria-hidden=""true"">
        <div class=""modal-dialog modal-dialog-centered"" role=""document"">
            <div class=""modal-content"">
                <div class=""modal-body pd-20 pd-sm-30"">
                    <button type=""button"" class=""close pos-absolute t-20 r-20"" data-dismiss=""modal"" aria-label=""Close"">
                        <span aria-hidden=""true""><i data-feather=""x""></i></span>
                    </button>
                    <h5 class=""tx-18 tx-sm-20 mg-b-20 mg-sm-b-30"">Periodos de vacaciones</h5>

                    <div id=""content_vacacionesAcitivitdssdfsdf"">
                        <table class=""table"">
                            <thead>
                                <tr>
                                    <th>Periodo</th>
                                    <th>Dias</th>
                   ");
            WriteLiteral("             </tr>\r\n                            </thead>\r\n\r\n                            <tbody>\r\n");
            EndContext();
#line 78 "C:\Luis Martinez backup\Personal\Developments\NET\GrupoSplittel\GrupoSplittel\GestionPersonal\Views\Incidencia\Index.cshtml"
                                 foreach (var item in periodos)
                                {

#line default
#line hidden
            BeginContext(4744, 86, true);
            WriteLiteral("                                    <tr>\r\n                                        <td>");
            EndContext();
            BeginContext(4831, 18, false);
#line 81 "C:\Luis Martinez backup\Personal\Developments\NET\GrupoSplittel\GrupoSplittel\GestionPersonal\Views\Incidencia\Index.cshtml"
                                       Write(item.NumeroPeriodo);

#line default
#line hidden
            EndContext();
            BeginContext(4849, 59, true);
            WriteLiteral("</td>\r\n                                        <td><strong>");
            EndContext();
            BeginContext(4909, 19, false);
#line 82 "C:\Luis Martinez backup\Personal\Developments\NET\GrupoSplittel\GrupoSplittel\GestionPersonal\Views\Incidencia\Index.cshtml"
                                               Write(item.DiasAprobadors);

#line default
#line hidden
            EndContext();
            BeginContext(4928, 25, true);
            WriteLiteral("</strong><span> / </span>");
            EndContext();
            BeginContext(4954, 15, false);
#line 82 "C:\Luis Martinez backup\Personal\Developments\NET\GrupoSplittel\GrupoSplittel\GestionPersonal\Views\Incidencia\Index.cshtml"
                                                                                            Write(item.DiasUsados);

#line default
#line hidden
            EndContext();
            BeginContext(4969, 50, true);
            WriteLiteral("</td>\r\n                                    </tr>\r\n");
            EndContext();
#line 84 "C:\Luis Martinez backup\Personal\Developments\NET\GrupoSplittel\GrupoSplittel\GestionPersonal\Views\Incidencia\Index.cshtml"
                                }

#line default
#line hidden
            BeginContext(5054, 2543, true);
            WriteLiteral(@"                            </tbody>
                        </table>
                    </div>
                </div><!-- modal-body -->
                <div class=""modal-footer"">
                    <a href="""" class=""btn btn-secondary"" data-dismiss=""modal"">Cerrar</a>
                </div><!-- modal-footer -->
            </div><!-- modal-content -->
        </div><!-- modal-dialog -->
    </div><!-- modal -->

    <div class=""modal calendar-modal-create fade effect-scale"" id=""modalActividadVacaciones"" role=""dialog"" data-backdrop=""false"" aria-hidden=""true"">
        <div class=""modal-dialog modal-dialog-centered"" role=""document"">
            <div class=""modal-content"">
                <div class=""modal-body pd-20 pd-sm-30"">
                    <button type=""button"" class=""close pos-absolute t-20 r-20"" data-dismiss=""modal"" aria-label=""Close"">
                        <span aria-hidden=""true""><i data-feather=""x""></i></span>
                    </button>
                    <h5 class=""tx-18 tx");
            WriteLiteral(@"-sm-20 mg-b-20 mg-sm-b-30"">Actividad solicitud de vacaciones</h5>

                    <div id=""content_vacacionesAcitivit""></div>
                </div><!-- modal-body -->
                <div class=""modal-footer"">
                    <a href="""" class=""btn btn-secondary"" data-dismiss=""modal"">Cerrar</a>
                </div><!-- modal-footer -->
            </div><!-- modal-content -->
        </div><!-- modal-dialog -->
    </div><!-- modal -->

    <div class=""modal calendar-modal-create fade effect-scale"" id=""modalActividadPermisos"" role=""dialog"" data-backdrop=""false"" aria-hidden=""true"">
        <div class=""modal-dialog modal-dialog-centered"" role=""document"">
            <div class=""modal-content"">
                <div class=""modal-body pd-20 pd-sm-30"">
                    <button type=""button"" class=""close pos-absolute t-20 r-20"" data-dismiss=""modal"" aria-label=""Close"">
                        <span aria-hidden=""true""><i data-feather=""x""></i></span>
                    </button>
       ");
            WriteLiteral(@"             <h5 class=""tx-18 tx-sm-20 mg-b-20 mg-sm-b-30"">Actividad solicitud de permiso</h5>

                    <div id=""content_permisoAcitivit""></div>
                </div><!-- modal-body -->
                <div class=""modal-footer"">
                    <a href="""" class=""btn btn-secondary"" data-dismiss=""modal"">Cerrar</a>
                </div><!-- modal-footer -->
            </div><!-- modal-content -->
        </div><!-- modal-dialog -->
    </div><!-- modal -->
</div>
");
            EndContext();
            DefineSection("Scripts", async() => {
                BeginContext(7615, 350, true);
                WriteLiteral(@"
    <script>
        var app_incidencias = new Vue({
            el: ""#app_incidencias"",
            data: {},
            mounted() { },
            methods: {
                ActividadVacacion: async function (id) {
                    document.getElementById(""content_vacacionesAcitivit"").innerHTML = """";
                    axios.post('");
                EndContext();
                BeginContext(7966, 44, false);
#line 141 "C:\Luis Martinez backup\Personal\Developments\NET\GrupoSplittel\GrupoSplittel\GestionPersonal\Views\Incidencia\Index.cshtml"
                           Write(Url.Action("Actividad","IncidenciaVacacion"));

#line default
#line hidden
                EndContext();
                BeginContext(8010, 907, true);
                WriteLiteral(@"/' + id, null, null).then(response => {
                        //bootbox.alert(response.data);
                        document.getElementById(""content_vacacionesAcitivit"").innerHTML = response.data;
                        //ShowMessageErrorShort(""Datos del personales empleado guardados"", ""success"")
                    }).catch(error => {
                        if (error.response) {
                            if (error.response.status === 400) {

                            }
                        }
                        console.error(error);
                        ShowMessageErrorShort(""Error al obtener la actividad de este permiso"", ""error"")
                    }).finally()

                },
                ActividadPermisos: async function (id) {
                    document.getElementById(""content_permisoAcitivit"").innerHTML = """";
                    axios.post('");
                EndContext();
                BeginContext(8918, 43, false);
#line 158 "C:\Luis Martinez backup\Personal\Developments\NET\GrupoSplittel\GrupoSplittel\GestionPersonal\Views\Incidencia\Index.cshtml"
                           Write(Url.Action("Actividad","IncidenciaPermiso"));

#line default
#line hidden
                EndContext();
                BeginContext(8961, 768, true);
                WriteLiteral(@"/' + id, null, null).then(response => {
                        //bootbox.alert(response.data);
                        document.getElementById(""content_permisoAcitivit"").innerHTML = response.data;
                        //ShowMessageErrorShort(""Datos del personales empleado guardados"", ""success"")
                    }).catch(error => {
                        if (error.response) {
                            if (error.response.status === 400) {

                            }
                        }
                        console.error(error);
                        ShowMessageErrorShort(""Error al obtener la actividad de este permiso"", ""error"")
                    }).finally()

                }
            }
        });
    </script>
");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<GestionPersonal.Models.Incidencias> Html { get; private set; }
    }
}
#pragma warning restore 1591
