using OAUGuideBook.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OAUGuideBook.Controllers
{
    public class HomeController : Controller
    {

        OAUGuideBookDBEntities Db = new OAUGuideBookDBEntities();
        const int recordsPerPage = 8;
        public ActionResult Index()
        {
           
            return View();


         
        }

         [HttpPost]

        public ActionResult Index(GuideBookModel mode)
        {
        List<GuideBookModel> GuideList = new List<GuideBookModel>();
            var r = Db.OAUGuideBookTables.Where(emp => emp.Title.Contains(mode.Search) || emp.ContentDescription.Contains(mode.Search) ).ToList();
            foreach (var a in r)
            {
                GuideBookModel model = new GuideBookModel();

                model.ContentId = a.ContentId;
                model.Title = a.Title;
                model.ContentDescription = a.ContentDescription;
                model.ContentPicture = a.ContentPicture;
                model.ContentVideo = a.ContentVideo;
                GuideList.Add(model);

            }
            mode.OAUGuideList = GuideList;

            return View(mode);
        }
        
        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

      
        public ActionResult UserPage(int? id)
        {
            GuideBookListModel model = new GuideBookListModel();
            var GuideList = OAUGuideDetail();
            model.OAUGuideListCollction = GuideList;
            return View(model);

        }

     
       

        public List<GuideBookModel> OAUGuideDetail()
        {
            List<GuideBookModel> OAUGuideBookList = new List<GuideBookModel>();

            List<OAUGuideBookTable> OAUGuideList = Db.OAUGuideBookTables.OrderBy(m => m.Title).ToList();
            foreach (var a in OAUGuideList)
            {
                GuideBookModel model = new GuideBookModel();
                model.ContentId = a.ContentId;
                model.Title = a.Title;
                model.ContentDescription = a.ContentDescription;
                model.ContentPicture = a.ContentPicture;
                model.ContentVideo = a.ContentVideo;


                OAUGuideBookList.Add(model);

            }
            return OAUGuideBookList;
        }

        [HttpPost]
        public ActionResult UserPage(GuideBookModel mode)
        {

            List<GuideBookModel> GuideList = new List<GuideBookModel>();
            var r = Db.OAUGuideBookTables.Where(emp => emp.Title.Contains(mode.Search) || emp.ContentDescription.Contains(mode.Search) ).ToList();
            foreach (var a in r)
            {
                GuideBookModel model = new GuideBookModel();

                model.ContentId = a.ContentId;
                model.Title = a.Title;
                model.ContentDescription = a.ContentDescription;
                model.ContentPicture = a.ContentPicture;
                model.ContentVideo = a.ContentVideo;
                GuideList.Add(model);

            }
            mode.OAUGuideList = GuideList;

            return View(mode);
        }

     
        public ActionResult SearchPage()
        {

            GuideBookModel model = new GuideBookModel();
            var GuideList = OAUGuide();
            model.OAUGuideList = GuideList;
            return View(model);
        }

        [HttpPost]
        public ActionResult SearchPage(GuideBookModel mode)
        {

            List<GuideBookModel> GuideList = new List<GuideBookModel>();
            var r = Db.OAUGuideBookTables.Where(emp => emp.Title.Contains(mode.Search) || emp.ContentDescription.Contains(mode.Search)).ToList();
            foreach (var a in r)
            {
                GuideBookModel model = new GuideBookModel();

                model.ContentId = a.ContentId;
                model.Title = a.Title;
                model.ContentDescription = a.ContentDescription;
                model.ContentPicture = a.ContentPicture;
                model.ContentVideo = a.ContentVideo;

                GuideList.Add(model);

            }
            mode.OAUGuideList = GuideList;

            return View(mode);
        }
        public List<GuideBookModel> OAUGuide()
        {
            List<GuideBookModel> OAUGuideList = new List<GuideBookModel>();
            List<OAUGuideBookTable> GuideList = Db.OAUGuideBookTables.OrderByDescending(x => x.ContentId).ToList();

            foreach (var a in GuideList)
            {
                GuideBookModel model = new GuideBookModel();

                model.ContentId = a.ContentId;
                model.Title = a.Title;
                model.ContentDescription = a.ContentDescription;
                model.ContentPicture = a.ContentPicture;
                model.ContentVideo = a.ContentVideo;

                OAUGuideList.Add(model);

            }
            return OAUGuideList;
        }

        public ActionResult CreateRecord()
        {
            GuideBookModel record = new GuideBookModel();
            return View(record);
        }

        [HttpPost]

        public ActionResult CreateRecord(GuideBookModel model)
        {


            if (ModelState.IsValid)
            {

                OAUGuideBookTable create = new OAUGuideBookTable();

                create.ContentId = model.ContentId;
                create.Title = model.Title;
                create.ContentDescription = model.ContentDescription;
                create.ContentPicture = model.ContentPicture;
                create.ContentVideo = model.ContentVideo;
                create.ContentDate = DateTime.Today;
                create.ContentApproval = false;
                


                Db.OAUGuideBookTables.Add(create);

                try
                {
                    Db.SaveChanges();
                    TempData["Success"] = "Content successfully added";

                }

                catch (DbEntityValidationException dbEx)
                {
                    foreach (var validationErrors in dbEx.EntityValidationErrors)
                    {
                        foreach (var validationError in validationErrors.ValidationErrors)
                        {
                            Trace.TraceInformation("Property: {0} Error: {1}",
                                                    validationError.PropertyName,
                                                    validationError.ErrorMessage);
                        }
                    }
                }
                return RedirectToAction("UserPage");

            }
            else
            {

                ModelState.AddModelError("", "Fill necessary fields");

                return View(model);


            }

        }

        public ActionResult ViewDetails(int Id)
        {


            var a = Db.OAUGuideBookTables.Where(x => x.ContentId == Id).SingleOrDefault();


            GuideBookModel model = new GuideBookModel();

            model.ContentId = Id;
            model.Title = a.Title;
            model.ContentDescription = a.ContentDescription;
            model.ContentPicture = a.ContentPicture;
            model.ContentVideo = a.ContentVideo;
           

            return View(model);
        }
        //Get
       
        public ActionResult Edit(int Id)
        {


            var a = Db.OAUGuideBookTables.Where(x => x.ContentId == Id).SingleOrDefault();


            GuideBookModel model = new GuideBookModel();

            model.ContentId = a.ContentId;
            model.Title = a.Title;
            model.ContentDescription = a.ContentDescription;
            model.ContentPicture = a.ContentPicture;
            model.ContentVideo = a.ContentVideo;
            


            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(GuideBookModel model)
        {

                OAUGuideBookTable create = new OAUGuideBookTable();

                create.ContentId = model.ContentId;
                create.Title = model.Title;
                create.ContentDescription = model.ContentDescription;
                create.ContentPicture = model.ContentPicture;
                create.ContentVideo = model.ContentVideo;
                create.ContentDate = DateTime.Today;
                create.ContentApproval = false;
                


               


            Db.Entry(create).State = EntityState.Modified;
            try
            {
                Db.SaveChanges();
                TempData["Success"] = "Content sucessfully edited!";

                return RedirectToAction("Edit");

            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        Trace.TraceInformation("Property: {0} Error: {1}",
                                                validationError.PropertyName,
                                                validationError.ErrorMessage);
                    }
                }
            }

            return RedirectToAction("Edit");

        }

    

    

      
    }
}
