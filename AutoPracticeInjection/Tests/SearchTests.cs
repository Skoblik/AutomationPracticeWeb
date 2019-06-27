using System;
using System.Linq;
using AutomationPracticeInjection.PageObjects;
using NUnit.Framework;

namespace AutomationPracticeInjection.Tests
{
    public class SearchTests : TestBase
    {
        [Test]
        public void SearchForSleeve()
        {
            LandingPage.Navigate();
            LandingPage.SearchBlock.Type("Sleeve");
            
            var hints = LandingPage.SearchBlock.SearchResultItems;
            //var hints = LandingPage.SearchBlock.GetHints();

            foreach (var hint in hints)
            {
                Console.WriteLine(hint.Text);
            }
        }

        [Test]
        public void SortBy()
        {
            LandingPage.Navigate();
            LandingPage.SearchBlock.Search("Sleeve");

            foreach (var option in Products.SortBy.Options)
            {
                Console.WriteLine(option.Text);
            }
            Products.SortBy.SelectByText("In stock");

            Products.SortBy.SelectByIndex(1);

            Products.SortBy.SelectByValue("name:desc");
        }

        [Test]
        public void ProductItems()
        {
            LandingPage.Navigate();
            LandingPage.SearchBlock.Search("Sleeve");
            foreach (var productItem in Products.Items)
            {
                Console.WriteLine($"Name: {productItem.Name} price: {productItem.Price}");
            }
        }

        [Test]
        public void OpenQuickView()
        {
            LandingPage.Navigate();
            LandingPage.SearchBlock.Search("Sleeve");
            //var productPrice = Products.Items.First().Price;
            Console.WriteLine(Products.Items.First().Price);

            var popup = Products.Items.First().OpenQuickView();
            var popupPrice = popup.Price;

            Console.WriteLine(popup.Price);

            Assert.Fail("Error!");

            popup.Close();

            var productPrice = Products.Items.First().Price;

            Assert.That(productPrice, Is.EqualTo(popupPrice), "Popup price is not equal to product price");

        }
    }
}