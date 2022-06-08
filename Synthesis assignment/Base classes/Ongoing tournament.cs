using Synthesis_assignment.Upload_classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Synthesis_assignment.Base_classes
{
    public class Ongoing_tournament : Tournament
    {
        private Dictionary<People, int> leaderboard;
        private List<Game> schedule;
        public People[] Players { get { return leaderboard.Keys.ToArray(); } }
        public Game[] Games { get { return schedule.ToArray(); } }
        public Ongoing_tournament(int id, string description, DateTime startDate, DateTime endDate, int minPlayers, int maxPlayers, string location, int numGames, Dictionary<People, int> leaderboard, List<Game> schedule) : base(id, description, startDate, endDate, minPlayers, maxPlayers, location, numGames)
        {
            this.leaderboard = leaderboard;
            this.schedule = schedule;
        }
        public void UpdateDesc(string description)
        {
            base.Description = description;
        }
        public void UpdateEndDate(DateTime endDate)
        {
            base.EndDate = endDate;
        }
        public Game[] GetUnfinishedGames()
        {
            List<Game> copy = new List<Game>();
            foreach (Game game in this.Games)
            {
                if (!game.IsFinish())
                {
                    copy.Add(game);
                }
            }
            return copy.ToArray();
        }
        public Tuple<List<string>, List<int>> GetLeaderboard()
        {
            Tuple<List<string>, List<int>> tuple = new Tuple<List<string>, List<int>>(new List<string>(), new List<int>());
            foreach(var item in leaderboard.OrderByDescending(i => i.Value))
            {
                string names = item.Key.Fname + " " + item.Key.Lname;
                tuple.Item1.Add(names);
                tuple.Item2.Add(item.Value);
            }
            return tuple;
        }
        public Game GetGame(int id)
        {
            foreach (Game game in this.Games)
            {
                if (game.Id == id)
                {
                    return game;
                }
            }
            return null;
        }
    }
}
