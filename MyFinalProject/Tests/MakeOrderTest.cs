using BusinessObjects.PageObjects;
using BusinessObjects.Models;
using NUnit.Allure.Attributes;
using Allure.Net.Commons;

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
            new MainPage()
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

            new MainPage()
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
        }
    }
}