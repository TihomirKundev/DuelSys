using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Synthesis_assignment.Base_classes
{
    public class Past_tournament : Tournament
    {
        Dictionary<People, int> leaderboard;
        public People[] Players { get { return leaderboard.Keys.ToArray(); } }
        public Past_tournament(int id, string description, DateTime startDate, DateTime endDate, int minPlayers, int maxPlayers, string location, int numGames, Dictionary<People, int> leaderboard) : base(id, description, startDate, endDate, minPlayers, maxPlayers, location, numGames)
        {
            this.leaderboard = leaderboard;
        }
        public Tuple<List<string>, List<int>> GetLeaderboard()
        {
            Tuple<List<string>, List<int>> tuple = new Tuple<List<string>, List<int>>(new List<string>(), new List<int>());
            foreach (var item in leaderboard.OrderByDescending(i => i.Value))
            {
                string names = item.Key.Fname + " " + item.Key.Lname;
                tuple.Item1.Add(names);
                tuple.Item2.Add(item.Value);
            }
            return tuple;
        }
    }
}
