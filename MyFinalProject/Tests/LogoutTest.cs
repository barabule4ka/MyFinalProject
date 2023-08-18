using Allure.Net.Commons;
using BusinessObjects.Models;
using BusinessObjects.PageObjects;
using NUnit.Allure.Attributes;

namespace MyFinalProject.Tests
{
    internal class LogoutTest : BaseTest
    {
        [Test(Description = "Login and logout")]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureTag("Smoke")]
        [Description("Real test-user account")]
        [AllureOwner("Barabule4ka")]
        [AllureSuite("Prestashop")]
        [AllureSubSuite("Login tests")]
        [AllureTms("TFS_MTS")]
        [AllureIssue("issue-12458")]
        [Category("Login")]
        public void Logout()
        {
            var expectedUrl = "http://prestashop.qatestlab.com.ua/ru/authentication?back=my-account";
            var url =
            new LoginPage()
            .OpenPage()
            .LoginAsRealUser()
            .LogOut()
            .GetCurrentUrl();

            Assert.That(url, Is.EqualTo(expectedUrl));
        }
    }
}
