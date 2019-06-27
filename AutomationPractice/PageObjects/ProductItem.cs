using AutomationPractice.Extensions;
using AutomationPracticeInjection.PageObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Internal;

namespace AutomationPractice.PageObjects
{
    public class ProductItem
    {
        public ProductItem(IWebElement parent)
        {
            _parent = parent;
        }

        public string Name => _parent.GetElement(_namelocator).Text;

        public string Price
        {
            get
            {
				string leftPrice = _parent.GetElement(_leftPriceLocator).Text;
				string rightPrice = _parent.GetElement(_rightPriceLocator).Text;

                return !string.IsNullOrEmpty(leftPrice) ? leftPrice : rightPrice;
            }
        }

        public QuickViewPopup OpenQuickView()
        {
            var driver = ((IWrapsDriver) _parent).WrappedDriver;

            Actions action = new Actions(driver);
            action.MoveToElement(_parent).Perform();
            _parent.GetElement(_quickViewLocator).Click();

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