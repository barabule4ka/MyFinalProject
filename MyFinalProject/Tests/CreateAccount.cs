using BusinessObjects.Models;
using BusinessObjects.PageObjects;
using NUnit.Allure.Attributes;
using Allure.Net.Commons;


namespace MyFinalProject.Tests
{
    [TestFixture]
    internal class CreateAccount : BaseTest
    {
        [Test]
        [AllureTag("First priority cases")]
        [Description("Non-existent account")]
        [AllureOwner("Barabule4ka")]
        [AllureSuite("Prestashop")]
        [AllureSubSuite("Login tests")]
        [AllureTms("TFS_MTS")]
        [AllureIssue("issue-1234")]
        public void CreateAccountAndLogIn()
        {
            var user = UserBuilder.CreateFakeUser();

            new LoginPage()
                .OpenPage()
                .CreateNewAccount(user)
                .GetCurrentUrl();
         

        }
    }
}
