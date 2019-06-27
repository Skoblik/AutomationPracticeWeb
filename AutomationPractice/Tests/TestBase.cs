using System;
using System.IO;
using AutomationPractice.PageObjects;
using AutomationPractice.Utility;
using AutomationPracticeInjection.PageObjects;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;

namespace AutomationPractice.Tests
{
    public abstract class TestBase
    {
        
        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            _selenium.CloseBrowser();
        }

        [TearDown]
        public virtual void TearDown()
        {
	        Console.WriteLine("Base");
            if (TestContext.CurrentContext.Result.Outcome.Equals(ResultState.Error) || 
                TestContext.CurrentContext.Result.Outcome.Equals(ResultState.Failure) || 
                TestContext.CurrentContext.Result.Outcome.Equals(ResultState.SetUpFailure) || 
                TestContext.CurrentContext.Result.Outcome.Equals(ResultState.SetUpError))
            {

                ((ITakesScreenshot)_selenium.Driver)?.GetScreenshot().SaveAsFile(ScreenShotFileName, ScreenshotImageFormat.Jpeg);
            }
        }

        private string ScreenShotFileName
        {
            get
            {
                var filename = TestContext.CurrentContext.Test.Name + "_" + DateTime.UtcNow.ToString("yyyy-MM-dd-HH-mm") + ".jpg";

                foreach (char c in Path.GetInvalidFileNameChars())
                {
                    filename = filename.Replace(c.ToString(), newValue: String.Empty);
                }

                string screenshotFolder = Settings.ScreenShotFolder;
	                //@"C:\Users\yandru\Desktop\Trainings\Automation\Solutions\Screenshots";

                var path = Path.Combine(screenshotFolder, filename);

                if (path.Length > 250)
                {
                    throw new Exception("File path is too long");
                }

                return Path.Combine(screenshotFolder, filename);
            }
        }

		//protected LandingPage LandingPage => _landingPage ?? (_landingPage = new LandingPage(_selenium.Driver));
		//protected SignInBlock SignIn => _signIn ?? (_signIn = new SignInBlock(_selenium.Driver));
		////protected CreateAccountBlock CreateAccount => _createAccount ?? (_createAccount = new CreateAccountBlock(_selenium.Driver));
		//protected ProductsBlock Products => _products ?? (_products = new ProductsBlock(_selenium.Driver));

		//private LandingPage _landingPage;
		//private SignInBlock _signIn;
		//private ProductsBlock _products;

		protected App App => _App ?? (_App = new App(_selenium.Driver));

		private App _App;
		private readonly Selenium _selenium = new Selenium();
    }
}