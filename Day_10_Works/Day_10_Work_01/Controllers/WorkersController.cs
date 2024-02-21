using Day_10_Work_01.Models;
using Day_10_Work_01.ViewModels;
using Day_10_Work_01.ViewModels.Input;
using System;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Threading;
using System.Web.Mvc;

namespace Day_10_Work_01.Controllers
{
    public class WorkersController : Controller
    {
        private readonly WorkerDbContext db = new WorkerDbContext();
        // GET: Workers
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetWorkersTable(int page = 1)
        {
            Thread.Sleep(500);
            ViewBag.PageCount = (int)Math.Ceiling((double)db.Workers.Count() / 5);
            ViewBag.Current = page;
            var data = db.Workers
                .Select(w => new WorkerViewModel
                {
                    WorkerId = w.WorkerId,
                    Name = w.Name,
                    PayRate = w.PayRate,
                    Trade = w.Trade,
                    StartDate = w.StartDate,
                    EndDate = w.EndDate,
                    Picture = w.Picture,
                    Contact = w.Contact
                }).OrderBy(x => x.WorkerId).Skip((page - 1) * 5).Take(5).ToList();
            return PartialView("_WorkersTable", data);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(WorkerInputModel model)
        {
            if (ModelState.IsValid)
            {
                var worker = new Worker
                {
                    Name = model.Name,
                    Contact = model.Contact,
                    Trade = model.Trade,
                    StartDate = model.StartDate,
                    EndDate = model.EndDate,
                    PayRate = model.PayRate

                };
                string ext = Path.GetExtension(model.Picture.FileName);
                string fileName = Path.GetFileNameWithoutExtension(Path.GetRandomFileName()) + ext;
                string savePath = Path.Combine(Server.MapPath("~/Pictures"), fileName);
                model.Picture.SaveAs(savePath);
                worker.Picture = fileName;
                db.Workers.Add(worker);
                db.SaveChanges();
                return PartialView("_Success");
            }
            return PartialView("_Fail");
        }
        public ActionResult Edit(int id)
        {
            var worker = db.Workers.FirstOrDefault(x => x.WorkerId == id);
            if (worker == null) { return new HttpNotFoundResult(); }
            var model = new WorkerEditModel
            {
                WorkerId = id,
                Name = worker.Name,
                Contact = worker.Contact,
                Trade = worker.Trade,
                StartDate = worker.StartDate,
                EndDate = worker.EndDate,
                PayRate = worker.PayRate
            };
            ViewBag.CurrentPic = worker.Picture;
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(WorkerEditModel model)
        {
            var worker = db.Workers.FirstOrDefault(x => x.WorkerId == model.WorkerId);
            if (worker == null) { return new HttpNotFoundResult(); }

            if(ModelState.IsValid)
            {
               
                worker.Name = model.Name;
                worker.Contact = model.Contact;
                worker.Trade = model.Trade;
                worker.StartDate = model.StartDate;
                worker.EndDate = model.EndDate;
                worker.PayRate = model.PayRate;
                if(model.Picture!= null)
                {
                    string ext = Path.GetExtension(model.Picture.FileName);
                    string fileName = Path.GetFileNameWithoutExtension(Path.GetRandomFileName()) + ext;
                    string savePath = Path.Combine(Server.MapPath("~/Pictures"), fileName);
                    model.Picture.SaveAs(savePath);
                    worker.Picture = fileName;
                }
                db.SaveChanges();
                return PartialView("_Success");
            }

            ViewBag.CurrentPic = worker.Picture;
            return PartialView("_Fail");
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var worker = db.Workers.FirstOrDefault(x=> x.WorkerId == id);
            if (worker == null) { return new HttpNotFoundResult(); }
            return Json(new { success=true, message="Data deleted" });
        }
        //[HttpPost, ActionName("Delete")]
        //public ActionResult DoDelete(int id)
        //{
        //    var worker = new Worker { WorkerId = id };
        //    db.Entry(worker).State = EntityState.Deleted;
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}
    }
}