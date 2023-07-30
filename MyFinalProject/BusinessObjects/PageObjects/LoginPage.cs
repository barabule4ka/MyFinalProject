using Core.Selenium;
using MyFinalProject.Models;
using OpenQA.Selenium;
using NUnit.Allure.Attributes;
using NLog;

namespace MyFinalProject.BusinessObjects.PageObjects
{
    internal class LoginPage : BasePage
    {
        private By UserEmailInput = By.Id("email");
        private By PasswordInput = By.Id("passwd");
        private By LoginButton = By.Id("SubmitLogin");
        private By ErrorMessage = By.XPath("/html/body/div/div[2]/div/div[2]/div/div[1]/ol/li");

        public const string url = "http://prestashop.qatestlab.com.ua/ru/authentication?back=my-account";
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public LoginPage() : base()
        {

        }

        [AllureStep("Open login page")]
        public override LoginPage OpenPage()
        {
            logger.Info($"Navigate to url {url}");

            Browser.Instance.NavigateToUrl(url);
            return this;
        }

        [AllureStep("Press sign in button")]
        public void ClickSubmitButtonToLogin()
        {
            driver.FindElement(LoginButton).Submit();
        }

        [AllureStep("error message exists")]
        public bool VerifyErrorMesage()
        {
            driver.FindElement(ErrorMessage);
            return false;
        }

        [AllureStep("Find error message text")]
        public string FindErrorMessage(string message)
        {
            string errorText = driver.FindElement(ErrorMessage).Text;

            switch (VerifyErrorMesage())
            {
                case true:
                    {
                        ClickSubmitButtonToLogin();
                        return errorText;

                    }
                case false:
                    {
                        return errorText;
                    }
            }
        }

        [AllureStep("Try to login")]
        public void TryToLogin(UserAuthModel user)
        {
            logger.Info($"Login as user {user}");

            driver.FindElement(UserEmailInput).SendKeys(user.Email);
            driver.FindElement(PasswordInput).SendKeys(user.Password);
            driver.FindElement(LoginButton).Click();
        }

        public LoginPage TryToLoginAsUser()
        {
            var user = UserBuilder.UseRealUser();
            TryToLogin(user);

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
