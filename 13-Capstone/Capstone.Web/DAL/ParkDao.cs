using Capstone.Web.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.DAL
{
    public class ParkDao : IParkDao
    {
        private readonly string connectionString;
        public ParkDao(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<Park> GetAllParks()
        {
            List<Park> parks = new List<Park>();

            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();

            SqlCommand cmd = new SqlCommand("SELECT parkCode, parkName, state, parkDescription FROM park", conn);

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Park park = new Park();

                park.ParkCode = Convert.ToString(reader["parkCode"]);
                park.ParkName = Convert.ToString(reader["parkName"]);
                park.State = Convert.ToString(reader["state"]);
                park.ParkDescription = Convert.ToString(reader["parkDescription"]);

                parks.Add(park);
            }
            return parks;
        }


        public Park GetPark(string parkCode)
        {
            Park park = new Park();
            SqlConnection conn = new SqlConnection(connectionString);
            conn.Open();

            SqlCommand cmd = new SqlCommand("SELECT * FROM park WHERE parkCode = @parkCode", conn);
            cmd.Parameters.AddWithValue("@parkCode", parkCode);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                park.ParkCode = Convert.ToString(reader["parkCode"]);
                park.ParkName = Convert.ToString(reader["parkName"]);
                park.State = Convert.ToString(reader["state"]);
                park.ParkDescription = Convert.ToString(reader["parkDescription"]);
                park.Acreage = Convert.ToInt32(reader["acreage"]);
                park.ElevationOfFeet = Convert.ToInt32(reader["elevationInFeet"]);
                park.MilesOfTrail = Convert.ToInt32(reader["milesofTrail"]);
                park.NumberOfCampsites = Convert.ToInt32(reader["numberOfCampsites"]);
                park.Climate = Convert.ToString(reader["climate"]);
                park.YearFounded = Convert.ToInt32(reader["yearFounded"]);
                park.AnnualVisitorCount = Convert.ToInt32(reader["annualVisitorCount"]);
                park.InspirationalQuote = Convert.ToString(reader["inspirationalQuote"]);
                park.InspirationalQuoteSource = Convert.ToString(reader["inspirationalQuoteSource"]);
                park.EntryFee = Convert.ToInt32(reader["entryFee"]);
                park.NumberOfAnimalSpecies = Convert.ToInt32(reader["numberOfAnimalSpecies"]);

               
            }
            reader.Close();

            //GET FORECAST FOR ONE PARK THAT WAS SELECTED AND SORT BY DAY
            using (SqlCommand weathercmd = new SqlCommand("SELECT * FROM weather WHERE parkCode = @parkCode ORDER BY fiveDayForecastValue", conn))
            {
                weathercmd.Parameters.AddWithValue("@parkCode", park.ParkCode);
                using (SqlDataReader weatherReader = weathercmd.ExecuteReader())
                {
                    park.Forecast = new List<Weather>();
                    while (weatherReader.Read())
                    {
                        park.Forecast.Add(new Weather
                        {
                            //create object properties 
                            FiveDayForecastValue = Convert.ToInt32(weatherReader["fiveDayForecastValue"]),
                            High = Convert.ToInt32(weatherReader["high"]),
                            Low = Convert.ToInt32(weatherReader["low"]),
                            Forecast = Convert.ToString(weatherReader["forecast"]),
                            ParkCode = Convert.ToString(weatherReader["parkCode"])
                        });
                    }
                    weatherReader.Close();
                }
            }
            return park;

        }
    }
}
