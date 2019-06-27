using NUnit.Framework;

namespace AutomationPracticeInjection.Tests
{
    public class CreateAccountTest : TestBase
    {
        [Test]
        public void CreateAccountWithAlreadyExistingCredentials()
        {
            string errorMessage = "An account using this email address has already been registered. Please enter a valid password or request a new one.";

            LandingPage.Navigate();
            CreateAccount.CreateAccount(email: "skullmail@ukr.net");
            Assert.That(LandingPage.ErrorMessageRegistrationForm, Is.EqualTo(errorMessage));
        }

        [Test]
        public void Empty()
        {
            
        }
    }
}