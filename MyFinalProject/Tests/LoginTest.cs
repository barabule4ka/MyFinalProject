using MyFinalProject.BusinessObjects.PageObjects;
using MyFinalProject.Models;
using OpenQA.Selenium.DevTools.V112.Network;

namespace MyFinalProject.Tests
{
    [TestFixture]

    internal class LoginTest : BaseTest
    {

        [Test]
        public void LoginAsUnknownUser()
        {
            var expectedError = "Authentication failed";
            var user = UserBuilder.LoginAsFakeUser();

            var page = new LoginPage();
            page.OpenPage();
            page.TryToLogin(user);
            string text = page.FindErrorMessage(expectedError);

            Assert.That(text, Does.Contain(expectedError));
        }

        
        [Test]
        public void LoginWithWrongPassword()
        {
            var expectedError = "Invalid password";
            var user = UserBuilder.UseRealUserWitIncorrectPass();

            var page = new LoginPage();
            page.OpenPage();
            page.TryToLogin(user);
            string text = page.FindErrorMessage(expectedError);

            Assert.That(text, Does.Contain(expectedError));
            
        }

        [Test]
        public void LoginAsUser()
        {
            var expectedUrl = "http://prestashop.qatestlab.com.ua/ru/my-account";
            
            var page = new LoginPage()
            .OpenPage()
            .TryToLoginAsUser();
            string currentUrl = page.GetCurrentUrl();

            Assert.That(currentUrl, Is.EqualTo(expectedUrl));
        }

    }
}
