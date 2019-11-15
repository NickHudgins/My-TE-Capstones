using Capstone.Web.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace CapstoneTests.cs
{
    [TestClass]
    public class TheForecastWarningMsgTest
    {
        [TestMethod]
        public void ForecastWarningMsg()
        {
            Weather ForecastWarning = new Weather();

            ForecastWarning.Forecast="rain";
            string result = "Please pack rain gear and wear waterproof shoes!";
            Assert.AreEqual(result, ForecastWarning.ForecastWarningMsg);

            ForecastWarning.Forecast = "sun";
            result = "Please pack sunblock!";
            Assert.AreNotEqual("sunny", ForecastWarning.Forecast, "Oops...there is no Warning MSG for sun");
        }
    }
}

