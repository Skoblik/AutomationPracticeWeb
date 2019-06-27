using AutomationPractice.PageObjects;
using AutomationPractice.Utility;
using NUnit.Framework;

namespace AutomationPractice.Tests
{
    [TestFixture]
    public class LoginTests : TestBase
    {
        [Test]
        public void UserCanLoginWithValidCredentials()
        {
            App.LandingPage.Navigate();
            App.SignIn.SignIn(Settings.PositiveUser.Login, Settings.PositiveUser.Password);
            Assert.That(App.LandingPage.UserName, Is.EqualTo(Settings.PositiveUser.Name));
        }

        [Test]
        public void UserCannotLoginWithInvalidCredentials()
        {
	        App.LandingPage.Navigate();
	        App.SignIn.SignIn(Settings.NegativeUser.Login, Settings.NegativeUser.Password);
            Assert.That(App.LandingPage.ErrorMessage, Is.EqualTo(expected: "Authentication failed."));
        }

        [TearDown]
        public override void TearDown()
        {
			base.TearDown();

			if (!string.IsNullOrEmpty((App.LandingPage.UserName)))
            {
	            App.LandingPage.LogOut();
            }
        }

    }
}