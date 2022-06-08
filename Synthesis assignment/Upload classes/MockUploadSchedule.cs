using Synthesis_assignment.Base_classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Synthesis_assignment.Upload_classes
{
    public class MockUploadSchedule : IUploadSchedule
    {
        public int gamesWon = 0;
        public void AddWin(int gameId, string playerEmail)
        {
            gamesWon = 1;
        }
        public void UploadMatchResults(int gameID, int matchId, int player1Points, int player2Points)
        {
        }
    }
}
