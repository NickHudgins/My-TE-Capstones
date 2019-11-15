using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace CapstoneTests.cs.SurveyController
{
    public class SurveySeleniumTest
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
                return chromeDriver.FindElement(By.Id("ParkCode"));
            }
        }

        public IWebElement EmailBox
        {
            get
            {
                return chromeDriver.FindElement(By.Id("EmailAddress"));
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
                return chromeDriver.FindElement(By.Id("submit"));
            }
        }

        public IWebElement Survey
        {
            get
            {
                return chromeDriver.FindElement(By.Id("survey"));
            }
        }

        public void WaitForElement(By location)
        {
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(location));
        }

        
        public IWebElement SurveyEmail(string email)
        {
            SelectElement ParkSelector = new SelectElement(chromeDriver.FindElement(By.Id("ParkCode")));
            ParkSelector.SelectByValue("CVNP");

            WaitForElement(By.Id("EmailAddress"));
            EmailBox.Clear();
            EmailBox.SendKeys(email);

            SelectElement StateSelector = new SelectElement(chromeDriver.FindElement(By.Id("State")));
            StateSelector.SelectByValue("OH");

            IList<IWebElement> radioSelect = chromeDriver.FindElements(By.Id("ActivityLevel"));
            radioSelect[0].Click();

            WaitForElement(By.Id("submit"));
            SubmitButton.Click();

            WaitForElement(By.Id("survey"));
            return Survey;
        }
    }
}
