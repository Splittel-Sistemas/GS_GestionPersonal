#pragma checksum "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Organigrama\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7eb82f270f5f0951b9f2484de2cf4061dacfa17d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Organigrama_Index), @"mvc.1.0.view", @"/Views/Organigrama/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7eb82f270f5f0951b9f2484de2cf4061dacfa17d", @"/Views/Organigrama/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"44f628e23a2086c1f04f862587f80afdb82e0a32", @"/Views/_ViewImports.cshtml")]
    public class Views_Organigrama_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<GPSInformation.Models.OrganigramaVersion>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Organigrama\Index.cshtml"
  
    ViewData["Title"] = "Lista de versiones";

#line default
#line hidden
#nullable disable
            WriteLiteral("<div id=\"app_organigrama\">\r\n");
#nullable restore
#line 6 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Organigrama\Index.cshtml"
     if (Model.Where(a => a.Autirizada == 2).ToList().Count <= 0)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"        <div class=""alert alert-warning "" role=""alert"">
            <h4 class=""alert-heading"">Advertencia!</h4>
            <p>Gestión de personal necesita un tener un organigrama autorizado para poder funcionar correctamente, de ello depende que los empleados puedan generar sus solicitudes de vaciones y permisos</p>
            <hr>
            <p class=""mb-0"">Por favor crea un organigrama o autoriza alguno!</p>
        </div>
");
#nullable restore
#line 14 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Organigrama\Index.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
    <div class=""d-sm-flex align-items-center justify-content-between mg-b-20 mg-lg-b-25 mg-xl-b-30"">
        <div>
            <nav aria-label=""breadcrumb"">
                <ol class=""breadcrumb breadcrumb-style1 mg-b-10"">
                    <li class=""breadcrumb-item active"" aria-current=""page"">");
#nullable restore
#line 20 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Organigrama\Index.cshtml"
                                                                      Write(ViewData["Title"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n                </ol>\r\n            </nav>\r\n            <h4 class=\"mg-b-0 tx-spacing--1 \">");
#nullable restore
#line 23 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Organigrama\Index.cshtml"
                                         Write(ViewData["Title"]);

#line default
#line hidden
#nullable disable
            WriteLiteral(@" </h4>
        </div>
        <div class=""d-none d-md-block"">
            <div class=""btn-group btn-group-sm"" role=""group"" aria-label=""Basic example"">
                <a class=""btn btn-sm btn-outline-light"" href=""#modal2"" data-toggle=""modal"" title=""crear una version desde cero""><i data-feather=""plus-square"" class=""wd-10 mg-r-5""></i>Nuevo</a>
            </div>
        </div>
    </div>
    <table class=""table"">
        <thead>
            <tr>
                <th>
                    ");
#nullable restore
#line 35 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Organigrama\Index.cshtml"
               Write(Html.DisplayNameFor(model => model.IdOrganigramaVersion));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
#nullable restore
#line 38 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Organigrama\Index.cshtml"
               Write(Html.DisplayNameFor(model => model.FechaCreacion));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
#nullable restore
#line 41 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Organigrama\Index.cshtml"
               Write(Html.DisplayNameFor(model => model.FechaActualizacion));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
#nullable restore
#line 44 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Organigrama\Index.cshtml"
               Write(Html.DisplayNameFor(model => model.Autirizada));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
#nullable restore
#line 47 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Organigrama\Index.cshtml"
               Write(Html.DisplayNameFor(model => model.Comentarios));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </th>\r\n                <th></th>\r\n            </tr>\r\n        </thead>\r\n        <tbody>\r\n");
#nullable restore
#line 53 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Organigrama\Index.cshtml"
             foreach (var item in Model)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n                    <td>\r\n                        ");
#nullable restore
#line 57 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Organigrama\Index.cshtml"
                   Write(Html.DisplayFor(modelItem => item.IdOrganigramaVersion));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 60 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Organigrama\Index.cshtml"
                   Write(Html.DisplayFor(modelItem => item.FechaCreacion));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 63 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Organigrama\Index.cshtml"
                   Write(Html.DisplayFor(modelItem => item.FechaActualizacion));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n");
#nullable restore
#line 66 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Organigrama\Index.cshtml"
                         if (item.Autirizada == 2)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <span class=\"badge badge-pill badge-primary\">Antorizado</span>\r\n");
#nullable restore
#line 69 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Organigrama\Index.cshtml"
                        }
                        else
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <span class=\"badge badge-pill badge-light\">No Antorizado</span>\r\n");
#nullable restore
#line 73 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Organigrama\Index.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </td>\r\n                    <td>\r\n                        ");
#nullable restore
#line 76 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Organigrama\Index.cshtml"
                   Write(Html.DisplayFor(modelItem => item.Comentarios));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n");
#nullable restore
#line 79 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Organigrama\Index.cshtml"
                         if ((bool)ViewBag.AccesoEdit5)
                        {
                            

#line default
#line hidden
#nullable disable
#nullable restore
#line 81 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Organigrama\Index.cshtml"
                       Write(Html.ActionLink("Editar", "Editor", new { id = item.IdOrganigramaVersion }));

#line default
#line hidden
#nullable disable
#nullable restore
#line 81 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Organigrama\Index.cshtml"
                                                                                                        
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <span>|</span>\r\n");
#nullable restore
#line 84 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Organigrama\Index.cshtml"
                         if ((bool)ViewBag.AccesoEdit4)
                        {
                            

#line default
#line hidden
#nullable disable
#nullable restore
#line 86 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Organigrama\Index.cshtml"
                       Write(Html.ActionLink("Ver", "Details", new { id = item.IdOrganigramaVersion }));

#line default
#line hidden
#nullable disable
#nullable restore
#line 86 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Organigrama\Index.cshtml"
                                                                                                      
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    </td>\r\n                </tr>\r\n");
#nullable restore
#line 90 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Organigrama\Index.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"        </tbody>
    </table>
    <div class=""modal fade"" id=""modal2"" tabindex=""-1"" role=""dialog"" aria-labelledby=""exampleModalLabel"" aria-hidden=""true"">
        <div class=""modal-dialog"" role=""document"">
            <div class=""modal-content tx-14"">
                <div class=""modal-header"">
                    <h6 class=""modal-title"" id=""exampleModalLabel"">Crer nueva versión desde cero</h6>
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
          ");
            WriteLiteral(@"          <button type=""button"" class=""btn btn-secondary tx-13"" data-dismiss=""modal"">Cerrar</button>
                    <button type=""button"" class=""btn btn-primary tx-13"" v-if=""comentarios2.length > 0"" v-on:click=""OrgCreate()"">Crear nuevo</button>
                </div>
            </div>
        </div>
    </div>
</div>

");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"
    <script type=""text/javascript"" src=""https://www.gstatic.com/charts/loader.js""></script>

    <script type=""text/javascript"">

        var app_organigrama = new Vue({
            el: ""#app_organigrama"",
            data: {
                data: [],
                chart: null,
                dataChart: [],
                comentarios: '',
                comentarios2: '',
                selected: ''
            },
            async mounted() {

            },
            methods: {
                OrgCreate: async function () {
                    await axios.post('");
#nullable restore
#line 137 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\Organigrama\Index.cshtml"
                                 Write(Url.Action("OrgCreate", "Organigrama"));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"?Comentario=' + this.comentarios2, null, null).then(response => {
                        ShowMessageErrorShort(""Organigrama creado"",""success"")
                        //document.getElementById(""btn_refrescar"").click();
                        window.location =  response.data;
                        //this.chart.remove(a);
                    }).catch(error => {
                        GlobalValidAxios(error)
                    }).finally()
                }
            }
        });
    </script>
");
            }
            );
            WriteLiteral("\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<GPSInformation.Models.OrganigramaVersion>> Html { get; private set; }
    }
}
#pragma warning restore 1591
