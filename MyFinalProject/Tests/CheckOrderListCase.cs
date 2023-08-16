using Allure.Net.Commons;
using BusinessObjects.Models;
using BusinessObjects.PageObjects;
using NUnit.Allure.Attributes;

namespace MyFinalProject.Tests
{
    internal class CheckOrderListCase : BaseTest
    {
        [Test(Description = "Login and check orders for new user")]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureTag("Smoke")]
        [Description("New test-user account")]
        [AllureOwner("Barabule4ka")]
        [AllureSuite("Prestashop")]
        [AllureSubSuite("Order page tests")]
        [AllureTms("TFS_MTS")]
        [AllureIssue("issue-12458")]
        [Category("Order")]
        public void CreateNewAccountAndGoToOrders()
        {
            var user = UserBuilder.CreateFakeUser();

            new LoginPage()
                .OpenPage()
                .CreateNewAccount(user)
                .GoToOrderPage()
                .VerifyEmptyOrdersHistoryMessage();
        }

        [Test(Description = "Login and check orders history for real user")]
        [AllureSeverity(SeverityLevel.normal)]
        [AllureTag("Smoke")]
        [Description("Real test-user account")]
        [AllureOwner("Barabule4ka")]
        [AllureSuite("Prestashop")]
        [AllureSubSuite("Order page tests")]
        [AllureTms("TFS_MTS")]
        [AllureIssue("issue-12458")]
        [Category("Order")]
        public void GoToRealUserOrdersHistory()
        {
            new LoginPage()
                .OpenPage()
                .LoginAsRealUser()
                .GoToOrderPage()
                .VerifyExistingOrdersHistoryTable();
        }
    }
}
