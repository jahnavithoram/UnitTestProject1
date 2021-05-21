using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;

namespace logtest
{
    [TestClass]
    public class logtest
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
                var Email = driver.FindElementByName("Input.Email");
                Assert.IsNotNull(Email);
                Email.SendKeys("Hello123@gmail.com");
                var passw = driver.FindElementByName("Input.Password");
                Assert.IsNotNull(passw);
                passw.SendKeys("Hello123@gmail.com");
                var rbtn = driver.FindElementByXPath("//button[contains(text(), 'Log in')]");
                Assert.IsNotNull(rbtn);
                rbtn.Click();
                new WebDriverWait(driver, TimeSpan.FromSeconds(5)).Until(
                     d => ((IJavaScriptExecutor)d).ExecuteScript("return document.readyState").Equals("complete")
                     );
                var pagetitle = driver.PageSource.Contains("Hello");
                Assert.IsTrue(pagetitle);
                var pagetitle2 = driver.PageSource.Contains("My Orders");
                Assert.IsTrue(pagetitle2);
                //Enter diff email id for everytime while testing




            }
        }
    }
}
