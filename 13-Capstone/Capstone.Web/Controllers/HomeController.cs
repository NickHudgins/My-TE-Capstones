using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Capstone.Web.Models;
using Capstone.Web.DAL;
using Microsoft.AspNetCore.Http;

namespace Capstone.Web.Controllers
{
    public class HomeController : Controller
    {
        private const string IsCelsius = "IsCelsius"; //for session
        private IParkDao parkDao; //declare our dao
        public HomeController(IParkDao parkDao) //initialize our dao with dependency injection
        {
            this.parkDao = parkDao;
        }

        public IActionResult Index() //get list of parks and send it to the index view 
        {
            List<Park> parks = parkDao.GetAllParks();
            return View(parks);
        }

        public IActionResult Detail(string parkCode, string IsCelsius) //bring in a park code with parameters & a string that is initally null
        {
            if(HttpContext.Session.GetString("IsCelsius") == null) //check to see if key(IsCelsius) is null
            {
                HttpContext.Session.SetString("IsCelsius", "0");//if it is null we set it to value(zero)
            }
            if(IsCelsius != null) //check to see if the string we brought in is not null 
            {
                HttpContext.Session.SetString("IsCelsius", IsCelsius); // we set is celsius to a the value in the string that was brought in
            }
            
            Park park = parkDao.GetParkWithForecast(parkCode); //get park based on the parkCode we brought in
            park.IsCelsius = Convert.ToInt32(HttpContext.Session.GetString("IsCelsius")); //using our value up above we assign it to the park
            return View(park); //detail page with the specific park 
        }
    }
}
