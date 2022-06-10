using SynthesisAssignment.Base_classes;
using SynthesisAssignment.Upload_classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SynthesisAssignment
{
    public class LoginRegister
    {
        IUploadPeople upload;
        public LoginRegister(IUploadPeople uploadPeople)
        {
            if(uploadPeople.GetType() == typeof(UploadPeople))
            {
                upload = new UploadPeople();
            }
            else if(uploadPeople.GetType() == typeof(MockUploadPeople))
            {
                upload = new MockUploadPeople();
            }
        }
        public People Login(string email, string password, string type)
        {
            return upload.Login(email, password, type); ;
        }
        public People RegisterPlayer(People people)
        {
            return upload.RegisterPlayer(people);
        }
        public string CheckPass(string pass)
        {
            Regex upperCase = new Regex("[A-Z]");
            Regex lowerCase = new Regex("[a-z]");
            Regex number = new Regex("[0-9]");
            if (!upperCase.IsMatch(pass))
            {
                return "Your password should have at least one upper case!";
            }
            else if (!lowerCase.IsMatch(pass))
            {
                return "Your password should have at least one lower case!";
            }
            else if (!number.IsMatch(pass))
            {
                return "Your password should have at least one number!";
            }
            else if (pass.Length < 6)
            {
                return "Your password should be at least 6 symbols in it!";
            }
            return "Complete";
        }
    }
}
