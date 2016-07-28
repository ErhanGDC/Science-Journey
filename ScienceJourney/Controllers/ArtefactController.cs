using log4net;
using ScienceJourney.DAL;
using System;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;

namespace ScienceJourney.Controllers
{
    public class ArtefactController : Controller
    {
        private ScienceJourneyEntities2 context = new ScienceJourneyEntities2();
        static ILog log = log4net.LogManager.GetLogger(typeof(ArtefactController));
        //
        // GET: /Artefact/
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetArtefactsByMuseumId(int museumId)
        {
            try
            {
                var artefacts = (from u in context.Artefacts
                                 where u.MuseumID == museumId
                                 select new
                                 {
                                     ArtefactName = u.ArtefactName,
                                     ArtefactDescription = u.ArtefactDescription,
                                     ArtefactID = u.ArtefactID,
                                     MuseumID = u.MuseumID
                                 }).ToList();

                return Json(artefacts, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                log.Info(String.Format("Exception occurred" + MethodBase.GetCurrentMethod()));
                log.Error(ex.Message);
            }
            return Json(null, JsonRequestBehavior.AllowGet);
        }

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
                                   OpeningHours = u.OpeningHours,
                                   MuseumID = u.MuseumID
                               }).ToList();

                return Json(museums, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                log.Info(String.Format("Exception occurred" + MethodBase.GetCurrentMethod()));
                log.Error(ex.Message);
            }
            return Json(null, JsonRequestBehavior.AllowGet);
        }
    }
}