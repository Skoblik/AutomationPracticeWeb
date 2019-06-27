using AutomationPractice.Extensions;
using AutomationPractice.PageObjects;
using OpenQA.Selenium;

namespace AutomationPractice.PageObjects
{
	public class SignInBlock : PageBase
	{
        #region Constructor
        public SignInBlock(IWebDriver driver) : base(driver)
        {
        }
        #endregion
        public void SignIn(string email, string password)
        {

			Driver.GetElement(_loginButton).Click();
			Driver.GetElement(_email).SendKeys(email);
			Driver.GetElement(_password).SendKeys(password);
			Driver.GetElement(_submitButton).Click();

			//Driver.FindElement(_loginButton).Click();
			//Driver.FindElement(_email).SendKeys(email);
			//Driver.FindElement(_password).SendKeys(password);
			//Driver.FindElement(_submitButton).Click();
		}

		private readonly By _loginButton = By.ClassName("login");
		private readonly By _email = By.Id("email");
		private readonly By _password = By.Id("passwd");
		private readonly By _submitButton = By.Id("SubmitLogin");
        
    }
}