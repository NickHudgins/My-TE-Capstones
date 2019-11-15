using Capstone.Web.DAL;
using Capstone.Web.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Transactions;

namespace CapstoneTests.cs
{
    [TestClass]
    public class ParkWithForecastTest
    {
        protected string connectionString = "Data Source=.\\sqlexpress;Initial Catalog=NPGeek;Integrated Security=True";

        private TransactionScope transaction;
        private IParkDao parkDao;

        public ParkWithForecastTest()
        {
            parkDao = new ParkDao(connectionString);
        }

        [TestInitialize]
        public void Setup()
        {
            transaction = new TransactionScope();
        }

        [TestCleanup]
        public void Cleanup()
        {
            transaction.Dispose();
        }

        [TestMethod]
        public void FindNewPark()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("INSERT INTO park (parkCode, parkName, state, acreage, elevationInFeet, milesOfTrail, numberOfCampsites, climate, yearFounded, annualVisitorCount, inspirationalQuote, inspirationalQuoteSource, parkDescription, entryFee, numberOfAnimalSpecies) VALUES ('TEST', 'TestPark', 'Ohio', 1, 1, 1, 1, 'hot', 1999, 1, 'testquote', 'me', 'thisparkdoesntexist', 1, 1);", conn);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {

            }
            Park park = parkDao.GetParkWithForecast("TEST");
            //variables
            string myParkCode = "TestPark";
            Assert.AreEqual(myParkCode, park.ParkName);

        }
        [TestMethod]
        public void ParkWithForecast()
        {
            bool foundForecast = false;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("INSERT INTO park (parkCode, parkName, state, acreage, elevationInFeet, milesOfTrail, numberOfCampsites, climate, yearFounded, annualVisitorCount, inspirationalQuote, inspirationalQuoteSource, parkDescription, entryFee, numberOfAnimalSpecies) VALUES ('TEST', 'TestPark', 'Ohio', 1, 1, 1, 1, 'hot', 1999, 1, 'testquote', 'me', 'thisparkdoesntexist', 1, 1);", conn);
                    cmd.ExecuteNonQuery();
                    cmd = new SqlCommand("INSERT INTO weather (parkCode, fiveDayForecastValue, low, high, forecast) VALUES ('TEST',1, 50, 70,'sunny');", conn);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {

            }
            Park park = parkDao.GetParkWithForecast("TEST");
            //variables
            foreach (Weather weather in park.Forecast)
            {
                if (weather.Forecast == "sunny")
                {
                    foundForecast = true;
                    break;
                }

            }
            Assert.IsTrue(foundForecast);
        }
        [TestMethod]
        public void FindListOfParks()
        {
            bool foundMyPark = false;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("INSERT INTO park (parkCode, parkName, state, acreage, elevationInFeet, milesOfTrail, numberOfCampsites, climate, yearFounded, annualVisitorCount, inspirationalQuote, inspirationalQuoteSource, parkDescription, entryFee, numberOfAnimalSpecies) VALUES ('TEST', 'TestPark', 'Ohio', 1, 1, 1, 1, 'hot', 1999, 1, 'testquote', 'me', 'thisparkdoesntexist', 1, 1);", conn);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {

            }
            List<Park> parks = parkDao.GetAllParks();
            //variables
            foreach (Park park in parks)
            {
                if (park.ParkCode =="TEST")
                {
                    foundMyPark = true;
                    break;
                }
            }
            Assert.IsTrue(foundMyPark);
        }
    }
}




