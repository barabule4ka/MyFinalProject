using Core.Selenium;
using MyFinalProject.Models;
using OpenQA.Selenium;
using Core.Configuration;

namespace MyFinalProject.BusinessObjects.PageObjects
{
    internal class LoginPage : BasePage
    {
        //private const string USER_EMAIL = "qweqwe@qweqwe.ru";
        //private const string PASSWORD = "qweQwe";

        private By UserEmailInput = By.Id("email");
        private By PasswordInput = By.Id("passwd");
        private By LoginButton = By.Id("SubmitLogin");
        private By ErrorMessage = By.XPath("/html/body/div/div[2]/div/div[2]/div/div[1]/ol/li");

        public const string url = "http://prestashop.qatestlab.com.ua/ru/authentication?back=my-account";


        public LoginPage() : base()
        {

        }
        public override LoginPage OpenPage()
        {
            Browser.Instance.NavigateToUrl(url);
            return this;
        }
        public void EnterEmail(UserAuthModel user)
        {
            driver.FindElement(UserEmailInput).SendKeys(user.Email);
        }
        public void EnterPassword(UserAuthModel user)
        {
            driver.FindElement(PasswordInput).SendKeys(user.Password);
        }
        public void ClickSubmitButtonToLogin()
        {
            driver.FindElement(LoginButton).Submit();
        }
        public bool VerifyErrorMesage()
        {
            driver.FindElement(ErrorMessage);
            return false;
        }
        public string FindErrorMessage(string message)
        {
            string errorText = driver.FindElement(ErrorMessage).Text;

            switch (VerifyErrorMesage())
            {
                case true:
                    {
                        return errorText;

                    }
                case false:
                    {
                        ClickSubmitButtonToLogin();
                        return errorText;
                    }
            }
        }

        public void TryToLogin(UserAuthModel user)
        {
            driver.FindElement(UserEmailInput).SendKeys(user.Email);
            driver.FindElement(PasswordInput).SendKeys(user.Password);
            driver.FindElement(LoginButton).Click();
        }

        //public void TryToLoginWithWrongCredentials(UserAuthModel user)
        //{
            
        //    EnterEmail(user);
        //    EnterPassword(user);
        //    ClickSubmitButtonToLogin();
        //}

        public LoginPage TryToLoginAsUser()
        {
            var user = UserBuilder.UseRealUser();
            TryToLogin(user);

            return this;
        }

        public string GetCurrentUrl()
        {
            var currentUrl = driver.Url.ToString();
            return currentUrl;
        }

        //internal bool VerifyErrorMesage()
        //{
        //    return false;
        //}
    }
}
