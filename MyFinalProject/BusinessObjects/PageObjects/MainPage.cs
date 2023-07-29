﻿using Core.Selenium;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace MyFinalProject.BusinessObjects.PageObjects
{
    internal class MainPage : BasePage
    {

        private By SigninMenuItem = By.CssSelector("a.login");
        private By DefaultLanguage = By.CssSelector("//div[@class='current'");
        private By ChangeLanguageDropDown = By.XPath("//div[@id='languages-block-top']");
        private By ProductCardWithNavigateButtons = By.XPath("//li[@class='ajax_block_product col-xs-12 col-sm-4 col-md-3 first-in-line first-item-of-tablet-line first-item-of-mobile-line']");
        private By QuickViewButton = By.XPath("//*[@class='product-container']//a[@class='quick-view']");

        public const string url = "http://prestashop.qatestlab.com.ua/ru/";
        public MainPage() : base()
        {
        }
        public void GoToLogin()
        {
            driver.FindElement(SigninMenuItem).Click();
        }

        public void DefineDefaultLanguage(string text)
        {
            var language = driver.FindElement(DefaultLanguage).Text;
        }

        public void SetNewLanguage()
        {
            driver.FindElement(ChangeLanguageDropDown).Click();
        }

        public void GoToChangeLanguage()
        {
            driver.FindElement(ChangeLanguageDropDown).Click();
        }

        public MainPage ShowSmallCardWithButtons()
        {
            Actions action = new Actions(driver);
            var productCardWithNavigateButtons = driver.FindElement(ProductCardWithNavigateButtons);
            action.MoveToElement(productCardWithNavigateButtons).Perform();
            return this;
        }

        public MainPage OpenQuickViewCard()
        {
            var quickViewButton = driver.FindElement(QuickViewButton);
            (quickViewButton).Click();
            return this;
        }

        public MainPage AddProductToCartFromSmallCard()
        {
            var quickViewButton = driver.FindElement(QuickViewButton);
            (quickViewButton).Click();
            return this;
        }

        public override BasePage OpenPage()
        {
            Browser.Instance.NavigateToUrl(url);
            return this;
        }
    }
}