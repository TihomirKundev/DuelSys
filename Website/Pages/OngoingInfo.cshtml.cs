using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Synthesis_assignment.Base_classes;

namespace Website.Pages
{
    public class OngoingInfoModel : PageModel
    {
        [BindProperty]
        public Ongoing_tournament Tournament { get; set; }
        public int? Id { get; set; }
        public void OnGet()
        {
        }
    }
}
