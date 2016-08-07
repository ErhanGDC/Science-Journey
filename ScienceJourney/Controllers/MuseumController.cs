using log4net;
using ScienceJourney.DAL;
using System;
using System.Linq;
using System.Web.Mvc;


namespace ScienceJourney.Controllers
{
    public class MuseumController : Controller
    {
        private ScienceJourneyEntities context = new ScienceJourneyEntities();
        static ILog log = log4net.LogManager.GetLogger(typeof(HomeController));
        //
        // GET: /Museum/
        public ActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpGet]
        public JsonResult GetMuseums()
        {
            try
            {
                var museums = (from u in context.Museums
                               select new
                               {
                                   AnnualVisitorCount = u.AnnualVisitorCount,
                                   MuseumDescription = u.MuseumDescription,
                                   MuseumName = u.MuseumName,
                                   OpeningHours = u.OpeningHours.Value.ToString(),
                                   Shop=u.Shop,
                                   Smoking=u.Smoking,
                                   DateBuilt=u.DateBuilt.Value.ToString(),
                                   Picture = u.Picture
                               }).ToList();



                return Json(museums, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                log.Info(String.Format("Exception occurred"));
                log.Error(ex.Message);
            }
            return Json(null, JsonRequestBehavior.AllowGet);
        }

        [AllowAnonymous]
        [HttpGet]
        public JsonResult GetPicturePath()
        {
            try
            {
                var picturePaths = (from p in context.UploadedFiles
                                    select new
                                    {
                                        FilePath = p.FilePath,
                                        FileID = p.FileID,
                                        FileName = p.FileName,
                                        FileSize = p.FileSize,
                                        Description = p.Description
                                    }).ToList();

                return Json(picturePaths, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                log.Info(String.Format("Exception occurred"));
                log.Error(ex.Message);
            }
            return Json(null, JsonRequestBehavior.AllowGet);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                context.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}