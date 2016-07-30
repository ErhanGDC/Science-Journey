using log4net;
using ScienceJourney.DAL;
using ScienceJourney.Models;
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

        public JsonResult GetArtefacts()
        {
            try
            {
                var artefacts = (from u in context.Artefacts
                                 select new
                                 {
                                     ArtefactName = u.ArtefactName,
                                     ArtefactDescription = u.ArtefactDescription,
                                     ArtefactID = u.ArtefactID
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

        [HttpPost]
        public ActionResult SaveArtefact(ArtefactViewModel _viewModel)
        {
            try
            {
                Artefact model = new Artefact();
                model.ArtefactDescription = _viewModel.ArtefactDescription;
                model.ArtefactName = _viewModel.ArtefactName;
                model.MuseumID = _viewModel.MuseumID;

                if (ModelState.IsValid)
                {
                    //Save Progcess
                    context.Artefacts.Add(model);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                log.Info(String.Format("Exception occurred"));
                log.Error(ex.Message);
            }
            return RedirectToAction("Index");
        }
    }
}
