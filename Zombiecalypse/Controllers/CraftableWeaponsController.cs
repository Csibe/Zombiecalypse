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
    public class CraftableWeaponsController : Controller
    {
        private DataContext db = new DataContext();

        // GET: CraftableWeapons
        public ActionResult Index()
        {
            return View(db.CraftableWeapons.ToList());
        }

        // GET: CraftableWeapons/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CraftableWeapon craftableWeapon = db.CraftableWeapons.Find(id);

            ICollection<CraftableWeaponMaterial> cwm = db.CraftableWeaponsMaterials.Where(s => s.WeaponID == id).ToList() ;
            craftableWeapon.WeaponMaterials = cwm;

            if (craftableWeapon == null)
            {
                return HttpNotFound();
            }
            return View(craftableWeapon);
        }

        // GET: CraftableWeapons/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CraftableWeapons/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ItemID,ItemName,ItemType,ItemPicture,WeaponID,WeaponDurability,WeaponDamage")] CraftableWeapon craftableWeapon)
        {
            if (ModelState.IsValid)
            {
                db.Items.Add(craftableWeapon);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(craftableWeapon);
        }

        // GET: CraftableWeapons/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CraftableWeapon craftableWeapon = db.CraftableWeapons.Find(id);
            if (craftableWeapon == null)
            {
                return HttpNotFound();
            }
            return View(craftableWeapon);
        }

        // POST: CraftableWeapons/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ItemID,ItemName,ItemType,ItemPicture,WeaponID,WeaponDurability,WeaponDamage")] CraftableWeapon craftableWeapon)
        {
            if (ModelState.IsValid)
            {
                db.Entry(craftableWeapon).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(craftableWeapon);
        }

        // GET: CraftableWeapons/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CraftableWeapon craftableWeapon = db.CraftableWeapons.Find(id);
            if (craftableWeapon == null)
            {
                return HttpNotFound();
            }
            return View(craftableWeapon);
        }

        // POST: CraftableWeapons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CraftableWeapon craftableWeapon = db.CraftableWeapons.Find(id);
            db.Items.Remove(craftableWeapon);
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
