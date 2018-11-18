using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Zombiecalypse.DAL;
using Zombiecalypse.Models;

namespace Zombiecalypse.Controllers
{
    public class HomeController : Controller
    {
        DataContext db = new DataContext();

        public ActionResult Index() {
            HomeViewModel model = new HomeViewModel();

            if (User.Identity.IsAuthenticated)
            {
                model.UserKe = db.Characters.Where(y => y.ApplicationUserID == User.Identity.Name).FirstOrDefault().ApplicationUserID;
                model.PageUrl = this.Request.FilePath;
                model.Fields = db.CharacterFields.Where(x => x.CharacterID == db.Characters.Where(y => y.ApplicationUserID == User.Identity.Name).FirstOrDefault().CharacterID).ToList();
                model.EnergyPlusDate = db.Characters.Where(y => y.ApplicationUserID == User.Identity.Name).FirstOrDefault().EnergyPlusDate;
                model.AttackingZombies = db.ZombieAttackBases.Where(x => x.CharacterID == db.Characters.Where(y => y.ApplicationUserID == User.Identity.Name).FirstOrDefault().CharacterID).ToList();
                model.AdventureFinishDate = db.Characters.Where(y => y.ApplicationUserID == User.Identity.Name).FirstOrDefault().FinishAdventure;
                model.LastZombieAttackDate = db.Characters.Where(y => y.ApplicationUserID == User.Identity.Name).FirstOrDefault().LastZombieAttackTime;

            }
            return View(model);
        }

    }
}
