using BusinessObjects.PageObjects;
using NUnit.Allure.Attributes;

namespace MyFinalProject.Tests
{
    public class ChangeLanguageTest : BaseTest
    {

        [Test(Description = "Change language")]
        [AllureTag("First priority cases")]
        [AllureOwner("Barabule4ka")]
        [AllureSuite("Prestashop")]
        [AllureTms("TFS_MTS")]
        [AllureIssue("issue-12348")]
        public void ChangeLanguageAndCheckUrl()
        {
            var expectedUrl = "http://prestashop.qatestlab.com.ua/en/";

            var url = new MainPage()
                .OpenPage()
                .SetNewLanguage()
                .GetCurrentUrl();

            Assert.That(url, Is.EqualTo(expectedUrl));
        }
    }
}
