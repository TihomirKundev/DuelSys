using Microsoft.VisualStudio.TestTools.UnitTesting;
using SynthesisAssignment.Base_classes;
using System;
using System.Collections.Generic;

namespace UnitTests
{
    [TestClass]
    public class BaseClassesTests
    {
        [TestMethod]
        public void RegisterResultInWrongMach()
        {
            Game game = new Game(1, "Badminton", "tihomirkanedv@gmail.com", "gabrielgarbov@gmail.com", new int[3] { 21, 0, 0 }, new int[3] { 15, 0, 0 });

            string res = game.RegisterResults(1, 12, 21);

            Assert.AreEqual(21, game.Result().Item1[0]);
            Assert.AreEqual("None", res);
        }
        [TestMethod]
        public void RegisterResult()
        {
            Game game = new Game(1, "Badminton", "tihomirkanedv@gmail.com", "gabrielgarbov@gmail.com", new int[3] { 21, 0, 0 }, new int[3] { 15, 0, 0 });

            string res = game.RegisterResults(2, 12, 21);

            Assert.AreEqual(12, game.Result().Item1[1]);
            Assert.AreEqual("None", res);
        }
        [TestMethod]
        public void RegisterResultAndAddWin()
        {
            Game game = new Game(1, "Badminton", "tihomirkanedv@gmail.com", "gabrielgarbov@gmail.com", new int[3] { 21, 21, 0 }, new int[3] { 15, 15, 0 });

            string res = game.RegisterResults(3, 12, 21);

            Assert.AreEqual(12, game.Result().Item1[2]);
            Assert.AreEqual("tihomirkanedv@gmail.com", res);
        }
        [TestMethod]
        public void CheckIsGameFinish()
        {
            Game game = new Game(1, "Badminton", "tihomirkanedv@gmail.com", "gabrielgarbov@gmail.com", new int[3] { 21, 21, 21 }, new int[3] { 15, 15, 15 });

            bool res = game.IsFinish();

            Assert.IsTrue(res);
        }
        [TestMethod]
        public void GetUnfinishedGames()
        {
            Game gameFinish = new Game(1, "Badminton", "tihomirkanedv@gmail.com", "gabrielgarbov@gmail.com", new int[3] { 21, 21, 21 }, new int[3] { 15, 15, 15 });
            Game gameUnfinish = new Game(2, "Badminton", "tihomirkanedv@gmail.com", "rosenstanchev@gmail.com", new int[3] { 21, 0, 0 }, new int[3] { 15, 0, 0 });
            Ongoing_tournament tournament = new Ongoing_tournament(2, "Badminton", "Test2", new DateTime(2022, 06, 06), new DateTime(2022, 07, 01), 3, 7, "Amsterdam", 3, new Dictionary<People, int>(), new List<Game>() { gameFinish,gameUnfinish});

            Game[] arr = tournament.GetUnfinishedGames();

            Assert.AreEqual(2,arr[0].Id);
        }
        [TestMethod]
        public void GetLeaderboard()
        {
            People people1 = new People("Anna", "Kadurina", "annakadurina@gmail.com", "Anna1234");
            People people2 = new People("Rosen", "Stanchev", "rosenstanchev@gmail.com", "Rosen1234");
            People people3 = new People("Tihomir", "Kandev", "tihomirkandev@gmail.com", "Tihomir1234");
            Dictionary<People, int> persons = new Dictionary<People, int>();
            persons.Add(people1, 0);
            persons.Add(people2, 2);
            persons.Add(people3, 1);
            Ongoing_tournament tournament = new Ongoing_tournament(2, "Badminton", "Test2", new DateTime(2022, 06, 06), new DateTime(2022, 07, 01), 3, 7, "Amsterdam", 3, persons , new List<Game>());

            Tuple<List<string>,List<int>> tuple = tournament.GetLeaderboard();

            Assert.AreEqual(2, tuple.Item2[0]);
            Assert.AreEqual("Tihomir Kandev", tuple.Item1[1]);
            Assert.AreEqual(3, tuple.Item1.Count);

        }
        [TestMethod]
        public void GetGame()
        {
            Game gameFinish = new Game(1, "Badminton", "tihomirkanedv@gmail.com", "gabrielgarbov@gmail.com", new int[3] { 21, 21, 21 }, new int[3] { 15, 15, 15 });
            Game gameUnfinish = new Game(2, "Badminton", "tihomirkanedv@gmail.com", "rosenstanchev@gmail.com", new int[3] { 21, 0, 0 }, new int[3] { 15, 0, 0 });
            Ongoing_tournament tournament = new Ongoing_tournament(2, "Badminton", "Test2", new DateTime(2022, 06, 06), new DateTime(2022, 07, 01), 3, 7, "Amsterdam", 3, new Dictionary<People, int>(), new List<Game>() { gameFinish, gameUnfinish });

            Game game = tournament.GetGame(2);

            Assert.AreEqual("tihomirkanedv@gmail.com", game.player1Email);
        }
        [TestMethod]
        public void AddParticipant()
        {
            Upcoming_tournament tournament = new Upcoming_tournament(2, "Badminton", "Test2", new DateTime(2022, 06, 06), new DateTime(2022, 07, 01), 3, 7, "Amsterdam", 3, new List<People>());
            People people = new People("Tihomir", "Kandev", "tihomirkandev@gmail.com", "Tihomir1234");

            string res = tournament.AddParticipant(people);

            Assert.AreEqual("Complete", res);
        }

        [TestMethod]
        public void AddExistingParticipant()
        {
            People people1 = new People("Rosen", "Stanchev", "tihomirkandev@gmail.com", "Tihomir1234");
            Upcoming_tournament tournament = new Upcoming_tournament(2, "Badminton", "Test2", new DateTime(2022, 06, 06), new DateTime(2022, 07, 01), 3, 7, "Amsterdam", 3, new List<People>() { people1});
            People people = new People("Tihomir", "Kandev", "tihomirkandev@gmail.com", "Tihomir1234");

            string res = tournament.AddParticipant(people);

            Assert.AreEqual("You are already registered!", res);
        }
    }
}
