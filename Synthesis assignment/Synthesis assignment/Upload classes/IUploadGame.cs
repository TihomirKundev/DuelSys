using SynthesisAssignment.Base_classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SynthesisAssignment.Upload_classes
{
    public interface IUploadGame
    {
        void UploadMatchResults(int gameID, int matchId, int player1Points, int player2Points);
        void AddWin(int gameId, string playerEmail);

    }
}
