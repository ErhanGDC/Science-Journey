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
            //string[] filePaths = Directory.GetFiles(Server.MapPath("~/assets/img/"));
            //List<Slider> files = new List<Slider>();
            //foreach (string filePath in filePaths)
            //{
            //    string fileName = Path.GetFileName(filePath);
            //    files.Add(new Slider
            //    {
            //        title = fileName.Split('.')[0].ToString(),
            //        src = "../assets/img/" + fileName
            //    });
            //}

            return View();
        }

        [HttpPost]
        public JsonResult GetScientistById(int id)
        {
            try
            {
                Scientist _scien = new Scientist();
                _scien = db.Scientists.Find(id);
                return Json(_scien, JsonRequestBehavior.AllowGet);
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