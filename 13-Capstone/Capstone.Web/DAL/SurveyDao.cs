using Capstone.Web.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.DAL
{
    public class SurveyDao : ISurveyDao
    {
        private readonly string connectionString;
        private readonly string sql_saveSurvey = "INSERT INTO survey_result (parkCode, emailAddress, state, activityLevel) VALUES" +
            "(@parkCode, @emailAddress, @state, @activityLevel)";

        public SurveyDao(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public Survey SaveSurvey(Survey survey)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = conn.CreateCommand();

                    cmd.CommandText = sql_saveSurvey;
                    cmd.Parameters.AddWithValue("@parkCode", survey.ParkCode);
                    cmd.Parameters.AddWithValue("@emailAddress", survey.EmailAddress);
                    cmd.Parameters.AddWithValue("@state", survey.State);
                    cmd.Parameters.AddWithValue("@activityLevel", survey.ActivityLevel);

                    cmd.ExecuteNonQuery();
                }
            }
            catch(Exception ex)
            {

            }

                return survey;
        }

        public Survey FavoritePark()
        {
            Survey survey = new Survey();




            return survey;
        }
    }
}
