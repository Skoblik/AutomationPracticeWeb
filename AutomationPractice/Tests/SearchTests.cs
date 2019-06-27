using System;
using System.Linq;
using AutomationPractice.PageObjects;
using NUnit.Framework;

namespace AutomationPractice.Tests
{
	public class SearchTests : TestBase
	{
		[Test]
		public void NoResultsMessage()
		{
			App.LandingPage.Navigate();
			App.LandingPage.SearchBlock.Search("Not Existing Item Search");
			Assert.AreEqual("No results were found for your search \"Not Existing Item Search\"", App.LandingPage.SearchBlock.NoResultsMessage, "NoResults message is wrong");
		}

		[Test]
		public void SearchForSleeve()
		{
			App.LandingPage.Navigate();
			App.LandingPage.SearchBlock.Type("Sleeve");
			var hints = App.LandingPage.SearchBlock.SearchResultItems;
			//var hints = LandingPage.SearchBlock.GetHints();

			foreach (var hint in hints)
			{
				Console.WriteLine(hint.Text);
			}
		}

		[Test]
		public void OpenQuickView()
		{
			App.LandingPage.Navigate();
			App.LandingPage.SearchBlock.Search("Sleeve");
			//var productPrice = Products.Items.First().Price;
			Console.WriteLine(App.Products.Items.First().Price);

			var popup = App.Products.Items.First().OpenQuickView();
			var popupPrice = popup.Price;

			Console.WriteLine(popup.Price);

			popup.Close();

			var productPrice = App.Products.Items[0].Price;

			Assert.That(productPrice, Is.EqualTo(popupPrice), "Popup price is not equal to product price");

		}
	}
}