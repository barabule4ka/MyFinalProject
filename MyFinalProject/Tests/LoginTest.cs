using MyFinalProject.BusinessObjects.PageObjects;
using MyFinalProject.Models;
using NUnit.Allure.Attributes;
using Allure.Net.Commons;

namespace MyFinalProject.Tests
{
    [TestFixture]

    internal class LoginTest : BaseTest
    {

        [Test(Description = "Login as unknown user")]
        [AllureTag("First priority cases")]
        [Description("Non-existent account")]
        [AllureOwner("Barabule4ka")]
        [AllureSuite("Prestashop")]
        [AllureSubSuite("Login tests")]
        [AllureTms("TFS_MTS")]
        [AllureIssue("issue-1234")]
        public void LoginAsUnknownUser()
        {
            var expectedError = "Authentication failed";
            var user = UserBuilder.LoginAsFakeUser();

            var page = new LoginPage();
            page.OpenPage();
            page.TryToLogin(user);
            string text = page.FindErrorMessage(expectedError);

            page.VerifyErrorMesage();

            Assert.That(text, Does.Contain(expectedError));
        }


        [Test(Description = "Right email - wrong pass")]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureTag("First priority cases")]
        [Description("User logs in, but makes mistake in password")]
        [AllureOwner("Barabule4ka")]
        [AllureSuite("Prestashop")]
        [AllureSubSuite("Login tests")]
        [AllureTms("TFS_MTS")]
        [AllureIssue("issue-123")]
        [AllureLink("https://google.com")]
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

        [Test(Description = "Login as real user")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureTag("Basic")]
        [Description("Use real user")]
        [AllureOwner("Barabule4ka")]
        [AllureSuite("Prestashop")]
        [AllureSubSuite("Smoke cases")]
        [AllureTms("TFS_MTS")]
        [AllureIssue("issue-12345")]
        public void LoginAsRealUser()
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
