using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Transactions;
using CapstoneTests.cs.SurveyController;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace capstonetests.cs.surveycontroller
{
    [TestClass]
    public class SurveyTest
    {
        private TransactionScope transaction;
        //actual selenium tests
        [TestInitialize]
        public void Initialize()
        {
            transaction = new TransactionScope();
        }
        //make sure everything is disposed of and not saved 
        [TestCleanup]
        public void Cleanup()
        {
            transaction.Dispose();
        }

        //method that will go to the page on line var url and navigate 
        [TestMethod]
        public void SurveyEntryTest()
        {
            var browserDriverPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            ChromeOptions options = new ChromeOptions();
            options.AddArguments("--start-maximized");

            using (var chromeDriver = new ChromeDriver(browserDriverPath, options))
            {
                var url = "http://localhost:60349/Survey";
                chromeDriver.Navigate().GoToUrl(url);

                SurveySeleniumTest surveySelenium = new SurveySeleniumTest(chromeDriver);

                IWebElement result = surveySelenium.SurveyEmail("EmailAddress@smail.com"); //grab and insert the email

                Assert.IsNotNull(result);
                chromeDriver.Close();

            }
        }
    }
}
