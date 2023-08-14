using Core.Selenium;
using BusinessObjects.Models;
using OpenQA.Selenium;
using NUnit.Allure.Attributes;

namespace BusinessObjects.PageObjects
{
    public class LoginPage : BasePage
    {
        private By UserEmailInput = By.Id("email");
        private By PasswordInput = By.Id("passwd");
        private By LoginButton = By.Id("SubmitLogin");
        private By ErrorMessage = By.XPath("//*[@class='alert alert-danger'][.//li[contains(text(),' ')]]");
        private By UserCreateEmail = By.Id("email_create");
        private By CreateAccountButton = By.Id("SubmitCreate");
        private By FirstNameInput = By.Id("customer_firstname");
        private By LastNameInput = By.Id("customer_lastname");
        private By RegisterButton = By.Id("submitAccount");

        public const string url = "http://prestashop.qatestlab.com.ua/ru/authentication?back=my-account";
        
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
        public string FindErrorMessage()
        {
            string errorText = driver.FindElement(ErrorMessage).Text;
            logger.Info($"Error message found: {errorText}");

            return errorText;
        }

        [AllureStep("Try to create account")]
        public AccountPage CreateNewAccount(UserModel user)
        {
            logger.Info($"Create new account for user: \nEmail: {user.Email}, \nPassword:{user.Password}, \nFirstName: {user.FirstName}, \nLastName:{user.LastName}");

            driver.FindElement(UserCreateEmail).SendKeys(user.Email);
            driver.FindElement(CreateAccountButton).Submit();
            driver.FindElement(FirstNameInput).SendKeys(user.FirstName);
            driver.FindElement(LastNameInput).SendKeys(user.LastName);
            driver.FindElement(PasswordInput).SendKeys(user.Password);
            driver.FindElement(RegisterButton).Submit();

            return new AccountPage();   
        }

        [AllureStep("Try to login")]
        public void TryToLogin(UserModel user)
        {
            logger.Info($"Login as user {user}");

            driver.FindElement(UserEmailInput).SendKeys(user.Email);
            driver.FindElement(PasswordInput).SendKeys(user.Password);
            driver.FindElement(LoginButton).Click();
        }

        public AccountPage LoginAsRealUser()
        {
            var user = UserBuilder.UseRealUser();
            TryToLogin(user);

            return new AccountPage();
        }

        [AllureStep("Get url of current page")]
        public string GetCurrentUrl()
        {
            logger.Info($"Get Current page Url {driver.Url}");

            return driver.Url.ToString();
        }               
    }
}
