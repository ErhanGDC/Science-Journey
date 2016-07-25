using log4net;
using ScienceJourney.DAL;
using System;
using System.Linq;
using System.Web.Mvc;

namespace ScienceJourney.Controllers
{
    public class MuseumController : Controller
    {
        private ScienceJourneyEntities2 context = new ScienceJourneyEntities2();
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
                                   OpeningHours = u.OpeningHours
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