using Synthesis_assignment.Base_classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Synthesis_assignment.Upload_classes
{
    public interface IUploadSchedule
    {
        void UploadMatchResults(int gameID, int matchId, int player1Points, int player2Points);
        void AddWin(int gameId, string playerEmail);

    }
}
