#pragma checksum "C:\Luis Martinez backup\Personal\Developments\NET\GrupoSplittel\GrupoSplittel\GestionPersonal\Views\CatalogoOpciones\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "32b3fa2f2660b020a246e79b0b2ff3c5abc1f8ad"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_CatalogoOpciones_Index), @"mvc.1.0.view", @"/Views/CatalogoOpciones/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/CatalogoOpciones/Index.cshtml", typeof(AspNetCore.Views_CatalogoOpciones_Index))]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"32b3fa2f2660b020a246e79b0b2ff3c5abc1f8ad", @"/Views/CatalogoOpciones/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"44f628e23a2086c1f04f862587f80afdb82e0a32", @"/Views/_ViewImports.cshtml")]
    public class Views_CatalogoOpciones_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<GPSInformation.Models.CatalogoOpciones>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(60, 2, true);
            WriteLiteral("\r\n");
            EndContext();
#line 3 "C:\Luis Martinez backup\Personal\Developments\NET\GrupoSplittel\GrupoSplittel\GestionPersonal\Views\CatalogoOpciones\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
            BeginContext(103, 29, true);
            WriteLiteral("\r\n<h2>Index</h2>\r\n\r\n<p>\r\n    ");
            EndContext();
            BeginContext(132, 37, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "81db3f1e4af4466bbb0aa6ca76ebc1ba", async() => {
                BeginContext(155, 10, true);
                WriteLiteral("Create New");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(169, 92, true);
            WriteLiteral("\r\n</p>\r\n<table class=\"table\">\r\n    <thead>\r\n        <tr>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(262, 54, false);
#line 16 "C:\Luis Martinez backup\Personal\Developments\NET\GrupoSplittel\GrupoSplittel\GestionPersonal\Views\CatalogoOpciones\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.IdCatalogoOpciones));

#line default
#line hidden
            EndContext();
            BeginContext(316, 55, true);
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
            EndContext();
            BeginContext(372, 47, false);
#line 19 "C:\Luis Martinez backup\Personal\Developments\NET\GrupoSplittel\GrupoSplittel\GestionPersonal\Views\CatalogoOpciones\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Descripcion));

#line default
#line hidden
            EndContext();
            BeginContext(419, 86, true);
            WriteLiteral("\r\n            </th>\r\n            <th></th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
            EndContext();
#line 25 "C:\Luis Martinez backup\Personal\Developments\NET\GrupoSplittel\GrupoSplittel\GestionPersonal\Views\CatalogoOpciones\Index.cshtml"
 foreach (var item in Model) {

#line default
#line hidden
            BeginContext(537, 48, true);
            WriteLiteral("        <tr>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(586, 53, false);
#line 28 "C:\Luis Martinez backup\Personal\Developments\NET\GrupoSplittel\GrupoSplittel\GestionPersonal\Views\CatalogoOpciones\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.IdCatalogoOpciones));

#line default
#line hidden
            EndContext();
            BeginContext(639, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(695, 46, false);
#line 31 "C:\Luis Martinez backup\Personal\Developments\NET\GrupoSplittel\GrupoSplittel\GestionPersonal\Views\CatalogoOpciones\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Descripcion));

#line default
#line hidden
            EndContext();
            BeginContext(741, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(797, 67, false);
#line 34 "C:\Luis Martinez backup\Personal\Developments\NET\GrupoSplittel\GrupoSplittel\GestionPersonal\Views\CatalogoOpciones\Index.cshtml"
           Write(Html.ActionLink("Edit", "Edit", new { id=item.IdCatalogoOpciones }));

#line default
#line hidden
            EndContext();
            BeginContext(864, 20, true);
            WriteLiteral(" |\r\n                ");
            EndContext();
            BeginContext(885, 71, false);
#line 35 "C:\Luis Martinez backup\Personal\Developments\NET\GrupoSplittel\GrupoSplittel\GestionPersonal\Views\CatalogoOpciones\Index.cshtml"
           Write(Html.ActionLink("Details", "Details", new { /* id=item.PrimaryKey */ }));

#line default
#line hidden
            EndContext();
            BeginContext(956, 20, true);
            WriteLiteral(" |\r\n                ");
            EndContext();
            BeginContext(977, 69, false);
#line 36 "C:\Luis Martinez backup\Personal\Developments\NET\GrupoSplittel\GrupoSplittel\GestionPersonal\Views\CatalogoOpciones\Index.cshtml"
           Write(Html.ActionLink("Delete", "Delete", new { /* id=item.PrimaryKey */ }));

#line default
#line hidden
            EndContext();
            BeginContext(1046, 36, true);
            WriteLiteral("\r\n            </td>\r\n        </tr>\r\n");
            EndContext();
#line 39 "C:\Luis Martinez backup\Personal\Developments\NET\GrupoSplittel\GrupoSplittel\GestionPersonal\Views\CatalogoOpciones\Index.cshtml"
}

#line default
#line hidden
            BeginContext(1085, 24, true);
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<GPSInformation.Models.CatalogoOpciones>> Html { get; private set; }
    }
}
#pragma warning restore 1591