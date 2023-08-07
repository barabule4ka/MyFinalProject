using Core.Selenium;
using OpenQA.Selenium;
using NLog;

namespace BusinessObjects.PageObjects
{ 
    public abstract class BasePage
    {
        protected IWebDriver driver;
        protected static Logger logger = LogManager.GetCurrentClassLogger();

        public BasePage()
        {
            driver = Browser.Instance.Driver;
        }

        public abstract BasePage OpenPage();
    }
}
