#pragma checksum "C:\Users\Veso\Desktop\Programs\C#\TechModul4.0\FinalExam4Dec\Skeleton-C#\BandRegister\Views\Band\Edit.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "3c0922d7859b7879b7b3f7c071179938251f3cd8"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Band_Edit), @"mvc.1.0.view", @"/Views/Band/Edit.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Band/Edit.cshtml", typeof(AspNetCore.Views_Band_Edit))]
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
#line 1 "C:\Users\Veso\Desktop\Programs\C#\TechModul4.0\FinalExam4Dec\Skeleton-C#\BandRegister\Views\_ViewImports.cshtml"
using BandRegister;

#line default
#line hidden
#line 2 "C:\Users\Veso\Desktop\Programs\C#\TechModul4.0\FinalExam4Dec\Skeleton-C#\BandRegister\Views\_ViewImports.cshtml"
using BandRegister.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3c0922d7859b7879b7b3f7c071179938251f3cd8", @"/Views/Band/Edit.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"689402075cb61d2590e8fdf596412101e16e7f0e", @"/Views/_ViewImports.cshtml")]
    public class Views_Band_Edit : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Band>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Band", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "POST", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "C:\Users\Veso\Desktop\Programs\C#\TechModul4.0\FinalExam4Dec\Skeleton-C#\BandRegister\Views\Band\Edit.cshtml"
  
    ViewData["Title"] = "Edit";

#line default
#line hidden
            BeginContext(53, 103, true);
            WriteLiteral("\r\n<h2>Edit</h2>\r\n\r\n<div id=\"band-wrapper\">\r\n    <section class=\"band\">\r\n        <article>\r\n            ");
            EndContext();
            BeginContext(156, 1583, false);
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1990a22c8be54828aa3eddedad9699af", async() => {
                BeginContext(241, 163, true);
                WriteLiteral("\r\n                <div class=\"row\">\r\n                    <label for=\"bandName\">Band name:</label>\r\n                    <input type=\"text\" id=\"bandName\" name=\"name\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 404, "\"", 423, 1);
#line 14 "C:\Users\Veso\Desktop\Programs\C#\TechModul4.0\FinalExam4Dec\Skeleton-C#\BandRegister\Views\Band\Edit.cshtml"
WriteAttributeValue("", 412, Model.Name, 412, 11, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(424, 263, true);
                WriteLiteral(@" placeholder=""Name"" required>
                </div>
                <div class=""row"">
                    <label for=""members"">Members:</label>
                    <textarea rows=""5"" id=""members"" name=""Members"" placeholder=""Member 1, Member 2, ..."" required>");
                EndContext();
                BeginContext(688, 13, false);
#line 18 "C:\Users\Veso\Desktop\Programs\C#\TechModul4.0\FinalExam4Dec\Skeleton-C#\BandRegister\Views\Band\Edit.cshtml"
                                                                                                             Write(Model.Members);

#line default
#line hidden
                EndContext();
                BeginContext(701, 209, true);
                WriteLiteral("</textarea>\r\n                </div>\r\n                <div class=\"row\">\r\n                    <label for=\"honorarium\">Honorarium:</label>\r\n                    <input type=\"text\" id=\"honorarium\" name=\"honorarium\"");
                EndContext();
                BeginWriteAttribute("value", " value=\"", 910, "\"", 935, 1);
#line 22 "C:\Users\Veso\Desktop\Programs\C#\TechModul4.0\FinalExam4Dec\Skeleton-C#\BandRegister\Views\Band\Edit.cshtml"
WriteAttributeValue("", 918, Model.Honorarium, 918, 17, false);

#line default
#line hidden
                EndWriteAttribute();
                BeginContext(936, 704, true);
                WriteLiteral(@" placeholder=""price"" required>
                </div>
                <div class=""row"">
                    <label for=""genre"">Genre:</label>
                    <div class=""genre-select"">
                        <input type=""radio"" id=""genre"" name=""genre"" value=""Rock"" checked>Rock
                        <input type=""radio"" id=""genre"" name=""genre"" value=""Metal"">Metal
                        <input type=""radio"" id=""genre"" name=""genre"" value=""Pop"">Pop
                        <input type=""radio"" id=""genre"" name=""genre"" value=""Other"">Other
                    </div>
                </div>
                <div>
                    <button type=""submit"">Edit</button>
                    ");
                EndContext();
                BeginContext(1640, 54, false);
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7ffc9de8ef544a329b21d9fc7e6e4604", async() => {
                    BeginContext(1684, 6, true);
                    WriteLiteral("Cancel");
                    EndContext();
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
                __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                EndContext();
                BeginContext(1694, 38, true);
                WriteLiteral("\r\n                </div>\r\n            ");
                EndContext();
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#line 11 "C:\Users\Veso\Desktop\Programs\C#\TechModul4.0\FinalExam4Dec\Skeleton-C#\BandRegister\Views\Band\Edit.cshtml"
                                                            WriteLiteral(Model.Id);

#line default
#line hidden
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            EndContext();
            BeginContext(1739, 46, true);
            WriteLiteral("\r\n        </article>\r\n    </section>\r\n</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Band> Html { get; private set; }
    }
}
#pragma warning restore 1591
