using AutomationPractice.Utility;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationPractice.Page_Objects
{
    public class SignInBlock
    {
        public void SignIn(string email, string password)
        {
            SeleniumSingleton.Instance.Driver.FindElement(_loginButton).Click();
            SeleniumSingleton.Instance.Driver.FindElement(_email).SendKeys(email);
            SeleniumSingleton.Instance.Driver.FindElement(_password).SendKeys(password);
            SeleniumSingleton.Instance.Driver.FindElement(_submitButton).Click();
        }

        private readonly By _loginButton = By.ClassName("login");
        private readonly By _email = By.Id("email");
        private readonly By _password = By.Id("passwd");
        private readonly By _submitButton = By.Id("SubmitLogin");
    }
    
}
