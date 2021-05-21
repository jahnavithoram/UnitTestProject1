using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;

namespace Hometest
{
    [TestClass]
    public class Hometest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            using (var driver = new ChromeDriver())
            {
                // driver.Manage().Window.Maximize();
                driver.Navigate().GoToUrl("https://capstproj2021.azurewebsites.net");
                new WebDriverWait(driver, TimeSpan.FromSeconds(5)).Until(
                    d => ((IJavaScriptExecutor)d).ExecuteScript("return document.readyState").Equals("complete")
                    );
                var loginbtn = driver.FindElementByXPath("//a[@href='/Identity/Account/Login']");
                Assert.IsNotNull(loginbtn);//   Console.Read();

                loginbtn.Click();
                new WebDriverWait(driver, TimeSpan.FromSeconds(5)).Until(
                    d => ((IJavaScriptExecutor)d).ExecuteScript("return document.readyState").Equals("complete")
                    );
                var pagetitle = driver.PageSource.Contains("Log in");
                Assert.IsTrue(pagetitle);
                var regbtn = driver.FindElementByXPath("//a[@href='/Identity/Account/Register']");
                Assert.IsNotNull(regbtn);//   Console.Read();

                regbtn.Click();
                new WebDriverWait(driver, TimeSpan.FromSeconds(5)).Until(
                    d => ((IJavaScriptExecutor)d).ExecuteScript("return document.readyState").Equals("complete")
                    );
                 pagetitle = driver.PageSource.Contains("Register");
                Assert.IsTrue(pagetitle);

                var meds = driver.FindElementByXPath("//a[@href='/Product/Index1']");
                Assert.IsNotNull(regbtn);//   Console.Read();

                meds.Click();
                new WebDriverWait(driver, TimeSpan.FromSeconds(5)).Until(
                    d => ((IJavaScriptExecutor)d).ExecuteScript("return document.readyState").Equals("complete")
                    );
                pagetitle = driver.PageSource.Contains("Categories");
                var pagetitle1 = driver.PageSource.Contains("Search");
                var pagetitle2 = driver.PageSource.Contains("Add to cart");
                Assert.IsTrue(pagetitle);
                Assert.IsTrue(pagetitle1);
                Assert.IsTrue(pagetitle2);

            }
        }
    }
}
