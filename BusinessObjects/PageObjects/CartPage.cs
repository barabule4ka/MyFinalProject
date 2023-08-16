using Core.Selenium;
using NUnit.Allure.Attributes;
using OpenQA.Selenium;
using BusinessObjects.Models;
using MyFinalProject.Models;
using Bogus.DataSets;
using System.Diagnostics.Metrics;

namespace BusinessObjects.PageObjects
{
    public class CartPage : BasePage
    {
        public const string url = "http://prestashop.qatestlab.com.ua/ru/order";

        private By ProductRowPresents = By.ClassName("cart_product");
        private By ProceedToCheckoutButtonFromFirstStep = By.XPath("//*[@id='center_column']/p[2]/a/span");
        private By CheckboxAddressesAreEquals = By.CssSelector("#uniform-addressesAreEquals > span");
        private By ProceedToCheckoutButtonFromAddressStep = By.XPath("//*[@id='center_column']/form/p/button");
        private By ShippingTypeTakeAwayRadioButton = By.XPath("//input[@class='delivery_option_radio'][@data-key='1,']");
        private By AgreeTermsOfServiceCheckbox = By.Id("cgv");
        private By ProceedToCheckoutToPayment = By.XPath("//*[@id='form']/p/button");
        private By PaymentTypeBank = By.ClassName("bankwire");
        private By CartIsEmptyMessage = By.CssSelector("p.alert.alert-warning");
        private By FirstNameInput = By.Id("firstname");
        private By LastNameInput = By.Id("lastname");
        private By AddressInput = By.Id("address1");
        private By ZipCodeInput = By.Id("postcode");
        private By CityInput = By.Id("city");
        private By CountryDropdown = By.CssSelector("#id_country > option:nth-child(2)");
        private By HomePhoneInput = By.Id("phone");
        private By StateDropdown = By.CssSelector("#id_state > option:nth-child(24)");
        private By AliasInput = By.Id("alias");
        private By SaveAddressButton = By.Id("submitAddress");

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

        [AllureStep("Empty cart")]
        public bool AssertEmptyCart()
        {
            driver.FindElement(CartIsEmptyMessage);
            string message = driver.FindElement(CartIsEmptyMessage).Text;

            logger.Info($"Empty cart message is: {message}");

            return true;
        }

        [AllureStep("Try to create account")]
        public CartPage CreateNewAddress(UserDeliveryAddressModel address)
        {
            logger.Info($"Create new address: "+
                $"FirstName: {address.FirstName}, " +
                $"LastName: {address.LastName}, " +
                $"Address: {address.Address}, " +
                $"PostalCode: {address.PostalCode}, " +
                $"City: {address.City}, " +
                $"Country: {driver.FindElement(CountryDropdown).Text}, " +
                $"HomePhone: {address.HomePhone}, " +
                $"State: {driver.FindElement(StateDropdown).Text}, " +
                $"Alias: {address.Alias}");

            driver.FindElement(FirstNameInput).SendKeys(address.FirstName);
            driver.FindElement(LastNameInput).SendKeys(address.LastName);
            driver.FindElement(AddressInput).SendKeys(address.Address);
            driver.FindElement(ZipCodeInput).SendKeys(address.PostalCode);
            driver.FindElement(CityInput).SendKeys(address.City);
            driver.FindElement(CountryDropdown).Click();
            driver.FindElement(HomePhoneInput).SendKeys(address.HomePhone);
            driver.FindElement(StateDropdown).Click();
            driver.FindElement(AliasInput).SendKeys(address.Alias);
            driver.FindElement(SaveAddressButton).Submit();

            return this;
        }

    }
}
