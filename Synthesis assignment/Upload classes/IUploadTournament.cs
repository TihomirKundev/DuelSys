using Synthesis_assignment.Base_classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Synthesis_assignment.Upload_classes
{
    public interface IUploadTournament
    {
        List<Tournament> GetTournaments();
        void Create(Upcoming_tournament tournament);
        void Update(Tournament tournament);
        void DeleteTournament(Tournament tournament);
        void AddPlayer(int tournamentID, People player);
    }
}
