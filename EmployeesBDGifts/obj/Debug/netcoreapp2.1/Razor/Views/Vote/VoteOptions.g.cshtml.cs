#pragma checksum "C:\Users\Alex\source\repos\EmployeesBDGifts\EmployeesBDGifts\Views\Vote\VoteOptions.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "71fe28b203b84ea68c439eca06aed8080ded8591"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Vote_VoteOptions), @"mvc.1.0.view", @"/Views/Vote/VoteOptions.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Vote/VoteOptions.cshtml", typeof(AspNetCore.Views_Vote_VoteOptions))]
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
#line 1 "C:\Users\Alex\source\repos\EmployeesBDGifts\EmployeesBDGifts\Views\_ViewImports.cshtml"
using EmployeesBDGifts;

#line default
#line hidden
#line 2 "C:\Users\Alex\source\repos\EmployeesBDGifts\EmployeesBDGifts\Views\_ViewImports.cshtml"
using EmployeesBDGifts.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"71fe28b203b84ea68c439eca06aed8080ded8591", @"/Views/Vote/VoteOptions.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"10e6764d46cb88ba54026c35e50974ef7bd63c37", @"/Views/_ViewImports.cshtml")]
    public class Views_Vote_VoteOptions : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<EmployeesBDGifts.ViewModels.VoteOptionsViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "C:\Users\Alex\source\repos\EmployeesBDGifts\EmployeesBDGifts\Views\Vote\VoteOptions.cshtml"
  
    ViewData["Title"] = "VoteOptions";

#line default
#line hidden
            BeginContext(104, 79, true);
            WriteLiteral("\r\n<style>\r\n    table tr th, td {\r\n        padding:5px;\r\n    }\r\n</style>\r\n\r\n<h2>");
            EndContext();
            BeginContext(184, 17, false);
#line 12 "C:\Users\Alex\source\repos\EmployeesBDGifts\EmployeesBDGifts\Views\Vote\VoteOptions.cshtml"
Write(Model.BDUser.Name);

#line default
#line hidden
            EndContext();
            BeginContext(201, 2, true);
            WriteLiteral(" (");
            EndContext();
            BeginContext(204, 37, false);
#line 12 "C:\Users\Alex\source\repos\EmployeesBDGifts\EmployeesBDGifts\Views\Vote\VoteOptions.cshtml"
                   Write(Model.BDUser.Bday.ToShortDateString());

#line default
#line hidden
            EndContext();
            BeginContext(241, 56, true);
            WriteLiteral(")</h2>\r\n<hr />\r\n\r\n<h3>Select the best gift for the year ");
            EndContext();
            BeginContext(298, 10, false);
#line 15 "C:\Users\Alex\source\repos\EmployeesBDGifts\EmployeesBDGifts\Views\Vote\VoteOptions.cshtml"
                                 Write(Model.Year);

#line default
#line hidden
            EndContext();
            BeginContext(308, 7, true);
            WriteLiteral("</h3>\r\n");
            EndContext();
#line 16 "C:\Users\Alex\source\repos\EmployeesBDGifts\EmployeesBDGifts\Views\Vote\VoteOptions.cshtml"
 if (Model.userIsOwner)
{

#line default
#line hidden
            BeginContext(343, 86, true);
            WriteLiteral("    <div>\r\n        You Started this vote you can end it whenever you want.\r\n        <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 429, "\"", 482, 2);
            WriteAttributeValue("", 436, "/vote/endVote?voteId=", 436, 21, true);
#line 20 "C:\Users\Alex\source\repos\EmployeesBDGifts\EmployeesBDGifts\Views\Vote\VoteOptions.cshtml"
WriteAttributeValue("", 457, Model.VoteInfoList[0].Id, 457, 25, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(483, 52, true);
            WriteLiteral("  class=\"btn btn-primary\">End vote</a>\r\n    </div>\r\n");
            EndContext();
#line 22 "C:\Users\Alex\source\repos\EmployeesBDGifts\EmployeesBDGifts\Views\Vote\VoteOptions.cshtml"
}

#line default
#line hidden
            BeginContext(538, 181, true);
            WriteLiteral("<br />\r\n    Change year\r\n    <input id=\"yearChange\" type=\"number\" />\r\n    <input onclick=\"ChangeYear()\" value=\"Change Year\" class=\"btn btn-primary\"/>\r\n    <hr />\r\nShow Vote Info\r\n<a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 719, "\"", 785, 4);
            WriteAttributeValue("", 726, "/vote/ShowVoteInfo?userId=", 726, 26, true);
#line 29 "C:\Users\Alex\source\repos\EmployeesBDGifts\EmployeesBDGifts\Views\Vote\VoteOptions.cshtml"
WriteAttributeValue("", 752, Model.BDUser.Id, 752, 16, false);

#line default
#line hidden
            WriteAttributeValue("", 768, "&year=", 768, 6, true);
#line 29 "C:\Users\Alex\source\repos\EmployeesBDGifts\EmployeesBDGifts\Views\Vote\VoteOptions.cshtml"
WriteAttributeValue("", 774, Model.Year, 774, 11, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(786, 152, true);
            WriteLiteral(" class=\"btn btn-primary\">Show</a>\r\n<table>\r\n    <tr>\r\n        <th>Name</th>\r\n        <th>Number of Votes</th>\r\n        <th>Cast a vote</th>\r\n    </tr>\r\n");
            EndContext();
#line 36 "C:\Users\Alex\source\repos\EmployeesBDGifts\EmployeesBDGifts\Views\Vote\VoteOptions.cshtml"
     foreach (var gift in Model.Gifts)
    {
        int voteInfoId = 0;
        var voteInfo = Model.VoteInfoList.SingleOrDefault(x => x.GiftId == gift.Id);
        if (voteInfo != null)
        {
            voteInfoId = voteInfo.Id;
        }

#line default
#line hidden
            BeginContext(1192, 48, true);
            WriteLiteral("        <tr>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(1241, 9, false);
#line 46 "C:\Users\Alex\source\repos\EmployeesBDGifts\EmployeesBDGifts\Views\Vote\VoteOptions.cshtml"
           Write(gift.Name);

#line default
#line hidden
            EndContext();
            BeginContext(1250, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(1306, 69, false);
#line 49 "C:\Users\Alex\source\repos\EmployeesBDGifts\EmployeesBDGifts\Views\Vote\VoteOptions.cshtml"
           Write(Model.VoteInfoList.SingleOrDefault(x=> x.GiftId == gift.Id)?.Quantity);

#line default
#line hidden
            EndContext();
            BeginContext(1375, 57, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                <a");
            EndContext();
            BeginWriteAttribute("href", " href=\"", 1432, "\"", 1510, 6);
            WriteAttributeValue("", 1439, "/vote/castvote?userId=", 1439, 22, true);
#line 52 "C:\Users\Alex\source\repos\EmployeesBDGifts\EmployeesBDGifts\Views\Vote\VoteOptions.cshtml"
WriteAttributeValue("", 1461, Model.BDUser.Id, 1461, 16, false);

#line default
#line hidden
            WriteAttributeValue("", 1477, "&giftId=", 1477, 8, true);
#line 52 "C:\Users\Alex\source\repos\EmployeesBDGifts\EmployeesBDGifts\Views\Vote\VoteOptions.cshtml"
WriteAttributeValue("", 1485, gift.Id, 1485, 8, false);

#line default
#line hidden
            WriteAttributeValue("", 1493, "&year=", 1493, 6, true);
#line 52 "C:\Users\Alex\source\repos\EmployeesBDGifts\EmployeesBDGifts\Views\Vote\VoteOptions.cshtml"
WriteAttributeValue("", 1499, Model.Year, 1499, 11, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(1511, 69, true);
            WriteLiteral(" class=\"btn-primary btn\">Vote</a>\r\n            </td>\r\n        </tr>\r\n");
            EndContext();
#line 55 "C:\Users\Alex\source\repos\EmployeesBDGifts\EmployeesBDGifts\Views\Vote\VoteOptions.cshtml"
    }

#line default
#line hidden
            BeginContext(1587, 324, true);
            WriteLiteral(@"</table>




<script type=""text/javascript"">
    function ChangeYear() {
        var year = $(""#yearChange"").val();
        if (year == """" || year <2020 || year >2030) {
            alert(""Please type in a year from 2020 to 2030."")
        }
        window.location.href = RootUrl + ""/Vote/VoteOptions?userId="" + ");
            EndContext();
            BeginContext(1912, 15, false);
#line 67 "C:\Users\Alex\source\repos\EmployeesBDGifts\EmployeesBDGifts\Views\Vote\VoteOptions.cshtml"
                                                                  Write(Model.BDUser.Id);

#line default
#line hidden
            EndContext();
            BeginContext(1927, 37, true);
            WriteLiteral("+ \"&year=\" + year\r\n    }\r\n\r\n</script>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<EmployeesBDGifts.ViewModels.VoteOptionsViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591