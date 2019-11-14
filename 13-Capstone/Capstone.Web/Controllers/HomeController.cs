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
        private const string IsCelsius = "IsCelsius";
        private IParkDao parkDao;
        public HomeController(IParkDao parkDao)
        {
            this.parkDao = parkDao;
        }

        public IActionResult Index()
        {
            List<Park> parks = parkDao.GetAllParks();
            return View(parks);
        }

        public IActionResult Detail(string parkCode)
        {
            Park park = parkDao.GetPark(parkCode);
            return View(park);
        }

        public bool IsFarenheitOrCelsius(Park park)
        {
            bool isCelsius = false;
            HttpContext.Session.SetInt32(IsCelsius, park.IsCelsius);
            if(park.IsCelsius == 1)
            {
                isCelsius = true;
            }
            return isCelsius;
        }
    }
}
