using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace AutomationPracticeInjection.Utility
{
    public class Selenium
    {
        public IWebDriver Driver
        {
            get
            {
                if (_driver == null)
                {
                    InitDriver();
                }
                return _driver;
            }
        }

        public void CloseBrowser()
        {
            if (_driver == null) return;
            _driver.Quit();
            _driver.Dispose();
            _driver = null;
        }

        private void InitDriver()
        {
            _driver = new ChromeDriver(AppDomain.CurrentDomain.BaseDirectory, GetChromeOptions());
            //_driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        private ChromeOptions GetChromeOptions()
        {
            var options = new ChromeOptions();
            options.AddArgument("--start-maximized");
            options.AddArgument("--disable-extensions");
            options.AddArgument("--disable-infobars");
            return options;
        }

        private IWebDriver _driver;
    }
}