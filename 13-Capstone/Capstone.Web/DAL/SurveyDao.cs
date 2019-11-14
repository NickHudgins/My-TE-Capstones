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

        private readonly string sql_favoritePark = "SELECT survey_result.parkCode, parkName, COUNT(*) as park_count FROM survey_result " +
        "JOIN park ON survey_result.parkCode = park.parkCode GROUP BY survey_result.parkCode, parkName " +
        "ORDER BY park_count DESC, parkName";

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
            catch (Exception ex)
            {
                
            }

            return survey;
        }

        public List<Survey> FavoritePark()
        {
            List<Survey> surveys = new List<Survey>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(sql_favoritePark, conn);

                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Survey survey = new Survey()
                        {
                            ParkCode = Convert.ToString(reader["parkCode"]),
                            SurveyCount = Convert.ToInt32(reader["park_count"]),
                            ParkName = Convert.ToString(reader["parkName"])
                        };

                        surveys.Add(survey);
                    }

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {

            }

            return surveys;
        }
    }
}
