using BusinessObjects.PageObjects;
using NUnit.Allure.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
