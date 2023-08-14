using Core.Selenium;
using NLog;
using NUnit.Allure.Attributes;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using MyFinalProject.BusinessObjects.PageObjects;
using NLog.Fluent;

namespace BusinessObjects.PageObjects
{
    public class MainPage : BasePage
    {

        private By SigninMenuItem = By.CssSelector("a.login");
        private By DefaultLanguage = By.XPath("//*[@id='languages-block-top']/div");
        private By ChangeLanguageDropDown = By.XPath("//div[@id='languages-block-top']");
        private By SelectEnglish = By.XPath(".//a[@title='English (United States)']");
        private By ProductCardWithNavigateButtons = By.XPath("//li[@class='ajax_block_product col-xs-12 col-sm-4 col-md-3 first-in-line first-item-of-tablet-line first-item-of-mobile-line']");
        private By QuickViewButton = By.XPath("//*[@class='product-container']//a[@class='quick-view']");

        public const string url = "http://prestashop.qatestlab.com.ua/ru/";

        public MainPage() : base()
        {
        }
        [AllureStep]
        public LoginPage GoToLoginPage()
        {
            driver.FindElement(SigninMenuItem).Click();
            return new LoginPage();
        }

        public MainPage SetNewLanguage()
        {
            string currentLanguage = driver.FindElement(DefaultLanguage).Text;

            if (currentLanguage.Contains("English"))
            {
                logger.Info("English has been already selected");
            }
            else
            {
                driver.FindElement(ChangeLanguageDropDown).Click();
                driver.FindElement(SelectEnglish).Click();
                logger.Info("English is selected like current language");
            }
            return this;
        }

        public MainPage ShowSmallCardWithButtons()
        {
            Actions action = new Actions(driver);
            var productCardWithNavigateButtons = driver.FindElement(ProductCardWithNavigateButtons);
            action.MoveToElement(productCardWithNavigateButtons).Perform();
            return this;
        }

        public MainPage OpenQuickViewCard()
        {
            var quickViewButton = driver.FindElement(QuickViewButton);
            (quickViewButton).Click();
            return this;
        }

        public MainPage AddProductToCartFromSmallCard()
        {
            var quickViewButton = driver.FindElement(QuickViewButton);
            (quickViewButton).Click();
            return this;
        }

        [AllureStep("Open page")]
        public override MainPage OpenPage()
        {
            logger.Info($"Navigate to url {url}");

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