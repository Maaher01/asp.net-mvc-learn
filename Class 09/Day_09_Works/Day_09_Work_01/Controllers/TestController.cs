using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Day_09_Work_01.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Test1(int id) 
        {
            return View(id);
        }

        [HttpPost]
        public ActionResult Test2(List<int> x) 
        {
            return View(x);
        }

        [HttpPost]
        public ActionResult Test3(Test x)
        {
            return View(x);
        }
    }

    public class Test
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
}