#pragma checksum "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\IncidenciaVacacion\DetailsEmail.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f1b3626be4e847a14e71f3bc9afb12455a6be035"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_IncidenciaVacacion_DetailsEmail), @"mvc.1.0.view", @"/Views/IncidenciaVacacion/DetailsEmail.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/IncidenciaVacacion/DetailsEmail.cshtml", typeof(AspNetCore.Views_IncidenciaVacacion_DetailsEmail))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f1b3626be4e847a14e71f3bc9afb12455a6be035", @"/Views/IncidenciaVacacion/DetailsEmail.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"44f628e23a2086c1f04f862587f80afdb82e0a32", @"/Views/_ViewImports.cshtml")]
    public class Views_IncidenciaVacacion_DetailsEmail : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<GPSInformation.Reportes.IncidenciaVacaRe>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("width", new global::Microsoft.AspNetCore.Html.HtmlString("100%"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("margin: 0; padding: 0 !important; mso-line-height-rule: exactly; background-color: #f1f1f1;"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            BeginContext(49, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\IncidenciaVacacion\DetailsEmail.cshtml"
  
    Layout = null;
    string Link = "";

    

#line default
#line hidden
#line 7 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\IncidenciaVacacion\DetailsEmail.cshtml"
     if (Model.ModeAmin)
    {
        Link = string.Format("http://{0}:{1}/IncidenciaVacacion/Aprobar?id={2}&Mode=2", "192.168.2.29", "3456", Model.IncidenciaVacacion.IdIncidenciaVacacion); ;
    }
    else
    {
        Link = string.Format("http://{0}:{1}/IncidenciaVacacion/Aprobar?id={2}&Mode=1", "192.168.2.29", "3456", Model.IncidenciaVacacion.IdIncidenciaVacacion); ;
    }

#line default
#line hidden
            BeginContext(495, 164, true);
            WriteLiteral("\r\n<!DOCTYPE html>\r\n<html lang=\"en\" xmlns=\"http://www.w3.org/1999/xhtml\" xmlns:v=\"urn:schemas-microsoft-com:vml\" xmlns:o=\"urn:schemas-microsoft-com:office:office\">\r\n");
            EndContext();
            BeginContext(659, 12204, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b72498b778724f08bbc95fd4baac934f", async() => {
                BeginContext(665, 301, true);
                WriteLiteral(@"
    <meta charset=""utf-8"">
    <meta name=""viewport"" content=""width=device-width"">
    <meta http-equiv=""X-UA-Compatible"" content=""IE=edge"">
    <meta name=""x-apple-disable-message-reformatting"">
    <title>Notificacion</title>

    <style id="""" media=""all"">
        /* latin-ext */
        ");
                EndContext();
                BeginContext(967, 383, true);
                WriteLiteral(@"@font-face {
            font-family: 'Lato';
            font-style: normal;
            font-weight: 300;
            src: url(/fonts.gstatic.com/s/lato/v17/S6u9w4BMUTPHh7USSwaPGR_p.woff2) format('woff2');
            unicode-range: U+0100-024F, U+0259, U+1E00-1EFF, U+2020, U+20A0-20AB, U+20AD-20CF, U+2113, U+2C60-2C7F, U+A720-A7FF;
        }
        /* latin */
        ");
                EndContext();
                BeginContext(1351, 439, true);
                WriteLiteral(@"@font-face {
            font-family: 'Lato';
            font-style: normal;
            font-weight: 300;
            src: url(/fonts.gstatic.com/s/lato/v17/S6u9w4BMUTPHh7USSwiPGQ.woff2) format('woff2');
            unicode-range: U+0000-00FF, U+0131, U+0152-0153, U+02BB-02BC, U+02C6, U+02DA, U+02DC, U+2000-206F, U+2074, U+20AC, U+2122, U+2191, U+2193, U+2212, U+2215, U+FEFF, U+FFFD;
        }
        /* latin-ext */
        ");
                EndContext();
                BeginContext(1791, 379, true);
                WriteLiteral(@"@font-face {
            font-family: 'Lato';
            font-style: normal;
            font-weight: 400;
            src: url(/fonts.gstatic.com/s/lato/v17/S6uyw4BMUTPHjxAwXjeu.woff2) format('woff2');
            unicode-range: U+0100-024F, U+0259, U+1E00-1EFF, U+2020, U+20A0-20AB, U+20AD-20CF, U+2113, U+2C60-2C7F, U+A720-A7FF;
        }
        /* latin */
        ");
                EndContext();
                BeginContext(2171, 435, true);
                WriteLiteral(@"@font-face {
            font-family: 'Lato';
            font-style: normal;
            font-weight: 400;
            src: url(/fonts.gstatic.com/s/lato/v17/S6uyw4BMUTPHjx4wXg.woff2) format('woff2');
            unicode-range: U+0000-00FF, U+0131, U+0152-0153, U+02BB-02BC, U+02C6, U+02DA, U+02DC, U+2000-206F, U+2074, U+20AC, U+2122, U+2191, U+2193, U+2212, U+2215, U+FEFF, U+FFFD;
        }
        /* latin-ext */
        ");
                EndContext();
                BeginContext(2607, 383, true);
                WriteLiteral(@"@font-face {
            font-family: 'Lato';
            font-style: normal;
            font-weight: 700;
            src: url(/fonts.gstatic.com/s/lato/v17/S6u9w4BMUTPHh6UVSwaPGR_p.woff2) format('woff2');
            unicode-range: U+0100-024F, U+0259, U+1E00-1EFF, U+2020, U+20A0-20AB, U+20AD-20CF, U+2113, U+2C60-2C7F, U+A720-A7FF;
        }
        /* latin */
        ");
                EndContext();
                BeginContext(2991, 3474, true);
                WriteLiteral(@"@font-face {
            font-family: 'Lato';
            font-style: normal;
            font-weight: 700;
            src: url(/fonts.gstatic.com/s/lato/v17/S6u9w4BMUTPHh6UVSwiPGQ.woff2) format('woff2');
            unicode-range: U+0000-00FF, U+0131, U+0152-0153, U+02BB-02BC, U+02C6, U+02DA, U+02DC, U+2000-206F, U+2074, U+20AC, U+2122, U+2191, U+2193, U+2212, U+2215, U+FEFF, U+FFFD;
        }
    </style>

    <style>

        /* What it does: Remove spaces around the email design added by some email clients. */
        /* Beware: It can remove the padding / margin and add a background color to the compose a reply window. */
        html,
        body {
            margin: 0 auto !important;
            padding: 0 !important;
            height: 100% !important;
            width: 100% !important;
            background: #f1f1f1;
        }

        /* What it does: Stops email clients resizing small text. */
        * {
            -ms-text-size-adjust: 100%;
            -webkit-te");
                WriteLiteral(@"xt-size-adjust: 100%;
        }

        /* What it does: Centers email on Android 4.4 */
        div[style*=""margin: 16px 0""] {
            margin: 0 !important;
        }

        /* What it does: Stops Outlook from adding extra spacing to tables. */
        table,
        td {
            mso-table-lspace: 0pt !important;
            mso-table-rspace: 0pt !important;
        }

        /* What it does: Fixes webkit padding issue. */
        table {
            /*border-spacing: 0 !important;
            border-collapse: collapse !important;
            table-layout: fixed !important;
            margin: 0 auto !important;*/
            width: 100% !important
        }

        /* What it does: Uses a better rendering method when resizing images in IE. */
        img {
            -ms-interpolation-mode: bicubic;
        }

        /* What it does: Prevents Windows 10 Mail from underlining links despite inline CSS. Styles for underlined links should be inline. */
        a {
 ");
                WriteLiteral(@"           text-decoration: none;
        }

        /* What it does: A work-around for email clients meddling in triggered links. */
        *[x-apple-data-detectors], /* iOS */
        .unstyle-auto-detected-links *,
        .aBn {
            border-bottom: 0 !important;
            cursor: default !important;
            color: inherit !important;
            text-decoration: none !important;
            font-size: inherit !important;
            font-family: inherit !important;
            font-weight: inherit !important;
            line-height: inherit !important;
        }

        /* What it does: Prevents Gmail from displaying a download button on large, non-linked images. */
        .a6S {
            display: none !important;
            opacity: 0.01 !important;
        }

        /* What it does: Prevents Gmail from changing the text color in conversation threads. */
        .im {
            color: inherit !important;
        }

        /* If the above doesn't work, ");
                WriteLiteral(@"add a .g-img class to any image in question. */
        img.g-img + div {
            display: none !important;
        }

        /* What it does: Removes right gutter in Gmail iOS app: https://github.com/TedGoas/Cerberus/issues/89  */
        /* Create one of these media queries for each additional viewport size you'd like to fix */

        /* iPhone 4, 4S, 5, 5S, 5C, and 5SE */
        ");
                EndContext();
                BeginContext(6466, 243, true);
                WriteLiteral("@media only screen and (min-device-width: 320px) and (max-device-width: 374px) {\r\n            u ~ div .email-container {\r\n                min-width: 320px !important;\r\n            }\r\n        }\r\n        /* iPhone 6, 6S, 7, 8, and X */\r\n        ");
                EndContext();
                BeginContext(6710, 239, true);
                WriteLiteral("@media only screen and (min-device-width: 375px) and (max-device-width: 413px) {\r\n            u ~ div .email-container {\r\n                min-width: 375px !important;\r\n            }\r\n        }\r\n        /* iPhone 6+, 7+, and 8+ */\r\n        ");
                EndContext();
                BeginContext(6950, 5838, true);
                WriteLiteral(@"@media only screen and (min-device-width: 414px) {
            u ~ div .email-container {
                min-width: 414px !important;
            }
        }
    </style>

    <style>
        .preheader {
            color: transparent;
            display: none;
            height: 0;
            max-height: 0;
            max-width: 0;
            opacity: 0;
            overflow: hidden;
            mso-hide: all;
            visibility: hidden;
            width: 0;
        }
        .primary {
            background: #30e3ca;
        }

        .bg_white {
            background: #ffffff;
        }

        .bg_light {
            background: #fafafa;
        }

        .bg_black {
            background: #000000;
        }

        .bg_dark {
            background: rgba(0,0,0,.8);
        }

        .email-section {
            padding: 2.5em;
        }

        /*BUTTON*/
        .btn {
            padding: 10px 15px;
            display: inline-block;
");
                WriteLiteral(@"        }

            .btn.btn-primary {
                border-radius: 5px;
                background: #30e3ca;
                color: #ffffff;
            }
            .btn.btn-danger {
                border-radius: 5px;
                background: #d9534f;
                color: #ffffff;
            }

            .btn.btn-white {
                border-radius: 5px;
                background: #ffffff;
                color: #000000;
            }

            .btn.btn-white-outline {
                border-radius: 5px;
                background: transparent;
                border: 1px solid #fff;
                color: #fff;
            }

            .btn.btn-black-outline {
                border-radius: 0px;
                background: transparent;
                border: 2px solid #000;
                color: #000;
                font-weight: 700;
            }

        h1, h2, h3, h4, h5, h6 {
            font-family: 'Lato', sans-serif;
            color: #");
                WriteLiteral(@"000000;
            margin-top: 0;
            font-weight: 400;
        }

        body {
            font-family: 'Lato', sans-serif;
            font-weight: 400;
            font-size: 15px;
            line-height: 1.8;
            color: rgba(0,0,0,.4);
        }

        a {
            color: #30e3ca;
        }

        table {
        }
        /*LOGO*/

        .logo h1 {
            margin: 0;
        }

            .logo h1 a {
                color: #30e3ca;
                font-size: 24px;
                font-weight: 700;
                font-family: 'Lato', sans-serif;
            }

        /*HERO*/
        .hero {
            position: relative;
            z-index: 0;
        }

            .hero .text {
                color: rgba(0,0,0,.3);
            }

                .hero .text h2 {
                    color: #000;
                    font-size: 40px;
                    margin-bottom: 0;
                    font-weight: 400;
           ");
                WriteLiteral(@"         line-height: 1.4;
                }

                .hero .text h3 {
                    font-size: 24px;
                    font-weight: 300;
                }

                .hero .text h2 span {
                    font-weight: 600;
                    color: #30e3ca;
                }


        /*HEADING SECTION*/
        .heading-section {
        }

            .heading-section h2 {
                color: #000000;
                font-size: 28px;
                margin-top: 0;
                line-height: 1.4;
                font-weight: 400;
            }

            .heading-section .subheading {
                margin-bottom: 20px !important;
                display: inline-block;
                font-size: 13px;
                text-transform: uppercase;
                letter-spacing: 2px;
                color: rgba(0,0,0,.4);
                position: relative;
            }

                .heading-section .subheading::after {
                ");
                WriteLiteral(@"    position: absolute;
                    left: 0;
                    right: 0;
                    bottom: -10px;
                    content: '';
                    width: 100%;
                    height: 2px;
                    background: #30e3ca;
                    margin: 0 auto;
                }

        .heading-section-white {
            color: rgba(255,255,255,.8);
        }

            .heading-section-white h2 {
                font-family: line-height: 1;
                padding-bottom: 0;
            }

            .heading-section-white h2 {
                color: #ffffff;
            }

            .heading-section-white .subheading {
                margin-bottom: 0;
                display: inline-block;
                font-size: 13px;
                text-transform: uppercase;
                letter-spacing: 2px;
                color: rgba(255,255,255,.4);
            }


        ul.social {
            padding: 0;
        }

            ul.");
                WriteLiteral(@"social li {
                display: inline-block;
                margin-right: 10px;
            }

        /*FOOTER*/

        .footer {
            border-top: 1px solid rgba(0,0,0,.05);
            color: rgba(0,0,0,.5);
        }

            .footer .heading {
                color: #000;
                font-size: 20px;
            }

            .footer ul {
                margin: 0;
                padding: 0;
            }

                .footer ul li {
                    list-style: none;
                    margin-bottom: 10px;
                }

                    .footer ul li a {
                        color: rgba(0,0,0,1);
                    }


        ");
                EndContext();
                BeginContext(12789, 67, true);
                WriteLiteral("@media screen and (max-width: 500px) {\r\n        }\r\n    </style>\r\n\r\n");
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
            BeginContext(12863, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(12865, 6946, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "13f663bf39ac47be8b8e4f730a068dab", async() => {
                BeginContext(12984, 1303, true);
                WriteLiteral(@"
    <span class=""preheader"">Gestión de personal</span>
    <center style=""width: 100%; background-color: #f1f1f1;"">
        <div style=""display: none; font-size: 1px;max-height: 0px; max-width: 0px; opacity: 0; overflow: hidden; mso-hide: all; font-family: sans-serif;"">
            &zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;&zwnj;&nbsp;
        </div>
        <div style=""max-width: 900px; margin: 0 auto;"" class=""email-container"">
            <table align=""center"" role=""presentation"" cellspacing=""0"" cellpadding=""0"" border=""0"" width=""100%"" style=""margin: auto;"">
                <tr>
                    <td class=""bg_light"" style=""text-align: center;"">
                        <h1>Sistema Gestión de Personal </h1>
                    </td>
                </tr>
            </table>
            <table align=""center"" role=""presentation"" cells");
                WriteLiteral(@"pacing=""0"" cellpadding=""0"" border=""0"" width=""100%"" style=""margin: auto;"">
                <tr>
                    <td valign=""middle"" class=""hero bg_white"" style=""padding: 2em 0 4em 0;"">
                        <div class=""text"" style=""padding: 0 2.5em; text-align: left;"">
");
                EndContext();
#line 435 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\IncidenciaVacacion\DetailsEmail.cshtml"
                             if (Model.Mode == "CreadoN1")
                            {

#line default
#line hidden
                BeginContext(14378, 328, true);
                WriteLiteral(@"                                <p style=""padding: 0 2.5em; text-align: left;"">
                                    Estimado Usuario, se ha creado una nueva solicitud de vacaciones, por favor ingresa a cualquiera de las opciones que se encuentran al final de este correo para revisarla!!
                                </p>
");
                EndContext();
#line 440 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\IncidenciaVacacion\DetailsEmail.cshtml"
                            }
                            else if (Model.Mode == "CreadoN2")
                            {

#line default
#line hidden
                BeginContext(14832, 328, true);
                WriteLiteral(@"                                <p style=""padding: 0 2.5em; text-align: left;"">
                                    Estimado Usuario, se ha creado una nueva solicitud de vacaciones, por favor ingresa a cualquiera de las opciones que se encuentran al final de este correo para revisarla!!
                                </p>
");
                EndContext();
#line 446 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\IncidenciaVacacion\DetailsEmail.cshtml"
                            }
                            else if (Model.Mode == "Aceptado")
                            {

#line default
#line hidden
                BeginContext(15286, 341, true);
                WriteLiteral(@"                                <p style=""padding: 0 2.5em; text-align: left;"">
                                    Estimado Usuario, su solicitud de vaciones ha sido <strong>aceptada!</strong>, por favor ingresa a cualquiera de las opciones que se encuentran al final de este correo para revisarla!!
                                </p>
");
                EndContext();
#line 452 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\IncidenciaVacacion\DetailsEmail.cshtml"
                            }
                            else if (Model.Mode == "Rechazado")
                            {

#line default
#line hidden
                BeginContext(15754, 319, true);
                WriteLiteral(@"                        <p style=""padding: 0 2.5em; text-align: left;"">
                            Estimado Usuario, su solicitud de vaciones ha sido <strong>rechazada!</strong>s, por favor ingresa a cualquiera de las opciones que se encuentran al final de este correo para revisarla!!
                        </p>
");
                EndContext();
#line 458 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\IncidenciaVacacion\DetailsEmail.cshtml"
                            }

#line default
#line hidden
                BeginContext(16104, 559, true);
                WriteLiteral(@"                            <br />
                            <br />
                            <table style=""padding: 0 2.5em; text-align: left;"" role=""presentation"" border=""0"" cellpadding=""0"" cellspacing=""0"" class="""">
                                <tr>
                                    <th colspan=""2"" style=""background-color: lightgray"">Solicitante</th>
                                </tr>
                                <tr>
                                    <td><strong>No.Nomina</strong></td>
                                    <td>");
                EndContext();
                BeginContext(16664, 32, false);
#line 467 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\IncidenciaVacacion\DetailsEmail.cshtml"
                                   Write(Model.view_Empleado.NumeroNomina);

#line default
#line hidden
                EndContext();
                BeginContext(16696, 203, true);
                WriteLiteral("</td>\r\n                                </tr>\r\n                                <tr>\r\n                                    <td><strong>Nombre completo</strong></td>\r\n                                    <td>");
                EndContext();
                BeginContext(16900, 34, false);
#line 471 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\IncidenciaVacacion\DetailsEmail.cshtml"
                                   Write(Model.view_Empleado.NombreCompleto);

#line default
#line hidden
                EndContext();
                BeginContext(16934, 200, true);
                WriteLiteral("</td>\r\n                                </tr>\r\n                                <tr>\r\n                                    <td><strong>Departamento</strong></td>\r\n                                    <td>");
                EndContext();
                BeginContext(17135, 38, false);
#line 475 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\IncidenciaVacacion\DetailsEmail.cshtml"
                                   Write(Model.view_Empleado.NombreDepartamento);

#line default
#line hidden
                EndContext();
                BeginContext(17173, 194, true);
                WriteLiteral("</td>\r\n                                </tr>\r\n                                <tr>\r\n                                    <td><strong>Puesto</strong></td>\r\n                                    <td>");
                EndContext();
                BeginContext(17368, 32, false);
#line 479 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\IncidenciaVacacion\DetailsEmail.cshtml"
                                   Write(Model.view_Empleado.PuestoNombre);

#line default
#line hidden
                EndContext();
                BeginContext(17400, 388, true);
                WriteLiteral(@"</td>
                                </tr>
                                <tr>
                                    <th colspan=""2"" style=""background-color: lightgray"">Detalle de la solicitud</th>
                                </tr>
                                <tr>
                                    <td><strong>Folio</strong></td>
                                    <td>");
                EndContext();
                BeginContext(17789, 30, false);
#line 486 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\IncidenciaVacacion\DetailsEmail.cshtml"
                                   Write(Model.IncidenciaVacacion.Folio);

#line default
#line hidden
                EndContext();
                BeginContext(17819, 203, true);
                WriteLiteral("</td>\r\n                                </tr>\r\n                                <tr>\r\n                                    <td><strong>Fecha de salida</strong></td>\r\n                                    <td>");
                EndContext();
                BeginContext(18023, 54, false);
#line 490 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\IncidenciaVacacion\DetailsEmail.cshtml"
                                   Write(Model.IncidenciaVacacion.Inicio.ToString("yyyy-MM-dd"));

#line default
#line hidden
                EndContext();
                BeginContext(18077, 198, true);
                WriteLiteral("</td>\r\n                                </tr>\r\n                                <tr>\r\n                                    <td><strong>Último dia</strong></td>\r\n                                    <td>");
                EndContext();
                BeginContext(18276, 51, false);
#line 494 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\IncidenciaVacacion\DetailsEmail.cshtml"
                                   Write(Model.IncidenciaVacacion.Fin.ToString("yyyy-MM-dd"));

#line default
#line hidden
                EndContext();
                BeginContext(18327, 361, true);
                WriteLiteral(@"</td>
                                </tr>
                            </table>
                            <br />
                            <br />
                            <br />
                            <div class=""text"" style=""padding: 0 2.5em; text-align: center;"">
                                <p>
                                    <a");
                EndContext();
                BeginWriteAttribute("href", " href=\"", 18688, "\"", 18713, 1);
#line 502 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\IncidenciaVacacion\DetailsEmail.cshtml"
WriteAttributeValue("", 18695, Model.LinkPrivate, 18695, 18, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(18714, 45, true);
                WriteLiteral(" class=\"btn btn-danger\">Enlace interno!</a>\r\n");
                EndContext();
                BeginContext(18871, 933, true);
                WriteLiteral(@"                                </p>
                            </div>
                        </div>

                    </td>
                </tr>

            </table>
            <table align=""center"" role=""presentation"" cellspacing=""0"" cellpadding=""0"" border=""0"" width=""100%"" style=""margin: auto;"">
                <tr>
                    <td class=""bg_light"" style=""text-align: center;"">
                        <p>
                            Este es un correo creado automaticamente por <strong>Sistema Gestión de Personal</strong>
                            <br />
                            Parque Tecnológico Innovación Querétaro Lateral de la carretera Estatal 431, km.2+200, Int.28, 76246 Santiago de Querétaro, Qro.<a href=""http://splittel.com"">Grupo Splittel</a>.
                        </p>
                    </td>
                </tr>
            </table>
        </div>
    </center>
");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
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
            BeginContext(19811, 11, true);
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<GPSInformation.Reportes.IncidenciaVacaRe> Html { get; private set; }
    }
}
#pragma warning restore 1591
