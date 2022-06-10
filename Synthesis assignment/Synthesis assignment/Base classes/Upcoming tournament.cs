using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SynthesisAssignment.Base_classes
{
    public class Upcoming_tournament : Tournament
    {
        private List<People> participants;
        public People[] Participants
        {
            get { return participants.ToArray(); }
        }
        public Upcoming_tournament()
        {
            participants = new List<People>();
        }
        public Upcoming_tournament(int id, string sportType, string description, DateTime startDate, DateTime endDate, int minPlayers, int maxPlayers, string location, int numGames, List<People> players) : base(id, sportType,description, startDate, endDate, minPlayers, maxPlayers, location, numGames)
        {
            participants = players;
        }
        public string AddParticipant(People player)
        {
            foreach(People p in participants)
            {
                if(p.Email == player.Email)
                {
                    return "You are already registered!";
                }
            }
            participants.Add(player);
            return "Complete";
        }
        public void UpdateDesc(string description)
        {
            base.Description = description;
        }
        public void UpdateStartDate(DateTime startDate)
        {
            base.StartDate = startDate;
        }
        public void UpdateEndDate(DateTime endDate)
        {
            base.EndDate = endDate;
        }
        public void UpdateGames(int games)
        {
            base.NumGames = games;
        }
    }
}
