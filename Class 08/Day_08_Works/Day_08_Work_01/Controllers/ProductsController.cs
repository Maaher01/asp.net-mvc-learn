using Day_08_Work_01.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Day_08_Work_01.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ProductDbContext db = new ProductDbContext();

        // GET: Products
        public ActionResult Index()
        {
            return View(db.Products.ToList());
        }

        public ActionResult Create()
        {
            ViewBag.Categories = db.Categories.ToList();
            return View();
        }

        [HttpPost]
        public ActionResult Create(Product p)
        {
            if(ModelState.IsValid)
            {
                db.Products.Add(p);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Edit(int id)
        {
            var product = db.Products.FirstOrDefault(x => x.ProductId == id);
            ViewBag.Categories = db.Categories.ToList();
            if(product == null) {
                return new HttpNotFoundResult();
            }
            return View(product);
        }

        [HttpPost]
        public ActionResult Edit(Product p)
        {
            if (ModelState.IsValid)
            {
                db.Entry(p).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}