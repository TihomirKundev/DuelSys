using SynthesisAssignment.Base_classes;
using SynthesisAssignment.Upload_classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SynthesisAssignment.Manager_classes
{
    public class TournamentManager
    {
        private IUploadTournament upload;
        private List<Tournament> tournaments;
        public Tournament[] Tournaments { get { return tournaments.ToArray(); } }
        public TournamentManager(IUploadTournament uploadTournament)
        {
            if(uploadTournament.GetType() == typeof(UploadTournament))
            {
                upload = new UploadTournament();
            }
            else if(uploadTournament.GetType() == typeof(MockUploadTournament))
            {
                upload = new MockUploadTournament();
            }
            tournaments = upload.GetTournaments();

        }
        public Tournament GetTournament(int? id)
        {
            foreach(Tournament tournament in tournaments)
            {
                if(tournament.Id == id)
                {
                    return tournament;
                }
            }
            return null;
        }
        public string CreateUpcoming(Upcoming_tournament tournament)
        {
            foreach(Tournament tournament1 in tournaments)
            {
                if(tournament1.Id == tournament.Id)
                {
                    return "Tournament with this ID already exist in the system!";
                }
            }
            tournaments.Add(tournament);
            upload.Create(tournament);
            return "Complete";
        }
        public void Update(Tournament tournament)
        {
            foreach(Tournament tournament1 in tournaments)
            {
                if(tournament1.Id == tournament.Id)
                {
                    if(tournament1 is Upcoming_tournament)
                    {
                        ((Upcoming_tournament)tournament1).UpdateDesc(tournament.Description);
                        ((Upcoming_tournament)tournament1).UpdateStartDate(tournament.StartDate);
                        ((Upcoming_tournament)tournament1).UpdateEndDate(tournament.EndDate);
                        ((Upcoming_tournament)tournament1).UpdateGames(tournament.NumGames);
                        upload.Update(tournament1);
                    }else if (tournament1 is Ongoing_tournament)
                    {
                        ((Ongoing_tournament)tournament1).UpdateDesc(tournament.Description);
                        ((Ongoing_tournament)tournament1).UpdateEndDate(tournament.EndDate);
                        upload.Update(tournament1);
                    }
                }
            }
        }
        public void Delete(Tournament tournament)
        {
            if(tournament.GetType() != typeof(Ongoing_tournament))
            {
                foreach (Tournament tournament1 in Tournaments)
                {
                    if (tournament1.Id == tournament.Id)
                    {
                        tournaments.Remove(tournament1);
                        upload.DeleteTournament(tournament1);
                    }
                }
            }
        }
        public void AddPlayer(int tournamentID, People player)
        {
            foreach(Tournament tournament in tournaments)
            {
                if(tournament is Upcoming_tournament)
                {
                    if (tournament.Id == tournamentID)
                    {
                        ((Upcoming_tournament)tournament).AddParticipant(player);
                        upload.AddPlayer(tournamentID, player);
                    }
                }
            }
        }
    }
}