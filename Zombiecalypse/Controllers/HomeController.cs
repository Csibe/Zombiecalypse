using System.Web.Mvc;

namespace Zombiecalypse.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index() {
            return View();
        }

    }
}
