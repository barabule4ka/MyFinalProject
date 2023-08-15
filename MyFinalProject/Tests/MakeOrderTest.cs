using OpenQA.Selenium;
using MyFinalProject.Models;
using BusinessObjects.PageObjects;
using BusinessObjects.Models;

namespace MyFinalProject.Tests
{
    [TestFixture]
    internal class MakeOrderTest : BaseTest
    {

    [Test]
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
        //[Test]
        //public void MakeOrderFromCreatedUser()
        //{
        //    var user = UserBuilder.CreateFakeUser();

        //    new MainPage()
        //    .OpenPage()
        //    .GoToLoginPage()
        //    .CreateNewAccount(user)
        //    .GoBackToMainPage()
        //    .OpenQuickViewCardForFirstProduct();


        //    //basic level of test
        //}
    }
}