using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Capstone.Web.Models;
using Capstone.Web.DAL;

namespace Capstone.Web.Controllers
{
    public class HomeController : Controller
    {
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
    }
}
