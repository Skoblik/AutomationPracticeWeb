using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;

namespace AutomationPracticeInjection.PageObjects
{
    public class ProductsBlock : PageBase
    {
        public ProductsBlock(IWebDriver driver) : base(driver)
        {
        }

        [FindsBy(How = How.Id, Using = "selectProductSort")]
        private IWebElement _sortByElement;

        public SelectElement SortBy => new SelectElement(_sortByElement);

        [FindsBy(How = How.XPath, Using = "//ul[contains(@class, 'product_list')]/li")]
        private IList<IWebElement> _productItems;

        //public List<ProductItem> Items => _productItems.Select(i => new ProductItem(i)).ToList();

        public List<ProductItem> Items
        {
            get
            {
                List<ProductItem> list = new List<ProductItem>();
                foreach (var productItems in _productItems)
                {
                    ProductItem product = new ProductItem(productItems);
                    list.Add(product);
                }

                return list;
            }
        }
    }
}