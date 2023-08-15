using Core.Selenium;
using NLog;
using NUnit.Allure.Attributes;
using OpenQA.Selenium;

namespace BusinessObjects.PageObjects
{
    public class CartPage : BasePage
    {
        public const string url = "http://prestashop.qatestlab.com.ua/ru/order";

        private By ProductRowPresents = By.Id("product_1_1_0_8283");
        private By ProceedToCheckoutButtonFromFirstStep = By.XPath("//*[@id='center_column']/p[2]/a/span");
        private By CheckboxAddressesAreEquals = By.CssSelector("#uniform-addressesAreEquals > span");
        private By ProceedToCheckoutButtonFromAddressStep = By.XPath("//*[@id='center_column']/form/p/button");
        private By ShippingTypeTakeAwayRadioButton = By.Id("delivery_option_8283_0");
        private By AgreeTermsOfServiceCheckbox = By.Id("cgv");
        private By ProceedToCheckoutToPayment = By.XPath("//*[@id='form']/p/button");
        private By PaymentTypeBank = By.ClassName("bankwire");


        public CartPage() : base()
        {
        }

        [AllureStep("Cart not empty")]
        public CartPage FindProductInCartAndGoToCheckout()
        {
            driver.FindElement(ProductRowPresents);
            driver.FindElement(ProceedToCheckoutButtonFromFirstStep).Click();

            logger.Info($"Product was found in cart, go to address");
            
            return this;
        }

        [AllureStep("Check address")]
        public CartPage CheckAddressPresentsAndGoToShipping()
        {
            driver.FindElement(CheckboxAddressesAreEquals);
            driver.FindElement(ProceedToCheckoutButtonFromAddressStep).Click();

            logger.Info($"Address has been already set, go to shipping");

            return this;
        }

        [AllureStep("Select shipping type")]
        public CartPage SelectShippingType()
        {
            driver.FindElement(ShippingTypeTakeAwayRadioButton).Click();

            logger.Info($"Shipping type selected");

            return this;
        }

        [AllureStep("Agree Terms Of Service")]
        public CartPage AgreeTermsOfServiceAndGoToPayment()
        {
            driver.FindElement(AgreeTermsOfServiceCheckbox).Click();
            driver.FindElement(ProceedToCheckoutToPayment).Click();

            logger.Info($"Checkbox TermsOfService is checked, go to payment");

            return this;
        }

        [AllureStep("Select bankwire")]
        public BankPaymentPage ChooseBankAsPaymentType()
        {
            driver.FindElement(PaymentTypeBank).Click();

            logger.Info($"bankwire is selected");

            return new BankPaymentPage();
        }

        [AllureStep("Open page")]
        public override CartPage OpenPage()
        {
            logger.Info($"Navigate to url {url}");

            Browser.Instance.NavigateToUrl(url);
            return this;
        }



    }
}
