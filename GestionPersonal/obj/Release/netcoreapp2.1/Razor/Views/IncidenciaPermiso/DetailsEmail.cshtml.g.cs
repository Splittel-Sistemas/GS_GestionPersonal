#pragma checksum "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\IncidenciaPermiso\DetailsEmail.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "16ab99e160125cbc3bd72725b65e8f6ba113d9f9"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_IncidenciaPermiso_DetailsEmail), @"mvc.1.0.view", @"/Views/IncidenciaPermiso/DetailsEmail.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/IncidenciaPermiso/DetailsEmail.cshtml", typeof(AspNetCore.Views_IncidenciaPermiso_DetailsEmail))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"16ab99e160125cbc3bd72725b65e8f6ba113d9f9", @"/Views/IncidenciaPermiso/DetailsEmail.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"44f628e23a2086c1f04f862587f80afdb82e0a32", @"/Views/_ViewImports.cshtml")]
    public class Views_IncidenciaPermiso_DetailsEmail : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<GPSInformation.Reportes.IncidenciaPermisoRe>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString(""), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            BeginContext(52, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\IncidenciaPermiso\DetailsEmail.cshtml"
  
    string Link = "";

    

#line default
#line hidden
#line 6 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\IncidenciaPermiso\DetailsEmail.cshtml"
     if (Model.ModeAmin)
    {
        Link = string.Format("http://{0}:{1}/IncidenciaPermiso/Aprobar?id={2}&Mode=2", "192.168.2.29", "3456", Model.IncidenciaPermiso.IdIncidenciaPermiso); ;
    }
    else
    {
        Link = string.Format("http://{0}:{1}/IncidenciaPermiso/Aprobar?id={2}&Mode=1", "192.168.2.29", "3456", Model.IncidenciaPermiso.IdIncidenciaPermiso); ;
    }

#line default
#line hidden
            BeginContext(472, 29, true);
            WriteLiteral("\r\n\r\n<!doctype html>\r\n<html>\r\n");
            EndContext();
            BeginContext(501, 11402, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "bd772dfdd46f46d4bd11004630b7c4d0", async() => {
                BeginContext(507, 6644, true);
                WriteLiteral(@"
    <meta name=""viewport"" content=""width=device-width"" />
    <meta http-equiv=""Content-Type"" content=""text/html; charset=UTF-8"" />
    <title>Ecommerce Grupo Splittel</title>
    <style>
        /* -------------------------------------
            GLOBAL RESETS
        ------------------------------------- */

        /*All the styling goes here*/

        img {
            border: none;
            -ms-interpolation-mode: bicubic;
            max-width: 100%;
        }

        .banner-img {
            width: 800px;
            height: 200px;
        }

        body {
            background-color: #f6f6f6;
            font-family: sans-serif;
            -webkit-font-smoothing: antialiased;
            font-size: 14px;
            line-height: 1.4;
            margin: 0;
            padding: 0;
            -ms-text-size-adjust: 100%;
            -webkit-text-size-adjust: 100%;
        }

        table {
            border-collapse: separate;
            mso-table-lspace");
                WriteLiteral(@": 0pt;
            mso-table-rspace: 0pt;
            width: 100%;
        }

            table td {
                font-family: sans-serif;
                font-size: 14px;
                vertical-align: top;
            }

        /* -------------------------------------
            BODY & CONTAINER
        ------------------------------------- */

        .body {
            background-color: #f6f6f6;
            width: 100%;
        }

        /* Set a max-width, and make it display as block so it will automatically stretch to that width, but will also shrink down on a phone or something */
        .container {
            display: block;
            margin: 0 auto !important;
            /* makes it centered */
            max-width: 780px;
            padding: 10px;
            width: 780px;
        }

        /* This should also be a block element, so that it will fill 100% of the .container */
        .content {
            box-sizing: border-box;
            display");
                WriteLiteral(@": block;
            margin: 0 auto;
            max-width: 780px;
            padding: 10px;
        }

        /* -------------------------------------
            HEADER, FOOTER, MAIN
        ------------------------------------- */
        .main {
            background: #ffffff;
            border-radius: 3px;
            width: 100%;
        }

        .wrapper {
            box-sizing: border-box;
            padding: 20px;
        }

        .content-block {
            padding-bottom: 10px;
            padding-top: 10px;
        }

        .footer {
            clear: both;
            margin-top: 10px;
            text-align: center;
            width: 100%;
        }

            .footer td,
            .footer p,
            .footer span,
            .footer a {
                color: #999999;
                font-size: 12px;
                text-align: center;
            }

        /* -------------------------------------
            TYPOGRAPHY
        ");
                WriteLiteral(@"------------------------------------- */
        h1,
        h2,
        h3,
        h4 {
            color: #000000;
            font-family: sans-serif;
            font-weight: 400;
            line-height: 1.4;
            margin: 0;
            margin-bottom: 30px;
        }

        h1 {
            font-size: 35px;
            font-weight: 300;
            text-align: center;
            text-transform: capitalize;
        }

        p,
        ul,
        ol {
            font-family: sans-serif;
            font-size: 14px;
            font-weight: normal;
            margin: 0;
            margin-bottom: 15px;
        }

            p li,
            ul li,
            ol li {
                list-style-position: inside;
                margin-left: 5px;
            }

        a {
            color: #3498db;
            text-decoration: underline;
        }

        /* -------------------------------------
            BUTTONS
        ----------------------");
                WriteLiteral(@"--------------- */
        .btn {
            box-sizing: border-box;
            width: 100%;
        }

            .btn > tbody > tr > td {
                padding-bottom: 15px;
            }

            .btn table {
                width: 100%;
            }

                .btn table td {
                    background-color: #ffffff;
                    border-radius: 5px;
                    text-align: center;
                }

            .btn a {
                background-color: #ffffff;
                border: solid 1px #3498db;
                border-radius: 5px;
                box-sizing: border-box;
                color: #3498db;
                cursor: pointer;
                display: inline-block;
                font-size: 14px;
                font-weight: bold;
                margin: 0;
                padding: 12px 25px;
                text-decoration: none;
                text-transform: capitalize;
            }

        .btn-primary table td");
                WriteLiteral(@" {
            background-color: #ffffff;
        }

        .btn-primary a {
            background-color: #3498db;
            border-color: #3498db;
            color: #ffffff;
        }

        /* -------------------------------------
            OTHER STYLES THAT MIGHT BE USEFUL
        ------------------------------------- */
        .last {
            margin-bottom: 0;
        }

        .first {
            margin-top: 0;
        }

        .align-center {
            text-align: center;
        }

        .align-right {
            text-align: right;
        }

        .align-left {
            text-align: left;
        }

        .clear {
            clear: both;
        }

        .mt0 {
            margin-top: 0;
        }

        .mb0 {
            margin-bottom: 0;
        }

        .preheader {
            color: transparent;
            display: none;
            height: 0;
            max-height: 0;
            max-width: 0;
            o");
                WriteLiteral(@"pacity: 0;
            overflow: hidden;
            mso-hide: all;
            visibility: hidden;
            width: 0;
        }

        .powered-by a {
            text-decoration: none;
        }

        hr {
            border: 0;
            border-bottom: 1px solid #f6f6f6;
            margin: 20px 0;
        }

        /* -------------------------------------
            RESPONSIVE AND MOBILE FRIENDLY STYLES
        ------------------------------------- */
        ");
                EndContext();
                BeginContext(7152, 1612, true);
                WriteLiteral(@"@media only screen and (max-width: 620px) {
            table[class=body] h1 {
                font-size: 28px !important;
                margin-bottom: 10px !important;
            }

            table[class=body] p,
            table[class=body] ul,
            table[class=body] ol,
            table[class=body] td,
            table[class=body] span,
            table[class=body] a {
                font-size: 16px !important;
            }

            table[class=body] .wrapper,
            table[class=body] .article {
                padding: 10px !important;
            }

            table[class=body] .content {
                padding: 0 !important;
            }

            table[class=body] .container {
                padding: 0 !important;
                width: 100% !important;
            }

            table[class=body] .main {
                border-left-width: 0 !important;
                border-radius: 0 !important;
                border-right-width: 0 !i");
                WriteLiteral(@"mportant;
            }

            table[class=body] .btn table {
                width: 100% !important;
            }

            table[class=body] .btn a {
                width: 100% !important;
            }

            table[class=body] .img-responsive {
                height: auto !important;
                max-width: 100% !important;
                width: auto !important;
            }
        }

        /* -------------------------------------
            PRESERVE THESE STYLES IN THE HEAD
        ------------------------------------- */
        ");
                EndContext();
                BeginContext(8765, 3131, true);
                WriteLiteral(@"@media all {
            .ExternalClass {
                width: 100%;
            }

                .ExternalClass,
                .ExternalClass p,
                .ExternalClass span,
                .ExternalClass font,
                .ExternalClass td,
                .ExternalClass div {
                    line-height: 100%;
                }

            .apple-link a {
                color: inherit !important;
                font-family: inherit !important;
                font-size: inherit !important;
                font-weight: inherit !important;
                line-height: inherit !important;
                text-decoration: none !important;
            }

            #MessageViewBody a {
                color: inherit;
                text-decoration: none;
                font-size: inherit;
                font-family: inherit;
                font-weight: inherit;
                line-height: inherit;
            }

            .btn-primary table td:hov");
                WriteLiteral(@"er {
                /* background-color: #34495e !important;  */
            }

            .btn-primary a:hover {
                background-color: #34495e !important;
                border-color: #34495e !important;
                font-family: sans-serif;
                font-size: 14px;
                /* vertical-align: top;  */
            }
        }

        .title {
            background-color: gray;
            border-radius: 5px;
            text-align: center;
        }

        .bloque-dere {
            border-left-color: gray;
            /* border-left-width: medium; */
            /* border-top-style: dotted; */
            border-left-style: solid;
            border-left-width: 2px;
        }

        .alert {
            padding: 8px 35px 8px 14px;
            margin-bottom: 18px;
            color: #c09853;
            text-shadow: 0 1px 0 rgba(255, 255, 255, 0.5);
            background-color: #fcf8e3;
            border: 1px solid #fbeed5;
          ");
                WriteLiteral(@"  -webkit-border-radius: 4px;
            -moz-border-radius: 4px;
            border-radius: 4px;
        }

        .alert-heading {
            color: inherit;
        }

        .alert .close {
            position: relative;
            top: -2px;
            right: -21px;
            line-height: 18px;
        }

        .alert-success {
            color: #468847;
            background-color: #dff0d8;
            border-color: #d6e9c6;
        }

        .alert-info {
            color: #3a87ad;
            background-color: #d9edf7;
            border-color: #bce8f1;
        }

        .alert-warning {
            color: #8a6d3b;
            background-color: #fcf8e3;
            border-color: #faebcc;
        }

        .alert-block {
            padding-top: 14px;
            padding-bottom: 14px;
        }

            .alert-block > p,
            .alert-block > ul {
                margin-bottom: 0;
            }

            .alert-block p + p {
    ");
                WriteLiteral("            margin-top: 5px;\r\n            }\r\n    </style>\r\n");
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
            BeginContext(11903, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(11905, 8360, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "5a9ce8eb5e114eaa800229eee9c45a47", async() => {
                BeginContext(11920, 1667, true);
                WriteLiteral(@"
    <span class=""preheader"">Gestión de personal</span>
    <table role=""presentation"" border=""0"" cellpadding=""0"" cellspacing=""0"" class=""body"">
        <tr>
            <td>&nbsp;</td>
            <td class=""container"">
                <div class=""content"">
                    <!-- START CENTERED WHITE CONTAINER -->
                    <table role=""presentation"" border=""0"" cellpadding=""0"" cellspacing=""0"" style=""background-color: white; padding-left:15px;"">
                        <tr>
                            <td><img class=""banner-img"" width=""600"" src=""https://media.licdn.com/dms/image/C511BAQFQ_xK7-1SOhQ/company-background_10000/0?e=2159024400&v=beta&t=NQ7sLlyJnnbRrEgjFOA6xG6bzJNqg51SR-mf77spfA8"" alt=""""></td>
                        </tr>
                        <tr>
                            <td>
                                <p>Se ha registrado una nueva solicitud de permiso</p>
                                <br />
                                <p>Detalle</p>
                  ");
                WriteLiteral(@"              <table role=""presentation"" border=""0"" cellpadding=""0"" cellspacing=""0"" class="""">
                                    <tr>
                                        <th style=""background-color: lightgray"">Solicitante</th>
                                    </tr>
                                    <tr>
                                        <th>
                                            <table style=""text-align: left"">
                                                <tr>
                                                    <td><strong>No.Nomina</strong></td>
                                                    <td>");
                EndContext();
                BeginContext(13588, 32, false);
#line 477 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\IncidenciaPermiso\DetailsEmail.cshtml"
                                                   Write(Model.view_Empleado.NumeroNomina);

#line default
#line hidden
                EndContext();
                BeginContext(13620, 267, true);
                WriteLiteral(@"</td>
                                                </tr>
                                                <tr>
                                                    <td><strong>Nombre completo</strong></td>
                                                    <td>");
                EndContext();
                BeginContext(13888, 34, false);
#line 481 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\IncidenciaPermiso\DetailsEmail.cshtml"
                                                   Write(Model.view_Empleado.NombreCompleto);

#line default
#line hidden
                EndContext();
                BeginContext(13922, 264, true);
                WriteLiteral(@"</td>
                                                </tr>
                                                <tr>
                                                    <td><strong>Departamento</strong></td>
                                                    <td>");
                EndContext();
                BeginContext(14187, 38, false);
#line 485 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\IncidenciaPermiso\DetailsEmail.cshtml"
                                                   Write(Model.view_Empleado.NombreDepartamento);

#line default
#line hidden
                EndContext();
                BeginContext(14225, 258, true);
                WriteLiteral(@"</td>
                                                </tr>
                                                <tr>
                                                    <td><strong>Puesto</strong></td>
                                                    <td>");
                EndContext();
                BeginContext(14484, 32, false);
#line 489 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\IncidenciaPermiso\DetailsEmail.cshtml"
                                                   Write(Model.view_Empleado.PuestoNombre);

#line default
#line hidden
                EndContext();
                BeginContext(14516, 749, true);
                WriteLiteral(@";</td>
                                                </tr>
                                            </table>
                                        </th>
                                    </tr>
                                    <tr>
                                        <th style=""background-color: lightgray"">Solicitud</th>
                                    </tr>
                                    <tr>
                                        <th>
                                            <table style=""text-align: left"">
                                                <tr>
                                                    <td><strong>Folio</strong></td>
                                                    <td>");
                EndContext();
                BeginContext(15266, 29, false);
#line 502 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\IncidenciaPermiso\DetailsEmail.cshtml"
                                                   Write(Model.IncidenciaPermiso.Folio);

#line default
#line hidden
                EndContext();
                BeginContext(15295, 257, true);
                WriteLiteral(@"</td>
                                                </tr>
                                                <tr>
                                                    <td><strong>Fecha</strong></td>
                                                    <td>");
                EndContext();
                BeginContext(15553, 52, false);
#line 506 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\IncidenciaPermiso\DetailsEmail.cshtml"
                                                   Write(Model.IncidenciaPermiso.Fecha.ToString("yyyy-MM-dd"));

#line default
#line hidden
                EndContext();
                BeginContext(15605, 254, true);
                WriteLiteral("</td>\r\n                                                </tr>\r\n                                                <tr>\r\n                                                    <td><strong>De</strong></td>\r\n                                                    <td>");
                EndContext();
                BeginContext(15860, 30, false);
#line 510 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\IncidenciaPermiso\DetailsEmail.cshtml"
                                                   Write(Model.IncidenciaPermiso.Inicio);

#line default
#line hidden
                EndContext();
                BeginContext(15890, 257, true);
                WriteLiteral(@"</td>
                                                </tr>
                                                <tr>
                                                    <td><strong>Hasta</strong></td>
                                                    <td>");
                EndContext();
                BeginContext(16148, 27, false);
#line 514 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\IncidenciaPermiso\DetailsEmail.cshtml"
                                                   Write(Model.IncidenciaPermiso.Fin);

#line default
#line hidden
                EndContext();
                BeginContext(16175, 258, true);
                WriteLiteral(@"</td>
                                                </tr>
                                                <tr>
                                                    <td><strong>Asunto</strong></td>
                                                    <td>");
                EndContext();
                BeginContext(16434, 12, false);
#line 518 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\IncidenciaPermiso\DetailsEmail.cshtml"
                                                   Write(Model.Asunto);

#line default
#line hidden
                EndContext();
                BeginContext(16446, 263, true);
                WriteLiteral(@"</td>
                                                </tr>
                                                <tr>
                                                    <td><strong>Comentarios</strong></td>
                                                    <td>");
                EndContext();
                BeginContext(16710, 41, false);
#line 522 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\IncidenciaPermiso\DetailsEmail.cshtml"
                                                   Write(Model.IncidenciaPermiso.DescripcionAsunto);

#line default
#line hidden
                EndContext();
                BeginContext(16751, 256, true);
                WriteLiteral(@"</td>
                                                </tr>
                                                <tr>
                                                    <td><strong>Pago</strong></td>
                                                    <td>");
                EndContext();
                BeginContext(17008, 17, false);
#line 526 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\IncidenciaPermiso\DetailsEmail.cshtml"
                                                   Write(Model.PagoPermiso);

#line default
#line hidden
                EndContext();
                BeginContext(17025, 1029, true);
                WriteLiteral(@"</td>
                                                </tr>
                                            </table>
                                        </th>
                                    </tr>
                                </table>
                                <p>
                                    <br>
                                    <table role=""presentation"" border=""0"" cellpadding=""0"" cellspacing=""0"" class="""">
                                        <tbody>
                                            <tr>
                                                <td>
                                                    <!-- <center> -->
                                                    <table role=""presentation"" border=""0"" cellpadding=""0"" cellspacing=""0"" class="""">
                                                        <tbody>
                                                            <tr>

                                                                <td align=""center""> <a tit");
                WriteLiteral("le=\"\"");
                EndContext();
                BeginWriteAttribute("href", " href=\"", 18054, "\"", 18066, 1);
#line 543 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\IncidenciaPermiso\DetailsEmail.cshtml"
WriteAttributeValue("", 18061, Link, 18061, 5, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(18067, 131, true);
                WriteLiteral(" target=\"_blank\">Aprobar o rechazar</a> </td>\r\n                                                                <!-- <td></td> -->\r\n");
                EndContext();
                BeginContext(18359, 1899, true);
                WriteLiteral(@"                                                            </tr>
                                                        </tbody>
                                                    </table>
                                                    <!-- </center> -->
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </p>

                                <p><br></p>
                                <p align=""center"">Este es un correo electrónico generado automáticamente</p>
                            </td>
                        </tr>
                    </table>
                    <!-- END CENTERED WHITE CONTAINER -->
                    <!-- START FOOTER -->
                    <div class=""footer"">
                        <table role=""presentation"" border=""0"" cellpadding=""0"" cellspacing=""0"">
                        ");
                WriteLiteral(@"    <tr>
                                <td class=""content-block"">
                                    <span class=""apple-link"">Grupo Splittel</span>
                                    <br> Parque Tecnológico Innovación Querétaro Lateral de la carretera Estatal 431, km.2+200, Int.28, 76246 Santiago de Querétaro, Qro.<a href=""http://splittel.com"">Grupo Splittel</a>.
                                </td>
                            </tr>
                            <tr>
                                <td class=""content-block powered-by"">
                                    </a>
                                </td>
                            </tr>
                        </table>
                    </div>
                    <!-- END FOOTER -->

                </div>
            </td>
            <td>&nbsp;</td>
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
            BeginContext(20265, 11, true);
            WriteLiteral("\r\n</html>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<GPSInformation.Reportes.IncidenciaPermisoRe> Html { get; private set; }
    }
}
#pragma warning restore 1591
