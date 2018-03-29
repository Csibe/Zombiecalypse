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
            character.CharacterXP++;

            ZombieAttackBase zombie2 = new ZombieAttackBase {CharacterID=ChId, ZombieAttackStart=DateTime.Now, Zombie = zombie, Character = character, ZombieID=ZombId};
            db.ZombieAttackBases.Add(zombie2);
            db.SaveChanges();
            int zab = db.ZombieAttackBases.Where(z => z.ZombieAttackBaseID == zombie2.ZombieAttackBaseID).FirstOrDefault().ZombieAttackBaseID;

            return RedirectToAction("ZombieAttackBase", "Zombies", new { ZabID = zab});
        }

        public ActionResult ZombieAttackBase(int ZabID) {

            ZombieAttackBase zombieAttackBase = new ZombieAttackBase();

            ZombieAttackBase zab = db.ZombieAttackBases.Find(ZabID);
            Zombie zombie = db.ZombieAttackBases.Find(ZabID).Zombie;
            Character character = db.ZombieAttackBases.Find(ZabID).Character;
            if (character == null)
            {
                ViewBag.Character = "üres" + character.CharacterID;
            }
            else {
                ViewBag.Character = "jo" + character.CharacterID;
            }
            
       //     character.CharacterXP++;
            // character.CharacterMoney++;
            zombie.ZombieLife--;
            db.SaveChanges();

            zombieAttackBase.ZombieAttackBaseID = character.CharacterID;
            zombieAttackBase.ZombieID = zombie.ZombieID;
            zombieAttackBase.ZombieAttackStart = DateTime.Now;
            
            

            zombieAttackBase.Character = character;
            zombieAttackBase.Zombie = zombie;

            if (zombie.ZombieLife <= 0)
            {
              /*  var rewardXP = zombie.RewardXP;
                var rewardCoin = zombie.RewardCoins;
                character.CharacterXP += rewardXP;
                character.CharacterMoney += rewardCoin;*/
                db.ZombieAttackBases.Remove(zab);
                
                db.SaveChanges();
                return RedirectToAction("CharacterDetails", "Characters", new { id = User.Identity.Name });
            }


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
