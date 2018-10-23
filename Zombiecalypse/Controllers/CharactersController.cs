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
        

        public ActionResult AddToEnergy()
        {
            Character character = db.Characters.Where(x => x.ApplicationUserID == User.Identity.Name).FirstOrDefault();
            character.CurrentEnergy++;
            db.SaveChanges();

            return RedirectToAction("Details", "Characters", new { id = User.Identity.Name });
        }

        public ActionResult SetLasLoginMinusMinute(string id)
        {
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


        public ActionResult ManageEnergy(string id, int energyCost, string returnUrl)
        {
            Character character = db.Characters.Where(x => x.ApplicationUserID == id).FirstOrDefault();

            if (character == null)
            {
                return HttpNotFound();
            }
            character.CurrentEnergy -= energyCost;


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



        public ActionResult ManageEnergyFromJavaScript(string id, string returnUrl)
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


        public ActionResult ManageXPAndLevelUp(int add, string returnUrl)
        {

            Character character = db.Characters.Where(x => x.ApplicationUserID == User.Identity.Name).FirstOrDefault(); ;
            Level DbLevel = db.Levels.Where(x => x.LevelID == character.CharacterLevel).SingleOrDefault();
            int DbLevelID = DbLevel.LevelID;
            int DbLevelXP = DbLevel.LevelMaxXP;
            character.CharacterXP += add;

            if (character.CharacterXP >= DbLevelXP)
            {
                character.CharacterLevel++;
            }

            db.SaveChanges();
            return RedirectToAction(returnUrl);
        }

        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return View("Index", "Home", null);
            }

            CharacterDetailsViewModel model = new CharacterDetailsViewModel();

            model.Character = db.Characters.Where(y => y.ApplicationUserID == User.Identity.Name).FirstOrDefault();
            model.CharacterBuildings = new List<Building>();

            foreach (var item in model.Character.Inventory)
            {
                foreach (var build in db.Buildings)
                {
                    if (item.ItemID == build.ItemID)
                    {
                        model.CharacterBuildings.Add(build);
                    }
                }
            }

            model.CharacterFields = db.CharacterFields.Where(x => x.CharacterID == model.Character.CharacterID).ToList();
            model.Adventures = db.Adventures.ToList();

            model.CharacterNextLevelXP = db.Levels.Where(l => l.LevelID == model.Character.CharacterLevel).FirstOrDefault().LevelMaxXP;

            string Picture = "/Content/Pictures/Base/";
            string[] BaseName;

            foreach (var build in model.CharacterBuildings)
            {
                BaseName = build.ItemName.Split(' ');
                Picture += BaseName[0] + build.BuildingLevel;
            }

            Picture += ".png";

            model.BasePicture = Picture;


            model.UserKe = db.Characters.Where(y => y.ApplicationUserID == User.Identity.Name).FirstOrDefault().ApplicationUserID;
            model.Fields = db.CharacterFields.Where(x => x.CharacterID == db.Characters.Where(y => y.ApplicationUserID == User.Identity.Name).FirstOrDefault().CharacterID).ToList();
            model.EnergyPlusDate = db.Characters.Where(y => y.ApplicationUserID == User.Identity.Name).FirstOrDefault().EnergyPlusDate;
            model.AttackingZombies = db.ZombieAttackBases.Where(x => x.CharacterID == db.Characters.Where(y => y.ApplicationUserID == User.Identity.Name).FirstOrDefault().CharacterID).ToList();
            model.AdventureFinishDate = db.Characters.Where(y => y.ApplicationUserID == User.Identity.Name).FirstOrDefault().FinishAdventure;

            return View(model);
        }

    }
}
