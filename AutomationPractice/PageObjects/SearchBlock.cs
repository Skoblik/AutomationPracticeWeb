using System;
using System.Collections.Generic;
using AutomationPractice.Extensions;
using AutomationPractice.PageObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace AutomationPracticeInjection.PageObjects
{
    public class SearchBlock : PageBase
    {
        #region Constructor
        public SearchBlock(IWebDriver driver) : base(driver)
        {
        }
        #endregion

        public void Type(string value)
        {
			Driver.GetElement(_searchValue).SendKeys(value);
        }

        public void Search(string value)
        {
            Type(value);
			Driver.GetElement(_submitSearchButton).Click();
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

        public string NoResultsMessage => Driver.GetElementText(_noResultsMessageLocator);
        public IList<IWebElement> SearchResultItems => Driver.GetElements(_searchResultItems);

        private By _noResultsMessageLocator = By.XPath("//p[@class = 'alert alert-warning']");

		private By _searchValue = By.Id("search_query_top");

        private By _searchResultItems = By.XPath("//div[@class='ac_results']//li");

		private By _submitSearchButton = By.Name("submit_search");



		//[FindsBy(How = How.Id, Using = "search_query_top")]
		//      private IWebElement _searchValue;

		//[FindsBy(How = How.XPath, Using = "//div[@class='ac_results']//li")]
  //      public IList<IWebElement> SearchResultItems;

        //[FindsBy(How = How.Name, Using = "submit_search")]
        //private IWebElement _submitSearchButton;
    }
}
