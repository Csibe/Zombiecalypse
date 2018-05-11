﻿using System;
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
    public class BuildingBuildingMaterialsController : Controller
    {
        private DataContext db = new DataContext();

        // GET: BuildingBuildingMaterials
        public ActionResult Index()
        {
            return View(db.BuildingBuildingMaterials.ToList());
        }

        // GET: BuildingBuildingMaterials/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BuildingBuildingMaterial buildingBuildingMaterial = db.BuildingBuildingMaterials.Find(id);
            if (buildingBuildingMaterial == null)
            {
                return HttpNotFound();
            }
            return View(buildingBuildingMaterial);
        }

        // GET: BuildingBuildingMaterials/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BuildingBuildingMaterials/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BuildingBuildingMaterialID,BuildingID,BuildingMaterialID,MaterialPieces")] BuildingBuildingMaterial buildingBuildingMaterial)
        {
            if (ModelState.IsValid)
            {
                db.BuildingBuildingMaterials.Add(buildingBuildingMaterial);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(buildingBuildingMaterial);
        }

        // GET: BuildingBuildingMaterials/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BuildingBuildingMaterial buildingBuildingMaterial = db.BuildingBuildingMaterials.Find(id);
            if (buildingBuildingMaterial == null)
            {
                return HttpNotFound();
            }
            return View(buildingBuildingMaterial);
        }

        // POST: BuildingBuildingMaterials/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BuildingBuildingMaterialID,BuildingID,BuildingMaterialID,MaterialPieces")] BuildingBuildingMaterial buildingBuildingMaterial)
        {
            if (ModelState.IsValid)
            {
                db.Entry(buildingBuildingMaterial).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(buildingBuildingMaterial);
        }

        // GET: BuildingBuildingMaterials/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BuildingBuildingMaterial buildingBuildingMaterial = db.BuildingBuildingMaterials.Find(id);
            if (buildingBuildingMaterial == null)
            {
                return HttpNotFound();
            }
            return View(buildingBuildingMaterial);
        }

        // POST: BuildingBuildingMaterials/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BuildingBuildingMaterial buildingBuildingMaterial = db.BuildingBuildingMaterials.Find(id);
            db.BuildingBuildingMaterials.Remove(buildingBuildingMaterial);
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
