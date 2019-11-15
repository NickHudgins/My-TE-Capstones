using Capstone.Web.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace CapstoneTests.cs
{
    [TestClass]
    public class TheWeatherImageTest
    {
        [TestMethod]
        public void WeatherImage()
        {
            Weather testForecastImage = new Weather();
            testForecastImage.Forecast="rain";
            //act
            string result = "rain.png";
            //Assert (with actual = result)
            Assert.AreEqual(result, testForecastImage.WeatherImage);

            testForecastImage.Forecast = "thunderstorms";
            //act
            result = "thunderstorms.png";
            //Assert (with actual = result)
            Assert.AreEqual(result, testForecastImage.WeatherImage);

           
            testForecastImage.Forecast = "thunderstorms";
            //act
            result = "cloudy.png";
            //Assert (with actual = result)
            Assert.AreNotEqual(result, testForecastImage.WeatherImage);
        }
        
    }
}

