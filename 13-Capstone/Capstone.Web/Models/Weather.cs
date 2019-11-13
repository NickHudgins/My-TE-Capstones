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
            string tempMsg = "";
            int TempDiff = Low - High;
            if (High > 75)
            {
                tempMsg = "Warning: Outside temperature is above 75. Please bring an extra gallon of water!";
            }
            else if (TempDiff > 20)
            {
                tempMsg = "Please wear breathable layers.";
            }
            else if (Low > 20)
            {
                tempMsg = "Warning: Outside temperature is below 20 degrees.You maybe exposed to frigid temperatures.";
            }
            return tempMsg;
        }

        public string ForecastWarningMsg(string forecast)
        {

            string forecastMsg = "";

            if (forecast == "rain")
            {
                forecastMsg ="Please pack rain gear and wear waterproof shoes!";
            }
            else if (forecast == "snow")
            {
                forecastMsg = "Please pack snowshoes!";
            }
            else if (forecast == "thunderstorm")
            {
                forecastMsg = "Please seek shelter and avoid hiking on exposed ridges!";
            }
            else if (forecast == "sun")
            {
                forecastMsg = "Please pack sunblock!";
            }
            return forecastMsg;
        }


    }
}

