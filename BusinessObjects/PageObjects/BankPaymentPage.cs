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
    public class BankPaymentPage : BasePage
    {
        public const string url = "http://prestashop.qatestlab.com.ua/ru/module/bankwire/payment";

        private By SubmitOrderButton = By.XPath("//*[@id='cart_navigation']/button");

        public BankPaymentPage() : base()
        {
        }

        [AllureStep("Make order")]
        public OrderConfirmedPage MakeOrder()
        {
            driver.FindElement(SubmitOrderButton).Click();

            logger.Info($"Navigate to url {url}");

            return new OrderConfirmedPage();
        }

        [AllureStep("Open page")]
        public override BankPaymentPage OpenPage()
        {
            logger.Info($"Navigate to url {url}");

            Browser.Instance.NavigateToUrl(url);
            return this;
        }
    }
}
