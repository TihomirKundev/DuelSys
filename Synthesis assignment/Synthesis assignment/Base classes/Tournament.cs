using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SynthesisAssignment.Base_classes
{
    public abstract class Tournament
    {
        private int id;
        private string sportType;
        private string description;
        private DateTime startDate;
        private DateTime endDate;
        private int minPlayers;
        private int maxPlayers;
        private string location;
        private string system = "Round-robin";
        private int numGames;
        public int Id { get { return id; } }
        public string SportType { get; protected set; }
        public string Description { get; protected set; }
        public DateTime StartDate { get; protected set; }
        public DateTime EndDate { get; protected set; }
        public int MinPlayers { get; protected set; }
        public int MaxPlayers { get; protected set; }
        public string Location { get; private set; }
        public string System { get { return system; } }
        public int NumGames { get; protected set; }
        protected Tournament()
        {

        }
        protected Tournament(int id,string sportType, string description, DateTime startDate, DateTime endDate, int minPlayers, int maxPlayers, string location, int numGames)
        {
            this.id = id;
            SportType = sportType;
            Description = description;
            StartDate = startDate;
            EndDate = endDate;
            MinPlayers = minPlayers;
            MaxPlayers = maxPlayers;
            Location = location;
            NumGames = numGames;
        }
    }
}
