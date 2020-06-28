using System;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Selenium
{
    public class VoteIncrementor
    {
        public void incrementCounter()
        {
            int i = 0;

            while (i < 200)
            {
                IWebDriver driver = new ChromeDriver();
                driver.Navigate().GoToUrl("https://fotofox.live/miss-uttar-pradesh-2020/?contest=photo-detail&photo_id=34383");
                driver.FindElement(By.XPath("(//div[contains(@class,'pc-image-info-box-button-btn-text')])[1]")).Click();
                Thread.Sleep(2000);
                driver.Quit();
                Console.WriteLine(i++);
            }
        }
    }
}
