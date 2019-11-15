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
    public class SurveyDAOTests
    {

        protected string connectionString = "Data Source=.\\sqlexpress;Initial Catalog=NPGeek;Integrated Security=True";

        private TransactionScope transaction;
        private ISurveyDao surveyDao;

        public SurveyDAOTests()
        {
            surveyDao = new SurveyDao(connectionString);
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
        public void SaveSurveyAddsARow()
        {

            int initialCount = GetRowCount("survey_result");

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

            Survey survey = new Survey();
            survey.ParkCode = "TEST";
            survey.EmailAddress = "d@g";
            survey.State = "OH";
            survey.ActivityLevel = "inactive";


            surveyDao.SaveSurvey(survey);

            int afterAdded = GetRowCount("survey_result");

            Assert.AreEqual(initialCount + 1, afterAdded);
        }

        [TestMethod]
        public void NewSurveyAppearsInList()
        {
            bool foundSurvey = false;

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

            Survey survey = new Survey();
            survey.ParkCode = "TEST";
            survey.EmailAddress = "d@g";
            survey.State = "OH";
            survey.ActivityLevel = "inactive";


            surveyDao.SaveSurvey(survey);

            List<Survey> testList = surveyDao.FavoritePark();

            foreach(Survey testSurvey in testList)
            {
                if(testSurvey.ParkCode == "TEST")
                {
                    foundSurvey = true;
                    break;
                }
            }

            Assert.IsTrue(foundSurvey);
        }

        protected int GetRowCount(string table)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand($"SELECT COUNT(*) FROM {table}", conn); //get # rows after adding survey
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                return count;
            }
        }
    }
}
