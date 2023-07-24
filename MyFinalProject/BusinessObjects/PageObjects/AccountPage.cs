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

        public AccountPage(WebDriver webDriver) : base(webDriver)
        {
        }

        public override AccountPage OpenPage()
        {
            driver.Navigate().GoToUrl(url);
            return this;
        }
    }
}
