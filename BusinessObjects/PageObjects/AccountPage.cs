using Core.Selenium;
using NUnit.Allure.Attributes;
using OpenQA.Selenium;

namespace BusinessObjects.PageObjects
{
    public class AccountPage : BasePage
    {
        public const string url = "http://prestashop.qatestlab.com.ua/ru/my-account";
      
        private By HomePageButton = By.CssSelector("#center_column > ul > li > a");
        private By LogoutLink = By.CssSelector("a.logout");
        private By AccountCreatedMessage = By.XPath("//*[@id='center_column']/p[1]");

        public AccountPage() : base()
        {
        }

        [AllureStep("Go Back To Main Page after login")]
        public MainPage GoBackToMainPage()
        {
            driver.FindElement(HomePageButton).Click();
            logger.Info($"Go Back To Main Page");

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

        [AllureStep("Logoff")]
        public LoginPage LogOut()
        {
            driver.FindElement(LogoutLink).Click();
            
            logger.Info($"Make logout");

            return new LoginPage();


        }

        [AllureStep("Find message about successful account creation")]
        public bool AccountCreated()
        {
            driver.FindElement(AccountCreatedMessage);

            logger.Info($"Message after account created: {driver.FindElement(AccountCreatedMessage).Text}");

            return true;
        }
    }
}
