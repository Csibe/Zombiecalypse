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



        public ActionResult GrowUpPlant(int InvID)
        {
            Inventory inventory = db.Inventories.Find(InvID);
            inventory.isFinished = true;
            db.SaveChanges();

            return RedirectToAction("CharacterDetails", "Characters", new { id = User.Identity.Name });
        }

        public ActionResult HarvestField(int InvID)
        {
            Inventory inventory = db.Inventories.Find(InvID);
            inventory.PlantField.PlantID = 0;
            inventory.PlantField.IsFieldEmpty = true;
            db.SaveChanges();

            return RedirectToAction("CharacterDetails", "Characters", new { id = User.Identity.Name });
        }

        public ActionResult PlantOnField(int InvID, int plantID)
        {
            Inventory inventory = db.Inventories.Find(InvID);

            Plant plant = db.Plants.Find(plantID);
            inventory.PlantField.PlantID = plantID;
            inventory.PlantField.Plant = plant;
            inventory.isFinished = false;
            inventory.PlantField.IsFieldEmpty = false;
            db.SaveChanges();

            return RedirectToAction("CharacterDetails", "Characters", new { id = User.Identity.Name });
        }

        public ActionResult ChoosePlantOnField(int id)
        {
            Inventory inventory = db.Inventories.Find(id);
            PlantField plantOnField = new PlantField();
            plantOnField.PlantFieldId = id;
            plantOnField.ItemID = inventory.ItemID;
            plantOnField.ItemName = inventory.Item.ItemName;
            ICollection<Plant> plants = db.Plants.ToList();
            plantOnField.PlantablePlants = plants;
            return View(plantOnField);
        }
    }
}
