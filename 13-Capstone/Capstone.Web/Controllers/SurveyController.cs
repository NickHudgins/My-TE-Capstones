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

        public SurveyController(ISurveyDao surveyDao, IParkDao parkDao) //we initialize our park and survey
        {
            this.surveyDao = surveyDao;
            this.parkDao = parkDao;
        }

        public IActionResult Index() //we create a new survey and get a list of parks
        {
            Survey survey = new Survey();
            survey.ParkList = parkDao.GetAllParks();

            return View(survey); //create new view bound to our survey
        }

        [HttpPost]
        [ValidateAntiForgeryToken] 
        public IActionResult Index(Survey survey)
        {
            if(!ModelState.IsValid) //if it is not valid ..we don't submit our survey and go back to index
            {
                survey.ParkList = parkDao.GetAllParks();
                return View(survey);
            }

            surveyDao.SaveSurvey(survey);//submit our survey

            return RedirectToAction("FavoritePark"); //otherwise we redirect to favorite park
        }
        public IActionResult FavoritePark()
        {
            List<Survey> surveys = surveyDao.FavoritePark();
            return View(surveys); // binds of list of surveys to fav park
        }
    }
}