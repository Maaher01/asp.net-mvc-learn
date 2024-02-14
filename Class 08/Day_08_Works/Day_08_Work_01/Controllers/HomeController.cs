using Day_08_Work_01.Models;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace Day_08_Work_01.Controllers
{
    public class HomeController : Controller
    {
        private readonly ProductDbContext db = new ProductDbContext();

        // GET: Home
        public ActionResult Index()
        {
            return View(db.Categories.Include(x => x.Products).ToList());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Category c)
        {
            if(ModelState.IsValid)
            {
                db.Categories.Add(c);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(c);
        }

        public ActionResult Edit(int id)
        {
            var category = db.Categories.FirstOrDefault(x => x.CategoryId == id);
            if(category == null)
            {
                return new HttpNotFoundResult();
            }
            return View(category);
        }

        [HttpPost]
        public ActionResult Edit(Category c)
        {
            if (ModelState.IsValid)
            {
                db.Entry(c).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(c);
        }
    }
}