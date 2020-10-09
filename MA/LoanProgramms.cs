using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MA
{
    class LoanProgramms
    {
        IWebDriver driver;

        [SetUp]
        public void startBrowser()
        {
            driver = new ChromeDriver();
        }

        [Test]
        public void test()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            driver.Url = "https://academymortgage.com/";
            driver.Manage().Window.Maximize();
            driver.FindElement(By.Id("cm-dropdown2")).Click();

            driver.FindElement(By.XPath("//*[@href='/loan-programs/fha-loans']")).Click();

            driver.FindElement(By.XPath("//*[@href='/find-a-loan-officer']")).Click();

            driver.FindElement(By.Id("Name")).Click();

            driver.FindElement(By.Id("Name")).SendKeys("Martin"); 

            driver.FindElement(By.Id("searchBtn")).Click();

            IList<IWebElement> names = driver.FindElements(By.XPath("//div[@class ='name-title-div']/h3"));

            
            foreach (IWebElement element in names)
            {
                String name = element.Text;
                Assert.True(name.ToLower().Contains("martin"));

            }
        }

        [TearDown]
        public void closeBrowser()
        {
            driver.Close();
        }
    }
}
