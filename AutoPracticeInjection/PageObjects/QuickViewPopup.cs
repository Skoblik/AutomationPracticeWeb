using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace AutomationPracticeInjection.PageObjects
{
    public class QuickViewPopup : PageBase
    {
        public QuickViewPopup(IWebDriver driver) : base(driver)
        {
        }

        public void Wait()
        {
            Driver.SwitchTo().Frame(_frame);
        }

        public void Close()
        {
            Driver.SwitchTo().DefaultContent();
            _close.Click();
        }

        public string Price => _price.Text;

        [FindsBy(How = How.Id, Using = "our_price_display")]
        private IWebElement _price;

        [FindsBy(How = How.XPath, Using = "//*[contains(@id, 'fancybox-frame')]")]
        private IWebElement _frame;

        [FindsBy(How = How.XPath, Using = "//*[contains(@class, 'fancybox-close')]")]
        private IWebElement _close;
    }
}