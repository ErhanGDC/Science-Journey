using log4net;
using ScienceJourney.DAL;
using ScienceJourney.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Mvc;


namespace ScienceJourney.Controllers
{
    public class HomeController : Controller
    {
        private ScienceJourneyEntities db = new ScienceJourneyEntities();
        static ILog log = log4net.LogManager.GetLogger(typeof(HomeController));

        public ActionResult Index()
        {
            List<Slider> files = new List<Slider>();
            try
            {
                log4net.Config.BasicConfigurator.Configure();
                log.Info(String.Format("Getting files from directory"));

                string[] filePaths = Directory.GetFiles(Server.MapPath("~/assets/img/"));
                foreach (string filePath in filePaths)
                {
                    string fileName = Path.GetFileName(filePath);
                    files.Add(new Slider
                    {
                        title = fileName.Split('.')[0].ToString(),
                        src = "../assets/img/" + fileName
                    });
                }
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
            finally
            {
                log.Debug(String.Format("Logger test finished"));
            }
            return View(files);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Science Journey";

            return View();
        }

        public ActionResult Register()
        {
            var countries = (from u in db.countries
                             select new CountryModel
                             {
                                 id = u.id,
                                 name = u.name,
                                 sortname = u.sortname
                             }).ToList();

            var cities = (from u in db.Cities
                          select new CityModel
                          {
                              id = u.id,
                              name = u.name,
                              country_id = u.country_id
                          }).ToList();

            RegisterPageViewModel registerPageViewModel = new RegisterPageViewModel();
            registerPageViewModel.Member = new MemberModel();
            registerPageViewModel.Countries = countries;
            registerPageViewModel.Cities = cities;

            try
            {
                return View(registerPageViewModel);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPost]
        public ActionResult Register(MemberModel register)
        {
            try
            {
                Member member = new Member();
                member.first_name = register.first_name;
                member.last_name = register.last_name;
                member.password = register.password;
                member.interests = register.interests;
                member.country = register.countryName + 1; //Index Number Start from Zero, Because of it, added +1
                member.city = register.cityName + 1;//Index Number Start from Zero, Because of it, added +1
                member.email = register.email;
                member.Gender = register.gender;
                member.createTime = DateTime.Now;

                if (ModelState.IsValid)
                {
                    // Save Progcess
                    db.Members.Add(member);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                log.Info(String.Format("Exception occurred"));
                log.Error(ex.Message);
            }
            return RedirectToAction("Index");
        }

        [AllowAnonymous]
        [HttpGet]
        public JsonResult GetCountries()
        {
            try
            {
                var countries = (from u in db.countries
                                 select new CountryModel
                                 {
                                     id = u.id,
                                     name = u.name,
                                     sortname = u.sortname
                                 }).ToList();

                return Json(countries, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                log.Info(String.Format("Exception occurred"));
                log.Error(ex.Message);
            }
            return Json(null);
        }

        [AllowAnonymous]
        [HttpGet]
        public JsonResult GetCitiesByCountryId(int countryId)
        {
            //Have to increase it, Because indext start from zero.
            countryId++;
            try
            {
                var cities = (from c in db.Cities
                              where c.country_id == countryId
                              select new CityModel
                              {
                                  id = c.id,
                                  name = c.name,
                                  country_id = c.country_id
                              }).ToList();

                return Json(cities, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                log.Info(String.Format("Exception occurred"));
                log.Error(ex.Message);
            }
            return Json(null);
        }

        [AllowAnonymous]
        [HttpGet]
        public JsonResult GetCities()
        {
            try
            {
                var cities = (from c in db.Cities
                              select new CityModel
                              {
                                  id = c.id,
                                  name = c.name,
                                  country_id = c.country_id
                              }).ToList();

                return Json(cities, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                log.Info(String.Format("Exception occurred"));
                log.Error(ex.Message);
            }
            return Json(null);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}