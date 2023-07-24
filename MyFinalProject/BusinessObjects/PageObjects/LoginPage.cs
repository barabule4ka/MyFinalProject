using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using MyFinalProject.Models;
using OpenQA.Selenium;

namespace MyFinalProject.BusinessObjects.PageObjects
{
    internal class LoginPage : BasePage
    {
        private const string USER_EMAIL = "qweqwe@qweqwe.ru";
        private const string PASSWORD = "qweQwe";

        private By UserEmailInput = By.Id("email");
        private By PasswordInput = By.Id("passwd");
        private By LoginButton = By.XPath("//button[@id='SubmitLogin']/span");
        private By ErrorMessage = By.XPath("/html/body/div/div[2]/div/div[2]/div/div[1]/ol/li");

        public const string url = "http://prestashop.qatestlab.com.ua/en/authentication?back=my-account";

        public LoginPage(WebDriver webDriver) : base(webDriver)
        {

        }

        public override LoginPage OpenPage()
        {
            driver.Navigate().GoToUrl(url);
            return this;
        }

        public void EnterEmail(UserModel user)
        {
            driver.FindElement(UserEmailInput).SendKeys(user.Email);
        }

        public void EnterPassword(UserModel user)
        {
            driver.FindElement(PasswordInput).SendKeys(user.Password);
        }

        public void ClickSubmitButtonToLogin()
        {
            driver.FindElement(LoginButton).Click();
        }

        public string FindErrorMessage (string message)
        {
            string errorText = driver.FindElement(ErrorMessage).Text;
            return errorText;
            
        }

        public void TryToLoginAsUnknownUser(UserModel user)
        {
            EnterEmail(user);
            EnterPassword(user);
            ClickSubmitButtonToLogin();

        }

        public AccountPage TryToLoginAsUser() 
        {
            driver.FindElement(UserEmailInput).SendKeys(USER_EMAIL);
            driver.FindElement(PasswordInput).SendKeys(PASSWORD);
            driver.FindElement(LoginButton).Click();

            return new AccountPage(driver);
        }


        internal bool VerifyErrorMesage()
        {
            return false;
        }
    }
}
