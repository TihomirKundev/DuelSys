using Microsoft.VisualStudio.TestTools.UnitTesting;
using SynthesisAssignment.Base_classes;
using SynthesisAssignment.Manager_classes;
using SynthesisAssignment.Upload_classes;
using System;
using System.Collections.Generic;

namespace UnitTests
{
    [TestClass]
    public class TournamentManagerTests
    {
        [TestMethod]
        public void CreateTournament()
        {
            TournamentManager tournamentManager = new TournamentManager(new MockUploadTournament());
            Upcoming_tournament tournament = new Upcoming_tournament(10,"Badminton","Test", new DateTime(2022, 06, 25), new DateTime(2022, 07, 10), 4, 8, "Eindhoven", 1, new List<People>());

            string res = tournamentManager.CreateUpcoming(tournament);

            Assert.AreEqual("Complete", res);
        }
        [TestMethod]
        public void CreateExistingTournament()
        {
            TournamentManager tournamentManager = new TournamentManager(new MockUploadTournament());
            Upcoming_tournament tournament = new Upcoming_tournament(1,"Badminton", "Test", new DateTime(2022, 06, 25), new DateTime(2022, 07, 10), 4, 8, "Eindhoven", 1, new List<People>());

            string res = tournamentManager.CreateUpcoming(tournament);

            Assert.AreEqual("Tournament with this ID already exist in the system!", res);
        }
        [TestMethod]
        public void UpdatePastTournament()
        {
            TournamentManager tournamentManager = new TournamentManager(new MockUploadTournament());
            Tournament tournament = new Past_tournament(3,"Badminton", "Test4", new DateTime(2022, 05, 20), new DateTime(2022, 06, 05), 5, 15, "Best", 5, new Dictionary<People, int>());

            tournamentManager.Update(tournament);

            Assert.AreNotEqual("Test4", tournamentManager.Tournaments[2].Description);
        }
        [TestMethod]
        public void UpdateCancelTournament()
        {
            TournamentManager tournamentManager = new TournamentManager(new MockUploadTournament());
            Tournament tournament = new Canceled_tournament(4, "Badminton", "Test5", new DateTime(2022, 05, 22), new DateTime(2022, 06, 02), 5, 15, "Best", 5, new List<People>());

            tournamentManager.Update(tournament);

            Assert.AreNotEqual("Test5", tournamentManager.Tournaments[3].Description);
        }
        [TestMethod]
        public void UpdateUpcomingTournament()
        {
            TournamentManager tournamentManager = new TournamentManager(new MockUploadTournament());
            Tournament tournament = new Upcoming_tournament(1, "Badminton", "Test2", new DateTime(2022, 06, 26), new DateTime(2022, 07, 11), 4, 8, "Eindhoven", 3, new List<People>());


            tournamentManager.Update(tournament);

            Assert.AreEqual("Test2", tournamentManager.Tournaments[0].Description);
            Assert.AreEqual(new DateTime(2022, 06, 26), tournamentManager.Tournaments[0].StartDate);
            Assert.AreEqual(new DateTime(2022, 07, 11), tournamentManager.Tournaments[0].EndDate);
            Assert.AreEqual(3, tournamentManager.Tournaments[0].NumGames);

        }
        [TestMethod]
        public void UpdateOngoingTournament()
        {
            TournamentManager tournamentManager = new TournamentManager(new MockUploadTournament());
            Tournament tournament = new Ongoing_tournament(2, "Badminton", "Test3", new DateTime(2022, 06, 06), new DateTime(2022, 07, 11), 3, 7, "Amsterdam", 3, new Dictionary<People, int>(), new List<Game>());


            tournamentManager.Update(tournament);

            Assert.AreEqual("Test3", tournamentManager.Tournaments[1].Description);
            Assert.AreEqual(new DateTime(2022, 07, 11), tournamentManager.Tournaments[1].EndDate);

        }
        [TestMethod]
        public void DeleteOngoingTournament()
        {
            TournamentManager tournamentManager = new TournamentManager(new MockUploadTournament());
            Tournament tournament = new Ongoing_tournament(2, "Badminton", "Test3", new DateTime(2022, 06, 06), new DateTime(2022, 07, 11), 3, 7, "Amsterdam", 3, new Dictionary<People, int>(), new List<Game>());

            tournamentManager.Delete(tournament);

            Assert.AreEqual(4, tournamentManager.Tournaments.Length);
        }
        [TestMethod]
        public void DeleteTournamentWithWrongID()
        {
            TournamentManager tournamentManager = new TournamentManager(new MockUploadTournament());
            Tournament tournament = new Upcoming_tournament(10, "Badminton", "Test3", new DateTime(2022, 06, 06), new DateTime(2022, 07, 11), 3, 7, "Amsterdam", 3, new List<People>());

            tournamentManager.Delete(tournament);

            Assert.AreEqual(4, tournamentManager.Tournaments.Length);
        }
        [TestMethod]
        public void DeleteTournament()
        {
            TournamentManager tournamentManager = new TournamentManager(new MockUploadTournament());
            Tournament tournament = new Upcoming_tournament(1, "Badminton", "Test3", new DateTime(2022, 06, 06), new DateTime(2022, 07, 11), 3, 7, "Amsterdam", 3, new List<People>());

            tournamentManager.Delete(tournament);

            Assert.AreNotEqual(1, tournamentManager.Tournaments[0].Id);
        }
        [TestMethod]
        public void AddPlayer()
        {
            TournamentManager tournamentManager = new TournamentManager(new MockUploadTournament());

            tournamentManager.AddPlayer(1, new People("Gabriel", "Garbov", "gabriel@gmail.com", "Gab1234"));
            int res = ((Upcoming_tournament)tournamentManager.Tournaments[0]).Participants.Length;

            Assert.AreEqual(1, res);
        }
        [TestMethod]
        public void AddPlayerToWrongTypeTournament()
        {
            TournamentManager tournamentManager = new TournamentManager(new MockUploadTournament());

            tournamentManager.AddPlayer(3, new People("Gabriel", "Garbov", "gabriel@gmail.com", "Gab1234"));
            int res = ((Past_tournament)tournamentManager.Tournaments[2]).Players.Length;

            Assert.AreEqual(0, res);
        }
        [TestMethod]
        public void AddPlayerToMissingTournament()
        {
            TournamentManager tournamentManager = new TournamentManager(new MockUploadTournament());

            tournamentManager.AddPlayer(10, new People("Gabriel", "Garbov", "gabriel@gmail.com", "Gab1234"));
            int res = ((Upcoming_tournament)tournamentManager.Tournaments[0]).Participants.Length;

            Assert.AreEqual(0, res);
        }
    }
}
