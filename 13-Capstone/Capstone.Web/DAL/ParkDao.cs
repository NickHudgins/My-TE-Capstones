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
                park.ParkName= Convert.ToString(reader["parkName"]);
                park.State = Convert.ToString(reader["state"]);
                park.Description = Convert.ToString(reader["parkDescription"]);

                parks.Add(park);
            }
            return parks;
        }
        public Park GetPark(string parkCode)
        {
            Park park = new Park();
            return park;
        }
    }
}
