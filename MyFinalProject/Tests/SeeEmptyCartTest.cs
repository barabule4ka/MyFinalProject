using BusinessObjects.PageObjects;
using NUnit.Allure.Attributes;

namespace MyFinalProject.Tests
{
    internal class SeeEmptyCartTest : BaseTest
    {
        [Test(Description = "See alert in Empty Cart")]
        [AllureTag("First priority cases")]
        [Description("Non-existent account")]
        [AllureOwner("Barabule4ka")]
        [AllureSuite("Prestashop")]
        [AllureSubSuite("Negative tests")]
        [AllureTms("TFS_MTS")]
        [AllureIssue("issue-1234")]

        public void SeeEmptyCart()
        {
            new CartPage()
                .OpenPage()
                .AssertEmptyCart();
        }
    }
}
