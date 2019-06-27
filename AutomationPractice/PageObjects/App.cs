using OpenQA.Selenium;

namespace AutomationPractice.PageObjects
{
	public class App
	{
		public App(IWebDriver driver)
		{
			_driver = driver;
		}
		public LandingPage LandingPage => _landingPage ?? (_landingPage = new LandingPage(_driver));
		public SignInBlock SignIn => _signIn ?? (_signIn = new SignInBlock(_driver));
		public ProductsBlock Products => _products ?? (_products = new ProductsBlock(_driver));

		private LandingPage _landingPage;
		private SignInBlock _signIn;
		private ProductsBlock _products;

		private IWebDriver _driver;
	}
}