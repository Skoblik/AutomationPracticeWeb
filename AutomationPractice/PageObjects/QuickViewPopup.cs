using AutomationPractice.Extensions;
using AutomationPractice.PageObjects;
using OpenQA.Selenium;

namespace AutomationPracticeInjection.PageObjects
{
    public class QuickViewPopup : PageBase
    {
        public QuickViewPopup(IWebDriver driver) : base(driver)
        {
        }

        public void Wait()
        {
	        var frame = Driver.GetElement(_frame);
            Driver.SwitchTo().Frame(frame);
        }

        public void Close()
        {
            Driver.SwitchTo().DefaultContent();
			Driver.GetElement(_close).Click();
        }

        public string Price => Driver.GetElementText(_price);

        private By _price = By.Id("our_price_display");

        private By _frame = By.XPath("//*[contains(@id, 'fancybox-frame')]");

		private By _close = By.XPath("//*[contains(@class, 'fancybox-close')]");


		//[FindsBy(How = How.Id, Using = "our_price_display")]
  //      private IWebElement _price;

  //      [FindsBy(How = How.XPath, Using = "//*[contains(@id, 'fancybox-frame')]")]
  //      private IWebElement _frame;

  //      [FindsBy(How = How.XPath, Using = "//*[contains(@class, 'fancybox-close')]")]
  //      private IWebElement _close;
    }
}