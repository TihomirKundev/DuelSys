#pragma checksum "C:\Users\tihom\OneDrive - FHICT\Desktop\Synthesis assignment\Website\Pages\OngoingInfo.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ffdd55cdb2a1287f32b0a973ebd4f895c24d952f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(Website.Pages.Pages_OngoingInfo), @"mvc.1.0.razor-page", @"/Pages/OngoingInfo.cshtml")]
namespace Website.Pages
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
#line 1 "C:\Users\tihom\OneDrive - FHICT\Desktop\Synthesis assignment\Website\Pages\_ViewImports.cshtml"
using Website;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\tihom\OneDrive - FHICT\Desktop\Synthesis assignment\Website\Pages\OngoingInfo.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\tihom\OneDrive - FHICT\Desktop\Synthesis assignment\Website\Pages\OngoingInfo.cshtml"
using Synthesis_assignment.Base_classes;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\tihom\OneDrive - FHICT\Desktop\Synthesis assignment\Website\Pages\OngoingInfo.cshtml"
using Synthesis_assignment.Manager_classes;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\tihom\OneDrive - FHICT\Desktop\Synthesis assignment\Website\Pages\OngoingInfo.cshtml"
using Synthesis_assignment.Upload_classes;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\tihom\OneDrive - FHICT\Desktop\Synthesis assignment\Website\Pages\OngoingInfo.cshtml"
using System.Text;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ffdd55cdb2a1287f32b0a973ebd4f895c24d952f", @"/Pages/OngoingInfo.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"459ff182d5c873ea1cf5eb7fbdf003d162ca66d3", @"/Pages/_ViewImports.cshtml")]
    #nullable restore
    public class Pages_OngoingInfo : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/OngoingPastInfo.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 8 "C:\Users\tihom\OneDrive - FHICT\Desktop\Synthesis assignment\Website\Pages\OngoingInfo.cshtml"
  
    Model.Id = HttpContext.Session.GetInt32("id");
    TournamentManager manager = new TournamentManager(new UploadTournament());
    Model.Tournament = (Ongoing_tournament)manager.GetTournament(Model.Id);

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "ffdd55cdb2a1287f32b0a973ebd4f895c24d952f5241", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "ffdd55cdb2a1287f32b0a973ebd4f895c24d952f6359", async() => {
                WriteLiteral("\r\n    <div id=\"sections\">\r\n    <section class=\"flex-item\">\r\n    <h2>ID: ");
#nullable restore
#line 18 "C:\Users\tihom\OneDrive - FHICT\Desktop\Synthesis assignment\Website\Pages\OngoingInfo.cshtml"
       Write(Model.Tournament.Id);

#line default
#line hidden
#nullable disable
                WriteLiteral("</h2>\r\n    <h2>Sport: ");
#nullable restore
#line 19 "C:\Users\tihom\OneDrive - FHICT\Desktop\Synthesis assignment\Website\Pages\OngoingInfo.cshtml"
          Write(Model.Tournament.SportType);

#line default
#line hidden
#nullable disable
                WriteLiteral("</h2>\r\n    <h2>Description: ");
#nullable restore
#line 20 "C:\Users\tihom\OneDrive - FHICT\Desktop\Synthesis assignment\Website\Pages\OngoingInfo.cshtml"
                Write(Model.Tournament.Description);

#line default
#line hidden
#nullable disable
                WriteLiteral("</h2>\r\n    <h2 id=\"startDate\">Start date: ");
#nullable restore
#line 21 "C:\Users\tihom\OneDrive - FHICT\Desktop\Synthesis assignment\Website\Pages\OngoingInfo.cshtml"
                              Write(Model.Tournament.StartDate.ToString("dd/MM/yyyy"));

#line default
#line hidden
#nullable disable
                WriteLiteral("</h2>\r\n    <h2 id=\"endDate\">End date: ");
#nullable restore
#line 22 "C:\Users\tihom\OneDrive - FHICT\Desktop\Synthesis assignment\Website\Pages\OngoingInfo.cshtml"
                          Write(Model.Tournament.EndDate.ToString("dd/MM/yyyy"));

#line default
#line hidden
#nullable disable
                WriteLiteral("</h2>\r\n    <h2 id=\"minPlayers\">Minimum players: ");
#nullable restore
#line 23 "C:\Users\tihom\OneDrive - FHICT\Desktop\Synthesis assignment\Website\Pages\OngoingInfo.cshtml"
                                    Write(Model.Tournament.MinPlayers);

#line default
#line hidden
#nullable disable
                WriteLiteral("</h2>\r\n    <h2 id=\"maxPlayers\">Maximum players: ");
#nullable restore
#line 24 "C:\Users\tihom\OneDrive - FHICT\Desktop\Synthesis assignment\Website\Pages\OngoingInfo.cshtml"
                                    Write(Model.Tournament.MaxPlayers);

#line default
#line hidden
#nullable disable
                WriteLiteral("</h2>\r\n    <h2>Address: ");
#nullable restore
#line 25 "C:\Users\tihom\OneDrive - FHICT\Desktop\Synthesis assignment\Website\Pages\OngoingInfo.cshtml"
            Write(Model.Tournament.Location);

#line default
#line hidden
#nullable disable
                WriteLiteral("</h2>\r\n    <h2>Tournament system: ");
#nullable restore
#line 26 "C:\Users\tihom\OneDrive - FHICT\Desktop\Synthesis assignment\Website\Pages\OngoingInfo.cshtml"
                      Write(Model.Tournament.System);

#line default
#line hidden
#nullable disable
                WriteLiteral("</h2>\r\n    <h2>Number of games: ");
#nullable restore
#line 27 "C:\Users\tihom\OneDrive - FHICT\Desktop\Synthesis assignment\Website\Pages\OngoingInfo.cshtml"
                    Write(Model.Tournament.NumGames);

#line default
#line hidden
#nullable disable
                WriteLiteral("</h2>\r\n    </section>\r\n    <section id=\"leaderboard\">\r\n        <h3 style=\"background-color: darkslategray\">Name</h3>\r\n        <h3 style=\"background-color: darkslategray\">Wins</h3>\r\n");
#nullable restore
#line 32 "C:\Users\tihom\OneDrive - FHICT\Desktop\Synthesis assignment\Website\Pages\OngoingInfo.cshtml"
         for(int i = 0; i < Model.Tournament.GetLeaderboard().Item1.Count; i++)
        {

#line default
#line hidden
#nullable disable
                WriteLiteral("            <h3>");
#nullable restore
#line 34 "C:\Users\tihom\OneDrive - FHICT\Desktop\Synthesis assignment\Website\Pages\OngoingInfo.cshtml"
           Write(Model.Tournament.GetLeaderboard().Item1[i]);

#line default
#line hidden
#nullable disable
                WriteLiteral("</h3>\r\n            <h3>");
#nullable restore
#line 35 "C:\Users\tihom\OneDrive - FHICT\Desktop\Synthesis assignment\Website\Pages\OngoingInfo.cshtml"
           Write(Model.Tournament.GetLeaderboard().Item2[i]);

#line default
#line hidden
#nullable disable
                WriteLiteral("</h3>\r\n");
#nullable restore
#line 36 "C:\Users\tihom\OneDrive - FHICT\Desktop\Synthesis assignment\Website\Pages\OngoingInfo.cshtml"
        }

#line default
#line hidden
#nullable disable
                WriteLiteral("    </section>\r\n    <section id=\"rightPart\">\r\n        <h3 style=\"background-color: darkslategray\">Names</h3>\r\n        <h3 style=\"background-color: darkslategray\">Results</h3>\r\n");
#nullable restore
#line 41 "C:\Users\tihom\OneDrive - FHICT\Desktop\Synthesis assignment\Website\Pages\OngoingInfo.cshtml"
         foreach(Game game in Model.Tournament.Games)
        {
            string player1Name = "";
            string player2Name = "";
            

#line default
#line hidden
#nullable disable
#nullable restore
#line 45 "C:\Users\tihom\OneDrive - FHICT\Desktop\Synthesis assignment\Website\Pages\OngoingInfo.cshtml"
             foreach(People people in Model.Tournament.Players)
            {
                if(people.Email == game.player1Email)
                {
                    player1Name = people.Fname + " " + people.Lname;
                }
                if(people.Email == game.player2Email)
                {
                    player2Name = people.Fname + " " + people.Lname;
                }
            }

#line default
#line hidden
#nullable disable
                WriteLiteral("            <h3 id=\"matches\">");
#nullable restore
#line 56 "C:\Users\tihom\OneDrive - FHICT\Desktop\Synthesis assignment\Website\Pages\OngoingInfo.cshtml"
                        Write(player1Name);

#line default
#line hidden
#nullable disable
                WriteLiteral(" - ");
#nullable restore
#line 56 "C:\Users\tihom\OneDrive - FHICT\Desktop\Synthesis assignment\Website\Pages\OngoingInfo.cshtml"
                                       Write(player2Name);

#line default
#line hidden
#nullable disable
                WriteLiteral("</h3>\r\n");
#nullable restore
#line 57 "C:\Users\tihom\OneDrive - FHICT\Desktop\Synthesis assignment\Website\Pages\OngoingInfo.cshtml"
            StringBuilder res = new StringBuilder();
            for(int i = 0; i < game.Result().Item1.Length; i++)
            {
                res.Append(game.Result().Item1[i] + "-" + game.Result().Item2[i] + " ");
                
            }

#line default
#line hidden
#nullable disable
                WriteLiteral("            <h3 id=\"results\">");
#nullable restore
#line 63 "C:\Users\tihom\OneDrive - FHICT\Desktop\Synthesis assignment\Website\Pages\OngoingInfo.cshtml"
                        Write(res);

#line default
#line hidden
#nullable disable
                WriteLiteral("</h3>\r\n");
#nullable restore
#line 64 "C:\Users\tihom\OneDrive - FHICT\Desktop\Synthesis assignment\Website\Pages\OngoingInfo.cshtml"
        }

#line default
#line hidden
#nullable disable
                WriteLiteral("    </section>\r\n    </div>\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Website.Pages.OngoingInfoModel> Html { get; private set; } = default!;
        #nullable disable
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<Website.Pages.OngoingInfoModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<Website.Pages.OngoingInfoModel>)PageContext?.ViewData;
        public Website.Pages.OngoingInfoModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
