using System.Linq;
using AutomationPractice.Extensions;
using AutomationPractice.Utility;
using AutomationPracticeInjection.PageObjects;
using OpenQA.Selenium;

namespace AutomationPractice.PageObjects
{
    public class LandingPage : PageBase
    {
        #region Constructor
        public LandingPage(IWebDriver driver) : base(driver)
        {
            SearchBlock = new SearchBlock(driver);
        }
        #endregion 
        public void Navigate()
        {
            Driver.Navigate().GoToUrl(Settings.Url);
        }
        
        public string UserName => Driver.GetElementText(_userNameLocator);
        public string ErrorMessage => Driver.GetElementText(_errorMessageLocator);
        public string ErrorMessageRegistrationForm => Driver.GetElementText(_errorMessageRegistration);

        public void LogOut()
        {
	        Driver.GetElement(_logoutButtonLocator).Click();
            //Driver.FindElement(_logoutButtonLocator).Click();
        }

        public SearchBlock SearchBlock;

        //Locators

        private readonly By _userNameLocator = By.ClassName("account");
        private readonly By _errorMessageLocator = By.XPath("//div[@class = 'alert alert-danger']//li");
        private readonly By _logoutButtonLocator = By.ClassName("logout");
        private readonly By _errorMessageRegistration = By.XPath("//*[@id='create_account_error']//li");
    }
}