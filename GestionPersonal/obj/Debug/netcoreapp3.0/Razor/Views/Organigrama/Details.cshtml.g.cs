#pragma checksum "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Organigrama\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "558104141a39ec01dd155db47c7294fe4547747e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Organigrama_Details), @"mvc.1.0.view", @"/Views/Organigrama/Details.cshtml")]
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
#nullable restore
#line 1 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\_ViewImports.cshtml"
using GestionPersonal;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\_ViewImports.cshtml"
using GestionPersonal.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"558104141a39ec01dd155db47c7294fe4547747e", @"/Views/Organigrama/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"44f628e23a2086c1f04f862587f80afdb82e0a32", @"/Views/_ViewImports.cshtml")]
    public class Views_Organigrama_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<GPSInformation.Models.OrganigramaVersion>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Organigrama\Details.cshtml"
  
    ViewData["Title"] = "detalle organigrama: " + string.Format("OR-{0:0000}", Model.IdOrganigramaVersion);

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<style>
    .maman {
        color: green;
        width: 60px;
        border: 1px solid #fff;
        text-align: center;
    }

    .google-visualization-orgchart-lineleft {
        border-left: 2px solid #333 !important;
    }

    .google-visualization-orgchart-linebottom {
        border-bottom: 2px solid #333 !important;
    }

    .google-visualization-orgchart-lineright {
        border-right: 2px solid #333 !important;
    }

    .maman img {
        clear: both;
        display: block;
        margin: auto;
    }

    .google-visualization-orgchart-node {
        border: 2px solid #b7ccd75c;
        background: -webkit-gradient(linear, left top, left bottom, from(#edf7ff), to(#cde7ee));
    }

    .google-visualization-orgchart-nodesel {
        border: 2px solid #e3ca4b;
        background-color: #fff7ae;
        background: -webkit-gradient(linear, left top, left bottom, from(#fff7ae), to(#eee79e));
    }

    .contenedororg {
        overflow-x: scroll;
 ");
            WriteLiteral(@"       overflow-y: scroll;
        /*height: 80px;*/
        /*white-space: pre-wrap;*/
        height: 100%;
        width: 100%;
    }

    .content-components {
        height: 100%;
    }

    .container-fluid {
        height: 100%;
    }

    .google-visualization-orgchart-table * {
        margin: 0;
        padding: 2px 10px 2px 10px !important;
    }
</style>


<div id=""app_organigrama"" class=""contenedororg"">
    <div class=""d-sm-flex align-items-center justify-content-between mg-b-20 mg-lg-b-25 mg-xl-b-30"">
        <div>
            <nav aria-label=""breadcrumb"">
                <ol class=""breadcrumb breadcrumb-style1 mg-b-10"">
                    <li class=""breadcrumb-item"" aria-current=""page""><a");
            BeginWriteAttribute("href", " href=\"", 1931, "\"", 1972, 1);
#nullable restore
#line 72 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Organigrama\Details.cshtml"
WriteAttributeValue("", 1938, Url.Action("Index","Organigrama"), 1938, 34, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Lista de versiones</a> </li>\r\n                    <li class=\"breadcrumb-item active\" aria-current=\"page\">");
#nullable restore
#line 73 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Organigrama\Details.cshtml"
                                                                      Write(ViewData["Title"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n                </ol>\r\n            </nav>\r\n            <h4 class=\"mg-b-0 tx-spacing--1 \">");
#nullable restore
#line 76 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Organigrama\Details.cshtml"
                                         Write(ViewData["Title"]);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </h4>\r\n");
#nullable restore
#line 77 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Organigrama\Details.cshtml"
             if (Model.Autirizada == 2)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <h5>Organigrama vigente</h5>\r\n");
#nullable restore
#line 80 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Organigrama\Details.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n        <div class=\"d-none d-md-block\">\r\n            <div class=\"btn-group btn-group-sm\" role=\"group\" aria-label=\"Basic example\">\r\n\r\n            </div>\r\n        </div>\r\n    </div>\r\n");
#nullable restore
#line 89 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Organigrama\Details.cshtml"
     if ((int)ViewBag.CountNodes == 0)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"        <div class=""alert alert-warning  col-md-12"" role=""alert"">
            <h4 class=""alert-heading"">Estimado usuarior</h4>
            <p>Este organigrama aun no cuenta con puestos</p>
            <hr>
            <p class=""mb-0"">Atte: Sistema Gestión de Personal.</p>
        </div>
");
#nullable restore
#line 97 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Organigrama\Details.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    <div id=""chart_div""></div>
    <div id=""offCanvas1"" class=""off-canvas off-canvas-overlay off-canvas-right wd-350"">
        <a href=""#"" class=""close""><i data-feather=""x""></i></a>
        <div class=""pd-25 ht-100p tx-13"" id=""contec_nodeItem"">
            Selecciona un puesto para ver sus detalles
        </div>
    </div><!-- off-canvas -->
    <div class=""modal fade"" id=""modal1"" tabindex=""-1"" role=""dialog"" aria-labelledby=""exampleModalLabel"" aria-hidden=""true"">
        <div class=""modal-dialog"" role=""document"">
            <div class=""modal-content tx-14"">
                <div class=""modal-header"">
                    <h6 class=""modal-title"" id=""exampleModalLabel"">Crear version en base al organigrama: ");
#nullable restore
#line 109 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Organigrama\Details.cshtml"
                                                                                                    Write(string.Format("OR-{0:0000}", Model.IdOrganigramaVersion));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"</h6>
                    <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
                        <span aria-hidden=""true"">&times;</span>
                    </button>
                </div>
                <div class=""modal-body"">
                    <div class=""form-group"">
                        <label>Crear en base a la version:</label>
                        <input type=""text"" readonly class=""form-control""");
            BeginWriteAttribute("value", " value=\"", 4118, "\"", 4183, 1);
#nullable restore
#line 117 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Organigrama\Details.cshtml"
WriteAttributeValue("", 4126, string.Format("OR-{0:0000}", Model.IdOrganigramaVersion), 4126, 57, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" />
                    </div>
                    <div class=""form-group"">
                        <label>Comentarios</label>
                        <textarea v-model=""comentarios"" rows=""8"" placeholder=""Introduce comentarios para poder continuar"" class=""form-control""></textarea>
                    </div>
                </div>
                <div class=""modal-footer"">
                    <button type=""button"" class=""btn btn-secondary tx-13"" data-dismiss=""modal"">Cerrar</button>
                    <button type=""button"" class=""btn btn-primary tx-13"" v-if=""comentarios.length > 0"" v-on:click=""OrgCopyTo()"">Crear copia</button>
                </div>
            </div>
        </div>
    </div>
    <div class=""modal fade"" id=""modal2"" tabindex=""-1"" role=""dialog"" aria-labelledby=""exampleModalLabel"" aria-hidden=""true"">
        <div class=""modal-dialog"" role=""document"">
            <div class=""modal-content tx-14"">
                <div class=""modal-header"">
                    <h6 class=""modal-tit");
            WriteLiteral(@"le"" id=""exampleModalLabel"">Crer nueva versión desde cero</h6>
                    <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
                        <span aria-hidden=""true"">&times;</span>
                    </button>
                </div>
                <div class=""modal-body"">
                    <div class=""form-group"">
                        <label>Comentarios</label>
                        <textarea v-model=""comentarios2"" placeholder=""Introduce comentarios para poder continuar"" rows=""8"" class=""form-control""></textarea>
                    </div>
                </div>
                <div class=""modal-footer"">
                    <button type=""button"" class=""btn btn-secondary tx-13"" data-dismiss=""modal"">Cerrar</button>
                    <button type=""button"" class=""btn btn-primary tx-13"" v-if=""comentarios2.length > 0"" v-on:click=""OrgCreate()"">Crear nuevo</button>
                </div>
            </div>
        </div>
    </div>
</div>
<button ");
            WriteLiteral("href=\"#\" onclick=\"window.location.reload()\" style=\"display: none\" id=\"btn_refrescar\" type=\"button\" class=\"btn btn-white\"><i class=\"icon ion-md-time mg-r-5 tx-16 lh--9\"></i>Refrescar</button>\r\n\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"
    <script type=""text/javascript"" src=""https://www.gstatic.com/charts/loader.js""></script>
    <script>
        $(function () {
            'use strict'

            // The code below is for demo purposes only.
            // For you to not be confused, please refer to
            // Off-Canvas starter template in Collections

            $('.off-canvas-menu').on('click', function (e) {
                e.preventDefault();
                var target = $(this).attr('href');
                $(target).addClass('show');
                window.localStorage.setItem('ShowDetailsPuesto', 'true');
            });


            $('.off-canvas .close').on('click', function (e) {
                e.preventDefault();
                $(this).closest('.off-canvas').removeClass('show');
                //app_ActivoDetailsPublic.refresh()
                window.localStorage.setItem('ShowDetailsPuesto', 'false');
            })

            $('#btnP_cancela').on('click', function (e) {
               ");
                WriteLiteral(@" e.stopPropagation();
                //app_ActivoDetailsPublic.refresh()
                // closing of sidebar menu when clicking outside of it
                if (!$(e.target).closest('.off-canvas-menu').length) {
                    var offCanvas = $(e.target).closest('.off-canvas').length;
                    if (!offCanvas) {
                        $('.off-canvas.show').removeClass('show');
                    }
                }
            });


        });
    </script>
    <script type=""text/javascript"">

        var app_organigrama = new Vue({
            el: ""#app_organigrama"",
            data: {
                idOrganigramaVersion: '");
#nullable restore
#line 201 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Organigrama\Details.cshtml"
                                  Write(Model.IdOrganigramaVersion);

#line default
#line hidden
#nullable disable
                WriteLiteral(@"',
                data: [],
                chart: null,
                dataChart: [],
                comentarios: '',
                comentarios2: '',
                selected: ''
            },
            async mounted() {
                this.LoadChart()
                if (window.localStorage.getItem('ShowDetailsPuesto') == null && window.localStorage.getItem('ShowDetailsPuesto') == undefined) {
                    window.localStorage.setItem('ShowDetailsPuesto', 'false');
                }

                if (window.localStorage.getItem('ShowDetailsPuesto') == 'true') {
                    $('#offCanvas1').addClass('show');

                } else {

                }
            },
            methods: {
                
                LoadChart: async function () {
                    await this.GetEstructura();
                    google.charts.load('current', { packages: [""orgchart""] });
                    google.charts.setOnLoadCallback(this.StartChartOrg);
       ");
                WriteLiteral(@"         },
                process: async function () {
                    var vacios = document.getElementsByClassName(""nodeHide"")
                    for (var i = 0; i < vacios.length; i++) {
                        document.getElementsByClassName(""nodeHide"")[i].parentElement.colSpan = 3

                        var clone = document.getElementsByClassName(""nodeHide"")[i].parentElement.cloneNode();
                        var normal = document.getElementsByClassName(""nodeHide"")[i].parentElement;

                        clone.classList = []
                        normal.classList = []

                        normal.classList.add(""google-visualization-orgchart-linenode"")
                        normal.classList.add(""google-visualization-orgchart-lineleft"")

                        //class=""google-visualization-orgchart-linenode google-visualization-orgchart-lineleft""
                        document.getElementsByClassName(""nodeHide"")[i].parentElement.parentElement.insertBefore(clone, normal");
                WriteLiteral(@")
                    }
                },
                GetEstructura: async function () {
                    ShowMessageErrorShort(""Obteniendo cambios del organigrama"",""success"")
                    let params = new URLSearchParams();
                    params.append('IdVersion', this.idOrganigramaVersion);
                    await axios.post('");
#nullable restore
#line 251 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Organigrama\Details.cshtml"
                                 Write(Url.Action("GetNodes","Organigrama"));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"', params, null).then(response => {
                        this.data = response.data
                        console.log(this.data);

                    }).catch(error => {
                        GlobalValidAxios(error)
                    }).finally()
                },
                StartChartOrg: async function () {
                    this.dataChart = new google.visualization.DataTable();
                    this.dataChart.addColumn('string', 'Name');
                    this.dataChart.addColumn('string', 'Manager');
                    this.dataChart.addColumn('string', 'ToolTip');
                    var rows = [];

                    this.data.forEach((e,i) => {

                                                if (e.idPuestoParent == 0) {
                            rows.push(
                                [
                                    {
                                        'v': 'uid_' + e.idPuesto,
                                        'f': e.dpu + '<div href");
                WriteLiteral(@"=""#offCanvas3"" id=""uid_' + e.idPuesto + '"" style=""color:blue; font-style:italic"" class=""mn-ht-0 off-canvas-menu"">' + e.descripcion + '</div>'
                                    },
                                    '',
                                    e.descripcion
                                ]
                            );
                        } else {
                            if (e.nivel != 0) {
                                var nivel = (e.nivel - 1);
                                var parent = e.idPuestoParent;
                                var idPuesto = e.idPuesto ;
                                for (var i = nivel; i >= 0; i--){
                                    if (i == 0)
                                    {
                                        rows.push(
                                            [
                                                {
                                                    'v': 'uid_' + e.idPuesto,
                              ");
                WriteLiteral(@"                      'f': e.dpu + '<div id=""uid_' + e.idPuesto + '"" style=""color:blue; font-style:italic"">' + e.descripcion + '</div>'
                                                },
                                                'uid_' + parent,
                                                e.descripcion
                                            ]
                                        );
                                    }
                                    else
                                    {
                                        rows.push(
                                            [
                                                {
                                                    'v': 'uid_' + e.idPuesto + '_' + i,
                                                    'f': '<div class=""nodeHide""></div>'
                                                },
                                                'uid_' + parent,
                                                '");
                WriteLiteral(@"'
                                            ]
                                        );
                                        parent = e.idPuesto + '_' + i;
                                    }
                                }
                            } else {
                                rows.push(
                                    [
                                        {
                                            'v': 'uid_' + e.idPuesto,
                                            'f': e.dpu + '<div id=""uid_' + e.idPuesto + '"" style=""color:blue; font-style:italic"">' + e.descripcion + '</div>'
                                        },
                                        'uid_' + e.idPuestoParent,
                                        e.descripcion
                                    ]
                                );
                            }
                        }
                    })


                    this                    .dataChart.addRows");
                WriteLiteral(@"(rows)
                    // Create the chart.
                    this.chart = new google.visualization.OrgChart(document.getElementById('chart_div'));
                    google.visualization.events.addListener(this.chart, 'collapse', this.process);
                    // Draw the chart, setting the allowHtml option to true for the tooltips.
                    this.chart.draw(this.dataChart, { 'allowHtml': true, 'allowCollapse': true });



                    this.process();
                }
            }
        });
    </script>
");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<GPSInformation.Models.OrganigramaVersion> Html { get; private set; }
    }
}
#pragma warning restore 1591
