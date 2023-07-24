using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFinalProject.BusinessObjects.PageObjects
{
    internal class MainPage : BasePage
    {

        private By SigninButton = By.CssSelector("a.login");

        public const string url = "http://prestashop.qatestlab.com.ua/ru/";

        public MainPage(WebDriver webDriver) : base(webDriver)
        {
        }

        public override BasePage OpenPage()
        {
            driver.Navigate().GoToUrl(url);
            return this;
        }


    }
}