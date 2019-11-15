using Capstone.Web.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace CapstoneTests.cs
{
    [TestClass]
    public class TempConversionTest
    {

        [TestMethod]
        public void TempConvert()
        {
            Weather testWeatherConversion = new Weather();
            //act
            decimal result = 37.7777777777778M;
            //Assert (with actual = result)
            Assert.AreEqual(result, testWeatherConversion.TempConvert(100));
        }
    }
}

