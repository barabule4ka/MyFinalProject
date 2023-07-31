using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using Core.Configuration;
using OpenQA.Selenium.Firefox;

namespace Core.Selenium
{
    public class DriverFactory
    {
        public static IWebDriver GetChromeDriver()
        {
            ChromeOptions options = new ChromeOptions();

            if (AppConfig.Browser.Headless) options.AddArgument("--headless");
            options.AddArgument("--disable-gpu");
            options.AddArgument("incognito");
            options.AddArgument("--start-maximized");

            return new ChromeDriver(options);
        }

        public static IWebDriver GetFirefoxDriver()
        {
            FirefoxOptions options = new FirefoxOptions();
            options.AddArgument("--headless");

            return new FirefoxDriver(options);
        }
    }
}
