using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.DAL;
using WebApplication1.Models;

namespace WebApplication1.Controllers
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
            Inventory inventory = db.Inventories.Find(id);
            if (inventory == null)
            {
                return HttpNotFound();
            }
            ViewBag.CharacterID = new SelectList(db.Characters, "CharacterID", "CharacterName", inventory.CharacterID);
            ViewBag.ItemID = new SelectList(db.Items, "ItemID", "ItemName", inventory.ItemID);

            if (inventory.Building.BuildingLevel < MaxBuildingLevel)
            {
                int charactersID = inventory.CharacterID;
                ICollection<Inventory>characterInventory = db.Inventories.Where(x=>x.CharacterID == charactersID).ToList();

                int BuildingLevel = inventory.Building.BuildingLevel;
                int NewBuildingLevel = ++BuildingLevel;
                string BuildingName = inventory.Building.ItemName;
                int NewBuildingID = inventory.Building.ItemID;
                NewBuildingID++;

                Building newBuilding = db.Buildings.Where(b => b.BuildingLevel == NewBuildingLevel).Where(b => b.ItemName == BuildingName).SingleOrDefault();
                // ICollection<BuildingBuildingMaterial> newBuildingBuildingMaterials = db.BuildingBuildingMaterials.Where(b => b.BuildingID == NewBuildingID).ToList();
                List<BuildingBuildingMaterial> newBuildingBuildingMaterials = db.BuildingBuildingMaterials.Where(b => b.BuildingID == NewBuildingID).ToList();
                BuildingBuildingMaterial newSingleBuilding = newBuildingBuildingMaterials.First();




                ViewBag.newBuilding = new Building() {ItemID=newBuilding.ItemID,BuildingLevel=newBuilding.BuildingLevel, BuildingBuildingMaterials = newBuildingBuildingMaterials };
                ViewBag.characterInventory = characterInventory;

                List<Inventory> invMatList = new List<Inventory>();
                List<BuildingBuildingMaterial> buldMatList = new List<BuildingBuildingMaterial>();
                List<BuildingBuildingMaterial> whatNeedList = new List<BuildingBuildingMaterial>();
                int mat = 0;
                int mat2 = 0;
                int mat3 = 0;
              /*  for (int i = 0; i < 5; i++) {
                    mat++;
                }
                */
                foreach (var invMat in characterInventory) {
                    invMatList.Add(invMat);
                    mat++;
                }

                foreach (var newMat in newBuildingBuildingMaterials) {
                    buldMatList.Add(newMat);
                    mat2++;
                }

                foreach (var invMat in characterInventory)
                {
                    foreach (var newMat in newBuildingBuildingMaterials)
                    {
                        if (invMat.ItemID == newMat.BuildingMaterialID)
                        {
                            if (invMat.ItemPieces >= newMat.MaterialPieces)
                                whatNeedList.Add(newMat);
                            mat3++;
                        }
                       
                    }
                }


                ViewBag.mat = mat;
                ViewBag.mat2 = mat2;
                ViewBag.mat3 = mat3;
                ViewBag.invMatList = invMatList;
                ViewBag.buldMatList = buldMatList;
                ViewBag.whatNeedList = whatNeedList;

                //characterInventory.Contains(newBuildingBuildingMaterials);

                /*.Where(b => b.BuildingLevel == NewBuildingLevel)
                .Where(b => b.ItemName == BuildingName)
                .FirstOrDefault()
                */
                //       List<BuildingBuildingMaterial> neededmaterials = newBuilding.ItemID;

                //  List<int> havematerials = inventory.Character.Inventory.Select(x=> x.BuildingBuildingMaterial.BuildingMaterialID).ToList();

                /*if(result == neededmaterials)
                {

                    Inventory addInventory = new Inventory { ItemID = newBuilding.ItemID, CharacterID = 1, ItemPieces = 1 };
                    db.Inventories.Add(addInventory);
                    db.Inventories.Remove(inventory);
                    db.SaveChanges();
                    return View("CharacterDetails/Index/1");
                }*/
            }
            return View(inventory);
            //return RedirectToAction("Index");
            //  return RedirectToAction("CharacterDetails/Index/1");
        }



        public ActionResult AddToItem(int? id)
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddToItem([Bind(Include = "InventoryID,CharacterID,ItemID,ItemPieces")] Inventory inventory, int addPieces)
        {
            if (ModelState.IsValid)
            {
                inventory.ItemPieces = inventory.ItemPieces + addPieces;
                db.Entry(inventory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CharacterID = new SelectList(db.Characters, "CharacterID", "CharacterName", inventory.CharacterID);
            ViewBag.ItemID = new SelectList(db.Items, "ItemID", "ItemName", inventory.ItemID);
            return View(inventory);
        }


        // GET: Inventories
        public ActionResult Index()
        {
            var inventories = db.Inventories.Include(i => i.Character).Include(i => i.Item);
            return View(inventories.ToList());
        }

        // GET: Inventories/Details/5
        public ActionResult Details(int? id)
        {
            
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inventory inventory = db.Inventories.Find(id);

            int newBuildingLevel = inventory.Building.BuildingLevel;
            newBuildingLevel++;
            string BuildingName = inventory.Building.ItemName;

            Building newBuilding = db.Buildings
            .Where(b => b.BuildingLevel == newBuildingLevel)
            .Where(b => b.ItemName == BuildingName)
            .FirstOrDefault();


            inventory.Building = newBuilding;
            inventory.Building.BuildingBuildingMaterials = db.BuildingBuildingMaterials
                .Where(b => b.BuildingID == inventory.Building.ItemID).ToList();

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
