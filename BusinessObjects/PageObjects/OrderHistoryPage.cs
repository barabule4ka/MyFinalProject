using Core.Selenium;
using NUnit.Allure.Attributes;
using OpenQA.Selenium;

namespace BusinessObjects.PageObjects
{
    public class OrderHistoryPage : BasePage
    {
        public const string url = "http://prestashop.qatestlab.com.ua/ru/order-history";

        private By EmptyOrdersHistoryMessage = By.XPath("//*[@id='block-history']/p");
        private By OrdersHistoryTable = By.XPath("//*[@id='order-list']/tbody/tr[1]");

        public OrderHistoryPage() : base()
        {
        }

        public override OrderHistoryPage OpenPage()
        {
            Browser.Instance.NavigateToUrl(url);
            return this;
        }

        [AllureStep("Verify Empty Orders History Message")]
        public bool VerifyEmptyOrdersHistoryMessage()
        {
            driver.FindElement(EmptyOrdersHistoryMessage);

            logger.Info($"Message at empty orders history: {driver.FindElement(EmptyOrdersHistoryMessage).Text}");

            return true;
        }

        [AllureStep("Verify Empty Orders History Message")]
        public bool VerifyExistingOrdersHistoryTable()
        {
            driver.FindElement(OrdersHistoryTable);

            logger.Info($"Order history table exists");

            return true;
        }


    }
}
