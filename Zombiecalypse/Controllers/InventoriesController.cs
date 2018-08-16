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
    public class InventoriesController : Controller
    {
        private DataContext db = new DataContext();
        private int MaxBuildingLevel = 5;


        public ActionResult LevelUpBuilding(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Inventory item = db.Inventories.Find(id);
            Building building = db.Buildings.Find(item.ItemID);

            if (item == null)
            {
                return HttpNotFound();
            }

            if (building == null)
            {
                return HttpNotFound();

            }

            if (building.BuildingLevel < MaxBuildingLevel)
            {
                int chID = item.CharacterID;
                ICollection<Inventory> characterInventory = db.Inventories.Where(x => x.CharacterID == chID).ToList();

                int buildingLevel = building.BuildingLevel;
                int newBuildingLevel = ++buildingLevel;
                string buildingName = building.ItemName;

                Building newBuilding = db.Buildings.Where(x => x.ItemName == buildingName).Where(x => x.BuildingLevel == newBuildingLevel).FirstOrDefault();
                List<BuildingBuildingMaterial> newBuildingBuildingMaterials = db.BuildingBuildingMaterials.Where(x => x.BuildingID == newBuilding.ItemID).ToList();

                int counter = 0;


                foreach (var invMat in characterInventory)
                {
                    foreach (var newMat in newBuildingBuildingMaterials)
                    {
                        if (invMat.ItemID == newMat.BuildingMaterialID)
                        {
                            if (invMat.ItemPieces >= newMat.MaterialPieces)
                            {
                                counter++;
                            }
                        }

                    }
                }
                if (counter == newBuildingBuildingMaterials.Count())
                {
                    foreach (var invMat in characterInventory)
                    {
                        foreach (var newMat in newBuildingBuildingMaterials)
                        {
                            if (invMat.ItemID == newMat.BuildingMaterialID)
                            {
                                invMat.ItemPieces = invMat.ItemPieces - newMat.MaterialPieces;

                            }
                        }
                    }
                    var newitem = db.Buildings.Where(p => p.ItemID == newBuilding.ItemID).FirstOrDefault();
                    item.Item = db.Items.Find(newitem.ItemID);
                    item.ItemID = newitem.ItemID;
                    item.ItemMaxDurability = newitem.ItemMaxDurability;
                    item.ItemCurrentDurability = newitem.ItemMaxDurability;

                    db.SaveChanges();

                    return RedirectToAction("Details", "Characters", new { id = User.Identity.Name });

                }
                else {
                    return View("~/Views/Shared/NotEnoughtEnergy.cshtml");
                }
                
            }
            else
            {
                return RedirectToAction("Details", "Characters", new { id = User.Identity.Name });
            }
        }



        // GET: Inventories/Details/5
        public ActionResult Details(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inventory inventory = db.Inventories.Find(id);

            //int newBuildingLevel = inventory.Building.BuildingLevel;
            //newBuildingLevel++;
            //string BuildingName = inventory.Building.ItemName;

            //Building newBuilding = db.Buildings
            //.Where(b => b.BuildingLevel == newBuildingLevel)
            //.Where(b => b.ItemName == BuildingName)
            //.FirstOrDefault();


            //inventory.Building = newBuilding;
            //inventory.Building.BuildingBuildingMaterials = db.BuildingBuildingMaterials
            //    .Where(b => b.BuildingID == inventory.Building.ItemID).ToList();

            /*  inventory.Building.BuildingBuildingMaterials = db.BuildingBuildingMaterials
              .Where(b => b.BuildingID == inventory.Building.ItemID).ToList();*/
            if (inventory == null)
            {
                return HttpNotFound();
            }
            return View(inventory);
        }

        // GET: Inventories/Create
        public ActionResult Create()
        {
            ViewBag.CharacterID = new SelectList(db.Characters, "CharacterID", "CharacterName");
            ViewBag.ItemID = new SelectList(db.Items, "ItemID", "ItemName");
            return View();
        }

        // POST: Inventories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "InventoryID,CharacterID,ItemID,ItemPieces")] Inventory inventory)
        {
            if (ModelState.IsValid)
            {
                db.Inventories.Add(inventory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CharacterID = new SelectList(db.Characters, "CharacterID", "CharacterName", inventory.CharacterID);
            ViewBag.ItemID = new SelectList(db.Items, "ItemID", "ItemName", inventory.ItemID);
            return View(inventory);
        }

        // GET: Inventories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inventory inventory = db.Inventories.Find(id);
            if (inventory == null)
            {
                return HttpNotFound();
            }
            ViewBag.CharacterID = new SelectList(db.Characters, "CharacterID", "CharacterName", inventory.CharacterID);
            ViewBag.ItemID = new SelectList(db.Items, "ItemID", "ItemName", inventory.ItemID);
            return View(inventory);
        }

        // POST: Inventories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "InventoryID,CharacterID,ItemID,ItemPieces")] Inventory inventory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(inventory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CharacterID = new SelectList(db.Characters, "CharacterID", "CharacterName", inventory.CharacterID);
            ViewBag.ItemID = new SelectList(db.Items, "ItemID", "ItemName", inventory.ItemID);
            return View(inventory);
        }

        // GET: Inventories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inventory inventory = db.Inventories.Find(id);
            if (inventory == null)
            {
                return HttpNotFound();
            }
            return View(inventory);
        }

        // POST: Inventories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Inventory inventory = db.Inventories.Find(id);
            db.Inventories.Remove(inventory);
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