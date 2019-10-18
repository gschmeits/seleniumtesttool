namespace UnitTestProject1
{
    using System;
    using System.Diagnostics;
    using System.Security.Cryptography.X509Certificates;
    using System.Threading;

    using DataStorage;

    using GeneralFunctionality;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;

    [TestClass]
    public class UnitTest1
    {
        private static int nummer;

        [TestMethod]
        public void A001_CheckIfFormFieldExists(IWebDriver driver)
        {
            Functions.GetCurrentDir();
            Functions.GetCredentials();
            Functions.InitializeDatabaseConnection();
            Functions.setTestrunID(General.GetLastTestRun());
            Functions.setApplicationName("TestApplication");
            Functions.CheckScreenshotDir();
            Functions.setClassName(this.GetType().Name);

            var Title = driver.Title;
            var TitleLength = driver.Title.Length;
            Console.WriteLine("Title of the page is : " + Title);
            Console.WriteLine("Length of the Title is : " + TitleLength);

            var PageURL = driver.Url;
            var URLLength = PageURL.Length;
            Console.WriteLine("URL of the page is : " + PageURL);
            Console.WriteLine("Length of the URL is : " + URLLength);

            var PageSource = driver.PageSource;
            var PageSourceLength = driver.PageSource.Length;
            Console.WriteLine("Page Source of the page is : " + PageSource);
            Console.WriteLine("Length of the Page Source is : " + PageSourceLength);
            //Thread.Sleep(5000);

            try
            {
                Assert.IsTrue(Functions.CheckBy(driver, "loginfmt", "name"));
            }
            catch (Exception e)
            {
                Debug.Print(e.Message + "\r\n" + e.Source + "\r\n" + e.StackTrace);
                throw;
            }
        }

        [TestMethod]
        public void A002_CheckIfFormExists(IWebDriver _driver)
        {
            try
            {
                Assert.IsTrue(Functions.CheckBy(_driver, "f1", "name"));
                _driver.Quit();
            }
            catch (Exception e)
            {
                Debug.Print(e.Message + "\r\n" + e.Source + "\r\n" + e.StackTrace);
                throw;
            }
        }

    }
}