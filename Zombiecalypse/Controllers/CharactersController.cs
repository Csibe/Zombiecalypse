using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Zombiecalypse.DAL;
using Zombiecalypse.Models;

namespace Zombiecalypse.Controllers
{
    public class CharactersController : Controller
    {
        private DataContext db = new DataContext();


        [Authorize]
        public ActionResult CharacterDetails(string id)
        {
            if (id == null)
            {
                return View("Index", "Home");
            }
            else
            {
                Character character = db.Characters.Where(c => c.ApplicationUserID == id).FirstOrDefault();

                CharacterDetailsViewModel characterDetails = new CharacterDetailsViewModel();

                characterDetails.CharacterID = character.CharacterID;
                characterDetails.CharacterName = character.CharacterName;
                characterDetails.CharacterItems = character.Inventory;
                characterDetails.CharacterType = character.CharacterType;
                characterDetails.CharacterMaxLife = character.CharacterMaxLife;
                characterDetails.CharacterCurrentLife = character.CharacterCurrentLife;
                characterDetails.CharacterXP = character.CharacterXP;
                characterDetails.CharacterLevel = character.CharacterLevel;
                characterDetails.Adventures = db.Adventures.ToList();
                characterDetails.Levels = db.Levels.ToList();
                characterDetails.AttackingZombies = db.ZombieAttackBases.Where(x => x.CharacterID == character.CharacterID).ToList();

                characterDetails.CharacterNextLevelXP = characterDetails.Levels.Where(l => l.LevelID == characterDetails.CharacterLevel).FirstOrDefault().LevelMaxXP;
                var NeededXPToNextLevel = characterDetails.CharacterNextLevelXP - characterDetails.CharacterXP;
                ViewData["NeededXPToNextLevel"] = NeededXPToNextLevel;
                int HouseID = 0;
                int GarageID = 0;

                string Picture = "/Content/Pictures/Base/";
                ICollection<Inventory> characterInventory = character.Inventory;
                foreach (var charinv in characterInventory)
                {
                    if (charinv.Item.ItemType == "building")
                    {
                        Picture += charinv.Item.ItemName + charinv.Building.BuildingLevel;
                        if (charinv.Item.ItemName == "House")
                        {
                            HouseID = charinv.Item.ItemID;
                        }
                        if (charinv.Item.ItemName == "Garage")
                        {
                            GarageID = charinv.Item.ItemID;
                        }
                    }

                }
                Picture += ".png";

                ViewBag.Picture = Picture;
                ViewBag.HouseID = HouseID;
                ViewBag.GarageID = GarageID;


                return View(characterDetails);


            }


        }

        public ActionResult MaxDate(int? id)
        {
            Character character = db.Characters.Find(id);
            //   character.FinishAdventure = DateTime.MaxValue;

            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult AddToXP(int? id, int? add, string returnUrl)
        {

            Character character = db.Characters.Find(id);
            int CharLevel = character.CharacterLevel;
            int CharXP = character.CharacterXP;
            Level DbLevel = db.Levels.Where(x => x.LevelID == CharLevel).SingleOrDefault();
            int DbLevelLevel = DbLevel.LevelID;
            int DbLevelXP = DbLevel.LevelMaxXP;
            CharXP += (int)add;

            character.CharacterXP = CharXP;
            if (CharXP >= DbLevelXP)
            {
                CharLevel++;
                character.CharacterLevel = CharLevel;
            }
            ViewBag.Add = add;

            db.SaveChanges();
            return RedirectToAction(returnUrl);
        }


        public ActionResult AddToEnergy(int? id)
        {/*
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Character character = db.Characters.Find(id);
            if (character == null)
            {
                return HttpNotFound();
            }
            ViewBag.CharacterID = new SelectList(db.Users, "UserID", "UserName", character.CharacterID);
            if (character.CurrentEnergy < character.MaxEnergy)
            {
                character.CurrentEnergy++;
                db.SaveChanges();
            }*/
            return RedirectToAction("Index");
        }



        // GET: Characters
        /*  public ActionResult Index()
          {
              var characters = db.Characters.Include(c => c.User);
              return View(characters.ToList());
          }*/

        // GET: Characters/Details/5
        public ActionResult Details(int? id)
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

        // GET: Characters/Create
        public ActionResult Create()
        {
            //  ViewBag.CharacterID = new SelectList(db.Users, "UserID", "UserName");
            return View();
        }

        // POST: Characters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Create([Bind(Include = "ApplicationUserID, CharacterID,CharacterName,CharacterType,MaxEnergy,CurrentEnergy, CharacterXP, CharacterLevel, IsOnAdventure")] Character character)
        {
            if (ModelState.IsValid)
            {
                string id = User.Identity.Name;
                character.ApplicationUserID = id;
                character.CharacterLevel = 1;
                character.CharacterType = 1;
                character.CharacterMaxLife = 10;
                character.CharacterCurrentLife = 10;
                character.CharacterXP = 0;
                character.CharacterMoney = 0;
                character.CurrentEnergy = 14;
                character.MaxEnergy = 14;
                character.IsOnAdventure = false;
                character.FinishAdventure = DateTime.MaxValue;

                db.Characters.Add(character);

                var buildings = new List<Inventory>
                {
                new Inventory{ CharacterID=character.CharacterID, ItemID=2, ItemPieces=1},
                new Inventory{ CharacterID=character.CharacterID, ItemID=16, ItemPieces=1},
                new Inventory{ CharacterID=character.CharacterID, ItemID=22, ItemPieces=1},
                new Inventory{ CharacterID=character.CharacterID, ItemID=28, ItemPieces=1},
                new Inventory{ CharacterID=character.CharacterID, ItemID=53, ItemPieces=1}
                };
                buildings.ForEach(s => db.Inventories.Add(s));

                db.SaveChanges();
                return RedirectToAction("CharacterDetails", "Characters", new { id = User.Identity.Name });
            }

            return RedirectToAction("Index", "Home", null);
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
            //   ViewBag.CharacterID = new SelectList(db.Users, "UserID", "UserName", character.CharacterID);
            return View(character);
        }

        // POST: Characters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CharacterID,CharacterName,CharacterType,MaxEnergy,CurrentEnergy,UserID")] Character character)
        {
            if (ModelState.IsValid)
            {
                db.Entry(character).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            //   ViewBag.CharacterID = new SelectList(db.Users, "UserID", "UserName", character.CharacterID);
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
