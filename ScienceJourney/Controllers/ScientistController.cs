using log4net;
using ScienceJourney.DAL;
using ScienceJourney.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ScienceJourney.Controllers
{
    public class ScientistController : Controller
    {
        private ScienceJourneyEntities2 db = new ScienceJourneyEntities2();
        static ILog log = log4net.LogManager.GetLogger(typeof(HomeController));

        //
        // GET: /Scientist/
        public ActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpGet]
        public JsonResult GetScientist()
        {
            try
            {
                var countries = (from u in db.Scientists
                                 select new Scientist
                                 {
                                     ScientistID = u.ScientistID,
                                     FirstName = u.FirstName,
                                     LastName = u.LastName,
                                     MiddleName = u.MiddleName,
                                     Title = u.Title
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