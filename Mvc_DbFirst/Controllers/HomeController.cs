using System.Web.Mvc;

namespace Mvc_DbFirst.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
    }
}