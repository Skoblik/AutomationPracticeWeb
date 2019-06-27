using AutomationPractice.Page_Objects;
using AutomationPractice.Utility;
using NUnit.Framework;

namespace AutomationPractice.Tests
{
    public class CreateAccountTests
    {
        [Test]
        public void CreateAccountWithAlreadyExistingCredentials()
        {
            string errorMessage = "An account using this email address has already been registered. Please enter a valid password or request a new one.";

            _landingPage.Navigate();
            _createAccount.CreateAccount(email:"skullmail@ukr.net");
            Assert.That(_landingPage.ErrorMessageRegistrationForm, Is.EqualTo(errorMessage));
        }

        [TearDown]
        public void TearDown()
        {
            if (!string.IsNullOrEmpty(_landingPage.UserName))
            {
                _landingPage.LogOut();
            }

        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            SeleniumSingleton.Instance.CloseBrowser();
        }

        private readonly LandingPage _landingPage = new LandingPage();
        private readonly SignInBlock _signIn = new SignInBlock();
        private readonly CreateAccountBlock _createAccount = new CreateAccountBlock();
    }
}