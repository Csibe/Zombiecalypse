using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Zombiecalypse.DAL;
using Zombiecalypse.Models;

namespace Zombiecalypse.Controllers
{
    public class HomeController : BaseController
    {

        public ActionResult Index()
        {
            HomeViewModel model = new HomeViewModel();


            base.SetModelProperties(model);
            return View(model);
        }

    }
}
