using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace CapstoneTests.cs.SurveyController
{
    [TestClass]
    class SurveySeleniumTest
    {
        private ChromeDriver chromeDriver;
        private WebDriverWait wait;
        
        public SurveySeleniumTest(ChromeDriver chromeDriver)
        {
            this.chromeDriver = chromeDriver;
            this.wait = new WebDriverWait(chromeDriver, new TimeSpan(0, 0, 0, 10));
        }

        public IWebElement ParkSelector
        {
            get
            {
                return chromeDriver.FindElement(By.Id("ParkName"));
            }
        }

        public IWebElement EmailBox
        {
            get
            {
                return chromeDriver.FindElement(By.Id("Email"));
            }
        }

        public IWebElement HomeStateSelector
        {
            get
            {
                return chromeDriver.FindElement(By.Id("State"));
            }
        }

        public IWebElement ActivityLevel
        {
            get
            {
                return chromeDriver.FindElement(By.Id("ActivityLevel"));
            }
        }

        public IWebElement SubmitButton
        {
            get
            {
                return chromeDriver.FindElement(By.Id("Submit"));
            }
        }

        public IWebElement HomeElement
        {
            get
            {
                return chromeDriver.FindElement(By.Id("Home"));
            }
        }

        public void WaitForElement(By location)
        {
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(location));
        }

        public IWebElement SurveyEmail(string email)
        {
            SelectElement ParkSelector = new SelectElement(chromeDriver.FindElement(By.Id("ParkName")));
            ParkSelector.SelectByValue("Cuyahoga Valley National Park");

            WaitForElement(By.Id("Email"));
            EmailBox.Clear();
            EmailBox.SendKeys(email);

            SelectElement StateSelector = new SelectElement(chromeDriver.FindElement(By.Id("State")));
            ParkSelector.SelectByValue("Ohio");

            SelectElement ActivitySelector = new SelectElement(chromeDriver.FindElement(By.Id("ActivityLevel")));
            ActivitySelector.SelectByValue("Active");

            WaitForElement(By.Id("Submit"));
            SubmitButton.Click();

            WaitForElement(By.Id("Home"));
            return HomeElement;
        }
    }
}
