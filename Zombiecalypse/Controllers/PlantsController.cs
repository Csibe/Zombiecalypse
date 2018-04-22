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

        public ActionResult HarvestField(int InvID, int plantID)
        {
            Inventory inventory = db.Inventories.Find(InvID);
            Plant plant = db.Plants.Find(plantID);
            Character character = db.Characters.Where(x => x.CharacterID == inventory.CharacterID).FirstOrDefault();

            inventory.PlantField.PlantID = 0;
            inventory.PlantField.IsFieldEmpty = true;

            character.CharacterMoney += plant.PlantRewardCoin;
            character.CharacterFood += plant.PlantRewardFood;
            db.SaveChanges();

            return RedirectToAction("CharacterDetails", "Characters", new { id = User.Identity.Name });
        }

        public ActionResult PlantOnField(int InvID, int plantID)
        {
            Inventory field = db.Inventories.Find(InvID);
            Inventory invPlant = db.Inventories.Where(x => x.ItemID == plantID).FirstOrDefault();
            Character character = db.Characters.Where(x => x.CharacterID == invPlant.CharacterID).FirstOrDefault();
            Plant plant = db.Plants.Find(plantID);


            field.PlantField.PlantID = plantID;
            field.PlantField.Plant = plant;
            field.isFinished = false;
            field.PlantField.IsFieldEmpty = false;
            invPlant.ItemPieces--;

            db.SaveChanges();

            return RedirectToAction("CharacterDetails", "Characters", new { id = User.Identity.Name });
        }

        public ActionResult ChoosePlantOnField(int id, int charID)
        {
            Inventory inventory = db.Inventories.Find(id);
            PlantOnField plantOnField = new PlantOnField();

           // PlantField plantOnField = new PlantField();
            plantOnField.FieldID = id;
            Character character = db.Characters.Find(charID);
            List<Plant> plants = new List<Plant>();
            List<Inventory> items = new List<Inventory>();
            foreach (var plant in db.Plants) {
                foreach (var item in character.Inventory) {
                    if (plant.ItemID == item.ItemID) {
                        plants.Add(plant);
                        items.Add(item);
                    } 
                }
            }

            plantOnField.Plants = plants;
            plantOnField.Inventory = items;
                 
            return View(plantOnField);
        }
    }
}
