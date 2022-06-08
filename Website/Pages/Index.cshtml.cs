using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Synthesis_assignment.Base_classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Website.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }
        public void OnPostLogOut()
        {
            HttpContext.Session.Remove("fname");
            HttpContext.Session.Remove("lname");
            HttpContext.Session.Remove("email");
            HttpContext.Session.Remove("password");
            Response.Redirect("Index");
        }
        public void OnPostLogIn()
        {
            Response.Redirect("Login");
        }
        public void OnPostInfoUpcoming(int id)
        {
            HttpContext.Session.SetInt32("id", id);
            Response.Redirect("UpcomingInfo");
        }
        public void OnPostInfoOngoing(int id)
        {
            HttpContext.Session.SetInt32("id", id);
            Response.Redirect("OngoingInfo");
        }
        public void OnPostInfoPast(int id)
        {
            HttpContext.Session.SetInt32("id", id);
            Response.Redirect("PastInfo");
        }
        public void OnPostInfoCancel(int id)
        {
            HttpContext.Session.SetInt32("id", id);
            Response.Redirect("CancelInfo");
        }
    }
}
