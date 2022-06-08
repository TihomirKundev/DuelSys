using Synthesis_assignment.Base_classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Synthesis_assignment.Upload_classes
{
    public class MockUploadTournament : IUploadTournament
    {
        private List<Tournament> tournaments = new List<Tournament>()
        {
            new Upcoming_tournament(1,"Test1", new DateTime(2022, 06, 25), new DateTime(2022, 07, 10),4,8,"Eindhoven",1,new List<People>()),
            new Ongoing_tournament(2, "Test2", new DateTime(2022,06,06), new DateTime(2022,07,01),3,7,"Amsterdam",3,new Dictionary<People, int>(),new List<Game>()),
            new Past_tournament(3, "Test3", new DateTime(2022,05,20), new DateTime(2022,06,05),5,15,"Best",5,new Dictionary<People, int>()),
            new Canceled_tournament(4, "Test4", new DateTime(2022,05,22), new DateTime(2022,06,02),5,15,"Best",5,new List<People>())
        };
        public void AddPlayer(int tournamentID, People player)
        {
        }

        public void Create(Upcoming_tournament tournament)
        {
        }

        public void DeleteTournament(Tournament tournament)
        {
        }

        public List<Tournament> GetTournaments()
        {
            return tournaments;
        }

        public void Update(Tournament tournament)
        {
        }
    }
}
