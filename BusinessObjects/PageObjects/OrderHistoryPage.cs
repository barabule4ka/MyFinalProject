using Core.Selenium;
using NUnit.Allure.Attributes;
using NUnit.Framework;
using OpenQA.Selenium;

namespace BusinessObjects.PageObjects
{
    public class OrderHistoryPage : BasePage
    {
        public const string url = "http://prestashop.qatestlab.com.ua/ru/order-history";

        private By EmptyOrdersHistoryMessage = By.XPath("//*[@id='block-history']/p");
        private By OrdersHistoryTable = By.XPath("//*[@id='order-list']/tbody/tr");

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
            var emptyHistoryMessage = driver.FindElements(EmptyOrdersHistoryMessage).ToArray();

            if (emptyHistoryMessage.Length > 0)
            {
                logger.Info($"Message at empty orders history: {driver.FindElement(EmptyOrdersHistoryMessage).Text}");

                return true;
            }
            else
            {
                logger.Info($"Message at empty orders history not found, there may be some orders");

                return false;
            }
        }

        [AllureStep("Verify Orders History Exists")]
        public bool VerifyExistingOrdersHistoryTable()
        {
            List<IWebElement> orderHistoryTableRows = driver.FindElements(OrdersHistoryTable).ToList();

            if (orderHistoryTableRows.Count > 0)
            {
                logger.Info($"Order history table exists. There are {orderHistoryTableRows.Count} orders");

                return true;
            }
            else
            {
                logger.Info($"Order history table not exists");

                return false;
            }
        }
    }
}
