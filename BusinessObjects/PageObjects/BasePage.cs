using Core.Selenium;
using OpenQA.Selenium;

namespace MyFinalProject.BusinessObjects.PageObjects
{
    public abstract class BasePage
    {
        protected IWebDriver driver;

        public BasePage()
        {
            driver = Browser.Instance.Driver;
        }

        public abstract BasePage OpenPage();

    }
}