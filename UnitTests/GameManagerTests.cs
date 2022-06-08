using Microsoft.VisualStudio.TestTools.UnitTesting;
using Synthesis_assignment.Base_classes;
using Synthesis_assignment.Manager_classes;
using Synthesis_assignment.Upload_classes;

namespace UnitTests
{
    [TestClass]
    public class GameManagerTests
    {
        [TestMethod]
        public void RegisterResults()
        {
            Game game = new Game(1, "tihomirkandev@gmail.com", "gabrielgarbov@gmail.com", new int[3], new int[3]);
            GameManager gameManager = new GameManager(game, new MockUploadSchedule());

            gameManager.RegisterResults(1, 21, 19);

            Assert.AreEqual(21, game.Result().Item1[0]);
            Assert.AreEqual(19, game.Result().Item2[0]);
        }
        [TestMethod]
        public void RegisterResultsWithWrongMatchID()
        {
            Game game = new Game(1, "tihomirkandev@gmail.com", "gabrielgarbov@gmail.com", new int[3], new int[3]);
            GameManager gameManager = new GameManager(game, new MockUploadSchedule());

            gameManager.RegisterResults(-1, 21, 19);

            Assert.AreEqual(0, game.Result().Item1[0]);
            Assert.AreEqual(0, game.Result().Item2[0]);
        }
        [TestMethod]
        public void AddWin()
        {
            Game game = new Game(1, "tihomirkandev@gmail.com", "gabrielgarbov@gmail.com", new int[3] {21,21,0}, new int[3] {16,16,0});
            MockUploadSchedule mockUploadSchedule = new MockUploadSchedule();
            GameManager gameManager = new GameManager(game, mockUploadSchedule);

            gameManager.RegisterResults(3, 21, 19);

            Assert.AreEqual(1, mockUploadSchedule.gamesWon);
        }
        [TestMethod]
        public void CorrectPointsCheckWhenAIs21()
        {
            Game game = new Game(1, "tihomirkandev@gmail.com", "gabrielgarbov@gmail.com", new int[3], new int[3]);
            GameManager gameManager = new GameManager(game, new MockUploadSchedule());

            bool res = gameManager.PointsCheck(21, 15);

            Assert.IsTrue(res);
        }
        [TestMethod]
        public void CorrectPointsCheckWhenBIs21()
        {
            Game game = new Game(1, "tihomirkandev@gmail.com", "gabrielgarbov@gmail.com", new int[3], new int[3]);
            GameManager gameManager = new GameManager(game, new MockUploadSchedule());

            bool res = gameManager.PointsCheck(15, 21);

            Assert.IsTrue(res);
        }
        [TestMethod]
        public void CorrectPointsCheckWhenABetween21And29()
        {
            Game game = new Game(1, "tihomirkandev@gmail.com", "gabrielgarbov@gmail.com", new int[3], new int[3]);
            GameManager gameManager = new GameManager(game, new MockUploadSchedule());

            bool res = gameManager.PointsCheck(23, 21);

            Assert.IsTrue(res);
        }
        [TestMethod]
        public void CorrectPointsCheckWhenBBetween21And29()
        {
            Game game = new Game(1, "tihomirkandev@gmail.com", "gabrielgarbov@gmail.com", new int[3], new int[3]);
            GameManager gameManager = new GameManager(game, new MockUploadSchedule());

            bool res = gameManager.PointsCheck(21, 23);

            Assert.IsTrue(res);
        }
        [TestMethod]
        public void CorrectPointsCheckWhenAIs30()
        {
            Game game = new Game(1, "tihomirkandev@gmail.com", "gabrielgarbov@gmail.com", new int[3], new int[3]);
            GameManager gameManager = new GameManager(game, new MockUploadSchedule());

            bool res = gameManager.PointsCheck(30, 29);

            Assert.IsTrue(res);
        }
        [TestMethod]
        public void CorrectPointsCheckWhenBIs30()
        {
            Game game = new Game(1, "tihomirkandev@gmail.com", "gabrielgarbov@gmail.com", new int[3], new int[3]);
            GameManager gameManager = new GameManager(game, new MockUploadSchedule());

            bool res = gameManager.PointsCheck(29, 30);

            Assert.IsTrue(res);
        }
        [TestMethod]
        public void WrongPointsCheckWhenAIs21()
        {
            Game game = new Game(1, "tihomirkandev@gmail.com", "gabrielgarbov@gmail.com", new int[3], new int[3]);
            GameManager gameManager = new GameManager(game, new MockUploadSchedule());

            bool res = gameManager.PointsCheck(21, 31);

            Assert.IsFalse(res);
        }

        [TestMethod]
        public void WrongPointsCheckWhenBIs21()
        {
            Game game = new Game(1, "tihomirkandev@gmail.com", "gabrielgarbov@gmail.com", new int[3], new int[3]);
            GameManager gameManager = new GameManager(game, new MockUploadSchedule());

            bool res = gameManager.PointsCheck(31, 21);

            Assert.IsFalse(res);
        }
        [TestMethod]
        public void WrongPointsCheckWhenABetween21and29()
        {
            Game game = new Game(1, "tihomirkandev@gmail.com", "gabrielgarbov@gmail.com", new int[3], new int[3]);
            GameManager gameManager = new GameManager(game, new MockUploadSchedule());

            bool res = gameManager.PointsCheck(27, 21);

            Assert.IsFalse(res);
        }

        [TestMethod]
        public void WrongPointsCheckWhenBBetween21and29()
        {
            Game game = new Game(1, "tihomirkandev@gmail.com", "gabrielgarbov@gmail.com", new int[3], new int[3]);
            GameManager gameManager = new GameManager(game, new MockUploadSchedule());

            bool res = gameManager.PointsCheck(21, 27);

            Assert.IsFalse(res);
        }

        [TestMethod]
        public void WrongPointsCheckWhenAis30()
        {
            Game game = new Game(1, "tihomirkandev@gmail.com", "gabrielgarbov@gmail.com", new int[3], new int[3]);
            GameManager gameManager = new GameManager(game, new MockUploadSchedule());

            bool res = gameManager.PointsCheck(30, 27);

            Assert.IsFalse(res);
        }

        [TestMethod]
        public void WrongPointsCheckWhenBis30()
        {
            Game game = new Game(1, "tihomirkandev@gmail.com", "gabrielgarbov@gmail.com", new int[3], new int[3]);
            GameManager gameManager = new GameManager(game, new MockUploadSchedule());

            bool res = gameManager.PointsCheck(27, 30);

            Assert.IsFalse(res);
        }
    }
}
