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
            .ShowSmallCardWithButtons()
            .OpenQuickViewCard();           


            //basic level of test
    }
        [Test]
        public void MakeOrderFromCreatedUser()
        {
            var user = UserBuilder.CreateFakeUser();

            new MainPage()
            .OpenPage()
            .GoToLoginPage()
            .CreateNewAccount(user)
            .GoBackToMainPage()
            .ShowSmallCardWithButtons()
            .OpenQuickViewCard();


            //basic level of test
        }
    }
}