using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.Models
{
    public class Weather
    {
        private int sun;

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

        public string TempWarningMsg(int temp)
        {
            int TempDiff = Low - High;
            if (High > 75)
            {
                return "Warning: Outside temperature is above 75. Please bring an extra gallon of water!";
            }
            else if (TempDiff > 20)
            {
                return "Please wear breathable layers.";
            }
            else if (Low > 20)
            {
                return "Warning: Outside temperature is below 20 degrees.You maybe exposed to frigid temperatures.";
            }
        }

        public string ForecastWarningMsg()
        {
            foreach (var item in List<Weather>)
            {
                if (Forecast = rain)
                {
                    return "Please pack rain gear and wear waterproof shoes!");
                }
                else if (Forecast = snow)
                {
                    return "Please pack snowshoes!");
                }
                else if (Forecast = thunderstorm)
                {
                    return "Please seek shelter and avoid hiking on exposed ridges!";
                }
                else if (Forecast = sun)
                {
                    return "Please pack sunblock!";
                }
                return 
            }

        }
    }
}
