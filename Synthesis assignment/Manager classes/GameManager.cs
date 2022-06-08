using Synthesis_assignment.Base_classes;
using Synthesis_assignment.Upload_classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Synthesis_assignment.Manager_classes
{
    public class GameManager
    {
        private IUploadSchedule uploadSchedule;
        public Game Game { get; private set; }
        public GameManager(Game game1, IUploadSchedule upload)
        {
            Game = game1;
            uploadSchedule = upload;
        }
        public void RegisterResults(int matchID, int player1Points, int player2Points)
        {
            if(matchID > 0 && matchID <= Game.Result().Item1.Length)
            {
                string res = Game.RegisterResults(matchID, player1Points, player2Points);
                uploadSchedule.UploadMatchResults(Game.Id, matchID, player1Points, player2Points);
                if (res != "None")
                {
                    uploadSchedule.AddWin(Game.Id, res);
                }
            }
        }
        public bool PointsCheck(int a, int b)
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

    }
}
