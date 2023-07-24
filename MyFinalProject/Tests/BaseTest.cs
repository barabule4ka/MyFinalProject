using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace MyFinalProject.Tests
{
    public class BaseTest
    {
        protected WebDriver driver;

        [SetUp]

        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Navigate().GoToUrl("http://prestashop.qatestlab.com.ua/ru/");
        }

        //[TearDown]
        //public void TearDown()
        //{
        //    driver.Quit();
        //}
    }
}
