using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Threading;

namespace Selenium
{
    class Program
    {
        private static IWebDriver driver = new ChromeDriver();

        private static string UserName = "Shilpi_04";

        static void Main(string[] args)
        {
            //new VoteIncrementor().incrementCounter();
            Initialise();
            ExecuteTest();
            Cleanup();

        }
        
        public static void Initialise()
        {
            driver.Navigate().GoToUrl("https://opensource-demo.orangehrmlive.com/");
        }
        
        public static void ExecuteTest()
        {
            //Fill Username
            driver.FindElement(By.Id("txtUsername")).SendKeys("Admin");

            //Fill Password
            driver.FindElement(By.Id("txtPassword")).SendKeys("admin123");

            //Click Login:
            driver.FindElement(By.Id("btnLogin")).Click();

            //Click Admin
            driver.FindElement(By.XPath("//b[contains(.,'Admin')]")).Click();

            //btnAdd
            driver.FindElement(By.Id("btnAdd")).Click();

            //Select Role
            var selectElement = new SelectElement(driver.FindElement(By.Id("systemUser_userType")));
            //select by value
            selectElement.SelectByText("Admin");

            // Fill Employee Name
            driver.FindElement(By.Id("systemUser_employeeName_empName")).SendKeys("Linda Anderson");

            // Fill UserName
            driver.FindElement(By.Id("systemUser_userName")).SendKeys(UserName);

            //Select Status
            var selectStatus = new SelectElement(driver.FindElement(By.Id("systemUser_status")));
            //select by value
            selectStatus.SelectByText("Enabled");

            // Fill Password
            driver.FindElement(By.Id("systemUser_password")).SendKeys("Test@0105");

            // Fill Confirm Password
            driver.FindElement(By.Id("systemUser_confirmPassword")).SendKeys("Test@0105");


            driver.FindElement(By.Id("btnSave")).Click();
            Thread.Sleep(2000);


            //Click Admin
            driver.FindElement(By.XPath("//b[contains(.,'Admin')]")).Click();


            // Search UserId
            driver.FindElement(By.Id("searchSystemUser_userName")).SendKeys(UserName);

            //Click on Search button
            driver.FindElement(By.Id("searchBtn")).Click();

            //Verify the user Id is saved
            Assert.True(SearchUsername(UserName));

            //Delete user
            driver.FindElement(By.XPath("//input[contains(@name,'chkSelectRow[]')]")).Click();
            driver.FindElement(By.XPath("//input[contains(@id,'btnDelete')]")).Click();

            driver.FindElement(By.Id("dialogDeleteBtn")).Click();
            //Verify the user Id is Deleted
            Assert.False(SearchUsername(UserName));

        }

       
        public static void Cleanup()
        {
            driver.Quit();
        }

        
        public static bool SearchUsername(string username)
        {
            bool isFound = false;
            Console.WriteLine("In searchUserName:: "+username);

            IWebElement elemTable = driver.FindElement(By.Id("resultTable"));
            List<IWebElement> lstTrElem = new List<IWebElement>(elemTable.FindElements(By.TagName("tr")));

            foreach (IWebElement row in lstTrElem)
            {
                List<IWebElement> lstTdElem = new List<IWebElement>(row.FindElements(By.TagName("td")));
                if (lstTdElem.Count > 0)
                {
                    foreach (var elemTd in lstTdElem)
                    {
                        string strRowData =  elemTd.Text;
                        Console.WriteLine("UserName:: " + strRowData);
                        Console.WriteLine(strRowData);
                        if (username.Equals(strRowData))
                        {
                            return true;
                        }
                    }
                }
            }
            return isFound;
        }
    }

    
}
