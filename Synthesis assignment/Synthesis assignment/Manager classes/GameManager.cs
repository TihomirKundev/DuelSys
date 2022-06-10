using SynthesisAssignment.Base_classes;
using SynthesisAssignment.Upload_classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SynthesisAssignment.Manager_classes
{
    public class GameManager
    {
        private IUploadGame upload;
        public Game Game { get; private set; }
        public GameManager(Game game1, IUploadGame upload)
        {
            Game = game1;
            this.upload = upload;
        }
        public void RegisterResults(int matchID, int player1Points, int player2Points)
        {
            if(matchID > 0 && matchID <= Game.Result().Item1.Length)
            {
                string res = Game.RegisterResults(matchID, player1Points, player2Points);
                upload.UploadMatchResults(Game.Id, matchID, player1Points, player2Points);
                if (res != "None")
                {
                    upload.AddWin(Game.Id, res);
                }
            }
        }
        public bool PointsCheck(int a, int b)
        {
            if(Game.Type == "Badminton")
            {
                return BadmintonPointsCheck(a, b);
            }else if(Game.Type == "Football")
            {
                return FootballPointsCheck(a, b);
            }
            return false;
        }
        private bool BadmintonPointsCheck(int a, int b)
        {
            if (a == 21 && b < 20 && b >= 0)
            {
                return true;
            }
            else if (b == 21 && a < 20 && a >= 0)
            {
                return true;
            }
            else if (a > 21 && a <= 29 && a - 2 == b)
            {
                return true;
            }
            else if (b > 21 && b <= 29 && b - 2 == a)
            {
                return true;
            }
            else if ((a == 30 && b == 29) || (a == 29 && b == 30))
            {
                return true;
            }
            else if (a == b && a == 0)
            {
                return true;
            }
            return false;
        }
        private bool FootballPointsCheck(int a, int b)
        {
            if(a < 0 || b < 0 || a >= 10 || b >= 10)
            {
                return false;
            }else if(a == b)
            {
                return false;
            }
            return true;
        }
    }
}
