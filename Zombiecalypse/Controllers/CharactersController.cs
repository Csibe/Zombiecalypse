using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Zombiecalypse.DAL;
using Zombiecalypse.Models;

namespace Zombiecalypse.Controllers
{
    public class CharactersController : Controller
    {
        private DataContext db = new DataContext();

        // GET: Characters
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SetLasLoginMinusMinute(string id) {
            Character character = db.Characters.Where(x => x.ApplicationUserID == id).FirstOrDefault();
            if (character == null)
            {
                return HttpNotFound();
            }
            character.LastLogin = character.LastLogin.AddMinutes(-1);
            db.SaveChanges();
            return RedirectToAction("Details", "Characters", new { id = User.Identity.Name });
        }

        public ActionResult SetLasLoginMinusHour(string id)
        {
            Character character = db.Characters.Where(x => x.ApplicationUserID == id).FirstOrDefault();
            if (character == null)
            {
                return HttpNotFound();
            }
            character.LastLogin = character.LastLogin.AddHours(-1);
            db.SaveChanges();
            return RedirectToAction("Details", "Characters", new { id = User.Identity.Name });
        }


        public ActionResult DoSomething(string id, string returnUrl)
        {
            Character character = db.Characters.Where(x => x.ApplicationUserID == id).FirstOrDefault();
            if (character == null)
            {
                return HttpNotFound();
            }
            character.CurrentEnergy--;
           

            if (character.CurrentEnergy == character.MaxEnergy && character.EnergyPlusDate.Year == DateTime.MaxValue.Year)
            {
            }
            else if (character.CurrentEnergy < character.MaxEnergy && character.EnergyPlusDate.Year == DateTime.MaxValue.Year)
            {
                character.EnergyPlusDate = DateTime.Now.AddSeconds(20);
            }
            else if (character.CurrentEnergy == character.MaxEnergy && character.EnergyPlusDate.Year < DateTime.MaxValue.Year)
            {
                character.EnergyPlusDate = DateTime.MaxValue;
            }
            else if (character.CurrentEnergy < character.MaxEnergy && character.EnergyPlusDate <= DateTime.Now)
            {
                character.EnergyPlusDate = DateTime.Now.AddSeconds(20);
                character.CurrentEnergy++;
            }
            else if (character.CurrentEnergy < character.MaxEnergy && character.EnergyPlusDate > DateTime.Now)
            {
            }
            else if (character.CurrentEnergy < character.MaxEnergy && character.EnergyPlusDate < DateTime.Now)
            {

                character.CurrentEnergy++;
                character.EnergyPlusDate = DateTime.MaxValue;
            }

            db.SaveChanges();
            return RedirectToAction(returnUrl);
        }



        public ActionResult CheckEnergyFromJavaScript(string id)
        {
            Character character = db.Characters.Where(x => x.ApplicationUserID == id).FirstOrDefault();
            if (character == null)
            {
                return HttpNotFound();
            }

            if (character.CurrentEnergy == character.MaxEnergy && character.EnergyPlusDate == DateTime.MaxValue)
            {
            }
            else if (character.CurrentEnergy < character.MaxEnergy && character.EnergyPlusDate == DateTime.MaxValue)
            {
                character.EnergyPlusDate = DateTime.Now.AddSeconds(20);
            }
            else if (character.CurrentEnergy == character.MaxEnergy && character.EnergyPlusDate.Year < DateTime.MaxValue.Year)
            {
                character.EnergyPlusDate = DateTime.MaxValue;
            }
            else if (character.CurrentEnergy < character.MaxEnergy && character.EnergyPlusDate <= DateTime.Now)
            {
                character.EnergyPlusDate = DateTime.Now.AddSeconds(20);
                character.CurrentEnergy++;
            }
            else if (character.CurrentEnergy < character.MaxEnergy && character.EnergyPlusDate > DateTime.Now)
            {
            }
            else if (character.CurrentEnergy < character.MaxEnergy && character.EnergyPlusDate < DateTime.Now)
            {

                character.CurrentEnergy++;
                character.EnergyPlusDate = DateTime.MaxValue;
            }

            db.SaveChanges();
            return RedirectToAction("Details", "Characters", new { id = User.Identity.Name });
            //return RedirectToAction(returnUrl);
        }


        public ActionResult ManageXPAndLevelUp(string id, int? add, string returnUrl)
        {

            Character character = db.Characters.Where(x => x.ApplicationUserID == id).FirstOrDefault(); ;
            Level DbLevel = db.Levels.Where(x => x.LevelID == character.CharacterLevel).SingleOrDefault();
            int DbLevelLevel = DbLevel.LevelID;
            int DbLevelXP = DbLevel.LevelMaxXP;
            character.CharacterXP += (int)add;

            if (character.CharacterXP >= DbLevelXP)
            {
                character.CharacterLevel++;
            }

            db.SaveChanges();
            return RedirectToAction(returnUrl);
        }

        // GET: Characters/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return View("Index", "Home", null);
            }

            Character character = db.Characters.Where(c => c.ApplicationUserID == id).FirstOrDefault();

            CharacterDetailsViewModel characterDetails = new CharacterDetailsViewModel();

            characterDetails.CharacterID = character.CharacterID;
            characterDetails.ApplicationUserID = character.ApplicationUserID;
            characterDetails.CharacterMoney = character.CharacterMoney;
            characterDetails.CharacterName = character.CharacterName;
            characterDetails.CharacterItems = character.Inventory;
            characterDetails.CharacterType = character.CharacterType;
            characterDetails.CurrentEnergy = character.CurrentEnergy;
            characterDetails.MaxEnergy = character.MaxEnergy;
            characterDetails.CharacterXP = character.CharacterXP;
            characterDetails.CharacterLevel = character.CharacterLevel;
            characterDetails.CharacterBuildings = new List<Building>();
            characterDetails.AdventureID = character.AdventureID;
            characterDetails.LastLogin = character.LastLogin;

            foreach (var item in characterDetails.CharacterItems)
            {
                foreach (var build in db.Buildings)
                {
                    if (item.ItemID == build.ItemID)
                    {
                        characterDetails.CharacterBuildings.Add(build);
                    }
                }
            }

            characterDetails.CharacterFields = db.CharacterFields.Where(x => x.CharacterID == character.CharacterID).ToList();

            characterDetails.Adventures = db.Adventures.ToList();
            characterDetails.CharacterFood = character.CharacterFood;


            characterDetails.CharacterNextLevelXP = db.Levels.Where(l => l.LevelID == characterDetails.CharacterLevel).FirstOrDefault().LevelMaxXP;
            var NeededXPToNextLevel = characterDetails.CharacterNextLevelXP - characterDetails.CharacterXP;
            ViewData["NeededXPToNextLevel"] = NeededXPToNextLevel;

            string Picture = "/Content/Pictures/Base/";
            ICollection<Inventory> characterInventory = character.Inventory;
            foreach (var build in characterDetails.CharacterBuildings)
            {
                Picture += build.ItemName + build.BuildingLevel;

            }
            Picture += ".png";

            ViewBag.Picture = Picture;


            characterDetails.PageName = db.Characters.Where(y => y.ApplicationUserID == User.Identity.Name).FirstOrDefault().ApplicationUserID;
            characterDetails.Fields = db.CharacterFields.Where(x => x.CharacterID == db.Characters.Where(y => y.ApplicationUserID == User.Identity.Name).FirstOrDefault().CharacterID).ToList();
            characterDetails.EnergyPlusDate = db.Characters.Where(y => y.ApplicationUserID == User.Identity.Name).FirstOrDefault().EnergyPlusDate;
            characterDetails.AttackingZombies = db.ZombieAttackBases.Where(x => x.CharacterID == db.Characters.Where(y => y.ApplicationUserID == User.Identity.Name).FirstOrDefault().CharacterID).ToList();
            characterDetails.AdventureFinishDate = db.Characters.Where(y => y.ApplicationUserID == User.Identity.Name).FirstOrDefault().FinishAdventure;

            return View(characterDetails);
    }


    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            db.Dispose();
        }
        base.Dispose(disposing);
    }
}
}
