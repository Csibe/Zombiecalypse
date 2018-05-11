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
    public class BuildingMaterialsController : Controller
    {
        private DataContext db = new DataContext();

        // GET: BuildingMaterials
        public ActionResult Index()
        {
            return View(db.BuildingMaterials.ToList());
        }

        // GET: BuildingMaterials/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BuildingMaterial buildingMaterial = db.BuildingMaterials.Find(id);
            if (buildingMaterial == null)
            {
                return HttpNotFound();
            }
            return View(buildingMaterial);
        }

        // GET: BuildingMaterials/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BuildingMaterials/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ItemID,ItemName,ItemPicture,ItemMaxDurability")] BuildingMaterial buildingMaterial)
        {
            if (ModelState.IsValid)
            {
                db.Items.Add(buildingMaterial);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(buildingMaterial);
        }

        // GET: BuildingMaterials/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BuildingMaterial buildingMaterial = db.BuildingMaterials.Find(id);
            if (buildingMaterial == null)
            {
                return HttpNotFound();
            }
            return View(buildingMaterial);
        }

        // POST: BuildingMaterials/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ItemID,ItemName,ItemPicture,ItemMaxDurability")] BuildingMaterial buildingMaterial)
        {
            if (ModelState.IsValid)
            {
                db.Entry(buildingMaterial).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(buildingMaterial);
        }

        // GET: BuildingMaterials/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BuildingMaterial buildingMaterial = db.BuildingMaterials.Find(id);
            if (buildingMaterial == null)
            {
                return HttpNotFound();
            }
            return View(buildingMaterial);
        }

        // POST: BuildingMaterials/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BuildingMaterial buildingMaterial = db.BuildingMaterials.Find(id);
            db.Items.Remove(buildingMaterial);
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
