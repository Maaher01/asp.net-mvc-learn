using System.Collections.Generic;
using System.Web.Mvc;

namespace Day_06_Work_01.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            ViewBag.Author = "Maaher Hossain";
            ViewData["City"] = "Dhaka";

            return View( new List<Student> 
            { 
                new Student { Id = 1, Name = "John" },
                new Student { Id = 2, Name = "Jack" }
            });
        }
    }

    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}