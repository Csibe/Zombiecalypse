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
    public class AdventuresController : Controller
    {
        private DataContext db = new DataContext();


        public ActionResult AdventureCounter(int AdId, int ChId)
        {
            AdventureViewModel adventureViewModel = new AdventureViewModel();

            adventureViewModel.Character = db.Characters.Find(ChId);
            adventureViewModel.Adventure = db.Adventures.Find(AdId);

            adventureViewModel.PageName = db.Characters.Where(y => y.ApplicationUserID == User.Identity.Name).FirstOrDefault().ApplicationUserID;
            adventureViewModel.Fields = db.CharacterFields.Where(x => x.CharacterID == db.Characters.Where(y => y.ApplicationUserID == User.Identity.Name).FirstOrDefault().CharacterID).ToList();
            adventureViewModel.EnergyPlusDate = db.Characters.Where(y => y.ApplicationUserID == User.Identity.Name).FirstOrDefault().EnergyPlusDate;
            adventureViewModel.AttackingZombies = db.ZombieAttackBases.Where(x => x.CharacterID == db.Characters.Where(y => y.ApplicationUserID == User.Identity.Name).FirstOrDefault().CharacterID).ToList();
            adventureViewModel.AdventureFinishDate = db.Characters.Where(y => y.ApplicationUserID == User.Identity.Name).FirstOrDefault().FinishAdventure;

            return View(adventureViewModel);
        }

        public ActionResult AttackZombie(int zAAID, int invID)
        {
            Character character = db.Characters.Where(y => y.ApplicationUserID == User.Identity.Name).FirstOrDefault();
            ZombieAttackAdventurer zAA = db.ZombieAttackAdventurers.Find(zAAID);
            zAA.Zombie = db.Zombies.Find(zAA.ZombieID);
            Inventory item = db.Inventories.Find(invID);
            Weapon weapon = db.Weapons.Find(item.ItemID);

            var inv = db.Inventories.Find(invID);
            if (inv.ItemCurrentDurability > 1 && inv.ItemMaxDurability != 999)
            {
                inv.ItemCurrentDurability--;
            }
            else if (inv.ItemCurrentDurability > 1 && inv.ItemMaxDurability == 999)
            {
            }
            else
            {
                if (inv.ItemPieces > 0)
                {
                    inv.ItemCurrentDurability = inv.ItemMaxDurability;
                    inv.ItemPieces--;
                }
            }

            if (zAA.ZombieLife > weapon.WeaponDamage)
            {
                zAA.ZombieLife = zAA.ZombieLife - weapon.WeaponDamage;
            }
            else
            {
                var addXP = new CharactersController().ManageXPAndLevelUp(character.ApplicationUserID, zAA.Zombie.RewardXP, this.Request.FilePath);
                character.CharacterMoney += zAA.Zombie.RewardCoins;
                db.ZombieAttackAdventurers.Remove(zAA);
            }

            db.SaveChanges();
            return RedirectToAction("AdventureZombieAttack", "Adventures", new { ChId = zAA.CharacterID });
        }

        //public ActionResult RemoveAdventure(int ChId)
        //{

        //    var remove = db.ZombieAttackAdventurers.Where(x => x.CharacterID == ChId).ToList();
        //    remove.ForEach(s => db.ZombieAttackAdventurers.Remove(s));
        //    db.SaveChanges();

        //    return RedirectToAction("Details", "Characters", new { id = User.Identity.Name });
        //}


        public ActionResult AdventureZombieAttack(int ChId)
        {

            AdventureViewModel adventureViewModel = new AdventureViewModel();
            Character character = db.Characters.Find(ChId);


            if (character.IsOnAdventure == false)
            {
                return RedirectToAction("Details", "Characters", new { id = User.Identity.Name });
            }

            adventureViewModel.Adventure = db.Adventures.Find(1);
            adventureViewModel.CharacterID = ChId;
            adventureViewModel.ZombiesAttackAdventurer = db.ZombieAttackAdventurers.Where(x => x.CharacterID == ChId).ToList();
            adventureViewModel.Character = db.Characters.Find(ChId);
            adventureViewModel.Weapons = db.Weapons.ToList();
            int maxSteps = adventureViewModel.Adventure.AdventureSteps;

           
            foreach (var zombie in adventureViewModel.ZombiesAttackAdventurer)
            {
                zombie.Zombie = db.Zombies.Find(zombie.ZombieID);
            }

            for (int c = 1; c < maxSteps + 1; c++)
            {
                int counter = adventureViewModel.ZombiesAttackAdventurer.Where(x => x.State == c).Count();
                if (character.AdventureState == c && counter == 0)
                {
                    character.AdventureState++;
                    character.FinishAdventure = DateTime.Now.AddSeconds(adventureViewModel.Adventure.AdventureWaitingTime);
                    db.SaveChanges();
                    return RedirectToAction("AdventureCounter", "Adventures", new { AdId = adventureViewModel.Adventure.AdventureID, ChId = ChId });

                }
                if (counter > 0 && character.AdventureState <= maxSteps)
                {
                    character.AdventureState = c;
                    break;
                }
            }


            character.FinishAdventure = DateTime.Now.AddSeconds(adventureViewModel.Adventure.AdventureWaitingTime);
            db.SaveChanges();

            adventureViewModel.PageName = db.Characters.Where(y => y.ApplicationUserID == User.Identity.Name).FirstOrDefault().ApplicationUserID;
            adventureViewModel.Fields = db.CharacterFields.Where(x => x.CharacterID == db.Characters.Where(y => y.ApplicationUserID == User.Identity.Name).FirstOrDefault().CharacterID).ToList();
            adventureViewModel.EnergyPlusDate = db.Characters.Where(y => y.ApplicationUserID == User.Identity.Name).FirstOrDefault().EnergyPlusDate;
            adventureViewModel.AttackingZombies = db.ZombieAttackBases.Where(x => x.CharacterID == db.Characters.Where(y => y.ApplicationUserID == User.Identity.Name).FirstOrDefault().CharacterID).ToList();
            adventureViewModel.AdventureFinishDate = db.Characters.Where(y => y.ApplicationUserID == User.Identity.Name).FirstOrDefault().FinishAdventure;

            return View(adventureViewModel);
        }


        public ActionResult AddToInventory(int ChId, int ItemId, int addPieces)
        {

            Inventory inventory = db.Inventories.Where(s => s.ItemID == ItemId).Where(s => s.CharacterID == ChId).FirstOrDefault();
            if (inventory == null)
            {
                Inventory newinventory = new Inventory { ItemID = ItemId, ItemPieces = addPieces, CharacterID = ChId };
                db.Inventories.Add(newinventory);
            }
            else
            {
                inventory.ItemPieces += addPieces;
            }
            db.SaveChanges();
            return View();
        }



        public ActionResult AdventureDropCalculator(int? AdId, int ChId)
        {

            AdventureDropVM adventureDrop = new AdventureDropVM();
            List<AdventureDrop> dropList = db.AdventureDrops.Where(a => a.AdventureID == AdId).ToList();
            adventureDrop.ItemList = db.Items.ToList();
            adventureDrop.Rewards = new List<Inventory>();


            Random rand = new Random();

            foreach (var drop in dropList)
            {
                double myRand = rand.NextDouble();

                if (myRand > (1 - drop.ItemDroprate))
                {
                    int addPieces = rand.Next(1, drop.ItemMaxDrop);
                    Inventory inventory = new Inventory { CharacterID = ChId, ItemID = drop.DropableItemID, ItemPieces = addPieces };
                    var addItem = new AdventuresController().AddToInventory(ChId, drop.DropableItemID, addPieces);

                    Inventory item = new Inventory { ItemID = drop.DropableItemID, ItemPieces = addPieces };

                    adventureDrop.Rewards.Add(item);

                    db.SaveChanges();

                }
            }



            adventureDrop.PageName = db.Characters.Where(y => y.ApplicationUserID == User.Identity.Name).FirstOrDefault().ApplicationUserID;
            adventureDrop.Fields = db.CharacterFields.Where(x => x.CharacterID == db.Characters.Where(y => y.ApplicationUserID == User.Identity.Name).FirstOrDefault().CharacterID).ToList();
            adventureDrop.EnergyPlusDate = db.Characters.Where(y => y.ApplicationUserID == User.Identity.Name).FirstOrDefault().EnergyPlusDate;
            adventureDrop.AttackingZombies = db.ZombieAttackBases.Where(x => x.CharacterID == db.Characters.Where(y => y.ApplicationUserID == User.Identity.Name).FirstOrDefault().CharacterID).ToList();
            adventureDrop.AdventureFinishDate = db.Characters.Where(y => y.ApplicationUserID == User.Identity.Name).FirstOrDefault().FinishAdventure;

            return View(adventureDrop);
           // return RedirectToAction(returnUrl);
        }


        public ActionResult StartAdventure(int AdId, int ChId)
        {
            Adventure adventure = db.Adventures.Find(AdId);
            Character character = db.Characters.Find(ChId);
            List<ZombieAttackAdventurer> zombies = new List<ZombieAttackAdventurer>();
            Random rand = new Random();


            if (AdId == 1) {
                for (int i = 0; i < 3; i++) {
                    double myRand = rand.Next(1,4);
                    Zombie zombie = db.Zombies.Find(myRand);
                    ZombieAttackAdventurer zAA = new ZombieAttackAdventurer();
                    zAA.Zombie = zombie;
                    zAA.State = 1;
                    zAA.ZombieID = zombie.ZombieID;
                    zAA.ZombieLife = zombie.ZombieLife;
                    zAA.CharacterID = ChId;
                    zombies.Add(zAA);
                }
                for (int i = 0; i < 2; i++)
                {
                    double myRand = rand.Next(1, 4);
                    Zombie zombie = db.Zombies.Find(myRand);
                    ZombieAttackAdventurer zAA = new ZombieAttackAdventurer();
                    zAA.Zombie = zombie;
                    zAA.State = 2;
                    zAA.ZombieID = zombie.ZombieID;
                    zAA.ZombieLife = zombie.ZombieLife;
                    zAA.CharacterID = ChId;
                    zombies.Add(zAA);
                }
                for (int i = 0; i < 3; i++)
                {
                    double myRand = rand.Next(1, 4);
                    Zombie zombie = db.Zombies.Find(myRand);
                    ZombieAttackAdventurer zAA = new ZombieAttackAdventurer();
                    zAA.Zombie = zombie;
                    zAA.State = 3;
                    zAA.ZombieID = zombie.ZombieID;
                    zAA.ZombieLife = zombie.ZombieLife;
                    zAA.CharacterID = ChId;
                    zombies.Add(zAA);
                }
            }

          
            zombies.ForEach(x => db.ZombieAttackAdventurers.Add(x));

            ViewBag.BeforeCharacterFinishDate = character.FinishAdventure;

            character.FinishAdventure = DateTime.Now.AddSeconds(adventure.AdventureWaitingTime);
            character.AdventureState = 1;
            character.AdventureID = AdId;


            var FullDate = character.FinishAdventure;
            int CharID = ChId;
            int AdvID = AdId;
            var FinishAdventureYear = character.FinishAdventure.Year;
            var FinishAdventureMonth = character.FinishAdventure.Month;
            var FinishAdventureDay = character.FinishAdventure.Day;
            var FinishAdventureHour = character.FinishAdventure.Hour;
            var FinishAdventureMinute = character.FinishAdventure.Minute;
            var FinishAdventureSecond = character.FinishAdventure.Second;


            ViewBag.CharID = CharID;
            ViewBag.AdvID = AdvID;

            ViewBag.FullDate = FullDate;

            ViewBag.FinishAdventureYear = FinishAdventureYear;
            ViewBag.FinishAdventureMonth = FinishAdventureMonth;
            ViewBag.FinishAdventureDay = FinishAdventureDay;
            ViewBag.FinishAdventureHour = FinishAdventureHour;
            ViewBag.FinishAdventureMinute = FinishAdventureMinute;
            ViewBag.FinishAdventureSecond = FinishAdventureSecond;

            character.IsOnAdventure = true;
            db.SaveChanges();
            // return View(adventure);
            return RedirectToAction("AdventureZombieAttack", "Adventures", new { ChId = ChId });
        }

        public ActionResult StopAdventure(int? AdId, int ChId)
        {
            Adventure adventure = db.Adventures.Find(AdId);
            Character character = db.Characters.Find(ChId);

            character.FinishAdventure = DateTime.MaxValue;
            character.IsOnAdventure = false;

            var remove = db.ZombieAttackAdventurers.Where(x => x.CharacterID == ChId).ToList();
            remove.ForEach(s => db.ZombieAttackAdventurers.Remove(s));

            var addXP = new CharactersController().ManageXPAndLevelUp(character.ApplicationUserID, adventure.AdventureXPBonus, this.Request.FilePath);
          //  var addDrops = new AdventuresController().AdventureDropCalculator(AdId, ChId);
            db.SaveChanges();
            return RedirectToAction("AdventureDropCalculator", "Adventures", new { AdId = adventure.AdventureID, ChId = character.CharacterID });
        }

        // GET: Adventures
        public ActionResult Index()
        {
            return View(db.Adventures.ToList());
        }

        // GET: Adventures/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Adventure adventure = db.Adventures.Find(id);
            if (adventure == null)
            {
                return HttpNotFound();
            }
            return View(adventure);
        }

        // GET: Adventures/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Adventures/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AdventureID,AdventureTime")] Adventure adventure)
        {
            if (ModelState.IsValid)
            {
                db.Adventures.Add(adventure);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(adventure);
        }

        // GET: Adventures/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Adventure adventure = db.Adventures.Find(id);
            if (adventure == null)
            {
                return HttpNotFound();
            }
            return View(adventure);
        }

        // POST: Adventures/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AdventureID,AdventureTime")] Adventure adventure)
        {
            if (ModelState.IsValid)
            {
                db.Entry(adventure).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(adventure);
        }

        // GET: Adventures/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Adventure adventure = db.Adventures.Find(id);
            if (adventure == null)
            {
                return HttpNotFound();
            }
            return View(adventure);
        }

        // POST: Adventures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Adventure adventure = db.Adventures.Find(id);
            db.Adventures.Remove(adventure);
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