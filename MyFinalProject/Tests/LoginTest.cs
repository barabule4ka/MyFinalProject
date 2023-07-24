using MyFinalProject.BusinessObjects.PageObjects;
using MyFinalProject.Models;


namespace MyFinalProject.Tests
{
    internal class LoginTest : BaseTest
    {

        [Test]
        public void LoginAsUnknownUser()
        {
            var expectedError = "Authentication failed";

            var user = new UserModel()
            {
                Email = "Test@test.test",
                Password = "password"
            };

            var page = new LoginPage(driver);

            page.OpenPage();
            page.TryToLoginAsUnknownUser(user);

            string text = page.FindErrorMessage(expectedError);

            Assert.That(text, Does.Contain(expectedError));
        }

        [Test]
        public void LoginAsUser()
        {
            var page = new LoginPage(driver);

            page.OpenPage();
            page.TryToLoginAsUser();
        }
    }
}
