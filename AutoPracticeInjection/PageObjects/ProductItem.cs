using System;
using System.Net.Http.Headers;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Internal;
using SeleniumExtras.PageObjects;

namespace AutomationPracticeInjection.PageObjects
{
    public class ProductItem
    {
        public ProductItem(IWebElement parent)
        {
            _parent = parent;
        }

        public string Name => _parent.FindElement(_namelocator).Text;

        public string Price
        {
            get
            {
                string leftPrice = _parent.FindElement(_leftPriceLocator).Text;
                string rightPrice = _parent.FindElement(_rightPriceLocator).Text;

                return !string.IsNullOrEmpty(leftPrice) ? leftPrice : rightPrice;
            }
        }

        public QuickViewPopup OpenQuickView()
        {
            var driver = ((IWrapsDriver) _parent).WrappedDriver;

            Actions action = new Actions(driver);
            action.MoveToElement(_parent).Perform();
            _parent.FindElement(_quickViewLocator).Click();

            var popup = new QuickViewPopup(driver);
            popup.Wait();

            return new QuickViewPopup(driver);
        }

        private readonly By _namelocator = By.XPath(".//a[@class='product-name']");
        private readonly By _leftPriceLocator = By.XPath(".//div[@class='left-block']//span[@itemprop='price']");
        private readonly By _rightPriceLocator = By.XPath(".//div[@class='right-block']//span[@itemprop='price']");
        private readonly By _quickViewLocator = By.XPath(".//a[@class='quick-view']");

        private readonly IWebElement _parent;
    }
}