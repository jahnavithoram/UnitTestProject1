using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;

namespace regtest
{
    [TestClass]
    public class regtest
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
              

                var regbtn = driver.FindElementByXPath("//a[@href='/Identity/Account/Register']");
                Assert.IsNotNull(regbtn);//   Console.Read();

                regbtn.Click();
                new WebDriverWait(driver, TimeSpan.FromSeconds(5)).Until(
                    d => ((IJavaScriptExecutor)d).ExecuteScript("return document.readyState").Equals("complete")
                    );
               var pagetitle = driver.PageSource.Contains("Register");
                Assert.IsTrue(pagetitle);
//Enter diff email id for everytime while testing
                var Email = driver.FindElementByName("Input.Email");
                Assert.IsNotNull(Email);
                Email.SendKeys("Adam12346500@gmail.com");
                var passw = driver.FindElementByName("Input.Password");
                Assert.IsNotNull(passw);
                passw.SendKeys("Adam@123");
                var cpassw = driver.FindElementByName("Input.ConfirmPassword");
                Assert.IsNotNull(cpassw);
                cpassw.SendKeys("Adam@123");
                var rbtn = driver.FindElementByXPath("//button[contains(text(), 'Register')]");
                Assert.IsNotNull(rbtn);
                rbtn.Click();
                new WebDriverWait(driver, TimeSpan.FromSeconds(5)).Until(
                     d => ((IJavaScriptExecutor)d).ExecuteScript("return document.readyState").Equals("complete")
                     );

            }
        }
    }
}
