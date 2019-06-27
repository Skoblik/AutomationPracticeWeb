using AutomationPractice.Utility;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationPractice.Utility
{
    public static class ByExtension
    {
        public static string GetElementText(this By locator)
        {
            return SeleniumSingleton.Instance.Driver
                .FindElements(locator)
                .FirstOrDefault()?.Text;
        }
    }
}