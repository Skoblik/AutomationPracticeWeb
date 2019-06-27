using AutomationPractice.Utility;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationPractice.Utility
{
    public class ByUtility
    {
        public static string GetElementText(By locator)
        {
            return SeleniumSingleton.Instance.Driver
                .FindElements(locator)
                .FirstOrDefault()?.Text;
        }
    }
}