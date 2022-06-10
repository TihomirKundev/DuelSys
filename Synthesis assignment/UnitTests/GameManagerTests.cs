using Microsoft.VisualStudio.TestTools.UnitTesting;
using SynthesisAssignment.Base_classes;
using SynthesisAssignment.Manager_classes;
using SynthesisAssignment.Upload_classes;

namespace UnitTests
{
    [TestClass]
    public class GameManagerTests
    {
        [TestMethod]
        public void RegisterResults()
        {
            Game game = new Game(1,"Badminton", "tihomirkandev@gmail.com", "gabrielgarbov@gmail.com", new int[3], new int[3]);
            GameManager gameManager = new GameManager(game, new MockUploadGame());

            gameManager.RegisterResults(1, 21, 19);

            Assert.AreEqual(21, game.Result().Item1[0]);
            Assert.AreEqual(19, game.Result().Item2[0]);
        }
        [TestMethod]
        public void RegisterResultsWithWrongMatchID()
        {
            Game game = new Game(1,"Badminton", "tihomirkandev@gmail.com", "gabrielgarbov@gmail.com", new int[3], new int[3]);
            GameManager gameManager = new GameManager(game, new MockUploadGame());

            gameManager.RegisterResults(-1, 21, 19);

            Assert.AreEqual(0, game.Result().Item1[0]);
            Assert.AreEqual(0, game.Result().Item2[0]);
        }
        [TestMethod]
        public void AddWin()
        {
            Game game = new Game(1,"Badminton", "tihomirkandev@gmail.com", "gabrielgarbov@gmail.com", new int[3] {21,21,0}, new int[3] {16,16,0});
            MockUploadGame mockUploadSchedule = new MockUploadGame();
            GameManager gameManager = new GameManager(game, mockUploadSchedule);

            gameManager.RegisterResults(3, 21, 19);

            Assert.AreEqual(1, mockUploadSchedule.gamesWon);
        }
        [TestMethod]
        public void CorrectBadmintonPointsCheckWhenAIs21()
        {
            Game game = new Game(1,"Badminton", "tihomirkandev@gmail.com", "gabrielgarbov@gmail.com", new int[3], new int[3]);
            GameManager gameManager = new GameManager(game, new MockUploadGame());

            bool res = gameManager.PointsCheck(21, 15);

            Assert.IsTrue(res);
        }
        [TestMethod]
        public void CorrectBadmintonPointsCheckWhenBIs21()
        {
            Game game = new Game(1, "Badminton", "tihomirkandev@gmail.com", "gabrielgarbov@gmail.com", new int[3], new int[3]);
            GameManager gameManager = new GameManager(game, new MockUploadGame());

            bool res = gameManager.PointsCheck(15, 21);

            Assert.IsTrue(res);
        }
        [TestMethod]
        public void CorrectBadmintonPointsCheckWhenABetween21And29()
        {
            Game game = new Game(1, "Badminton", "tihomirkandev@gmail.com", "gabrielgarbov@gmail.com", new int[3], new int[3]);
            GameManager gameManager = new GameManager(game, new MockUploadGame());

            bool res = gameManager.PointsCheck(23, 21);

            Assert.IsTrue(res);
        }
        [TestMethod]
        public void CorrectBadmintonPointsCheckWhenBBetween21And29()
        {
            Game game = new Game(1, "Badminton", "tihomirkandev@gmail.com", "gabrielgarbov@gmail.com", new int[3], new int[3]);
            GameManager gameManager = new GameManager(game, new MockUploadGame());

            bool res = gameManager.PointsCheck(21, 23);

            Assert.IsTrue(res);
        }
        [TestMethod]
        public void CorrectBadmintonPointsCheckWhenAIs30()
        {
            Game game = new Game(1, "Badminton", "tihomirkandev@gmail.com", "gabrielgarbov@gmail.com", new int[3], new int[3]);
            GameManager gameManager = new GameManager(game, new MockUploadGame());

            bool res = gameManager.PointsCheck(30, 29);

            Assert.IsTrue(res);
        }
        [TestMethod]
        public void CorrectBadmintonPointsCheckWhenBIs30()
        {
            Game game = new Game(1, "Badminton", "tihomirkandev@gmail.com", "gabrielgarbov@gmail.com", new int[3], new int[3]);
            GameManager gameManager = new GameManager(game, new MockUploadGame());

            bool res = gameManager.PointsCheck(29, 30);

            Assert.IsTrue(res);
        }
        [TestMethod]
        public void WrongBadmintonPointsCheckWhenAIs21()
        {
            Game game = new Game(1, "Badminton", "tihomirkandev@gmail.com", "gabrielgarbov@gmail.com", new int[3], new int[3]);
            GameManager gameManager = new GameManager(game, new MockUploadGame());

            bool res = gameManager.PointsCheck(21, 31);

            Assert.IsFalse(res);
        }

        [TestMethod]
        public void WrongBadmintonPointsCheckWhenBIs21()
        {
            Game game = new Game(1, "Badminton", "tihomirkandev@gmail.com", "gabrielgarbov@gmail.com", new int[3], new int[3]);
            GameManager gameManager = new GameManager(game, new MockUploadGame());

            bool res = gameManager.PointsCheck(31, 21);

            Assert.IsFalse(res);
        }
        [TestMethod]
        public void WrongBadmintonPointsCheckWhenABetween21and29()
        {
            Game game = new Game(1, "Badminton", "tihomirkandev@gmail.com", "gabrielgarbov@gmail.com", new int[3], new int[3]);
            GameManager gameManager = new GameManager(game, new MockUploadGame());

            bool res = gameManager.PointsCheck(27, 21);

            Assert.IsFalse(res);
        }

        [TestMethod]
        public void WrongBadmintonPointsCheckWhenBBetween21and29()
        {
            Game game = new Game(1, "Badminton", "tihomirkandev@gmail.com", "gabrielgarbov@gmail.com", new int[3], new int[3]);
            GameManager gameManager = new GameManager(game, new MockUploadGame());

            bool res = gameManager.PointsCheck(21, 27);

            Assert.IsFalse(res);
        }

        [TestMethod]
        public void WrongBadmintonPointsCheckWhenAis30()
        {
            Game game = new Game(1, "Badminton", "tihomirkandev@gmail.com", "gabrielgarbov@gmail.com", new int[3], new int[3]);
            GameManager gameManager = new GameManager(game, new MockUploadGame());

            bool res = gameManager.PointsCheck(30, 27);

            Assert.IsFalse(res);
        }

        [TestMethod]
        public void WrongBadmintonPointsCheckWhenBis30()
        {
            Game game = new Game(1, "Badminton", "tihomirkandev@gmail.com", "gabrielgarbov@gmail.com", new int[3], new int[3]);
            GameManager gameManager = new GameManager(game, new MockUploadGame());

            bool res = gameManager.PointsCheck(27, 30);

            Assert.IsFalse(res);
        }
        [TestMethod]
        public void CorrectFootballPoints()
        {
            Game game = new Game(1, "Football", "tihomirkandev@gmail.com", "gabrielgarbov@gmail.com", new int[3], new int[3]);
            GameManager gameManager = new GameManager(game, new MockUploadGame());

            bool res = gameManager.PointsCheck(3, 1);

            Assert.IsTrue(res);
        }
        [TestMethod]
        public void WrongFootballPointsWhenAIsBelow0()
        {
            Game game = new Game(1, "Football", "tihomirkandev@gmail.com", "gabrielgarbov@gmail.com", new int[3], new int[3]);
            GameManager gameManager = new GameManager(game, new MockUploadGame());

            bool res = gameManager.PointsCheck(-1, 1);

            Assert.IsFalse(res);
        }
        [TestMethod]
        public void WrongFootballPointsWhenBIsBelow0()
        {
            Game game = new Game(1, "Football", "tihomirkandev@gmail.com", "gabrielgarbov@gmail.com", new int[3], new int[3]);
            GameManager gameManager = new GameManager(game, new MockUploadGame());

            bool res = gameManager.PointsCheck(1, -1);

            Assert.IsFalse(res);
        }
        [TestMethod]
        public void WrongFootballPointsWhenAIsAbove10()
        {
            Game game = new Game(1, "Football", "tihomirkandev@gmail.com", "gabrielgarbov@gmail.com", new int[3], new int[3]);
            GameManager gameManager = new GameManager(game, new MockUploadGame());

            bool res = gameManager.PointsCheck(11, 1);

            Assert.IsFalse(res);
        }
        [TestMethod]
        public void WrongFootballPointsWhenBIsAbove10()
        {
            Game game = new Game(1, "Football", "tihomirkandev@gmail.com", "gabrielgarbov@gmail.com", new int[3], new int[3]);
            GameManager gameManager = new GameManager(game, new MockUploadGame());

            bool res = gameManager.PointsCheck(1, 11);

            Assert.IsFalse(res);
        }
        [TestMethod]
        public void FootballDraw()
        {
            Game game = new Game(1, "Football", "tihomirkandev@gmail.com", "gabrielgarbov@gmail.com", new int[3], new int[3]);
            GameManager gameManager = new GameManager(game, new MockUploadGame());

            bool res = gameManager.PointsCheck(3, 3);

            Assert.IsFalse(res);
        }
    }
}
