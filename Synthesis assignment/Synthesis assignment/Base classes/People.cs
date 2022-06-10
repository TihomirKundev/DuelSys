using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SynthesisAssignment.Base_classes
{
    public class People
    {
        public string Fname { get; private set; }
        public string Lname { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }

        public People(string fname, string lname, string email, string password)
        {
            Fname = fname;
            Lname = lname;
            Email = email;
            Password = password;
        }
    }
}
