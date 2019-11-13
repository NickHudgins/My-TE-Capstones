using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.Models
{
    public class Weather
    {
        public string ParkCode { get; set; }
        public string FiveDayForecastValue { get; set; }
        public int Low { get; set; }
        public int High { get; set; }
        public int Forecast { get; set; }

        public decimal TempConvert(int temp)
        {
            decimal convertedTemp = (Convert.ToDecimal((temp - 32) / 1.8));
            return convertedTemp;
        }
    }
}
