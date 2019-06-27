using System.Linq;
using AutomationPracticeInjection.Utility;
using OpenQA.Selenium;

namespace AutomationPracticeInjection.PageObjects
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

        //Via Base Class
        //public string UserName => GetElementText(_userNameLocator);
        //public string UserName => GetElementText(_errorMessageLocator);

        //Via Utility Class
        //public string UserName => ByUtility.GetElementText(_userNameLocator);
        //public string ErrorMessage => ByUtility.GetElementText(_errorMessageLocator);

        //Via Extension Class
        public string UserName => GetElementText(_userNameLocator);
        public string ErrorMessage => GetElementText(_errorMessageLocator);
        public string ErrorMessageRegistrationForm => GetElementText(_errorMessageRegistration);

        public void LogOut()
        {
            Driver.FindElement(_logoutButtonLocator).Click();
        }

        public SearchBlock SearchBlock;

        //Locators

        private readonly By _userNameLocator = By.ClassName("account");
        private readonly By _errorMessageLocator = By.XPath("//div[@class = 'alert alert-danger']//li");
        private readonly By _logoutButtonLocator = By.ClassName("logout");
        private readonly By _errorMessageRegistration = By.XPath("//*[@id='create_account_error']//li");

        public string GetElementText(By locator)
        {
            return Driver
                .FindElements(locator)
                .FirstOrDefault()?.Text;
        }
    }
}