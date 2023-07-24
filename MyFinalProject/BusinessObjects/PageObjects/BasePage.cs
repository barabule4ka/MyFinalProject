using OpenQA.Selenium;

namespace MyFinalProject.BusinessObjects.PageObjects
{
    public abstract class BasePage
    {
        protected WebDriver driver;

        public BasePage(WebDriver webDriver)
        {
            driver = webDriver;
        }

        public abstract BasePage OpenPage();
    }
}