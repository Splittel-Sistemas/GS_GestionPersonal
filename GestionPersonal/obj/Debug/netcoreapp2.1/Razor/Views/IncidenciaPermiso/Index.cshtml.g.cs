#pragma checksum "C:\Luis Martinez backup\Personal\Developments\NET\GrupoSplittel\GrupoSplittel\GestionPersonal\Views\IncidenciaPermiso\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "fbec0f053105b948a62df118a853b528d847d46b"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_IncidenciaPermiso_Index), @"mvc.1.0.view", @"/Views/IncidenciaPermiso/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/IncidenciaPermiso/Index.cshtml", typeof(AspNetCore.Views_IncidenciaPermiso_Index))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"fbec0f053105b948a62df118a853b528d847d46b", @"/Views/IncidenciaPermiso/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"44f628e23a2086c1f04f862587f80afdb82e0a32", @"/Views/_ViewImports.cshtml")]
    public class Views_IncidenciaPermiso_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<GPSInformation.Models.IncidenciaPermiso>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(61, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Luis Martinez backup\Personal\Developments\NET\GrupoSplittel\GrupoSplittel\GestionPersonal\Views\IncidenciaPermiso\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
#line 6 "C:\Luis Martinez backup\Personal\Developments\NET\GrupoSplittel\GrupoSplittel\GestionPersonal\Views\IncidenciaPermiso\Index.cshtml"
 if (Model.Count() == 0)
{

#line default
#line hidden
            BeginContext(133, 109, true);
            WriteLiteral("    <div class=\"alert alert-primary mg-b-0\" role=\"alert\">\r\n        Sin solicitudes de permisos \r\n    </div>\r\n");
            EndContext();
#line 11 "C:\Luis Martinez backup\Personal\Developments\NET\GrupoSplittel\GrupoSplittel\GestionPersonal\Views\IncidenciaPermiso\Index.cshtml"
}
else
{


#line default
#line hidden
            BeginContext(256, 104, true);
            WriteLiteral("    <table class=\"table\">\r\n        <thead>\r\n            <tr>\r\n                <th>\r\n                    ");
            EndContext();
            BeginContext(361, 41, false);
#line 19 "C:\Luis Martinez backup\Personal\Developments\NET\GrupoSplittel\GrupoSplittel\GestionPersonal\Views\IncidenciaPermiso\Index.cshtml"
               Write(Html.DisplayNameFor(model => model.Folio));

#line default
#line hidden
            EndContext();
            BeginContext(402, 67, true);
            WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
            EndContext();
            BeginContext(470, 45, false);
#line 22 "C:\Luis Martinez backup\Personal\Developments\NET\GrupoSplittel\GrupoSplittel\GestionPersonal\Views\IncidenciaPermiso\Index.cshtml"
               Write(Html.DisplayNameFor(model => model.IdPersona));

#line default
#line hidden
            EndContext();
            BeginContext(515, 67, true);
            WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
            EndContext();
            BeginContext(583, 41, false);
#line 25 "C:\Luis Martinez backup\Personal\Developments\NET\GrupoSplittel\GrupoSplittel\GestionPersonal\Views\IncidenciaPermiso\Index.cshtml"
               Write(Html.DisplayNameFor(model => model.Fecha));

#line default
#line hidden
            EndContext();
            BeginContext(624, 67, true);
            WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
            EndContext();
            BeginContext(692, 42, false);
#line 28 "C:\Luis Martinez backup\Personal\Developments\NET\GrupoSplittel\GrupoSplittel\GestionPersonal\Views\IncidenciaPermiso\Index.cshtml"
               Write(Html.DisplayNameFor(model => model.Inicio));

#line default
#line hidden
            EndContext();
            BeginContext(734, 67, true);
            WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
            EndContext();
            BeginContext(802, 39, false);
#line 31 "C:\Luis Martinez backup\Personal\Developments\NET\GrupoSplittel\GrupoSplittel\GestionPersonal\Views\IncidenciaPermiso\Index.cshtml"
               Write(Html.DisplayNameFor(model => model.Fin));

#line default
#line hidden
            EndContext();
            BeginContext(841, 67, true);
            WriteLiteral("\r\n                </th>\r\n                <th>\r\n                    ");
            EndContext();
            BeginContext(909, 43, false);
#line 34 "C:\Luis Martinez backup\Personal\Developments\NET\GrupoSplittel\GrupoSplittel\GestionPersonal\Views\IncidenciaPermiso\Index.cshtml"
               Write(Html.DisplayNameFor(model => model.Estatus));

#line default
#line hidden
            EndContext();
            BeginContext(952, 106, true);
            WriteLiteral("\r\n                </th>\r\n                <th></th>\r\n            </tr>\r\n        </thead>\r\n        <tbody>\r\n");
            EndContext();
#line 40 "C:\Luis Martinez backup\Personal\Developments\NET\GrupoSplittel\GrupoSplittel\GestionPersonal\Views\IncidenciaPermiso\Index.cshtml"
             foreach (var item in Model)
            {

#line default
#line hidden
            BeginContext(1115, 72, true);
            WriteLiteral("                <tr>\r\n                    <td>\r\n                        ");
            EndContext();
            BeginContext(1188, 40, false);
#line 44 "C:\Luis Martinez backup\Personal\Developments\NET\GrupoSplittel\GrupoSplittel\GestionPersonal\Views\IncidenciaPermiso\Index.cshtml"
                   Write(Html.DisplayFor(modelItem => item.Folio));

#line default
#line hidden
            EndContext();
            BeginContext(1228, 79, true);
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
            EndContext();
            BeginContext(1308, 49, false);
#line 47 "C:\Luis Martinez backup\Personal\Developments\NET\GrupoSplittel\GrupoSplittel\GestionPersonal\Views\IncidenciaPermiso\Index.cshtml"
                   Write(Html.DisplayFor(modelItem => item.EmpleadoNombre));

#line default
#line hidden
            EndContext();
            BeginContext(1357, 79, true);
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
            EndContext();
            BeginContext(1437, 40, false);
#line 50 "C:\Luis Martinez backup\Personal\Developments\NET\GrupoSplittel\GrupoSplittel\GestionPersonal\Views\IncidenciaPermiso\Index.cshtml"
                   Write(Html.DisplayFor(modelItem => item.Fecha));

#line default
#line hidden
            EndContext();
            BeginContext(1477, 79, true);
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
            EndContext();
            BeginContext(1557, 41, false);
#line 53 "C:\Luis Martinez backup\Personal\Developments\NET\GrupoSplittel\GrupoSplittel\GestionPersonal\Views\IncidenciaPermiso\Index.cshtml"
                   Write(Html.DisplayFor(modelItem => item.Inicio));

#line default
#line hidden
            EndContext();
            BeginContext(1598, 79, true);
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n                        ");
            EndContext();
            BeginContext(1678, 38, false);
#line 56 "C:\Luis Martinez backup\Personal\Developments\NET\GrupoSplittel\GrupoSplittel\GestionPersonal\Views\IncidenciaPermiso\Index.cshtml"
                   Write(Html.DisplayFor(modelItem => item.Fin));

#line default
#line hidden
            EndContext();
            BeginContext(1716, 55, true);
            WriteLiteral("\r\n                    </td>\r\n                    <td>\r\n");
            EndContext();
#line 59 "C:\Luis Martinez backup\Personal\Developments\NET\GrupoSplittel\GrupoSplittel\GestionPersonal\Views\IncidenciaPermiso\Index.cshtml"
                         if (item.Estatus == 1)
                        {

#line default
#line hidden
            BeginContext(1847, 81, true);
            WriteLiteral("                            <span class=\"badge badge-primary\">En proceso</span>\r\n");
            EndContext();
#line 62 "C:\Luis Martinez backup\Personal\Developments\NET\GrupoSplittel\GrupoSplittel\GestionPersonal\Views\IncidenciaPermiso\Index.cshtml"
                        }
                        else if (item.Estatus == 2)
                        {

#line default
#line hidden
            BeginContext(2035, 79, true);
            WriteLiteral("                            <span class=\"badge badge-danger\">Cancelada</span>\r\n");
            EndContext();
#line 66 "C:\Luis Martinez backup\Personal\Developments\NET\GrupoSplittel\GrupoSplittel\GestionPersonal\Views\IncidenciaPermiso\Index.cshtml"
                        }
                        else
                        {

#line default
#line hidden
            BeginContext(2198, 81, true);
            WriteLiteral("                            <span class=\"badge badge-primary\">Completada</span>\r\n");
            EndContext();
#line 70 "C:\Luis Martinez backup\Personal\Developments\NET\GrupoSplittel\GrupoSplittel\GestionPersonal\Views\IncidenciaPermiso\Index.cshtml"
                        }

#line default
#line hidden
            BeginContext(2306, 77, true);
            WriteLiteral("                    </td>\r\n                    <td>\r\n                        ");
            EndContext();
            BeginContext(2384, 97, false);
#line 73 "C:\Luis Martinez backup\Personal\Developments\NET\GrupoSplittel\GrupoSplittel\GestionPersonal\Views\IncidenciaPermiso\Index.cshtml"
                   Write(Html.ActionLink("Details", "Details", "IncidenciaPermiso", new { id = item.IdIncidenciaPermiso }));

#line default
#line hidden
            EndContext();
            BeginContext(2481, 4, true);
            WriteLiteral(" |\r\n");
            EndContext();
#line 74 "C:\Luis Martinez backup\Personal\Developments\NET\GrupoSplittel\GrupoSplittel\GestionPersonal\Views\IncidenciaPermiso\Index.cshtml"
                         if (item.Estatus == 1)
                        {
                            

#line default
#line hidden
            BeginContext(2590, 97, false);
#line 76 "C:\Luis Martinez backup\Personal\Developments\NET\GrupoSplittel\GrupoSplittel\GestionPersonal\Views\IncidenciaPermiso\Index.cshtml"
                       Write(Html.ActionLink("Cancelar", "Cancel", "IncidenciaPermiso", new { id = item.IdIncidenciaPermiso }));

#line default
#line hidden
            EndContext();
            BeginContext(2687, 16, true);
            WriteLiteral("<span>|</span>\r\n");
            EndContext();
#line 77 "C:\Luis Martinez backup\Personal\Developments\NET\GrupoSplittel\GrupoSplittel\GestionPersonal\Views\IncidenciaPermiso\Index.cshtml"
                        }

#line default
#line hidden
            BeginContext(2730, 73, true);
            WriteLiteral("                    <a href=\"#modalActividadPermisos\" data-toggle=\"modal\"");
            EndContext();
            BeginWriteAttribute("onclick", " onclick=\"", 2803, "\"", 2873, 3);
            WriteAttributeValue("", 2813, "app_incidencias.ActividadPermisos(", 2813, 34, true);
#line 78 "C:\Luis Martinez backup\Personal\Developments\NET\GrupoSplittel\GrupoSplittel\GestionPersonal\Views\IncidenciaPermiso\Index.cshtml"
WriteAttributeValue("", 2847, item.IdIncidenciaPermiso, 2847, 25, false);

#line default
#line hidden
            WriteAttributeValue("", 2872, ")", 2872, 1, true);
            EndWriteAttribute();
            BeginContext(2874, 66, true);
            WriteLiteral(">Actividad</a>\r\n                    </td>\r\n                </tr>\r\n");
            EndContext();
#line 81 "C:\Luis Martinez backup\Personal\Developments\NET\GrupoSplittel\GrupoSplittel\GestionPersonal\Views\IncidenciaPermiso\Index.cshtml"
            }

#line default
#line hidden
            BeginContext(2955, 32, true);
            WriteLiteral("        </tbody>\r\n    </table>\r\n");
            EndContext();
#line 84 "C:\Luis Martinez backup\Personal\Developments\NET\GrupoSplittel\GrupoSplittel\GestionPersonal\Views\IncidenciaPermiso\Index.cshtml"
}

#line default
#line hidden
            BeginContext(2990, 2, true);
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<GPSInformation.Models.IncidenciaPermiso>> Html { get; private set; }
    }
}
#pragma warning restore 1591