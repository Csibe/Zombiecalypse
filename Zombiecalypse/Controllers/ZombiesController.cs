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

        public ActionResult StartAttack(int ChId, int ZombId) {

            Zombie zombie = db.Zombies.Find(ZombId);
            Character character = db.Characters.Find(ChId);
           
           

            ZombieAttackBase zab = new ZombieAttackBase { ZombieAttackStart=DateTime.Now, Zombie = zombie,  Character = character, CharacterID = character.CharacterID, ZombieID=zombie.ZombieID, ZombieLife = zombie.ZombieLife};
            db.ZombieAttackBases.Add(zab);
            db.SaveChanges();

            return RedirectToAction("CharacterDetails", "Characters", new { id = User.Identity.Name, AttackPower = 0 });
        }

        public ActionResult ZombieAttackBase(int ZabID, int AttackPower) {

            ZombieAttackBase zombieAttackBase = db.ZombieAttackBases.Find(ZabID);
            Character character = zombieAttackBase.Character;
            ICollection<Inventory> inventory = character.Inventory;
            

            zombieAttackBase.ZombieLife -= AttackPower;
            db.SaveChanges();

            foreach (var inv in inventory)
            {
                if (inv.Item.ItemType.Contains("Weapon")) { 
                Weapon weapon = db.Weapons.Find(inv.ItemID);
                    zombieAttackBase.Weapons.Add(weapon);
                }

            }


            //     character.CharacterXP++;
            // character.CharacterMoney++;

            if (zombieAttackBase.ZombieLife <= 0)
            {
            }
              /*  var rewardXP = zombie.RewardXP;
                var rewardCoin = zombie.RewardCoins;
                character.CharacterXP += rewardXP;
                character.CharacterMoney += rewardCoin;*/
           /*     db.ZombieAttackBases.Remove(zab);
                
                db.SaveChanges();
                return RedirectToAction("CharacterDetails", "Characters", new { id = User.Identity.Name });
            }

    */
            return View(zombieAttackBase);
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
