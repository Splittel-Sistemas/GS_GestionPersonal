#pragma checksum "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\BuzonQueja\DetailsEmail.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "aa8cfeea1dae7345bb935d41e589738633d17055"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_BuzonQueja_DetailsEmail), @"mvc.1.0.view", @"/Views/BuzonQueja/DetailsEmail.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/BuzonQueja/DetailsEmail.cshtml", typeof(AspNetCore.Views_BuzonQueja_DetailsEmail))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"aa8cfeea1dae7345bb935d41e589738633d17055", @"/Views/BuzonQueja/DetailsEmail.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"44f628e23a2086c1f04f862587f80afdb82e0a32", @"/Views/_ViewImports.cshtml")]
    public class Views_BuzonQueja_DetailsEmail : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<GPSInformation.Models.BuzonQueja>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString(""), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("background-color: #f6f6f6; font-family: sans-serif; -webkit-font-smoothing: antialiased; font-size: 14px; line-height: 1.4; margin: 0; padding: 0; -ms-text-size-adjust: 100%; -webkit-text-size-adjust: 100%;"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            BeginContext(41, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\BuzonQueja\DetailsEmail.cshtml"
  
    ViewData["Title"] = "DetailsEmail";

#line default
#line hidden
            BeginContext(91, 27, true);
            WriteLiteral("\r\n<!doctype html>\r\n<html>\r\n");
            EndContext();
            BeginContext(118, 3728, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "2d8614c761bd4393a979fd2f6774e16e", async() => {
                BeginContext(124, 509, true);
                WriteLiteral(@"
    <meta name=""viewport"" content=""width=device-width"">
    <meta http-equiv=""Content-Type"" content=""text/html; charset=UTF-8"">
    <title>Simple Transactional Email</title>
    <style>
            /* -------------------------------------
            INLINED WITH htmlemail.io/inline
        ------------------------------------- */
            /* -------------------------------------
            RESPONSIVE AND MOBILE FRIENDLY STYLES
        ------------------------------------- */
            ");
                EndContext();
                BeginContext(634, 1780, true);
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
                    border-left-width: 0");
                WriteLiteral(@" !important;
                    border-radius: 0 !important;
                    border-right-width: 0 !important;
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
                BeginContext(2415, 1424, true);
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
                    font-weight: inh");
                WriteLiteral(@"erit;
                    line-height: inherit;
                }

                .btn-primary table td:hover {
                    background-color: #34495e !important;
                }

                .btn-primary a:hover {
                    background-color: #34495e !important;
                    border-color: #34495e !important;
                }
            }
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
            BeginContext(3846, 2, true);
            WriteLiteral("\r\n");
            EndContext();
            BeginContext(3848, 8619, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f8d7a78f515a4c6299b0f3698e6824b5", async() => {
                BeginContext(4078, 3236, true);
                WriteLiteral(@"
    <span class=""preheader"" style=""color: transparent; display: none; height: 0; max-height: 0; max-width: 0; opacity: 0; overflow: hidden; mso-hide: all; visibility: hidden; width: 0;"">Gestión de personal</span>
    <table border=""0"" cellpadding=""0"" cellspacing=""0"" class=""body"" style=""border-collapse: separate; mso-table-lspace: 0pt; mso-table-rspace: 0pt; width: 100%; background-color: #f6f6f6;"">
        <tr>
            <td style=""font-family: sans-serif; font-size: 14px; vertical-align: top;"">&nbsp;</td>
            <td class=""container"" style=""font-family: sans-serif; font-size: 14px; vertical-align: top; display: block; Margin: 0 auto; max-width: 580px; padding: 10px; width: 580px;"">
                <div class=""content"" style=""box-sizing: border-box; display: block; Margin: 0 auto; max-width: 580px; padding: 10px;"">
                    <table class=""main"" style=""border-collapse: separate; mso-table-lspace: 0pt; mso-table-rspace: 0pt; width: 100%; background: #ffffff; border-radius: 3px;"">
     ");
                WriteLiteral(@"                   <tr>
                            <td>
                                <p>
                                    <h2 align=""center"">Grupo Splittel</h2>
                                    <h4 align=""center"">Sistema Gestión de Personal</h4>
                                </p>
                            </td>
                        </tr>
                    </table>

                    <!-- START CENTERED WHITE CONTAINER -->
                    <table class=""main"" style=""border-collapse: separate; mso-table-lspace: 0pt; mso-table-rspace: 0pt; width: 100%; background: #ffffff; border-radius: 3px; "">

                        <!-- START MAIN CONTENT AREA -->
                        <tr>
                            <td class=""wrapper"" style=""font-family: sans-serif; font-size: 14px; vertical-align: top; box-sizing: border-box; padding: 20px;"">
                                <table border=""0"" cellpadding=""0"" cellspacing=""0"" style=""border-collapse: separate; mso-table-lspace: 0pt;");
                WriteLiteral(@" mso-table-rspace: 0pt; width: 100%;"">
                                    <tr>
                                        <td style=""font-family: sans-serif; font-size: 14px; vertical-align: top;"">
                                            <p style=""font-family: sans-serif; font-size: 14px; font-weight: normal; margin: 0; Margin-bottom: 15px;"">
                                                <br />
                                                <br />
                                                Hola: 
                                                <br />
                                                <br />
                                            </p>
                                            <p style=""font-family: sans-serif; font-size: 14px; font-weight: normal; margin: 0; Margin-bottom: 15px;"">
                                                Se ha generado un nuevo buzón, por favor ingresa a <a href=""http://192.168.2.29:3456/BuzonQueja/Index"">Gestion de personal</a>
               ");
                WriteLiteral("                                 <br />\r\n                                                <br />\r\n                                                <b>Comentario:</b> ");
                EndContext();
                BeginContext(7315, 16, false);
#line 154 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\BuzonQueja\DetailsEmail.cshtml"
                                                              Write(Model.Comentario);

#line default
#line hidden
                EndContext();
                BeginContext(7331, 120, true);
                WriteLiteral("\r\n                                                <br />\r\n                                                <b>fecha:</b> ");
                EndContext();
                BeginContext(7452, 14, false);
#line 156 "C:\Luis Martinez backup\Splittel\Repositorios\GS_GestionPersonal_\GestionPersonal\Views\BuzonQueja\DetailsEmail.cshtml"
                                                         Write(Model.Creacion);

#line default
#line hidden
                EndContext();
                BeginContext(7466, 108, true);
                WriteLiteral("\r\n                                                <br />\r\n                                            </p>\r\n");
                EndContext();
                BeginContext(9868, 2592, true);
                WriteLiteral(@"                                            <p style=""font-family: sans-serif; font-size: 14px; font-weight: normal; margin: 0; Margin-bottom: 15px;Margin-top: 95px;"">
                                                Este es un correo electrónico generado automáticamente por Sistema Gestión de Personal
                                            </p>
                                            <p style=""font-family: sans-serif; font-size: 14px; font-weight: normal; margin: 0; Margin-bottom: 15px;"">

                                            </p>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>

                        <!-- END MAIN CONTENT AREA -->
                    </table>

                    <!-- START FOOTER -->
                    <div class=""footer"" style=""clear: both; Margin-top: 10px; text-align: center; width: 100%;"">
                    ");
                WriteLiteral(@"    <table border=""0"" cellpadding=""0"" cellspacing=""0"" style=""border-collapse: separate; mso-table-lspace: 0pt; mso-table-rspace: 0pt; width: 100%;"">
                            <tr>
                                <td class=""content-block"" style=""font-family: sans-serif; vertical-align: top; padding-bottom: 10px; padding-top: 10px; font-size: 12px; color: #999999; text-align: center;"">
                                    <span class=""apple-link"" style=""color: #999999; font-size: 12px; text-align: center;"">Parque Tecnológico Innovación Querétaro Lateral de la carretera Estatal 431, km.2+200, Int.28, 76246 Santiago de Querétaro, Qro.</span>
                                </td>
                            </tr>
                            <tr>
                                <td class=""content-block powered-by"" style=""font-family: sans-serif; vertical-align: top; padding-bottom: 10px; padding-top: 10px; font-size: 12px; color: #999999; text-align: center;"">
                                    Powered by");
                WriteLiteral(@" <a href=""http://htmlemail.io"" style=""color: #999999; font-size: 12px; text-align: center; text-decoration: none;"">Grupo Splittel</a>.
                                </td>
                            </tr>
                        </table>
                    </div>
                    <!-- END FOOTER -->
                    <!-- END CENTERED WHITE CONTAINER -->
                </div>
            </td>
            <td style=""font-family: sans-serif; font-size: 14px; vertical-align: top;"">&nbsp;</td>
        </tr>
    </table>
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
            BeginContext(12467, 11, true);
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<GPSInformation.Models.BuzonQueja> Html { get; private set; }
    }
}
#pragma warning restore 1591
