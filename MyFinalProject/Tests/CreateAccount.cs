using BusinessObjects.Models;
using BusinessObjects.PageObjects;
using NUnit.Allure.Attributes;

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
        public void CreateNewAccount()
        {
            var user = UserBuilder.CreateFakeUser();

            var page = new LoginPage()
                .OpenPage()
                .CreateNewAccount(user);

                Assert.That(page.AccountCreated());
        }
    }
}
