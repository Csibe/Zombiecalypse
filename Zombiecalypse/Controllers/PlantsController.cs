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
    public class PlantsController : Controller
    {
        private DataContext db = new DataContext();



        public ActionResult GrowUpPlant(int fieldID)
        {
            CharacterFieldVM characterFieldVM = new CharacterFieldVM();

            characterFieldVM.CharacterField = db.CharacterFields.Find(fieldID);
            characterFieldVM.CharacterField.isFinished = true;
            characterFieldVM.CharacterField.FinishDate = DateTime.MaxValue;
            db.SaveChanges();



            characterFieldVM.PageName = db.Characters.Where(y => y.ApplicationUserID == User.Identity.Name).FirstOrDefault().ApplicationUserID;
            characterFieldVM.Fields = db.CharacterFields.Where(x => x.CharacterID == db.Characters.Where(y => y.ApplicationUserID == User.Identity.Name).FirstOrDefault().CharacterID).ToList();
            characterFieldVM.EnergyPlusDate = db.Characters.Where(y => y.ApplicationUserID == User.Identity.Name).FirstOrDefault().EnergyPlusDate;
            characterFieldVM.AttackingZombies = db.ZombieAttackBases.Where(x => x.CharacterID == db.Characters.Where(y => y.ApplicationUserID == User.Identity.Name).FirstOrDefault().CharacterID).ToList();
            characterFieldVM.AdventureFinishDate = db.Characters.Where(y => y.ApplicationUserID == User.Identity.Name).FirstOrDefault().FinishAdventure;


            return RedirectToAction("Details", "Characters", new { id = User.Identity.Name });
        }

        public ActionResult HarvestField(int fieldID, int plantID)
        {
            CharacterField field = db.CharacterFields.Find(fieldID);
            Plant plant = db.Plants.Find(plantID);
            Character character = db.Characters.Where(x => x.CharacterID == field.CharacterID).FirstOrDefault();

            field.PlantID = 0;
            field.IsEmpty = true;
            field.isFinished = false;
            field.FinishDate = DateTime.MaxValue;

            character.CharacterMoney += plant.PlantRewardCoin;
            character.CharacterFood += plant.PlantRewardFood;
            db.SaveChanges();

            return RedirectToAction("Details", "Characters", new { id = User.Identity.Name });
        }

        public ActionResult PlantOnField(int fieldID, int plantID)
        {
            CharacterField field = db.CharacterFields.Find(fieldID);
            Inventory invPlant = db.Inventories.Where(x => x.ItemID == plantID).FirstOrDefault();
            Character character = db.Characters.Where(x => x.CharacterID == invPlant.CharacterID).FirstOrDefault();
            Plant plant = db.Plants.Find(plantID);


            field.PlantID = plantID;
            field.Plant = plant;
            field.isFinished = false;
            field.IsEmpty = false;
            invPlant.ItemPieces--;
            field.FinishDate = DateTime.Now.AddSeconds(plant.PlantGrowTime);

            db.SaveChanges();

            return RedirectToAction("Details", "Characters", new { id = User.Identity.Name });
        }

        public ActionResult ChoosePlantOnField(int id, int charID)
        {
            Inventory inventory = db.Inventories.Find(id);
            PlantOnFieldVM plantOnField = new PlantOnFieldVM();

            // PlantField plantOnField = new PlantField();
            plantOnField.FieldID = id;
            Character character = db.Characters.Find(charID);
            List<Plant> plants = new List<Plant>();
            List<Inventory> items = new List<Inventory>();
            foreach (var plant in db.Plants)
            {
                foreach (var item in character.Inventory)
                {
                    if (plant.ItemID == item.ItemID)
                    {
                        plants.Add(plant);
                        items.Add(item);
                    }
                }
            }

            plantOnField.Plants = plants;
            plantOnField.Inventory = items;


            plantOnField.PageName = db.Characters.Where(y => y.ApplicationUserID == User.Identity.Name).FirstOrDefault().ApplicationUserID;
            plantOnField.Fields = db.CharacterFields.Where(x => x.CharacterID == db.Characters.Where(y => y.ApplicationUserID == User.Identity.Name).FirstOrDefault().CharacterID).ToList();
            plantOnField.EnergyPlusDate = db.Characters.Where(y => y.ApplicationUserID == User.Identity.Name).FirstOrDefault().EnergyPlusDate;
            plantOnField.AttackingZombies = db.ZombieAttackBases.Where(x => x.CharacterID == db.Characters.Where(y => y.ApplicationUserID == User.Identity.Name).FirstOrDefault().CharacterID).ToList();
            plantOnField.AdventureFinishDate = db.Characters.Where(y => y.ApplicationUserID == User.Identity.Name).FirstOrDefault().FinishAdventure;



            return View(plantOnField);
        }


        // GET: Plants
        public ActionResult Index()
        {
            return View(db.Plants.ToList());
        }

        // GET: Plants/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Plant plant = db.Plants.Find(id);
            if (plant == null)
            {
                return HttpNotFound();
            }
            return View(plant);
        }

        // GET: Plants/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Plants/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ItemID,ItemName,ItemPicture,ItemMaxDurability,PlantMoneyCost,PlantGrowTime,PlantRewardCoin,PlantRewardFood,PlantStartPicture,PlantFinishedPicture")] Plant plant)
        {
            if (ModelState.IsValid)
            {
                db.Items.Add(plant);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(plant);
        }

        // GET: Plants/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Plant plant = db.Plants.Find(id);
            if (plant == null)
            {
                return HttpNotFound();
            }
            return View(plant);
        }

        // POST: Plants/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ItemID,ItemName,ItemPicture,ItemMaxDurability,PlantMoneyCost,PlantGrowTime,PlantRewardCoin,PlantRewardFood,PlantStartPicture,PlantFinishedPicture")] Plant plant)
        {
            if (ModelState.IsValid)
            {
                db.Entry(plant).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(plant);
        }

        // GET: Plants/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Plant plant = db.Plants.Find(id);
            if (plant == null)
            {
                return HttpNotFound();
            }
            return View(plant);
        }

        // POST: Plants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Plant plant = db.Plants.Find(id);
            db.Items.Remove(plant);
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
