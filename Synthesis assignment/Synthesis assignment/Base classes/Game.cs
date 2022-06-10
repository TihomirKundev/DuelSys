using SynthesisAssignment.Upload_classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SynthesisAssignment.Base_classes
{
    public class Game
    {
        private int id;
        private string type;
        private Dictionary<string, int[]> playersPoints;
        public int Id { get; private set; }
        public string Type { get; private set; }
        public string player1Email { get { return playersPoints.Keys.First(); } }
        public string player2Email { get { return playersPoints.Keys.Last(); } }
        public Tuple<int[], int[]> Result()
        {
            return Tuple.Create(playersPoints[player1Email], playersPoints[player2Email]);
        }
        public Game(int id,string type, string player1Email, string player2Email, int[] player1Points, int[] player2Points)
        {
            Id = id;
            Type = type;
            playersPoints = new Dictionary<string, int[]>();
            playersPoints.Add(player1Email, player1Points);
            playersPoints.Add(player2Email, player2Points);
        }

        public string RegisterResults(int matchID, int player1Points, int player2Points)
        {
            if(playersPoints[player1Email][matchID-1] != 0)
            {
                return "None";
            }
            playersPoints[player1Email][matchID-1] = player1Points;
            playersPoints[player2Email][matchID-1] = player2Points;
            if(matchID == playersPoints[player1Email].Length)
            {
                int winsForPlayer1 = 0;
                for(int i = 0; i < playersPoints[player1Email].Length; i++)
                {
                    if(playersPoints[player1Email][i] > playersPoints[player2Email][i])
                    {
                        winsForPlayer1++;
                    }
                }
                if(winsForPlayer1 > matchID / 2)
                {
                    return player1Email;
                }
                else
                {
                    return player2Email;
                }
            }
            return "None";
        }
        public bool IsFinish()
        {
            int pos = Array.IndexOf(this.Result().Item1, 0);
            if(pos == -1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
