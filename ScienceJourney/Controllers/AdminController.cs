using log4net;
using ScienceJourney.DAL;
using ScienceJourney.Models;
using System;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;

namespace ScienceJourney.Controllers
{
    public class AdminController : Controller
    {
        private ScienceJourneyEntities2 context = new ScienceJourneyEntities2();
        static ILog log = log4net.LogManager.GetLogger(typeof(ArtefactController));
        //
        // GET: /Admin/
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

        public JsonResult GetArticles()
        {
            try
            {
                var Articles = (from u in context.Articles
                                select new
                                {
                                    ArticleID = u.ArticleID,
                                    MuseumID = u.MuseumID,
                                    ScientistID = u.ScientistID,
                                    ArtefactID = u.ArtefactID,
                                    ArticleDescription = u.ArticleDescription,
                                    createTime = u.createTime
                                }).ToList();

                return Json(Articles, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                log.Info(String.Format("Exception occurred" + MethodBase.GetCurrentMethod()));
                log.Error(ex.Message);
            }
            return Json(null, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetScientist()
        {
            try
            {
                var Scientist = (from u in context.Scientists
                                 select new
                                 {
                                     ScientistID = u.ScientistID,
                                     FirstName = u.FirstName,
                                     LastName = u.LastName,
                                     MiddleName = u.MiddleName,
                                     CreateTime = u.createTime,
                                     AddressID = u.AddressID,
                                     Title = u.Title
                                 }).ToList();

                return Json(Scientist, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                log.Info(String.Format("Exception occurred" + MethodBase.GetCurrentMethod()));
                log.Error(ex.Message);
            }
            return Json(null, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetAddresses()
        {
            try
            {
                var Addresses = (from u in context.Addresses
                                 select new
                                 {
                                     AddressID = u.AddressID,
                                     City = u.City,
                                     PostCode = u.PostCode,
                                     Country_Province_State = u.Country_Province_State,
                                     Country = u.Country,
                                     OtherDetails = u.OtherDetails
                                 }).ToList();

                return Json(Addresses, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                log.Info(String.Format("Exception occurred" + MethodBase.GetCurrentMethod()));
                log.Error(ex.Message);
            }
            return Json(null, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult SaveScientist(AdminModel _model)
        {
            try
            {
                Scientist model = new Scientist();
                model.ScientistID = _model._Scientist.ScientistID;
                model.LastName = _model._Scientist.LastName;
                model.FirstName = _model._Scientist.FirstName;
                model.AddressID = _model._Scientist.AddressID;
                model.Title = _model._Scientist.Title;
                model.MiddleName = _model._Scientist.MiddleName;
                model.createTime = DateTime.Now;
                model.Picture = _model._Scientist.Picture;

                if (ModelState.IsValid)
                {
                    //Save Progcess
                    context.Scientists.Add(model);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                log.Info(String.Format("Exception occurred" + MethodBase.GetCurrentMethod()));
                log.Error(ex.Message);
            }
            return RedirectToAction("Index");
        }
    }

}