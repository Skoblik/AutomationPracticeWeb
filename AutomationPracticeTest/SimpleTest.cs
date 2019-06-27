using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationPractice
{
    [TestFixture]
    public class SimpleTest
    {
        //[Test]
        public void HumanTest()
        {
            var human1 = new Human();
            human1.Name = "Vasya";
            human1.Age = 25;
            human1.Move(step: 1);
            human1.Eat(food: "banana");

            var human2 = new Human();
            human2.Name = "Petja";
            human2.Move(step: 1);

            Console.WriteLine(value:$"name: {human1.Name} age: {human1.Age}");
            Console.WriteLine(value:$"name: {human2.Name} age: {human2.Age}");
        }
        [Test]
        public void UserCanLoginWithValidCredentials()
        {
            var options = new ChromeOptions();
            options.AddArgument("--start-maximized");
            options.AddArgument("--disable-extensions");
            options.AddArgument("--disable-infobars");

            IWebDriver driver = new ChromeDriver(AppDomain.CurrentDomain.BaseDirectory, options);
            driver.Navigate().GoToUrl("http://automationpractice.com/index.php");
            //driver.Manage().Window.Maximize();
            driver.FindElement(By.XPath("//a[@class='login']")).Click();

            driver.FindElement(By.Id("email")).SendKeys("skullmail@ukr.net");
            driver.FindElement(By.Id("passwd")).SendKeys("12345");
            driver.FindElement(By.Id("SubmitLogin")).Click();

            var userName = driver.FindElements(By.ClassName("account")).FirstOrDefault().Text;
            Assert.IsNotNull(userName, "Cannot log in");

            Assert.That(userName, Is.EqualTo(expected: "A Che"));

            driver.Quit();
        }
        [Test]
        public void UserCannotLoginWithInvalidCredentials()
        {
            var options = new ChromeOptions();
            options.AddArgument("--start-maximized");
            options.AddArgument("--disable-extensions");
            options.AddArgument("--disable-infobars");

            IWebDriver driver = new ChromeDriver(AppDomain.CurrentDomain.BaseDirectory, options);
            driver.Navigate().GoToUrl("http://automationpractice.com/index.php");
            //driver.Manage().Window.Maximize();
            driver.FindElement(By.ClassName("login")).Click();

            driver.FindElement(By.Id("email")).SendKeys("invalid@ukr.net");
            driver.FindElement(By.Id("passwd")).SendKeys("12345");
            driver.FindElement(By.Id("SubmitLogin")).Click();

            var errorMessage = driver.FindElement(By.XPath("//div[@class = 'alert alert-danger']//li")).Text;

            Assert.That(errorMessage, Is.EqualTo(expected: "Authentication failed."));

            driver.Quit();
            
        }
    }
}

