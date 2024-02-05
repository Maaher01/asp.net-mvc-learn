using Day_07_Work_01.Models;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Day_07_Work_01.Controllers
{
    public class ProductsController : Controller
    {
        readonly StoreDbContext db = new StoreDbContext();

        // GET: Products
        public async Task<ActionResult> Index()
        {
            return View(await db.Products.ToListAsync());
        }
    }
}