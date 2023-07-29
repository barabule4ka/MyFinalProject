using MyFinalProject.BusinessObjects.PageObjects;
using OpenQA.Selenium;
using MyFinalProject.Models;


namespace MyFinalProject.Tests
{
    internal class MakeOrderTest : BaseTest
    {

    [Test]
    public void MakeOrder()
    {
            var main = new MainPage();
            main.OpenPage();
            main.GoToLogin();

            var login = new LoginPage();
            login.TryToLoginAsUser();
        
            var account = new AccountPage();
            account.GoBackToMainPage();

            main.ShowSmallCardWithButtons();
            main.OpenQuickViewCard();

            //basic level of test
    }
}
}