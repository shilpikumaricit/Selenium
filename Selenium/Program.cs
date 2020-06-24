using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Selenium
{
    class Program
    {
        static void Main(string[] args)
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.google.com/");
            //Find the element
            IWebElement webElement = driver.FindElement(By.Name("q"));
            //perform operation
            webElement.SendKeys("Execute Automation");
            driver.Close();
        }
    }
}
