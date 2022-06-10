using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SynthesisAssignment;
using SynthesisAssignment.Base_classes;
using SynthesisAssignment.Upload_classes;
using System;

namespace WAD_Project.Pages
{
    public class RegisterModel : PageModel
    {
        public void OnGet()
        {
        }
        public void OnPost()
        {
            HttpContext.Session.Clear();
            People player;
            LoginRegister loginRegister = new LoginRegister(new UploadPeople());
            HttpContext.Session.Remove("register");
            var firstName = Request.Form["fname"];
            var lastName = Request.Form["lname"];
            var email = Request.Form["email"];
            var password = Request.Form["password"];
            string checkPass = loginRegister.CheckPass(password);
            if(checkPass == "Complete")
            {
                player = loginRegister.RegisterPlayer(new People(firstName, lastName ,email, password));
                if (player == null)
                {
                    HttpContext.Session.SetString("register", "This email already exists!");
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
            else
            {
                HttpContext.Session.SetString("register", checkPass);
            }
            
        }
    }
}
