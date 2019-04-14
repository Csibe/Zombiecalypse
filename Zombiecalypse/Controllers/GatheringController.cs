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
    public class GatheringController : BaseController
    {

        public ActionResult HarvestField(int fieldID, int plantID, string returnUrl)
        {
            CharacterField field = db.CharacterFields.Find(fieldID);
            Plant plant = db.Plants.Find(plantID);
            Character character = db.Characters.Where(x => x.ApplicationUserID == User.Identity.Name).FirstOrDefault();

            field.PlantID = 0;
            field.IsEmpty = true;
            field.isFinished = false;

            character.CharacterMoney += plant.PlantRewardCoin;
            character.CharacterFood += plant.PlantRewardFood;
            var result = new MissionsController().HarvestMission(plantID, User.Identity.Name);

            db.SaveChanges();

            return Redirect(returnUrl);
        }

        public ActionResult PlantOnField(int fieldID, int plantID)
        {
            CharacterField field = db.CharacterFields.Find(fieldID);
            Inventory invPlant = db.Inventories.Where(x => x.ItemID == plantID).FirstOrDefault();
            Character character = db.Characters.Where(x => x.ApplicationUserID == User.Identity.Name).FirstOrDefault();
            Plant plant = db.Plants.Find(plantID);

            if (invPlant.ItemPieces > 0)
            {
                field.PlantID = plantID;
                field.isFinished = false;
                field.IsEmpty = false;
                invPlant.ItemPieces--;
                field.FinishDate = DateTime.Now.AddSeconds(plant.PlantGrowTime);

                db.SaveChanges();

            }

            return RedirectToAction("Details", "Characters", new { id = User.Identity.Name });
        }

        public ActionResult ChoosePlantOnField(int id)
        {
            Inventory inventory = db.Inventories.Find(id);
            PlantOnFieldVM model = new PlantOnFieldVM();

            model.FieldID = id;

            Character character = db.Characters.Where(x => x.ApplicationUserID == User.Identity.Name).FirstOrDefault();

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

            model.Plants = plants;
            model.Inventory = items;

            SetModelProperties(model);

            base.SetModelProperties(model);
            return View(model);
        }


    }
}
