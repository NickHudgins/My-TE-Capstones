using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.Models
{
    public class Weather
    {
        public string ParkCode { get; set; }
        public int FiveDayForecastValue { get; set; }
        public int Low { get; set; }
        public int High { get; set; }
        public string Forecast { get; set; }
        public string FullForecastMsg
        {
            get
            {
                return TempWarningMsg + " " + ForecastWarningMsg;
            }
        }
        public string WeatherImage
        {
            get
            {
                string image = "";
                if (Forecast == "rain")
                {
                    image = "rain.png";
                }
                else if (Forecast == "snow")
                {
                    image = "snow.png";
                }
                else if (Forecast == "thunderstorms")
                {
                    image = "thunderstorms.png";
                }
                else if (Forecast == "sunny")
                {
                    image = "sunny.png";
                }
                else if (Forecast == "partly cloudy")
                {
                    image = "partlyCloudy.png";
                }
                else if (Forecast == "cloudy")
                {
                    image = "Cloudy.png";
                }
                //default image
                return image;
            }
        }


        public decimal TempConvert(int temp)
        {
            decimal convertedTemp = (Convert.ToDecimal((temp - 32) / 1.8));
            return convertedTemp;
        }


        public string TempWarningMsg
        {
            get
            {
                string tempMsg = "";
                int TempDiff = Low - High;
                if (High > 75)
                {
                    tempMsg = "Warning: Outside temperature is above 75. Please bring an extra gallon of water!";
                }
                else if (TempDiff > 20)
                {
                    tempMsg = "Warning: Please wear breathable layers.";
                }
                else if (Low < 20)
                {
                    tempMsg = "Warning: Outside temperature is below 20 degrees.You maybe exposed to frigid temperatures!";
                }
                return tempMsg;
            }
        }

        public string ForecastWarningMsg
        {
            get
            {
                string forecastMsg = "";

                if (Forecast == "rain")
                {
                    forecastMsg = "Please pack rain gear and wear waterproof shoes!";
                }
                else if (Forecast == "snow")
                {
                    forecastMsg = "Please pack snowshoes!";
                }
                else if (Forecast == "thunderstorm")
                {
                    forecastMsg = "Please seek shelter and avoid hiking on exposed ridges!";
                }
                else if (Forecast == "sun")
                {
                    forecastMsg = "Please pack sunblock!";
                }
                else if (Forecast == "partly cloudy")
                {
                    forecastMsg = "Please pack sunblock!";
                }
                return forecastMsg;
            }
        }


    }
}

