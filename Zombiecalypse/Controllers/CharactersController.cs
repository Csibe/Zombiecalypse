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
            return View(db.Characters.ToList());
        }

        // GET: Characters/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return View("Index", "Home");
            }
            else
            {
                Character character = db.Characters.Where(c => c.ApplicationUserID == id).FirstOrDefault();

                if (character != null)
                {

                    CharacterDetailsViewModel characterDetails = new CharacterDetailsViewModel();

                    characterDetails.CharacterID = character.CharacterID;
                    characterDetails.CharacterMoney = character.CharacterMoney;
                    characterDetails.CharacterName = character.CharacterName;
                    characterDetails.CharacterItems = character.Inventory;
                    characterDetails.CharacterType = character.CharacterType;
                    characterDetails.CurrentEnergy = character.CurrentEnergy;
                    characterDetails.MaxEnergy = character.MaxEnergy;
                    characterDetails.CharacterXP = character.CharacterXP;
                    characterDetails.CharacterLevel = character.CharacterLevel;
                    characterDetails.CharacterBuildings = new List<Building>();

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


                    //characterDetails.Adventures = db.Adventures.ToList();
                    //characterDetails.Levels = db.Levels.ToList();
                    characterDetails.CharacterFood = character.CharacterFood;
                    //characterDetails.AttackingZombies = db.ZombieAttackBases.Where(x => x.CharacterID == character.CharacterID).ToList();

                    //characterDetails.CharacterNextLevelXP = characterDetails.Levels.Where(l => l.LevelID == characterDetails.CharacterLevel).FirstOrDefault().LevelMaxXP;
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

                    return View(characterDetails);
                }
            }
            return View("Index", "Home");
        }

        // GET: Characters/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Characters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CharacterID,ApplicationUserID,CharacterName,CharacterType,CharacterMoney,MaxEnergy,CurrentEnergy,CharacterFood,CharacterXP,CharacterLevel,IsOnAdventure,AdventureID,AdventureState,FinishAdventure")] Character character)
        {
            if (ModelState.IsValid)
            {
                db.Characters.Add(character);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(character);
        }

        // GET: Characters/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Character character = db.Characters.Find(id);
            if (character == null)
            {
                return HttpNotFound();
            }
            return View(character);
        }

        // POST: Characters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CharacterID,ApplicationUserID,CharacterName,CharacterType,CharacterMoney,MaxEnergy,CurrentEnergy,CharacterFood,CharacterXP,CharacterLevel,IsOnAdventure,AdventureID,AdventureState,FinishAdventure")] Character character)
        {
            if (ModelState.IsValid)
            {
                db.Entry(character).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(character);
        }

        // GET: Characters/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Character character = db.Characters.Find(id);
            if (character == null)
            {
                return HttpNotFound();
            }
            return View(character);
        }

        // POST: Characters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Character character = db.Characters.Find(id);
            db.Characters.Remove(character);
            db.SaveChanges();
            return RedirectToAction("Index");
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
