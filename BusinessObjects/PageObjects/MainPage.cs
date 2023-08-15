﻿using Core.Selenium;
using NLog;
using NUnit.Allure.Attributes;
using OpenQA.Selenium;
using BusinessObjects.PageObjects;
using NLog.Fluent;
using OpenQA.Selenium.DevTools.V112.Page;
using OpenQA.Selenium.Support.Extensions;
using System.Reflection.Metadata;

namespace BusinessObjects.PageObjects
{
    public class MainPage : BasePage
    {

        private By SigninMenuItem = By.CssSelector("a.login");
        private By DefaultLanguage = By.XPath("//*[@id='languages-block-top']/div");
        private By ChangeLanguageDropDown = By.XPath("//div[@id='languages-block-top']");
        private By SelectEnglish = By.XPath(".//a[@title='English (United States)']");
        private By QuickViewButton = By.ClassName("quick-view");
        private By AddToCartButton = By.XPath("//p[@id='add_to_cart']/button/span");
        private By MakeOrderButton = By.CssSelector("#layer_cart > div.clearfix > div.layer_cart_cart.col-xs-12.col-md-6 > div.button-container > a > span");


        public const string url = "http://prestashop.qatestlab.com.ua/ru/";

        public MainPage() : base()
        {
        }
        [AllureStep]
        public LoginPage GoToLoginPage()
        {
            driver.FindElement(SigninMenuItem).Click();
            return new LoginPage();
        }

        public MainPage SetNewLanguage()
        {
            string currentLanguage = driver.FindElement(DefaultLanguage).Text;

            if (currentLanguage.Contains("English"))
            {
                logger.Info("English has been already selected");
            }
            else
            {
                driver.FindElement(ChangeLanguageDropDown).Click();
                driver.FindElement(SelectEnglish).Click();
                logger.Info("English is selected like current language");
            }
            return this;
        }

        [AllureStep("Open quick view of first product")]
        public MainPage OpenQuickViewCardForFirstProduct()
        {
            driver.ExecuteJavaScript("document.getElementsByClassName('ajax_block_product')[0].className = document.getElementsByClassName('ajax_block_product')[0].className + ' hovered'");
            WaitHelper.WaitElement(driver, QuickViewButton);
            var quickViewButton = driver.FindElement(QuickViewButton);
            (quickViewButton).Click();

            logger.Info("quick view of first product opened");

            return this;
        }

        [AllureStep("Try to Add Product To Cart From Quick view")]
        public MainPage AddProductToCartFromSmallCard()
        {
            Thread.Sleep(5000);
            IWebElement iframe = driver.FindElement(By.ClassName("fancybox-iframe"));
            driver.SwitchTo().Frame(iframe);
            driver.FindElement(AddToCartButton).Click();
            driver.SwitchTo().DefaultContent();

            logger.Info("Try to add product to cart");

            return this;
        }

        [AllureStep("Show modal - product was successfully added to cart")]
        public CartPage ShowInfoModalWindowSuccessandClose()
        {
            Thread.Sleep(1000);
            driver.FindElement(MakeOrderButton).Click();

            logger.Info("product was successfully added to cart");

            return new CartPage();
        }

        [AllureStep("Open page")]
        public override MainPage OpenPage()
        {
            logger.Info($"Navigate to url {url}");

            Browser.Instance.NavigateToUrl(url);
            return this;
        }

        [AllureStep("Get url of current page")]
        public string GetCurrentUrl()
        {
            logger.Info($"Get Current page Url {driver.Url}");

            return driver.Url.ToString();
        }
    }
}