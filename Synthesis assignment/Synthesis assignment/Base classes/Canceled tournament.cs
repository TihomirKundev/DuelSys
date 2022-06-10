using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SynthesisAssignment.Base_classes
{
    public class Canceled_tournament : Tournament
    {
        private List<People> participants;
        public People[] Participants
        {
            get { return participants.ToArray(); }
        }
        public Canceled_tournament(int id,string sportType, string description, DateTime startDate, DateTime endDate, int minPlayers, int maxPlayers, string location, int numGames, List<People> players) : base(id,sportType, description, startDate, endDate, minPlayers, maxPlayers, location, numGames)
        {
            participants = players;
        }
    }
}
