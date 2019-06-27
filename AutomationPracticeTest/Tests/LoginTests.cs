using AutomationPractice.Page_Objects;
using AutomationPractice.Utility;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationPractice.Tests
{
    [TestFixture]
    public class LoginTests
    {
        [Test]
        public void UserCanLoginWithValidCredentials()
        {
            _landingPage.Navigate();
            _signIn.SignIn("skullmail@ukr.net", "12345");
            Assert.That(_landingPage.UserName, Is.EqualTo(expected: "A Che"));
        }

        [Test]
        public void UserCannotLoginWithInvalidCredentials()
        {
            _landingPage.Navigate();
            _signIn.SignIn("negative@ukr.net", "12345");
            Assert.That(_landingPage.ErrorMessage, Is.EqualTo(expected: "Authentication failed."));
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



        //public LoginTests()
        //{
        //    _landingPage = new LandingPage();
        //    _signIn = new SignInBlock();
        //}

        private readonly LandingPage _landingPage = new LandingPage();
        private readonly SignInBlock _signIn = new SignInBlock();
    }
}
