using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using AutomationPractice.Utility;
using OpenQA.Selenium;

namespace AutomationPractice.PageObjects
{
    public abstract class PageBase
    {
	    public PageBase(IWebDriver driver)
	    {
		    Driver = driver;
	    }

		protected readonly IWebDriver Driver;
	}
}