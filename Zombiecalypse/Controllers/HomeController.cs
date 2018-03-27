using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Zombiecalypse.DAL;

namespace Zombicalypse.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            DataContext db = new DataContext();
            var id = User.Identity.GetUserId();
            
           // var character = db.Characters.Where(c => c.ApplicationUserID == id).FirstOrDefault().CharacterName;
            ViewBag.id = id;
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}