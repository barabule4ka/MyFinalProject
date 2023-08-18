using BusinessObjects.PageObjects;
using BusinessObjects.Models;
using NUnit.Allure.Attributes;
using Allure.Net.Commons;
using Core.Selenium;
using OpenQA.Selenium;

namespace MyFinalProject.Tests
{
    [TestFixture]
    internal class MakeOrderTest : BaseTest
    {

        [Test(Description = "Login and make order")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureTag("First priority cases")]
        [Description("Real test-user account")]
        [AllureOwner("Barabule4ka")]
        [AllureSuite("Prestashop")]
        [AllureSubSuite("Make order tests")]
        [AllureTms("TFS_MTS")]
        [AllureIssue("issue-12458")]
        [Category("Order")]
        public void LoginAndMakeOrder()
    {
            string expectedNumberOfProductsInCart = "(пусто)";

            var page = new MainPage()
            .OpenPage()
            .GoToLoginPage()
            .LoginAsRealUser()
            .GoBackToMainPage()
            .OpenQuickViewCardForFirstProduct()
            .AddProductToCartFromSmallCard()
            .ShowInfoModalWindowSuccessandClose()
            .FindProductInCartAndGoToCheckout()
            .CheckAddressPresentsAndGoToShipping()
            .SelectShippingType()
            .AgreeTermsOfServiceAndGoToPayment()
            .ChooseBankAsPaymentType()
            .MakeOrder()
            .EndOrderAndGoBackToMainPage();

            Assert.That(page.GetEmptyCartNotification, Is.EqualTo(expectedNumberOfProductsInCart));
        }

        [Test(Description = "Create user and make order")]
        [AllureSeverity(SeverityLevel.critical)]
        [AllureTag("First priority cases")]
        [Description("New test-user account")]
        [AllureOwner("Barabule4ka")]
        [AllureSuite("Prestashop")]
        [AllureSubSuite("Make order tests")]
        [AllureTms("TFS_MTS")]
        [AllureIssue("issue-124580")]
        [Category("Order")]
        public void MakeOrderFromCreatedUser()
        {
            var user = UserBuilder.CreateFakeUser();
            var address = UserBuilder.CreateDeliveryAddress();
            var expectedUrl = "http://prestashop.qatestlab.com.ua/ru/";

            var page = new MainPage()
            .OpenPage()
            .GoToLoginPage()
            .CreateNewAccount(user)
            .GoBackToMainPage()
            .OpenQuickViewCardForFirstProduct()
            .AddProductToCartFromSmallCard()
            .ShowInfoModalWindowSuccessandClose()
            .FindProductInCartAndGoToCheckout()
            .CreateNewAddress(address)
            .CheckAddressPresentsAndGoToShipping()
            .SelectShippingType()
            .AgreeTermsOfServiceAndGoToPayment()
            .ChooseBankAsPaymentType()
            .MakeOrder()
            .EndOrderAndGoBackToMainPage();

            var url = page.GetCurrentUrl();

            Assert.That(url, Is.EqualTo(expectedUrl));
        }
    }
}