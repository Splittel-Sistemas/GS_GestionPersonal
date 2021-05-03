#pragma checksum "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\ProduccionV4\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "74e25ebf3ba42c2136a6f629643a2fc87c22a818"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_ProduccionV4_Index), @"mvc.1.0.view", @"/Views/ProduccionV4/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/ProduccionV4/Index.cshtml", typeof(AspNetCore.Views_ProduccionV4_Index))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"74e25ebf3ba42c2136a6f629643a2fc87c22a818", @"/Views/ProduccionV4/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"44f628e23a2086c1f04f862587f80afdb82e0a32", @"/Views/_ViewImports.cshtml")]
    public class Views_ProduccionV4_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<GPSInformation.Reportes.ProduccionV3.ReporteProd>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("value", "0", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(57, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\ProduccionV4\Index.cshtml"
  
    ViewData["Title"] = "Reporte: " + Model.Inicio.ToString("F");
    List<GPSInformation.Reportes.ProduccionV3.PermisosBloq> Permisos = (List<GPSInformation.Reportes.ProduccionV3.PermisosBloq>)ViewBag.Permisos;

#line default
#line hidden
            BeginContext(280, 137, true);
            WriteLiteral("<div id=\"app_reprteprod\">\r\n    <div class=\"d-flex align-items-center justify-content-between mg-b-30\">\r\n        <h4 class=\"tx-15 mg-b-0\">");
            EndContext();
            BeginContext(418, 17, false);
#line 9 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\ProduccionV4\Index.cshtml"
                            Write(ViewData["Title"]);

#line default
#line hidden
            EndContext();
            BeginContext(435, 124, true);
            WriteLiteral("</h4>\r\n        <div class=\"btn-group\" role=\"group\" aria-label=\"Basic example\">\r\n            <h2 class=\"tx-15 mg-b-0\"></h2>\r\n");
            EndContext();
#line 12 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\ProduccionV4\Index.cshtml"
             if (Permisos.Find(a => a.IdSubModulo == 1048).Autorization)
            {
                

#line default
#line hidden
#line 14 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\ProduccionV4\Index.cshtml"
                 if (Model.EmpleadoProds.Count(item => (item.Accessos.Count(a => a.Activo) % 2) != 0 || item.JornadaGrupos.Count <= 0) == 0)
                {

#line default
#line hidden
            BeginContext(809, 171, true);
            WriteLiteral("                    <a href=\"#\" v-on:click=\"CrearCorte()\" class=\"btn btn-outline-primary btn-sm d-flex align-items-center\"><i data-feather=\"scissors\"></i>Crear Corte</a>\r\n");
            EndContext();
#line 17 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\ProduccionV4\Index.cshtml"
                }

#line default
#line hidden
#line 17 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\ProduccionV4\Index.cshtml"
                 
            }

#line default
#line hidden
            BeginContext(1014, 14, true);
            WriteLiteral("            <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 1028, "\"", 1111, 1);
#line 19 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\ProduccionV4\Index.cshtml"
WriteAttributeValue("", 1035, Url.Action("DescargarReporte", "produccionv4", new {Inicio = Model.Inicio}), 1035, 76, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1112, 124, true);
            WriteLiteral(" title=\"Exportar Reporte\" class=\"btn btn-outline-primary btn-sm d-flex align-items-center\"><i data-feather=\"file\"></i></a>\r\n");
            EndContext();
#line 20 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\ProduccionV4\Index.cshtml"
             if (Permisos.Find(a => a.IdSubModulo == 1048).Autorization)
            {

#line default
#line hidden
            BeginContext(1325, 180, true);
            WriteLiteral("                <a href=\"#modal2\" data-toggle=\"modal\" title=\"Admistrar Permisos\" class=\"btn btn-outline-primary btn-sm d-flex align-items-center\"><i data-feather=\"users\"></i></a>\r\n");
            EndContext();
#line 23 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\ProduccionV4\Index.cshtml"
            }

#line default
#line hidden
            BeginContext(1520, 12, true);
            WriteLiteral("            ");
            EndContext();
#line 24 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\ProduccionV4\Index.cshtml"
             if (Permisos.Find(a => a.IdSubModulo == 1048).Autorization || Permisos.Find(a => a.IdSubModulo == 1052).Autorization)
            {

#line default
#line hidden
            BeginContext(1667, 18, true);
            WriteLiteral("                <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 1685, "\"", 1769, 1);
#line 26 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\ProduccionV4\Index.cshtml"
WriteAttributeValue("", 1692, Url.Action("Index", "produccionv4", new {Inicio = Model.Inicio.AddDays(-7)}), 1692, 77, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1770, 153, true);
            WriteLiteral(" title=\"Ver semana anterior\" class=\"btn btn-outline-primary btn-sm d-flex align-items-center\"><i data-feather=\"chevron-left\"></i></a>\r\n                <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 1923, "\"", 2006, 1);
#line 27 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\ProduccionV4\Index.cshtml"
WriteAttributeValue("", 1930, Url.Action("Index", "produccionv4", new {Inicio = Model.Inicio.AddDays(7)}), 1930, 76, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(2007, 137, true);
            WriteLiteral(" title=\"Ver siguiente semana\" class=\"btn btn-outline-primary btn-sm d-flex align-items-center\"><i data-feather=\"chevron-right\"></i></a>\r\n");
            EndContext();
#line 28 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\ProduccionV4\Index.cshtml"
            }

#line default
#line hidden
            BeginContext(2159, 40, true);
            WriteLiteral("        </div>\r\n    </div>\r\n    <hr />\r\n");
            EndContext();
#line 32 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\ProduccionV4\Index.cshtml"
     if (DateTime.Now >= Model.Inicio && DateTime.Now <= Model.Fin)
    {

#line default
#line hidden
            BeginContext(2275, 133, true);
            WriteLiteral("        <div class=\"alert alert-success\" role=\"alert\">\r\n            <h4 class=\"alert-heading\">Semana en curso!</h4>\r\n        </div>\r\n");
            EndContext();
#line 37 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\ProduccionV4\Index.cshtml"
    }
    else
    {

#line default
#line hidden
            BeginContext(2432, 138, true);
            WriteLiteral("        <div class=\"alert alert-danger\" role=\"alert\">\r\n            <h4 class=\"alert-heading\">Semana fuera de curso!</h4>\r\n        </div>\r\n");
            EndContext();
#line 43 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\ProduccionV4\Index.cshtml"
    }

#line default
#line hidden
            BeginContext(2577, 93, true);
            WriteLiteral("    <hr />\r\n    <div>\r\n        <dl class=\"dl-horizontal\">\r\n            <dt>\r\n                ");
            EndContext();
            BeginContext(2671, 42, false);
#line 48 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\ProduccionV4\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Inicio));

#line default
#line hidden
            EndContext();
            BeginContext(2713, 55, true);
            WriteLiteral("\r\n            </dt>\r\n            <dd>\r\n                ");
            EndContext();
            BeginContext(2769, 26, false);
#line 51 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\ProduccionV4\Index.cshtml"
           Write(Model.Inicio.ToString("F"));

#line default
#line hidden
            EndContext();
            BeginContext(2795, 55, true);
            WriteLiteral("\r\n            </dd>\r\n            <dt>\r\n                ");
            EndContext();
            BeginContext(2851, 39, false);
#line 54 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\ProduccionV4\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Fin));

#line default
#line hidden
            EndContext();
            BeginContext(2890, 55, true);
            WriteLiteral("\r\n            </dt>\r\n            <dd>\r\n                ");
            EndContext();
            BeginContext(2946, 23, false);
#line 57 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\ProduccionV4\Index.cshtml"
           Write(Model.Fin.ToString("F"));

#line default
#line hidden
            EndContext();
            BeginContext(2969, 672, true);
            WriteLiteral(@"
            </dd>
        </dl>
        <hr />
    </div>
    <table class=""table table-responsive-sm table-sm table-hover"">
        <thead>
            <tr>
                <th>
                    no.Nomina
                </th>
                <th>
                    Nombre
                </th>
                <th>
                    Puesto
                </th>
                <th>
                    Turno Actual
                </th>
                <th>
                    Hrs.Score
                </th>
                <th>

                </th>
                <th></th>
            </tr>
        </thead>
        <tbody>
");
            EndContext();
#line 87 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\ProduccionV4\Index.cshtml"
             foreach (var item in Model.EmpleadoProds)
            {

#line default
#line hidden
            BeginContext(3712, 72, true);
            WriteLiteral("                <tr>\r\n                    <td>\r\n                        ");
            EndContext();
            BeginContext(3785, 47, false);
#line 91 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\ProduccionV4\Index.cshtml"
                   Write(Html.DisplayFor(modelItem => item.NumeroNomina));

#line default
#line hidden
            EndContext();
            BeginContext(3832, 79, true);
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
            EndContext();
            BeginContext(3912, 49, false);
#line 94 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\ProduccionV4\Index.cshtml"
                   Write(Html.DisplayFor(modelItem => item.NombreCompleto));

#line default
#line hidden
            EndContext();
            BeginContext(3961, 79, true);
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
            EndContext();
            BeginContext(4041, 47, false);
#line 97 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\ProduccionV4\Index.cshtml"
                   Write(Html.DisplayFor(modelItem => item.PuestoNombre));

#line default
#line hidden
            EndContext();
            BeginContext(4088, 55, true);
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n");
            EndContext();
#line 100 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\ProduccionV4\Index.cshtml"
                         if (item.GrupoCambios.Count == 0)
                        {

#line default
#line hidden
            BeginContext(4230, 80, true);
            WriteLiteral("                            <span class=\"badge badge-default\">Sin turno</span>\r\n");
            EndContext();
#line 103 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\ProduccionV4\Index.cshtml"
                        }
                        else
                        {
                            var JornadaGrupos = item.JornadaGrupos.Find(a => DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd")) == DateTime.Parse(a.Fecha.ToString("yyyy-MM-dd")));
                            if (JornadaGrupos != null)
                            {

#line default
#line hidden
            BeginContext(4663, 37, true);
            WriteLiteral("                                <span");
            EndContext();
            BeginWriteAttribute("class", " class=\"", 4700, "\"", 4837, 3);
            WriteAttributeValue("", 4708, "badge", 4708, 5, true);
            WriteAttributeValue(" ", 4713, "badge-", 4714, 7, true);
#line 109 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\ProduccionV4\Index.cshtml"
WriteAttributeValue("", 4720, Html.Raw(JornadaGrupos.GrupoName == "Gris" ? "secondary" : JornadaGrupos.GrupoName == "Rojo" ? "danger" : "success"), 4720, 117, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(4838, 7, true);
            WriteLiteral(">Grupo ");
            EndContext();
            BeginContext(4846, 23, false);
#line 109 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\ProduccionV4\Index.cshtml"
                                                                                                                                                                                 Write(JornadaGrupos.GrupoName);

#line default
#line hidden
            EndContext();
            BeginContext(4869, 9, true);
            WriteLiteral("</span>\r\n");
            EndContext();
#line 110 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\ProduccionV4\Index.cshtml"
                            }
                            else
                            {

#line default
#line hidden
            BeginContext(4974, 92, true);
            WriteLiteral("                                <span class=\"badge badge-warning\">Dia no encontrado</span>\r\n");
            EndContext();
#line 114 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\ProduccionV4\Index.cshtml"
                            }
                        }

#line default
#line hidden
            BeginContext(5124, 53, true);
            WriteLiteral("                    </td>\r\n                    <td>\r\n");
            EndContext();
#line 118 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\ProduccionV4\Index.cshtml"
                         if (item.GrupoCambios.Count == 0)
                        {

#line default
#line hidden
            BeginContext(5264, 73, true);
            WriteLiteral("                            <span class=\"badge badge-default\">--</span>\r\n");
            EndContext();
#line 121 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\ProduccionV4\Index.cshtml"
                        }
                        else
                        {

#line default
#line hidden
            BeginContext(5421, 33, true);
            WriteLiteral("                            <span");
            EndContext();
            BeginWriteAttribute("class", " class=\"", 5454, "\"", 5527, 3);
            WriteAttributeValue("", 5462, "badge", 5462, 5, true);
            WriteAttributeValue(" ", 5467, "badge-", 5468, 7, true);
#line 124 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\ProduccionV4\Index.cshtml"
WriteAttributeValue("", 5474, Html.Raw(item.HorasScore > 0 ? "danger" : "success"), 5474, 53, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(5528, 1, true);
            WriteLiteral(">");
            EndContext();
            BeginContext(5530, 41, false);
#line 124 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\ProduccionV4\Index.cshtml"
                                                                                                       Write(Html.DisplayFor(model => item.HorasScore));

#line default
#line hidden
            EndContext();
            BeginContext(5571, 9, true);
            WriteLiteral("</span>\r\n");
            EndContext();
#line 125 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\ProduccionV4\Index.cshtml"
                        }

#line default
#line hidden
            BeginContext(5607, 55, true);
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n");
            EndContext();
#line 129 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\ProduccionV4\Index.cshtml"
                         if (item.GrupoCambios.Count == 0)
                        {

#line default
#line hidden
            BeginContext(5749, 75, true);
            WriteLiteral("                            <span class=\"badge badge-warning\">Info</span>\r\n");
            EndContext();
#line 132 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\ProduccionV4\Index.cshtml"
                        }
                        else
                        {
                            

#line default
#line hidden
#line 135 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\ProduccionV4\Index.cshtml"
                             if ((item.Accessos.Count(a => a.Activo) % 2) != 0 || item.JornadaGrupos.Count <= 0)
                            {

#line default
#line hidden
            BeginContext(6053, 79, true);
            WriteLiteral("                                <span class=\"badge badge-warning\">Info</span>\r\n");
            EndContext();
#line 138 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\ProduccionV4\Index.cshtml"
                            }
                            else
                            {

#line default
#line hidden
            BeginContext(6228, 77, true);
            WriteLiteral("                                <span class=\"badge badge-primary\">Ok</span>\r\n");
            EndContext();
#line 142 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\ProduccionV4\Index.cshtml"
                            }

#line default
#line hidden
#line 142 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\ProduccionV4\Index.cshtml"
                             
                        }

#line default
#line hidden
            BeginContext(6363, 77, true);
            WriteLiteral("                    </td>\r\n                    <td>\r\n                        ");
            EndContext();
            BeginContext(6441, 98, false);
#line 146 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\ProduccionV4\Index.cshtml"
                   Write(Html.ActionLink("Administrar", "Details", new { IdPersona = item.IdPersona, Inicio = item.Incio }));

#line default
#line hidden
            EndContext();
            BeginContext(6539, 52, true);
            WriteLiteral("\r\n                    </td>\r\n                </tr>\r\n");
            EndContext();
#line 149 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\ProduccionV4\Index.cshtml"
            }

#line default
#line hidden
            BeginContext(6606, 898, true);
            WriteLiteral(@"        </tbody>
    </table>

    <div class=""modal fade"" id=""modal2"" role=""dialog"" aria-labelledby=""exampleModalLabel2"" aria-hidden=""true"">
        <div class=""modal-dialog modal-dialog-centered"" role=""document"">
            <div class=""modal-content tx-14"">
                <div class=""modal-header"">
                    <h6 class=""modal-title"" id=""exampleModalLabel2"">Permisos</h6>
                    <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
                        <span aria-hidden=""true"">&times;</span>
                    </button>
                </div>
                <div class=""modal-body"">
                    <div class=""form-group"">
                        <label>Usuario</label>
                        <select class=""form-control select2"" id=""idPersona_per"" onchange=""app_reprteprod.VerPermisos()"">
                            ");
            EndContext();
            BeginContext(7504, 55, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "aa2b397629124574aa0e0df57f98c588", async() => {
                BeginContext(7531, 19, true);
                WriteLiteral("Secciona una opción");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            BeginWriteTagHelperAttribute();
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __tagHelperExecutionContext.AddHtmlAttribute("selected", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.Minimized);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(7559, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 167 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\ProduccionV4\Index.cshtml"
                             foreach (var item in Model.EmpleadoProds.OrderBy(a => a.NombreCompleto))
                            {

#line default
#line hidden
            BeginContext(7695, 32, true);
            WriteLiteral("                                ");
            EndContext();
            BeginContext(7727, 61, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "a808343fa2104d1aa32b631c3b2bab63", async() => {
                BeginContext(7760, 19, false);
#line 169 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\ProduccionV4\Index.cshtml"
                                                           Write(item.NombreCompleto);

#line default
#line hidden
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
            BeginWriteTagHelperAttribute();
#line 169 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\ProduccionV4\Index.cshtml"
                                   WriteLiteral(item.IdPersona);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(7788, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 170 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\ProduccionV4\Index.cshtml"
                            }

#line default
#line hidden
            BeginContext(7821, 1047, true);
            WriteLiteral(@"                        </select>
                    </div>
                    <div class=""form-group"" v-if=""permisos.length > 0"">
                        <label>Permisos</label>
                        <div class=""custom-control custom-checkbox"" v-for=""(item2, index2) in permisos"">
                            <input type=""checkbox"" class=""custom-control-input"" v-model=""item2.autorization"" v-bind:id=""'id_' + item2.idSubModulo"">
                            <label class=""custom-control-label"" v-bind:for=""'id_' + item2.idSubModulo"">{{item2.idSubModulo}}.-{{ item2.descripcion }}</label>
                        </div>
                    </div>
                </div>
                <div class=""modal-footer"">
                    <button type=""button"" class=""btn btn-secondary tx-13"" data-dismiss=""modal"">Cancelar</button>
                    <button type=""button"" class=""btn btn-primary tx-13"" v-on:click=""SavePermisos()"">Guardar cambios</button>
                </div>
            </div>
        </div");
            WriteLiteral(">\r\n    </div>\r\n</div>\r\n");
            EndContext();
            DefineSection("Scripts", async() => {
                BeginContext(8886, 535, true);
                WriteLiteral(@"
    <script>
        var app_reprteprod = new Vue({
            el: ""#app_reprteprod"",
            data: {
                permisos:[]
            },
            mounted() {

            },
            methods: {
                VerPermisos: async function () {
                    var IdPersona = document.getElementById(""idPersona_per"").value
                    const params = new URLSearchParams([
                        ['IdPersona_', IdPersona]
                        ]);
                    await axios.post('");
                EndContext();
                BeginContext(9422, 41, false);
#line 205 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\ProduccionV4\Index.cshtml"
                                 Write(Url.Action("VerPermisos", "produccionv4"));

#line default
#line hidden
                EndContext();
                BeginContext(9463, 534, true);
                WriteLiteral(@"', params, null).then(response => {
                        this.permisos = response.data
                    }).catch(error => {
                        if (error.response) {
                            if (error.response.status === 400) {
                                ShowMessageErrorShort(error.response.data, ""error"")
                            }
                        }
                    }).finally()
                },
                SavePermisos: async function () {

                    await axios.post('");
                EndContext();
                BeginContext(9998, 44, false);
#line 217 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\ProduccionV4\Index.cshtml"
                                 Write(Url.Action("ChangePermisos", "produccionv4"));

#line default
#line hidden
                EndContext();
                BeginContext(10042, 510, true);
                WriteLiteral(@"', this.permisos, null).then(response => {
                        ShowMessageErrorShort(response.data, ""success"")
                    }).catch(error => {
                        if (error.response) {
                            if (error.response.status === 400) {
                                ShowMessageErrorShort(error.response.data, ""error"")
                            }
                        }
                    }).finally()
                }
            }
        });
    </script>
");
                EndContext();
            }
            );
            BeginContext(10553, 1, true);
            WriteLiteral(";");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<GPSInformation.Reportes.ProduccionV3.ReporteProd> Html { get; private set; }
    }
}
#pragma warning restore 1591
