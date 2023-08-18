using Core.Selenium;
using NUnit.Allure.Attributes;
using OpenQA.Selenium;

namespace BusinessObjects.PageObjects
{
    public class OrderConfirmedPage : BasePage
    {
        public const string url = "http://prestashop.qatestlab.com.ua/ru/module/bankwire/payment";

        private By OrderConfirmedMessage = By.XPath("//*[@id='center_column']/div/p/strong");
        private By BackToOrdersLink = By.XPath("//*[@id='center_column']/p/a");

        public OrderConfirmedPage() : base()
        {
        }

        [AllureStep("Finish order")]
        public MainPage EndOrderAndGoBackToMainPage()
        {
            string text = driver.FindElement(OrderConfirmedMessage).Text;
            driver.FindElement(BackToOrdersLink).Click();

            logger.Info($"See message: {text}. Return to main page");

            return new MainPage();
        }

        [AllureStep("Open page")]
        public override OrderConfirmedPage OpenPage()
        {
            logger.Info($"Navigate to url {url}");

            Browser.Instance.NavigateToUrl(url);
            return this;
        }
    }
}

