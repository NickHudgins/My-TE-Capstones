using Capstone.Web.Models;
using System;
using System.Collections.Generic;
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
            return parks;
        }
        public Park GetPark(string parkCode)
        {
            Park park = new Park();
            return park;
        }
    }
}
