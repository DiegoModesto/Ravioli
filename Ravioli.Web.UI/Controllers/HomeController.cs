using System.Web.Mvc;

namespace Ravioli.Web.UI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View("Index");
        }

    }
}
