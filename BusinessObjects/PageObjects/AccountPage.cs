using Core.Selenium;
using NUnit.Allure.Attributes;
using OpenQA.Selenium;

namespace BusinessObjects.PageObjects
{
    public class AccountPage : BasePage
    {
        public const string url = "http://prestashop.qatestlab.com.ua/ru/my-account";
       // public string urlAccountCreation = "http://prestashop.qatestlab.com.ua/ru/authentication?back=my-account#account-creation";

        private By HomePageButton = By.CssSelector("#center_column > ul > li > a");

        public AccountPage() : base()
        {
        }

        public MainPage GoBackToMainPage()
        {
            driver.FindElement(HomePageButton).Click();
            return new MainPage();
        }

        public override AccountPage OpenPage()
        {
            Browser.Instance.NavigateToUrl(url);
            return this;
        }

        [AllureStep("Get url of current page")]
        public string GetCurrentUrl()
        {
            logger.Info($"Get Current page Url {driver.Url}");

            return driver.Url.ToString();
        }
    }
}
