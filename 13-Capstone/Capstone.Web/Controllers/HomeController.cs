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
        private string connectionString = "Data Source =.\\sqlexpress;Initial Catalog = NPGeek; Integrated Security = True";

        public IActionResult Index()
        {
            ParkDao dao = new ParkDao(connectionString);
            List<Park> parks = dao.GetAllParks();
            return View(parks);
        }

        public IActionResult Detail()
        {
            return View();
        }
        //TODO
        //TEMP CONVERSION


    }
}
