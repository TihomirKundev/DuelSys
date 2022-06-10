using SynthesisAssignment.Base_classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SynthesisAssignment.Upload_classes
{
    public class MockUploadPeople : IUploadPeople
    {
        private List<People> players = new List<People> { new People("Anna","Kadurina","annakadurina@gmail.com","Anna1234"),
                                                          new People("Rosen", "Stanchev","rosenstanchev@gmail.com","Rosen1234")};
        private List<People> staff = new List<People> { new People("Tihomir", "Kandev", "tihomirkandev@gmail.com", "Tihomir1234") };
        public People Login(string email, string password, string type)
        {
            People person = null;
            if (type.Equals("Staff"))
            {
                foreach(People p in staff)
                {
                    if(p.Email == email && p.Password == password)
                    {
                        person = p;
                    }
                }
            }
            else if(type.Equals("Player"))
            {
                foreach(People p in players)
                {
                    if(p.Email == email && p.Password == password)
                    {
                        person = p;
                    }
                }
            }
            return person;
        }

        public People RegisterPlayer(People people)
        {
            int exist = 0;
            foreach(People p in players)
            {
                if(p.Email == people.Email)
                {
                    exist = 1;
                }
            }
            if(exist == 0)
            {
                players.Add(people);
                return people;
            }
            else
            {
                return null;
            }
        }
    }
}
