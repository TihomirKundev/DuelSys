using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Synthesis_assignment.Base_classes;
using Synthesis_assignment.Manager_classes;
using Synthesis_assignment.Upload_classes;

namespace Website.Pages
{
    public class UpcomingInfoModel : PageModel
    {
        [BindProperty]
        public Upcoming_tournament Tournament { get; set; }
        public int? Id { get; set; }
        public void OnGet()
        {
        }
        public void OnPostRegister(int id)
        {
            TournamentManager manager = new TournamentManager(new UploadTournament());
            People player = new People(HttpContext.Session.GetString("fname"), HttpContext.Session.GetString("lname"), HttpContext.Session.GetString("email"), HttpContext.Session.GetString("password"));
            manager.AddPlayer(id, player);
            Response.Redirect("Index");
        }
    }
}
