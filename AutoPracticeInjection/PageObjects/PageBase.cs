using System;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace AutomationPracticeInjection.PageObjects
{
    public abstract class PageBase
    {
        public PageBase(IWebDriver driver)
        {
            Driver = driver;
            PageFactory.InitElements(this, new RetryingElementLocator(driver, TimeSpan.FromSeconds(10)));
        }

        protected readonly IWebDriver Driver;
    }
}