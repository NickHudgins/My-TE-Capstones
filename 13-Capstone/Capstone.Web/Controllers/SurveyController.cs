using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Capstone.Web.DAL;
using Capstone.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace Capstone.Web.Controllers
{
    public class SurveyController : Controller
    {
        ISurveyDao surveyDao;
        IParkDao parkDao;

        public SurveyController(ISurveyDao surveyDao, IParkDao parkDao)
        {
            this.surveyDao = surveyDao;
            this.parkDao = parkDao;
        }

        public IActionResult Index()
        {
            List<Park> parks = parkDao.GetAllParks();

            return View(parks);
        }

        [HttpPost]
        public IActionResult Index(Survey survey)
        {
            if(!ModelState.IsValid)
            {
                return View(survey);
            }



            return RedirectToAction("FavoritePark");
        }
        public IActionResult FavoritePark()
        {
            return View();
        }
        
       
    }
}