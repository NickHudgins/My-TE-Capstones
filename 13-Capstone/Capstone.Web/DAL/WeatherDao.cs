using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.DAL
{
    public class WeatherDao : IWeatherDao
    {
        private readonly string connectionString;
        public WeatherDao(string connectionString)
        {
            this.connectionString = connectionString;
        }
    }
}
