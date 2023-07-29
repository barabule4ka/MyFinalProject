using Core.Selenium;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFinalProject.BusinessObjects.PageObjects
{
    internal class AccountPage : BasePage
    {
        public const string url = "http://prestashop.qatestlab.com.ua/ru/my-account";

        private By HomePageButton = By.CssSelector("#center_column > ul > li > a");

        public AccountPage() : base()
        {
        }

        public void GoBackToMainPage()
        {
            driver.FindElement(HomePageButton).Click();
        }

        public override AccountPage OpenPage()
        {
            Browser.Instance.NavigateToUrl(url);
            return this;
        }
    }
}
