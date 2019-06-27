using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using AutomationPractice.Utility;
using OpenQA.Selenium;

namespace AutomationPractice.Extensions
{
	public static class WebDriverExtension
	{
		public static IWebElement GetElement(this ISearchContext driver, By locator)
		{
			Stopwatch stopwatch = Stopwatch.StartNew();
			IWebElement element = null;

			while (element == null)
			{
				element = driver.FindElements(locator).FirstOrDefault();
				if (stopwatch.Elapsed > Settings.ElementAppearedTimeout && element == null)
				{
					throw new NoSuchElementException($"Locator {locator}");
				}
				Thread.Sleep(EvaluatedInterval);
			}
			return element;
		}

		public static IList<IWebElement> GetElements(this ISearchContext driver, By locator)
		{
			Stopwatch stopwatch = Stopwatch.StartNew();
			IList<IWebElement> elements = null;

			while (elements == null || elements.Count == 0)
			{
				elements = driver.FindElements(locator);
				if (stopwatch.Elapsed > Settings.ElementAppearedTimeout && elements.Count == 0)
				{
					throw new NoSuchElementException($"Locator {locator}");
				}
				Thread.Sleep(EvaluatedInterval);
			}
			return elements;
		}

		public static string GetElementText(this IWebDriver driver, By locator)
		{
			//return GetElement(locator).Text;
			return driver.FindElements(locator).FirstOrDefault()?.Text;
		}

		private const int EvaluatedInterval = 500;

	}
}