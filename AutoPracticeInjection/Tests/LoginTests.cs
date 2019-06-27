using System;
using AutomationPracticeInjection.PageObjects;
using AutomationPracticeInjection.Utility;
using NUnit.Framework;

namespace AutomationPracticeInjection.Tests
{
    [TestFixture]
    public class LoginTests : TestBase
    {
        [Test]
        public void UserCanLoginWithValidCredentials()
        {
            LandingPage.Navigate();
            SignIn.SignIn(Settings.PositiveUser.Login, Settings.PositiveUser.Password);
			Assert.Fail("Error");
            //Assert.That(LandingPage.UserName, Is.EqualTo(Settings.PositiveUser.Name));
        }

        [Test]
        public void UserCannotLoginWithInvalidCredentials()
        {
            LandingPage.Navigate();
            SignIn.SignIn(Settings.NegativeUser.Login, Settings.NegativeUser.Password);
            Assert.That(LandingPage.ErrorMessage, Is.EqualTo(expected: "Authentication failed."));
        }

        [TearDown]
        public override void TearDown()
        {
	        Console.WriteLine("Before base");
			base.TearDown();
			Console.WriteLine("After base");

			if (!string.IsNullOrEmpty((LandingPage.UserName)))
            {
                LandingPage.LogOut();
            }
        }

    }
}