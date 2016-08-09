using log4net;
using ScienceJourney.DAL;
using ScienceJourney.Models;
using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;

namespace ScienceJourney.Controllers
{
    public class AdminController : Controller
    {
        private ScienceJourneyEntities context = new ScienceJourneyEntities();
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
        public ActionResult SaveScientist(AdminModel model, string description)
        {
            UploadedFile f = null;
            string Message, fileName, actualFileName;
            Message = fileName = actualFileName = string.Empty;
            bool flag = false;
            if (Request.Files != null)
            {
                var file = Request.Files[0];
                actualFileName = file.FileName;
                fileName = Guid.NewGuid() + Path.GetExtension(file.FileName);
                int size = file.ContentLength;

                try
                {
                    file.SaveAs(Path.Combine(Server.MapPath("~/UploadedFiles"), fileName));

                    f = new UploadedFile
                   {

                       FileName = actualFileName,
                       FilePath = fileName,
                       Description = description,
                       FileSize = size
                   };
                    using (ScienceJourneyEntities dc = new ScienceJourneyEntities())
                    {
                        dc.UploadedFiles.Add(f);
                        dc.SaveChanges();
                        Message = "File uploaded successfully";
                        flag = true;

                        //Scientist scientist = model.Scientist;
                        //scientist.Picture = f.FilePath;

                        //if (ModelState.IsValid)
                        //{
                        //    //Save Progcess
                        //    context.Scientists.Add(scientist);
                        //    context.SaveChanges();
                        //}
                    }
                    flag = true;
                }
                catch (Exception ex)
                {
                    Message = "File upload failed! Please try again";
                    log.Info(String.Format("Exception occurred" + MethodBase.GetCurrentMethod()));
                    log.Error(ex.Message);
                }

            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult SaveArtefact(AdminModel model)
        {
            try
            {
                Artefact artefact = model.Artefact;
                if (ModelState.IsValid)
                {
                    //Save Progcess
                    context.Artefacts.Add(artefact);
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
        [HttpPost]
        public ActionResult SaveMuseums(AdminModel model)
        {
            try
            {
                Museum museum = model.Museum;
                if (ModelState.IsValid)
                {
                    //Save Progcess
                    context.Museums.Add(museum);
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
        [HttpPost]
        public ActionResult SaveArticles(AdminModel model)
        {
            try
            {
                Article article = model.Article;
                if (ModelState.IsValid)
                {
                    //Save Progcess
                    context.Articles.Add(article);
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
        [HttpPost]
        public ActionResult SaveAddresses(AdminModel model)
        {
            try
            {
                Address address = model.Address;
                if (ModelState.IsValid)
                {
                    //Save Progcess
                    context.Addresses.Add(address);
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

        [HttpPost]
        public JsonResult SaveFiles(string description)
        {
            string Message, fileName, actualFileName;
            Message = fileName = actualFileName = string.Empty;
            bool flag = false;
            if (Request.Files != null)
            {
                var file = Request.Files[0];
                actualFileName = file.FileName;
                fileName = Guid.NewGuid() + Path.GetExtension(file.FileName);
                int size = file.ContentLength;

                try
                {
                    file.SaveAs(Path.Combine(Server.MapPath("~/UploadedFiles"), fileName));

                    UploadedFile f = new UploadedFile
                    {

                        FileName = actualFileName,
                        FilePath = fileName,
                        Description = description,
                        FileSize = size
                    };
                    using (ScienceJourneyEntities dc = new ScienceJourneyEntities())
                    {
                        dc.UploadedFiles.Add(f);
                        dc.SaveChanges();
                        Message = "File uploaded successfully";
                        flag = true;
                    }
                    flag = true;
                }
                catch (Exception ex)
                {
                    Message = "File upload failed! Please try again";
                }

            }
            return new JsonResult { Data = new { Message = Message, Status = flag } };
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