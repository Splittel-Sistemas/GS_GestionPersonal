#pragma checksum "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\IncPermiso\Notification.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5f79a70b644bb705ee872953d526e2621ce4d264"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_IncPermiso_Notification), @"mvc.1.0.view", @"/Views/IncPermiso/Notification.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/IncPermiso/Notification.cshtml", typeof(AspNetCore.Views_IncPermiso_Notification))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5f79a70b644bb705ee872953d526e2621ce4d264", @"/Views/IncPermiso/Notification.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"44f628e23a2086c1f04f862587f80afdb82e0a32", @"/Views/_ViewImports.cshtml")]
    public class Views_IncPermiso_Notification : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<GPSInformation.Models.IncidenciaPermiso>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("background-color: #f4f4f4; margin: 0 !important; padding: 0 !important;"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\IncPermiso\Notification.cshtml"
  
    ViewData["Title"] = "Detalle de solicitud: " + Model.Folio;
    Layout = null;

#line default
#line hidden
            BeginContext(140, 181, true);
            WriteLiteral("<!-- THIS EMAIL WAS BUILT AND TESTED WITH LITMUS http://litmus.com -->\r\n<!-- IT WAS RELEASED UNDER THE MIT LICENSE https://opensource.org/licenses/MIT -->\r\n<!-- QUESTIONS? TWEET US ");
            EndContext();
            BeginContext(322, 41, true);
            WriteLiteral("@LITMUSAPP -->\r\n<!DOCTYPE html>\r\n<html>\r\n");
            EndContext();
            BeginContext(363, 2647, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2fb9e077702c4badb36a3b9bbb66deac", async() => {
                BeginContext(369, 283, true);
                WriteLiteral(@"
    <title></title>
    <meta http-equiv=""Content-Type"" content=""text/html; charset=utf-8"" />
    <meta name=""viewport"" content=""width=device-width, initial-scale=1"">
    <meta http-equiv=""X-UA-Compatible"" content=""IE=edge"" />
    <style type=""text/css"">
    /* FONTS */
    ");
                EndContext();
                BeginContext(653, 25, true);
                WriteLiteral("@media screen {\r\n        ");
                EndContext();
                BeginContext(679, 296, true);
                WriteLiteral(@"@font-face {
          font-family: 'Lato';
          font-style: normal;
          font-weight: 400;
          src: local('Lato Regular'), local('Lato-Regular'), url(https://fonts.gstatic.com/s/lato/v11/qIIYRU-oROkIk8vfvxw6QvesZW2xOQ-xsNqO47m55DA.woff) format('woff');
        }

        ");
                EndContext();
                BeginContext(976, 299, true);
                WriteLiteral(@"@font -face {
            font-family: 'Lato';
            font-style: normal;
            font-weight: 700;
            src: local('Lato Bold'), local('Lato-Bold'), url(https://fonts.gstatic.com/s/lato/v11/qdgUG4U09HnJwhYI-uK18wLUuEpTyoUstqEm5AMlJo4.woff) format('woff');
        }

        ");
                EndContext();
                BeginContext(1276, 303, true);
                WriteLiteral(@"@font -face {
            font-family: 'Lato';
            font-style: italic;
            font-weight: 400;
            src: local('Lato Italic'), local('Lato-Italic'), url(https://fonts.gstatic.com/s/lato/v11/RYyZNoeFgb0l7W3Vu1aSWOvvDin1pK8aKteLpeZ5c0A.woff) format('woff');
        }

        ");
                EndContext();
                BeginContext(1580, 1161, true);
                WriteLiteral(@"@font-face {
          font-family: 'Lato';
          font-style: italic;
          font-weight: 700;
          src: local('Lato Bold Italic'), local('Lato-BoldItalic'), url(https://fonts.gstatic.com/s/lato/v11/HkF_qI1x_noxlxhrhMQYELO3LdcAZYWl9Si6vvxL-qU.woff) format('woff');
        }
    }

    /* CLIENT-SPECIFIC STYLES */
    body, table, td, a { -webkit-text-size-adjust: 100%; -ms-text-size-adjust: 100%; }
    table, td { mso-table-lspace: 0pt; mso-table-rspace: 0pt; }
    img { -ms-interpolation-mode: bicubic; }

    /* RESET STYLES */
    img { border: 0; height: auto; line-height: 100%; outline: none; text-decoration: none; }
    table { border-collapse: collapse !important; }
    body { height: 100% !important; margin: 0 !important; padding: 0 !important; width: 100% !important; }

    /* iOS BLUE LINKS */
    a[x-apple-data-detectors] {
        color: inherit !important;
        text-decoration: none !important;
        font-size: inherit !important;
        font-family: inheri");
                WriteLiteral("t !important;\r\n        font-weight: inherit !important;\r\n        line-height: inherit !important;\r\n    }\r\n\r\n    /* MOBILE STYLES */\r\n    ");
                EndContext();
                BeginContext(2742, 261, true);
                WriteLiteral(@"@media screen and (max-width:600px){
        h1 {
            font-size: 32px !important;
            line-height: 32px !important;
        }
    }

    /* ANDROID CENTER FIX */
    div[style*=""margin: 16px 0;""] { margin: 0 !important; }
    </style>
");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(3010, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(3012, 13887, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "02a6c0642e484fc8bc32aae34bbcdca2", async() => {
                BeginContext(3098, 943, true);
                WriteLiteral(@"

    <!-- HIDDEN PREHEADER TEXT -->
    <div style=""display: none; font-size: 1px; color: #fefefe; line-height: 1px; font-family: 'Lato', Helvetica, Arial, sans-serif; max-height: 0px; max-width: 0px; opacity: 0; overflow: hidden;"">
        Sistema Gestión de personal - Notificación
    </div>

    <table border=""0"" cellpadding=""0"" cellspacing=""0"" width=""100%"">
        <!-- LOGO -->
        <tr>
            <td bgcolor=""#ec6d64"" align=""center"">
                <!--[if (gte mso 9)|(IE)]>
                <table align=""center"" border=""0"" cellspacing=""0"" cellpadding=""0"" width=""600"">
                <tr>
                <td align=""center"" valign=""top"" width=""600"">
                <![endif]-->
                <table border=""0"" cellpadding=""0"" cellspacing=""0"" width=""100%"" style=""max-width: 600px;"">
                    <tr>
                        <td align=""center"" valign=""top"" style=""padding: 40px 10px 40px 10px;"">
");
                EndContext();
                BeginContext(4473, 2398, true);
                WriteLiteral(@"                        </td>
                    </tr>
                </table>
                <!--[if (gte mso 9)|(IE)]>
                </td>
                </tr>
                </table>
                <![endif]-->
            </td>
        </tr>
        <!-- HERO -->
        <tr>
            <td bgcolor=""#ec6d64"" align=""center"" style=""padding: 0px 10px 0px 10px;"">
                <!--[if (gte mso 9)|(IE)]>
                <table align=""center"" border=""0"" cellspacing=""0"" cellpadding=""0"" width=""600"">
                <tr>
                <td align=""center"" valign=""top"" width=""600"">
                <![endif]-->
                <table border=""0"" cellpadding=""0"" cellspacing=""0"" width=""100%"" style=""max-width: 600px;"">
                    <tr>
                        <td bgcolor=""#ffffff"" align=""center"" valign=""top"" style=""padding: 40px 20px 20px 20px; border-radius: 4px 4px 0px 0px; color: #111111; font-family: 'Lato', Helvetica, Arial, sans-serif; font-size: 48px; font-weight: 400; lette");
                WriteLiteral(@"r-spacing: 4px; line-height: 48px;"">
                            <h1 style=""font-size: 30px; font-weight: 400; margin: 0;"">Gestión de personal</h1>
                        </td>
                    </tr>
                </table>
                <!--[if (gte mso 9)|(IE)]>
                </td>
                </tr>
                </table>
                <![endif]-->
            </td>
        </tr>
        <!-- COPY BLOCK -->
        <tr>
            <td bgcolor=""#f4f4f4"" align=""center"" style=""padding: 0px 10px 0px 10px;"">
                <!--[if (gte mso 9)|(IE)]>
                <table align=""center"" border=""0"" cellspacing=""0"" cellpadding=""0"" width=""600"">
                <tr>
                <td align=""center"" valign=""top"" width=""600"">
                <![endif]-->
                <table border=""0"" cellpadding=""0"" cellspacing=""0"" width=""100%"" style=""max-width: 600px;"">
                    <!-- COPY -->
                    <tr>
                        <td bgcolor=""#ffffff"" align=""left"" ");
                WriteLiteral(@"style=""padding: 20px 30px 40px 30px; color: #666666; font-family: 'Lato', Helvetica, Arial, sans-serif; font-size: 18px; font-weight: 400; line-height: 25px;"">
                            <p style=""margin: 0; font-size: 14px; line-height: 1.2; text-align: left; word-break: break-word; mso-line-height-alt: 17px; margin-top: 0; margin-bottom: 0;"">
");
                EndContext();
#line 147 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\IncPermiso\Notification.cshtml"
                                 if (Model.Estatus == 2 || Model.Estatus == 3)
                                {


#line default
#line hidden
                BeginContext(6988, 297, true);
                WriteLiteral(@"                                    <strong><span style=""font-size: 14px;"">Estimado usuario</span></strong>
                                    <br />
                                    <br />
                                    <br />
                                    <span>El colaborador");
                EndContext();
                BeginContext(7286, 10, true);
                WriteLiteral("@ <strong>");
                EndContext();
                BeginContext(7297, 20, false);
#line 154 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\IncPermiso\Notification.cshtml"
                                                              Write(Model.EmpleadoNombre);

#line default
#line hidden
                EndContext();
                BeginContext(7317, 64, true);
                WriteLiteral("</strong> ha creado una solicitud de permiso con folio: <strong>");
                EndContext();
                BeginContext(7382, 11, false);
#line 154 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\IncPermiso\Notification.cshtml"
                                                                                                                                                   Write(Model.Folio);

#line default
#line hidden
                EndContext();
                BeginContext(7393, 133, true);
                WriteLiteral("</strong>y se requiere tu aprobación</span>\r\n                                    <br />\r\n                                    <br />\r\n");
                EndContext();
#line 157 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\IncPermiso\Notification.cshtml"

                                }
                                else
                                {

#line default
#line hidden
                BeginContext(7636, 368, true);
                WriteLiteral(@"                                    <strong><span style=""font-size: 14px;"">Estimado usuario</span></strong>
                                    <br />
                                    <br />
                                    <br />
                                    <span>
                                        Su solicitud de permiso con folio: <strong>");
                EndContext();
                BeginContext(8005, 11, false);
#line 166 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\IncPermiso\Notification.cshtml"
                                                                              Write(Model.Folio);

#line default
#line hidden
                EndContext();
                BeginContext(8016, 26, true);
                WriteLiteral("</strong> ha sido <strong>");
                EndContext();
                BeginContext(8043, 23, false);
#line 166 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\IncPermiso\Notification.cshtml"
                                                                                                                    Write(Model.EstatusDescricion);

#line default
#line hidden
                EndContext();
                BeginContext(8066, 190, true);
                WriteLiteral("</strong>\r\n\r\n                                    </span>\r\n                                    <br />\r\n                                    <br />\r\n                                    <br />\r\n");
                EndContext();
#line 172 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\IncPermiso\Notification.cshtml"
                                     if (Model.Estatus == 7)
                                    {

#line default
#line hidden
                BeginContext(8357, 251, true);
                WriteLiteral("                                        <strong><span style=\"font-size: 14px; width: 100%; color: #ec6d64;\">Detalle de rechazo de solicitud</span></strong>\r\n                                        <strong>\r\n                                            ");
                EndContext();
                BeginContext(8609, 88, false);
#line 176 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\IncPermiso\Notification.cshtml"
                                       Write(Html.DisplayNameFor(model => Model.Proceso.Find(a => a.Revisada && !a.Autorizada).Fecha));

#line default
#line hidden
                EndContext();
                BeginContext(8697, 101, true);
                WriteLiteral("\r\n                                        </strong>\r\n                                        <br />\r\n");
                EndContext();
                BeginContext(8839, 82, false);
#line 179 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\IncPermiso\Notification.cshtml"
                                   Write(string.Format("{0:F}", Model.Proceso.Find(a => a.Revisada && !a.Autorizada).Fecha));

#line default
#line hidden
                EndContext();
                BeginContext(8923, 190, true);
                WriteLiteral("                                        <br />\r\n                                        <br />\r\n                                        <strong>\r\n                                            ");
                EndContext();
                BeginContext(9114, 97, false);
#line 183 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\IncPermiso\Notification.cshtml"
                                       Write(Html.DisplayNameFor(model => Model.Proceso.Find(a => a.Revisada && !a.Autorizada).NombreEmpleado));

#line default
#line hidden
                EndContext();
                BeginContext(9211, 101, true);
                WriteLiteral("\r\n                                        </strong>\r\n                                        <br />\r\n");
                EndContext();
                BeginContext(9353, 93, false);
#line 186 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\IncPermiso\Notification.cshtml"
                                   Write(Html.DisplayFor(model => Model.Proceso.Find(a => a.Revisada && !a.Autorizada).NombreEmpleado));

#line default
#line hidden
                EndContext();
                BeginContext(9448, 190, true);
                WriteLiteral("                                        <br />\r\n                                        <br />\r\n                                        <strong>\r\n                                            ");
                EndContext();
                BeginContext(9639, 94, false);
#line 190 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\IncPermiso\Notification.cshtml"
                                       Write(Html.DisplayNameFor(model => Model.Proceso.Find(a => a.Revisada && !a.Autorizada).Comentarios));

#line default
#line hidden
                EndContext();
                BeginContext(9733, 101, true);
                WriteLiteral("\r\n                                        </strong>\r\n                                        <br />\r\n");
                EndContext();
                BeginContext(9875, 90, false);
#line 193 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\IncPermiso\Notification.cshtml"
                                   Write(Html.DisplayFor(model => Model.Proceso.Find(a => a.Revisada && !a.Autorizada).Comentarios));

#line default
#line hidden
                EndContext();
                BeginContext(9967, 48, true);
                WriteLiteral("                                        <br />\r\n");
                EndContext();
#line 195 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\IncPermiso\Notification.cshtml"
                                    }

#line default
#line hidden
                BeginContext(10054, 44, true);
                WriteLiteral("                                    <br />\r\n");
                EndContext();
#line 197 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\IncPermiso\Notification.cshtml"
                                }

#line default
#line hidden
                BeginContext(10133, 336, true);
                WriteLiteral(@"                                <br />
                                <strong><span style=""font-size: 14px; width: 100%; color: #ec6d64;"">Detalle de solicitud</span></strong>
                                <br />
                                <br />
                                <strong>
                                    ");
                EndContext();
                BeginContext(10470, 41, false);
#line 203 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\IncPermiso\Notification.cshtml"
                               Write(Html.DisplayNameFor(model => model.Fecha));

#line default
#line hidden
                EndContext();
                BeginContext(10511, 117, true);
                WriteLiteral("\r\n                                </strong>\r\n                                <br />\r\n                                ");
                EndContext();
                BeginContext(10629, 25, false);
#line 206 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\IncPermiso\Notification.cshtml"
                           Write(Model.Fecha.ToString("F"));

#line default
#line hidden
                EndContext();
                BeginContext(10654, 160, true);
                WriteLiteral("\r\n                                <br />\r\n                                <br />\r\n                                <strong>\r\n                                    ");
                EndContext();
                BeginContext(10815, 42, false);
#line 210 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\IncPermiso\Notification.cshtml"
                               Write(Html.DisplayNameFor(model => model.Inicio));

#line default
#line hidden
                EndContext();
                BeginContext(10857, 117, true);
                WriteLiteral("\r\n                                </strong>\r\n                                <br />\r\n                                ");
                EndContext();
                BeginContext(10975, 38, false);
#line 213 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\IncPermiso\Notification.cshtml"
                           Write(Html.DisplayFor(model => model.Inicio));

#line default
#line hidden
                EndContext();
                BeginContext(11013, 160, true);
                WriteLiteral("\r\n                                <br />\r\n                                <br />\r\n                                <strong>\r\n                                    ");
                EndContext();
                BeginContext(11174, 39, false);
#line 217 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\IncPermiso\Notification.cshtml"
                               Write(Html.DisplayNameFor(model => model.Fin));

#line default
#line hidden
                EndContext();
                BeginContext(11213, 117, true);
                WriteLiteral("\r\n                                </strong>\r\n                                <br />\r\n                                ");
                EndContext();
                BeginContext(11331, 35, false);
#line 220 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\IncPermiso\Notification.cshtml"
                           Write(Html.DisplayFor(model => model.Fin));

#line default
#line hidden
                EndContext();
                BeginContext(11366, 160, true);
                WriteLiteral("\r\n                                <br />\r\n                                <br />\r\n                                <strong>\r\n                                    ");
                EndContext();
                BeginContext(11527, 51, false);
#line 224 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\IncPermiso\Notification.cshtml"
                               Write(Html.DisplayNameFor(model => model.DEscripcionTipo));

#line default
#line hidden
                EndContext();
                BeginContext(11578, 117, true);
                WriteLiteral("\r\n                                </strong>\r\n                                <br />\r\n                                ");
                EndContext();
                BeginContext(11696, 47, false);
#line 227 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\IncPermiso\Notification.cshtml"
                           Write(Html.DisplayFor(model => model.DEscripcionTipo));

#line default
#line hidden
                EndContext();
                BeginContext(11743, 160, true);
                WriteLiteral("\r\n                                <br />\r\n                                <br />\r\n                                <strong>\r\n                                    ");
                EndContext();
                BeginContext(11904, 53, false);
#line 231 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\IncPermiso\Notification.cshtml"
                               Write(Html.DisplayNameFor(model => model.DescripcionAsunto));

#line default
#line hidden
                EndContext();
                BeginContext(11957, 117, true);
                WriteLiteral("\r\n                                </strong>\r\n                                <br />\r\n                                ");
                EndContext();
                BeginContext(12075, 49, false);
#line 234 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\IncPermiso\Notification.cshtml"
                           Write(Html.DisplayFor(model => model.DescripcionAsunto));

#line default
#line hidden
                EndContext();
                BeginContext(12124, 42, true);
                WriteLiteral("\r\n                                <br />\r\n");
                EndContext();
#line 236 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\IncPermiso\Notification.cshtml"
                                 if (Model.IdAsunto == 36)
                                {

#line default
#line hidden
                BeginContext(12261, 130, true);
                WriteLiteral("                                    <br />\r\n                                    <strong>\r\n                                        ");
                EndContext();
                BeginContext(12392, 51, false);
#line 240 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\IncPermiso\Notification.cshtml"
                                   Write(Html.DisplayNameFor(model => model.PagoPermisoDesc));

#line default
#line hidden
                EndContext();
                BeginContext(12443, 93, true);
                WriteLiteral("\r\n                                    </strong>\r\n                                    <br />\r\n");
                EndContext();
                BeginContext(12573, 47, false);
#line 243 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\IncPermiso\Notification.cshtml"
                               Write(Html.DisplayFor(model => model.PagoPermisoDesc));

#line default
#line hidden
                EndContext();
                BeginContext(12622, 44, true);
                WriteLiteral("                                    <br />\r\n");
                EndContext();
#line 245 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\IncPermiso\Notification.cshtml"
                                }

#line default
#line hidden
                BeginContext(12701, 80, true);
                WriteLiteral("                                <br />\r\n                                <br />\r\n");
                EndContext();
#line 248 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\IncPermiso\Notification.cshtml"
                                 if (Model.Estatus == 3)
                                {

#line default
#line hidden
                BeginContext(12874, 162, true);
                WriteLiteral("                                    <strong>\r\n                                        Comentarios de aprobación por jefe inmediato: <span style=\"color: #ec6d64;\">");
                EndContext();
                BeginContext(13037, 78, false);
#line 251 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\IncPermiso\Notification.cshtml"
                                                                                                               Write(Html.DisplayFor(model => Model.Proceso.Find(a => a.Nivel == 2).NombreEmpleado));

#line default
#line hidden
                EndContext();
                BeginContext(13115, 100, true);
                WriteLiteral("</span>\r\n                                    </strong>\r\n                                    <br />\r\n");
                EndContext();
                BeginContext(13252, 75, false);
#line 254 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\IncPermiso\Notification.cshtml"
                               Write(Html.DisplayFor(model => Model.Proceso.Find(a => a.Nivel == 2).Comentarios));

#line default
#line hidden
                EndContext();
                BeginContext(13329, 88, true);
                WriteLiteral("                                    <br />\r\n                                    <br />\r\n");
                EndContext();
#line 257 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\IncPermiso\Notification.cshtml"
                                }

#line default
#line hidden
                BeginContext(13452, 785, true);
                WriteLiteral(@"                            </p>

                        </td>
                    </tr>
                    <!-- BULLETPROOF BUTTON -->
                    <tr>
                        <td bgcolor=""#ffffff"" align=""left"">
                            <table width=""100%"" border=""0"" cellspacing=""0"" cellpadding=""0"">
                                <tr>
                                    <td bgcolor=""#ffffff"" align=""center"" style=""padding: 20px 30px 60px 30px;"">
                                        <table border=""0"" cellspacing=""0"" cellpadding=""0"">
                                            <tr>
                                                <td align=""center"" style=""border-radius: 3px;"" bgcolor=""#ec6d64"">
                                                    <a");
                EndContext();
                BeginWriteAttribute("href", " href=\"", 14237, "\"", 14255, 1);
#line 271 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\IncPermiso\Notification.cshtml"
WriteAttributeValue("", 14244, Model.Link, 14244, 11, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(14256, 2636, true);
                WriteLiteral(@" target=""_top"" style=""font-size: 20px; font-family: Helvetica, Arial, sans-serif; color: #ffffff; text-decoration: none; color: #ffffff; text-decoration: none; padding: 15px 25px; border-radius: 2px; border: 1px solid #ec6d64; display: inline-block;"">
                                                    Revisar!
                                                    </a>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
                <!--[if (gte mso 9)|(IE)]>
                </td>
                </tr>
                </table>
                <![endif]-->
            </td>
        </tr>
        <!-- FOOTER -->
        <tr>
            <td bgcolor=""#f4f4f4"" align=""center"" style=""padding: 40px 10");
                WriteLiteral(@"px 0px 10px;"">
                <!--[if (gte mso 9)|(IE)]>
                <table align=""center"" border=""0"" cellspacing=""0"" cellpadding=""0"" width=""600"">
                <tr>
                <td align=""center"" valign=""top"" width=""600"">
                <![endif]-->
                <table border=""0"" cellpadding=""0"" cellspacing=""0"" width=""100%"" style=""max-width: 600px;"">
                    <!-- UNSUBSCRIBE -->
                    <tr>
                        <td bgcolor=""#f4f4f4"" align=""left"" style=""padding: 0px 30px 30px 30px; color: #666666; font-family: 'Lato', Helvetica, Arial, sans-serif; font-size: 14px; font-weight: 400; line-height: 18px;"">
                            <p style=""margin: 0;"">Este es un correo creado automaticamente por Sistema Gestión de Personal.</p>
                        </td>
                    </tr>
                    <!-- ADDRESS -->
                    <tr>
                        <td bgcolor=""#f4f4f4"" align=""left"" style=""padding: 0px 30px 30px 30px; color: #666666;");
                WriteLiteral(@" font-family: 'Lato', Helvetica, Arial, sans-serif; font-size: 14px; font-weight: 400; line-height: 18px;"">
                            <p style=""margin: 0;"">Parque Tecnológico Innovación Querétaro Lateral de la carretera Estatal 431, km.2+200, Int.28, 76246 Santiago de Querétaro, Qro.Grupo Splittel.</p>
                        </td>
                    </tr>
                </table>
                <!--[if (gte mso 9)|(IE)]>
                </td>
                </tr>
                </table>
                <![endif]-->
            </td>
        </tr>
    </table>

");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(16899, 9, true);
            WriteLiteral("\r\n</html>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<GPSInformation.Models.IncidenciaPermiso> Html { get; private set; }
    }
}
#pragma warning restore 1591
