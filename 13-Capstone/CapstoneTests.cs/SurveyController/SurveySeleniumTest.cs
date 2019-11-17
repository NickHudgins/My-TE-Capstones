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
        private ChromeDriver chromeDriver;  //open chrome 
        private WebDriverWait wait; //wait to read your exceptions and wait for page to load

        //the controller
        public SurveySeleniumTest(ChromeDriver chromeDriver)
        {
            this.chromeDriver = chromeDriver;
            this.wait = new WebDriverWait(chromeDriver, new TimeSpan(0, 0, 0, 10));
        }
        
        //selenium select our park and use parkcode from the model
        public IWebElement ParkSelector
        {
            get
            {
                return chromeDriver.FindElement(By.Id("ParkCode"));
            }
        }
        //selenium use email from model.
        public IWebElement EmailBox
        {
            get
            {
                return chromeDriver.FindElement(By.Id("EmailAddress"));
            }
        }
        //selenium selects state from model.
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
        //finds the submit button
        public IWebElement SubmitButton
        {
            get
            {
                return chromeDriver.FindElement(By.Id("submit"));
            }
        }
        //goes to the survey page 
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
            //select our drop-down and enters a parkcode
            SelectElement ParkSelector = new SelectElement(chromeDriver.FindElement(By.Id("ParkCode")));
            ParkSelector.SelectByValue("CVNP");

            //type an email for us and then clears any older entries then send email brought in and types it in SendKeys(email)
            WaitForElement(By.Id("EmailAddress"));
            EmailBox.Clear();
            EmailBox.SendKeys(email);

            //select from a drop down menu
            SelectElement StateSelector = new SelectElement(chromeDriver.FindElement(By.Id("State")));
            StateSelector.SelectByValue("OH");

            //select radio butons 
            IList<IWebElement> radioSelect = chromeDriver.FindElements(By.Id("ActivityLevel"));
            radioSelect[0].Click();

            WaitForElement(By.Id("submit"));
            SubmitButton.Click();

            WaitForElement(By.Id("survey"));
            return Survey;
        }
    }
}
