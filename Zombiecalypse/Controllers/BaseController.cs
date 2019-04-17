using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Zombiecalypse.DAL;
using Zombiecalypse.Models;

namespace Zombiecalypse.Controllers
{

    [Authorize]
    public class BaseController : Controller
    {
        protected DataContext db = new DataContext();


        protected void SetModelProperties(ViewModelBase model)
        {

            if (User.Identity.IsAuthenticated)
            {

                model.Character = db.Characters.Where(y => y.ApplicationUserID == User.Identity.Name).FirstOrDefault();
                model.UserKe = db.Characters.Where(y => y.ApplicationUserID == User.Identity.Name).FirstOrDefault().ApplicationUserID;
                model.PageUrl = this.Request.FilePath;
                model.Fields = db.CharacterFields.Where(x => x.CharacterID == db.Characters.Where(y => y.ApplicationUserID == User.Identity.Name).FirstOrDefault().CharacterID).ToList();
                model.EnergyPlusDate = db.Characters.Where(y => y.ApplicationUserID == User.Identity.Name).FirstOrDefault().EnergyPlusDate;
                model.AttackingZombies = db.ZombieAttackBases.Where(x => x.CharacterID == db.Characters.Where(y => y.ApplicationUserID == User.Identity.Name).FirstOrDefault().CharacterID).ToList();
                model.AdventureFinishDate = db.Characters.Where(y => y.ApplicationUserID == User.Identity.Name).FirstOrDefault().FinishAdventure;
                model.LastZombieAttackDate = db.Characters.Where(y => y.ApplicationUserID == User.Identity.Name).FirstOrDefault().LastZombieAttackTime;
                model.DailyMissionDate = db.Characters.Where(x => x.ApplicationUserID == User.Identity.Name).FirstOrDefault().DailyMissionDate;
                model.ToleranceFinishDate = db.Characters.Where(x => x.ApplicationUserID == User.Identity.Name).FirstOrDefault().TolerancePlusDate;
            }

        }
    }
}