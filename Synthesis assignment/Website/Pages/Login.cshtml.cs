using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SynthesisAssignment;
using SynthesisAssignment.Base_classes;
using SynthesisAssignment.Upload_classes;
using System;

namespace WAD_Project.Pages
{
    public class LoginModel : PageModel
    {
        public void OnGet()
        {
        }
        public void OnPost()
        {
            People player;
            HttpContext.Session.Remove("login");
            var email = Request.Form["email"];
            var password = Request.Form["password"];
            player = new LoginRegister(new UploadPeople()).Login(email, password, "Player");
            if (player.Email == null)
            {
                HttpContext.Session.SetString("login", "Email or password is wrong");
            }
            else
            {
                HttpContext.Session.SetString("email", player.Email);
                HttpContext.Session.SetString("password", player.Password);
                HttpContext.Session.SetString("fname", player.Fname);
                HttpContext.Session.SetString("lname", player.Lname);
                Response.Redirect("Index");
            }
        }
    }
}
