#pragma checksum "C:\Users\Veso\Desktop\Programs\C#\TechModul4.0\WebProject\SoftUniTwitter\SoftUniTwitter\Views\Tweets\ByHashtag.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "da51179cda5230ba07784a51449717e576347320"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Tweets_ByHashtag), @"mvc.1.0.view", @"/Views/Tweets/ByHashtag.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Tweets/ByHashtag.cshtml", typeof(AspNetCore.Views_Tweets_ByHashtag))]
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
#line 1 "C:\Users\Veso\Desktop\Programs\C#\TechModul4.0\WebProject\SoftUniTwitter\SoftUniTwitter\Views\_ViewImports.cshtml"
using SoftUniTwitter;

#line default
#line hidden
#line 2 "C:\Users\Veso\Desktop\Programs\C#\TechModul4.0\WebProject\SoftUniTwitter\SoftUniTwitter\Views\_ViewImports.cshtml"
using SoftUniTwitter.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"da51179cda5230ba07784a51449717e576347320", @"/Views/Tweets/ByHashtag.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7984b14e62482b9774ef75af50fabea80e5fc2f4", @"/Views/_ViewImports.cshtml")]
    public class Views_Tweets_ByHashtag : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<TweetViewModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "C:\Users\Veso\Desktop\Programs\C#\TechModul4.0\WebProject\SoftUniTwitter\SoftUniTwitter\Views\Tweets\ByHashtag.cshtml"
  
    ViewData["Title"] = "ByHashtag";

#line default
#line hidden
            BeginContext(74, 24, true);
            WriteLiteral("\r\n<h1>ByHashtag</h1>\r\n\r\n");
            EndContext();
#line 8 "C:\Users\Veso\Desktop\Programs\C#\TechModul4.0\WebProject\SoftUniTwitter\SoftUniTwitter\Views\Tweets\ByHashtag.cshtml"
 foreach(var tweet in Model)
{

#line default
#line hidden
            BeginContext(131, 24, true);
            WriteLiteral("    <div>\r\n\t    <strong>");
            EndContext();
            BeginContext(156, 14, false);
#line 11 "C:\Users\Veso\Desktop\Programs\C#\TechModul4.0\WebProject\SoftUniTwitter\SoftUniTwitter\Views\Tweets\ByHashtag.cshtml"
           Write(tweet.Username);

#line default
#line hidden
            EndContext();
            BeginContext(170, 14, true);
            WriteLiteral(":</strong>\r\n\t\t");
            EndContext();
            BeginContext(185, 10, false);
#line 12 "C:\Users\Veso\Desktop\Programs\C#\TechModul4.0\WebProject\SoftUniTwitter\SoftUniTwitter\Views\Tweets\ByHashtag.cshtml"
   Write(tweet.Text);

#line default
#line hidden
            EndContext();
            BeginContext(195, 9, true);
            WriteLiteral("\r\n\t\t<em>(");
            EndContext();
            BeginContext(205, 15, false);
#line 13 "C:\Users\Veso\Desktop\Programs\C#\TechModul4.0\WebProject\SoftUniTwitter\SoftUniTwitter\Views\Tweets\ByHashtag.cshtml"
        Write(tweet.CreatedOn);

#line default
#line hidden
            EndContext();
            BeginContext(220, 17, true);
            WriteLiteral(")</em>\r\n\t</div>\r\n");
            EndContext();
#line 15 "C:\Users\Veso\Desktop\Programs\C#\TechModul4.0\WebProject\SoftUniTwitter\SoftUniTwitter\Views\Tweets\ByHashtag.cshtml"
}

#line default
#line hidden
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<TweetViewModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
