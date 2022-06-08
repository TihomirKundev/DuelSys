using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Synthesis_assignment.Base_classes;

namespace Website.Pages
{
    public class CancelInfoModel : PageModel
    {
        [BindProperty]
        public Canceled_tournament Tournament { get; set; }
        public int? Id { get; set; }
        public void OnGet()
        {
        }
    }
}
