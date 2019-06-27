using AutomationPractice.Utility;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationPractice.Page_Objects
{
    public class LandingPage : PageBase
    {
        public void Navigate()
        {
            SeleniumSingleton.Instance.Driver.Navigate().GoToUrl("http://automationpractice.com/index.php");
        }

        //Via Base Class
        //public string UserName => GetElementText(_userNameLocator);
        //public string UserName => GetElementText(_errorMessageLocator);

        //Via Utility Class
        //public string UserName => ByUtility.GetElementText(_userNameLocator);
        //public string ErrorMessage => ByUtility.GetElementText(_errorMessageLocator);

        //Via Extension Class
        public string UserName => _userNameLocator.GetElementText();
        public string ErrorMessage => _errorMessageLocator.GetElementText();
        public string ErrorMessageRegistrationForm => _errorMessageRegistration.GetElementText();

        public void LogOut()
        {
            SeleniumSingleton.Instance.Driver.FindElement(_logoutButtonLocator).Click();
        }

        //Locators

        private readonly By _userNameLocator = By.ClassName("account");
        private readonly By _errorMessageLocator = By.XPath("//div[@class = 'alert alert-danger']//li");
        private readonly By _logoutButtonLocator = By.ClassName("logout");
        private readonly By _errorMessageRegistration = By.XPath("//*[@id='create_account_error']//li");
    }
}
