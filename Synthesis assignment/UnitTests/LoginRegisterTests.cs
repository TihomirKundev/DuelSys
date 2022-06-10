using Microsoft.VisualStudio.TestTools.UnitTesting;
using SynthesisAssignment;
using SynthesisAssignment.Base_classes;
using SynthesisAssignment.Upload_classes;

namespace UnitTests
{
    [TestClass]
    public class LoginRegisterTests
    {
        [TestMethod]
        public void LoginPlayer()
        {
            LoginRegister loginRegister = new LoginRegister(new MockUploadPeople());

            People p = loginRegister.Login("annakadurina@gmail.com", "Anna1234", "Player");

            Assert.IsNotNull(p);
        }
        [TestMethod]
        public void LoginPlayerWithWrongCredentials()
        {
            LoginRegister loginRegister = new LoginRegister(new MockUploadPeople());

            People p = loginRegister.Login("annakadurina@gmail.com", "Anna", "Player");

            Assert.IsNull(p);
        }
        [TestMethod]
        public void LoginStaff()
        {
            LoginRegister loginRegister = new LoginRegister(new MockUploadPeople());

            People p = loginRegister.Login("tihomirkandev@gmail.com", "Tihomir1234", "Staff");

            Assert.IsNotNull(p);
        }
        [TestMethod]
        public void LoginStaffWithWrongCredentials()
        {
            LoginRegister loginRegister = new LoginRegister(new MockUploadPeople());

            People p = loginRegister.Login("tihomirkandev@gmail.com", "Tihomir", "Staff");

            Assert.IsNull(p);
        }
        [TestMethod]
        public void LoginWithWrongType()
        {
            LoginRegister loginRegister = new LoginRegister(new MockUploadPeople());

            People p = loginRegister.Login("tihomirkandev@gmail.com", "Tihomir1234", "Wrong");

            Assert.IsNull(p);
        }
        [TestMethod]
        public void Register()
        {
            LoginRegister loginRegister = new LoginRegister(new MockUploadPeople());
            People input = new People("Gabriel", "Garbov", "gabriel@gmail.com", "Gab1234");

            People p = loginRegister.RegisterPlayer(input);

            Assert.IsNotNull(p);
        }
        [TestMethod]
        public void RegisterExistingEmail()
        {
            LoginRegister loginRegister = new LoginRegister(new MockUploadPeople());
            People input = new People("Anna", "Kadurina", "annakadurina@gmail.com", "Anna1234");

            People p = loginRegister.RegisterPlayer(input);

            Assert.IsNull(p);
        }
        [TestMethod]
        public void PassCheckMissingCapitalCase()
        {
            LoginRegister loginRegister = new LoginRegister(new MockUploadPeople());

            string output = loginRegister.CheckPass("a1234");

            Assert.AreEqual("Your password should have at least one upper case!", output);
        }
        [TestMethod]
        public void PassCheckMissingLowerCase()
        {
            LoginRegister loginRegister = new LoginRegister(new MockUploadPeople());

            string output = loginRegister.CheckPass("A1234");

            Assert.AreEqual("Your password should have at least one lower case!", output);
        }
        [TestMethod]
        public void PassCheckMissingNumber()
        {
            LoginRegister loginRegister = new LoginRegister(new MockUploadPeople());

            string output = loginRegister.CheckPass("Aana");

            Assert.AreEqual("Your password should have at least one number!", output);
        }
        [TestMethod]
        public void PassCheckShortLenght()
        {
            LoginRegister loginRegister = new LoginRegister(new MockUploadPeople());

            string output = loginRegister.CheckPass("An12");

            Assert.AreEqual("Your password should be at least 6 symbols in it!", output);
        }
        [TestMethod]
        public void PassCheckComplete()
        {
            LoginRegister loginRegister = new LoginRegister(new MockUploadPeople());

            string output = loginRegister.CheckPass("Anna1234");

            Assert.AreEqual("Complete", output);
        }
    }
}
