#pragma checksum "/home/will/RiderProjects/WebApplication/WebApplication/Views/Shared/Error.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1082274aa0b3581fda169c736da45e4887d6e5d5"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Error), @"mvc.1.0.view", @"/Views/Shared/Error.cshtml")]
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
#line 1 "/home/will/RiderProjects/WebApplication/WebApplication/Views/_ViewImports.cshtml"
using WebApplication.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "/home/will/RiderProjects/WebApplication/WebApplication/Views/_ViewImports.cshtml"
using WebApplication.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1082274aa0b3581fda169c736da45e4887d6e5d5", @"/Views/Shared/Error.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cc5183831393a2c737b660827ae95016be589e8d", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Error : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "/home/will/RiderProjects/WebApplication/WebApplication/Views/Shared/Error.cshtml"
  
    ViewBag.Title = "title";

#line default
#line hidden
#nullable disable
            WriteLiteral("\n<h3>An error occured while processing you request.</h3>\n<hr/>\n\n<div class=\"alert alert-danger\">\n    <h5>Exception Path</h5>\n    <hr/>\n    <p>");
#nullable restore
#line 11 "/home/will/RiderProjects/WebApplication/WebApplication/Views/Shared/Error.cshtml"
  Write(ViewBag.ExceptionPath);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\n</div>\n<div class=\"alert alert-danger\">\n    <h5>Exception Message</h5>\n    <hr/>\n    <p>");
#nullable restore
#line 16 "/home/will/RiderProjects/WebApplication/WebApplication/Views/Shared/Error.cshtml"
  Write(ViewBag.ExceptionMessage);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\n</div>\n<div class=\"alert alert-danger\">\n    <h5>Exception Stack Trace</h5>\n    <hr/>\n    <p>");
#nullable restore
#line 21 "/home/will/RiderProjects/WebApplication/WebApplication/Views/Shared/Error.cshtml"
  Write(ViewBag.StackTrace);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
