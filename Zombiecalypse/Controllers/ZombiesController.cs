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
    public class ZombiesController : Controller
    {
        private DataContext db = new DataContext();

        public ActionResult StartAttack(int ChId)
        {

            Random rand = new Random();
            int ZombId = rand.Next(1, db.Zombies.Count() + 1);
            Zombie zombie = db.Zombies.Find(ZombId);
            Character character = db.Characters.Find(ChId);

            ZombieAttackBase zab = new ZombieAttackBase { ZombieAttackStart = DateTime.Now, Zombie = zombie, Character = character, CharacterID = character.CharacterID, ZombieID = zombie.ZombieID, ZombieLife = zombie.ZombieLife };
            db.ZombieAttackBases.Add(zab);
            db.SaveChanges();

            return RedirectToAction("CharacterDetails", "Characters", new { id = User.Identity.Name, AttackPower = 0 });
        }



        public ActionResult BaseDefenseFromZombie(int ZabID, int AttackPower, int invID)
        {
            ZombieAttackBase zombieAttackBase = db.ZombieAttackBases.Find(ZabID);
            Character character = zombieAttackBase.Character;
            ICollection<Inventory> inventory = character.Inventory;
            var isEnergyNull = new CharactersController().isEnergyNull(character.CharacterID);
            if (isEnergyNull)
            {

                if (invID != 0)
                {
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
                }
                if (AttackPower > 0) {
                    zombieAttackBase.ZombieLife -= AttackPower;
                    zombieAttackBase.Character.CurrentEnergy--;
                }

            }
            else
            {
                return View("~/Views/shared/NotEnoughtEnergy.cshtml");
            }
            foreach (var inv in inventory)
            {
                if (inv.Item.ItemType == "craftableWeapon" || inv.Item.ItemType == "buyableWeapon" || inv.Item.ItemType == "Weapon")
                {
                    Weapon weapon = db.Weapons.Find(inv.ItemID);

                    zombieAttackBase.Weapons.Add(weapon);
                }

            }

            if (zombieAttackBase.ZombieLife <= 0)
            {
                var result = new CharactersController().AddToXP(character.CharacterID, zombieAttackBase.Zombie.RewardXP, this.Request.FilePath);
                // character.CharacterXP += zombieAttackBase.Zombie.RewardXP;
                character.CharacterMoney += zombieAttackBase.Zombie.RewardCoins;
                db.ZombieAttackBases.Remove(zombieAttackBase);

                db.SaveChanges();
                return RedirectToAction("CharacterDetails", "Characters", new { id = User.Identity.Name });
            }

            db.SaveChanges();

            return View(zombieAttackBase);

        }

        public ActionResult ZombieAttackBase(int ZabID)
        {
            ZombieAttackBase zombieAttackBase = db.ZombieAttackBases.Find(ZabID);
            Character character = zombieAttackBase.Character;
            Zombie zombie = zombieAttackBase.Zombie;
            ICollection<Inventory> inventory = character.Inventory;

            int counter = 1;
            foreach (var inv in inventory)
            {
                if (inv.Item.ItemType == "building")
                {
                    Building building = db.Buildings.Find(inv.Item.ItemID);
                    if (building.BuildingLevel > 0)
                    {
                        building.BuildingID = counter;
                        zombieAttackBase.Buildings.Add(building);
                        counter++;
                    }
                }
            }

            Random rand = new Random();
            int random = rand.Next(1, zombieAttackBase.Buildings.Count() + 1);

            int buildingID = db.ZombieAttackBases.Find(ZabID).Buildings.Where(x => x.BuildingID == random).FirstOrDefault().ItemID;

            foreach (var inv in inventory)
            {
                if (inv.ItemID == buildingID)
                {
                    inv.ItemCurrentDurability--;
                }
            }
            db.SaveChanges();
            return View(zombieAttackBase);
            //  return RedirectToAction("CharacterDetails", "Characters", new { id = User.Identity.Name });
        }


        // GET: Zombies
        public ActionResult Index()
        {
            return View(db.Zombies.ToList());
        }

        // GET: Zombies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Zombie zombie = db.Zombies.Find(id);
            if (zombie == null)
            {
                return HttpNotFound();
            }
            return View(zombie);
        }

        // GET: Zombies/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Zombies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ZombieID,ZombieName,ZombieType,ZombieLife,ZombieDamage,RewardCoins,RewardXP")] Zombie zombie)
        {
            if (ModelState.IsValid)
            {
                db.Zombies.Add(zombie);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(zombie);
        }

        // GET: Zombies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Zombie zombie = db.Zombies.Find(id);
            if (zombie == null)
            {
                return HttpNotFound();
            }
            return View(zombie);
        }

        // POST: Zombies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ZombieID,ZombieName,ZombieType,ZombieLife,ZombieDamage,RewardCoins,RewardXP")] Zombie zombie)
        {
            if (ModelState.IsValid)
            {
                db.Entry(zombie).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(zombie);
        }

        // GET: Zombies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Zombie zombie = db.Zombies.Find(id);
            if (zombie == null)
            {
                return HttpNotFound();
            }
            return View(zombie);
        }

        // POST: Zombies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Zombie zombie = db.Zombies.Find(id);
            db.Zombies.Remove(zombie);
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
