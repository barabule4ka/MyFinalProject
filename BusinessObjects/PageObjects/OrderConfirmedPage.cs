using Core.Selenium;
using NUnit.Allure.Attributes;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        [AllureStep("Make order")]
        public MainPage EndOrderAndGoBackToMainPage()
        {
            string text = driver.FindElement(OrderConfirmedMessage).Text;
            driver.FindElement(BackToOrdersLink).Click();

            logger.Info($"Navigate to url {url}");

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

