using System.Threading;
using AutomationPractice.Utility;
using OpenQA.Selenium;

namespace AutomationPractice.Page_Objects
{
    public class CreateAccountBlock
    {
        public void CreateAccount(string email)
        {
            SeleniumSingleton.Instance.Driver.FindElement(_loginButton).Click();
            SeleniumSingleton.Instance.Driver.FindElement(_email).SendKeys(email);
            SeleniumSingleton.Instance.Driver.FindElement(_createButton).Click();
            Thread.Sleep(millisecondsTimeout:1000);
        }

        private readonly By _loginButton = By.ClassName("login");
        private readonly By _email = By.Id("email_create");
        private readonly By _createButton = By.Id("SubmitCreate");
    }
}