#pragma checksum "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\ProduccionV1\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6bdafc94dade73f0bf7742b1dde1a6e9a931fbe3"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_ProduccionV1_Index), @"mvc.1.0.view", @"/Views/ProduccionV1/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/ProduccionV1/Index.cshtml", typeof(AspNetCore.Views_ProduccionV1_Index))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6bdafc94dade73f0bf7742b1dde1a6e9a931fbe3", @"/Views/ProduccionV1/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"44f628e23a2086c1f04f862587f80afdb82e0a32", @"/Views/_ViewImports.cshtml")]
    public class Views_ProduccionV1_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<GPSInformation.Reportes.Produccion.ReporteProdEmp>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(58, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\ProduccionV1\Index.cshtml"
  
    ViewData["Title"] = "Index";
    DateTime Inicio = Model.Inicio;

#line default
#line hidden
            BeginContext(138, 342, true);
            WriteLiteral(@"<div class=""d-sm-flex align-items-center justify-content-between mg-b-20 mg-lg-b-30"">
    <div>
        <nav aria-label=""breadcrumb"">
            <ol class=""breadcrumb breadcrumb-style1 mg-b-10"">
                <li class=""breadcrumb-item""><a href=""#"">Home</a></li>
                <li class=""breadcrumb-item active"" aria-current=""page"">");
            EndContext();
            BeginContext(481, 17, false);
#line 12 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\ProduccionV1\Index.cshtml"
                                                                  Write(ViewData["Title"]);

#line default
#line hidden
            EndContext();
            BeginContext(498, 83, true);
            WriteLiteral("</li>\r\n            </ol>\r\n        </nav>\r\n        <h4 class=\"mg-b-0 tx-spacing--1\">");
            EndContext();
            BeginContext(582, 17, false);
#line 15 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\ProduccionV1\Index.cshtml"
                                    Write(ViewData["Title"]);

#line default
#line hidden
            EndContext();
            BeginContext(599, 445, true);
            WriteLiteral(@"</h4>
    </div>
    <div class=""d-none d-md-block"">
        <button class=""btn btn-sm pd-x-15 btn-white btn-uppercase"" title=""semana atras""><i data-feather=""chevron-left"" class=""wd-10 mg-r-5""></i> </button>
        <button class=""btn btn-sm pd-x-15 btn-white btn-uppercase mg-l-5"" title=""semana adelante""><i data-feather=""chevron-right"" class=""wd-10 mg-r-5""></i> </button>
    </div>
</div>
<dl class=""dl-horizontal"">
    <dt>
        ");
            EndContext();
            BeginContext(1045, 42, false);
#line 24 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\ProduccionV1\Index.cshtml"
   Write(Html.DisplayNameFor(model => model.Inicio));

#line default
#line hidden
            EndContext();
            BeginContext(1087, 31, true);
            WriteLiteral("\r\n    </dt>\r\n    <dd>\r\n        ");
            EndContext();
            BeginContext(1119, 38, false);
#line 27 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\ProduccionV1\Index.cshtml"
   Write(Html.DisplayFor(model => model.Inicio));

#line default
#line hidden
            EndContext();
            BeginContext(1157, 31, true);
            WriteLiteral("\r\n    </dd>\r\n    <dt>\r\n        ");
            EndContext();
            BeginContext(1189, 39, false);
#line 30 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\ProduccionV1\Index.cshtml"
   Write(Html.DisplayNameFor(model => model.Fin));

#line default
#line hidden
            EndContext();
            BeginContext(1228, 31, true);
            WriteLiteral("\r\n    </dt>\r\n    <dd>\r\n        ");
            EndContext();
            BeginContext(1260, 35, false);
#line 33 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\ProduccionV1\Index.cshtml"
   Write(Html.DisplayFor(model => model.Fin));

#line default
#line hidden
            EndContext();
            BeginContext(1295, 208, true);
            WriteLiteral("\r\n    </dd>\r\n</dl>\r\n<hr />\r\n<table class=\"table\">\r\n    <thead>\r\n        <tr>\r\n            <th>\r\n                No.Nomina\r\n            </th>\r\n            <th>\r\n                Colaborador\r\n            </th>\r\n");
            EndContext();
#line 52 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\ProduccionV1\Index.cshtml"
             while (Inicio <= Model.Fin)
            {

#line default
#line hidden
            BeginContext(1690, 24, true);
            WriteLiteral("        <th colspan=\"1\">");
            EndContext();
            BeginContext(1715, 27, false);
#line 54 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\ProduccionV1\Index.cshtml"
                   Write(Inicio.DayOfWeek.ToString());

#line default
#line hidden
            EndContext();
            BeginContext(1742, 8, true);
            WriteLiteral(" <br /> ");
            EndContext();
            BeginContext(1751, 10, false);
#line 54 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\ProduccionV1\Index.cshtml"
                                                       Write(Inicio.Day);

#line default
#line hidden
            EndContext();
            BeginContext(1761, 7, true);
            WriteLiteral("</th>\r\n");
            EndContext();
#line 55 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\ProduccionV1\Index.cshtml"
                Inicio = Inicio.AddDays(1);
            }

#line default
#line hidden
            BeginContext(1828, 93, true);
            WriteLiteral("            <th>Horas</th>\r\n            <th></th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
            EndContext();
#line 62 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\ProduccionV1\Index.cshtml"
         foreach (var item in Model.Empleados)
        {

#line default
#line hidden
            BeginContext(1980, 62, true);
            WriteLiteral("            <tr>\r\n\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(2043, 47, false);
#line 67 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\ProduccionV1\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.NumeroNomina));

#line default
#line hidden
            EndContext();
            BeginContext(2090, 3, true);
            WriteLiteral(" - ");
            EndContext();
            BeginContext(2094, 44, false);
#line 67 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\ProduccionV1\Index.cshtml"
                                                                  Write(Html.DisplayFor(modelItem => item.IdPersona));

#line default
#line hidden
            EndContext();
            BeginContext(2138, 67, true);
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
            EndContext();
            BeginContext(2206, 41, false);
#line 70 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\ProduccionV1\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.Nombre));

#line default
#line hidden
            EndContext();
            BeginContext(2247, 25, true);
            WriteLiteral("\r\n                </td>\r\n");
            EndContext();
#line 78 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\ProduccionV1\Index.cshtml"
                 foreach (var dia in item.Dias)
                {
                    

#line default
#line hidden
#line 80 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\ProduccionV1\Index.cshtml"
                     if (dia != null)
                    {

#line default
#line hidden
            BeginContext(2632, 18, true);
            WriteLiteral("            <td>\r\n");
            EndContext();
#line 84 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\ProduccionV1\Index.cshtml"
                 if (DateTime.Parse("0001-01-01 00:00:00") != dia.R_Entrada)
                {

#line default
#line hidden
            BeginContext(2823, 25, true);
            WriteLiteral("                    <span");
            EndContext();
            BeginWriteAttribute("class", " class=\"", 2848, "\"", 3044, 2);
            WriteAttributeValue("", 2856, "badge", 2856, 5, true);
#line 86 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\ProduccionV1\Index.cshtml"
WriteAttributeValue(" ", 2861, Html.Raw(dia.GrupoHorario.IdGrupo == 86 ? "badge-secondary" : dia.GrupoHorario.IdGrupo  == 87 ? "badge-danger" : dia.GrupoHorario.IdGrupo  == 88 ? "badge-success" : "badge-warning"), 2862, 182, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(3045, 1, true);
            WriteLiteral(">");
            EndContext();
            BeginContext(3047, 24, false);
#line 86 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\ProduccionV1\Index.cshtml"
                                                                                                                                                                                                                          Write(dia.GrupoHorario.IdGrupo);

#line default
#line hidden
            EndContext();
            BeginContext(3071, 68, true);
            WriteLiteral(" </span><br />\r\n                    <span class=\"badge badge-light\">");
            EndContext();
            BeginContext(3140, 24, false);
#line 87 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\ProduccionV1\Index.cshtml"
                                               Write(dia.GrupoHorario.TipoDia);

#line default
#line hidden
            EndContext();
            BeginContext(3164, 67, true);
            WriteLiteral("</span><br />\r\n                    <span class=\"badge badge-light\">");
            EndContext();
            BeginContext(3232, 45, false);
#line 88 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\ProduccionV1\Index.cshtml"
                                               Write(String.Format("{0:00.0}", dia.HorasAprobadas));

#line default
#line hidden
            EndContext();
            BeginContext(3277, 3, true);
            WriteLiteral(" / ");
            EndContext();
            BeginContext(3281, 40, false);
#line 88 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\ProduccionV1\Index.cshtml"
                                                                                                Write(String.Format("{0:00.0}", dia.HorasMeta));

#line default
#line hidden
            EndContext();
            BeginContext(3321, 67, true);
            WriteLiteral("</span><br />\r\n                    <span class=\"badge badge-light\">");
            EndContext();
            BeginContext(3389, 40, false);
#line 89 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\ProduccionV1\Index.cshtml"
                                               Write(String.Format("{0:00.0}", dia.HorasReal));

#line default
#line hidden
            EndContext();
            BeginContext(3429, 70, true);
            WriteLiteral(" </span><br />\r\n                    <span class=\"badge badge-warning\">");
            EndContext();
            BeginContext(3500, 13, false);
#line 90 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\ProduccionV1\Index.cshtml"
                                                 Write(dia.R_Entrada);

#line default
#line hidden
            EndContext();
            BeginContext(3513, 63, true);
            WriteLiteral("</span>\r\n                    <span class=\"badge badge-warning\">");
            EndContext();
            BeginContext(3577, 12, false);
#line 91 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\ProduccionV1\Index.cshtml"
                                                 Write(dia.R_Salida);

#line default
#line hidden
            EndContext();
            BeginContext(3589, 66, true);
            WriteLiteral("</span><br />\r\n                    <span class=\"badge badge-dark\">");
            EndContext();
            BeginContext(3656, 11, false);
#line 92 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\ProduccionV1\Index.cshtml"
                                              Write(dia.Entrada);

#line default
#line hidden
            EndContext();
            BeginContext(3667, 60, true);
            WriteLiteral("</span>\r\n                    <span class=\"badge badge-dark\">");
            EndContext();
            BeginContext(3728, 10, false);
#line 93 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\ProduccionV1\Index.cshtml"
                                              Write(dia.Salida);

#line default
#line hidden
            EndContext();
            BeginContext(3738, 9, true);
            WriteLiteral("</span>\r\n");
            EndContext();
#line 94 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\ProduccionV1\Index.cshtml"
                     if (dia.GrupoExcepcion != null)
                    {

#line default
#line hidden
            BeginContext(3824, 90, true);
            WriteLiteral("                        <br />\r\n                        <span class=\"badge badge-success\">");
            EndContext();
            BeginContext(3915, 30, false);
#line 97 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\ProduccionV1\Index.cshtml"
                                                     Write(dia.GrupoExcepcion.Comentarios);

#line default
#line hidden
            EndContext();
            BeginContext(3945, 9, true);
            WriteLiteral("</span>\r\n");
            EndContext();
#line 98 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\ProduccionV1\Index.cshtml"
                    }

#line default
#line hidden
            BeginContext(3977, 28, true);
            WriteLiteral("                    <br />\r\n");
            EndContext();
#line 100 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\ProduccionV1\Index.cshtml"
                     if (dia.Logs.Count > 0)
                    {
                        foreach (var item_log in dia.Logs)
                        {

#line default
#line hidden
            BeginContext(4161, 62, true);
            WriteLiteral("                            <span class=\"badge badge-primary\">");
            EndContext();
            BeginContext(4224, 78, false);
#line 104 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\ProduccionV1\Index.cshtml"
                                                         Write(Html.Raw($"{item_log.dtEventReal.ToString("MM-dd HH:mm")} - {item_log.tDesc}"));

#line default
#line hidden
            EndContext();
            BeginContext(4302, 15, true);
            WriteLiteral("</span><br />\r\n");
            EndContext();
#line 105 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\ProduccionV1\Index.cshtml"
                        }
                    }
                    else
                    {

#line default
#line hidden
            BeginContext(4416, 88, true);
            WriteLiteral("                        <span class=\"badge badge-danger\">No hay registros</span><br />\r\n");
            EndContext();
#line 110 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\ProduccionV1\Index.cshtml"
                    }

#line default
#line hidden
#line 110 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\ProduccionV1\Index.cshtml"
                     

                }
                else
                {
                    

#line default
#line hidden
#line 115 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\ProduccionV1\Index.cshtml"
                     if (dia.GrupoHorario.Descanso && !dia.GrupoHorario.EsCruce)
                    {

#line default
#line hidden
            BeginContext(4694, 73, true);
            WriteLiteral("                        <span class=\"badge badge-light\">Descanso</span>\r\n");
            EndContext();
#line 118 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\ProduccionV1\Index.cshtml"
                    }
                    else
                    {

#line default
#line hidden
            BeginContext(4839, 73, true);
            WriteLiteral("                        <span class=\"badge badge-light\">Descanso</span>\r\n");
            EndContext();
#line 122 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\ProduccionV1\Index.cshtml"
                    }

#line default
#line hidden
#line 122 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\ProduccionV1\Index.cshtml"
                     

                }

#line default
#line hidden
            BeginContext(4956, 19, true);
            WriteLiteral("            </td>\r\n");
            EndContext();
#line 126 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\ProduccionV1\Index.cshtml"

                    }
                    else
                    {

#line default
#line hidden
            BeginContext(5049, 74, true);
            WriteLiteral("                        <td style=\"background-color: red\">Sin turno</td>\r\n");
            EndContext();
#line 131 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\ProduccionV1\Index.cshtml"
                    }

#line default
#line hidden
#line 131 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\ProduccionV1\Index.cshtml"
                     
                }

#line default
#line hidden
            BeginContext(5165, 74, true);
            WriteLiteral("                <td>\r\n                    <span class=\"badge badge-light\">");
            EndContext();
            BeginContext(5240, 47, false);
#line 134 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\ProduccionV1\Index.cshtml"
                                               Write(String.Format("{0:00.0}", item.HorasTrabajadas));

#line default
#line hidden
            EndContext();
            BeginContext(5287, 3, true);
            WriteLiteral(" / ");
            EndContext();
            BeginContext(5291, 41, false);
#line 134 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\ProduccionV1\Index.cshtml"
                                                                                                  Write(String.Format("{0:00.0}", item.HorasMeta));

#line default
#line hidden
            EndContext();
            BeginContext(5332, 51, true);
            WriteLiteral("</span>\r\n                </td>\r\n            </tr>\r\n");
            EndContext();
#line 137 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\ProduccionV1\Index.cshtml"
        }

#line default
#line hidden
            BeginContext(5394, 24, true);
            WriteLiteral("    </tbody>\r\n</table>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<GPSInformation.Reportes.Produccion.ReporteProdEmp> Html { get; private set; }
    }
}
#pragma warning restore 1591
