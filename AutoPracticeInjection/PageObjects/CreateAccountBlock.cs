using System.Threading;
using AutomationPracticeInjection.Utility;
using OpenQA.Selenium;

namespace AutomationPracticeInjection.PageObjects
{
    public class CreateAccountBlock : PageBase
    {
        #region Constructor
        public CreateAccountBlock(IWebDriver driver) : base(driver)
        {
        }
        #endregion
        public void CreateAccount(string email)
        {
            Driver.FindElement(_loginButton).Click();
            Driver.FindElement(_email).SendKeys(email);
            Driver.FindElement(_createButton).Click();
            Thread.Sleep(millisecondsTimeout: 1000);
        }

        private readonly By _loginButton = By.ClassName("login");
        private readonly By _email = By.Id("email_create");
        private readonly By _createButton = By.Id("SubmitCreate");
    }
}