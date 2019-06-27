using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;

namespace AutomationPracticeInjection.PageObjects
{
    public class SearchBlock : PageBase
    {
        #region Constructor
        public SearchBlock(IWebDriver driver) : base(driver)
        {
            //PageFactory.InitElements(driver, this);
            //PageFactory.InitElements(this, new RetryingElementLocator(driver, TimeSpan.FromSeconds(10)));
        }
        #endregion

        public void Type(string value)
        {
            _searchValue.SendKeys(value);
        }

        public void Search(string value)
        {
            Type(value);
            _submitSearchButton.Click();
        }

        public IList<IWebElement> GetHints()
        {
            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            wait.Until(SearchResultFound);

            return SearchResultItems;
        }

        private bool SearchResultFound(IWebDriver driver)
        {
            return driver.FindElements(By.XPath("//div[@class='ac_results']//li")).Count > 0;
        }

        [FindsBy(How = How.Id, Using = "search_query_top")]
        private IWebElement _searchValue;

        [FindsBy(How = How.XPath, Using = "//div[@class='ac_results']//li")]
        public IList<IWebElement> SearchResultItems;

        [FindsBy(How = How.Name, Using = "submit_search")]
        private IWebElement _submitSearchButton;
    }
}
