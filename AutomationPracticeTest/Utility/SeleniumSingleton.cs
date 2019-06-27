using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationPractice.Utility
{
    public sealed class SeleniumSingleton
    {
        private static readonly Lazy<SeleniumSingleton> Lazy = new Lazy<SeleniumSingleton>(valueFactory: () => new SeleniumSingleton());
        public static SeleniumSingleton Instance => Lazy.Value;
        private SeleniumSingleton()
        {
        }

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
