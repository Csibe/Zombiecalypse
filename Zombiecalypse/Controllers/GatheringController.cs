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

        //public ActionResult GrowUpPlant(int fieldID)
        //{
        //    CharacterFieldVM model = new CharacterFieldVM();

        //    model.CharacterField = db.CharacterFields.Find(fieldID);
        //    model.CharacterField.isFinished = true;
        //    model.CharacterField.FinishDate = DateTime.MaxValue;
        //    db.SaveChanges();
                        
        //    return RedirectToAction("Details", "Characters", new { id = User.Identity.Name });
        //}

        public ActionResult HarvestField(int fieldID, int plantID, string returnUrl)
        {
            CharacterField field = db.CharacterFields.Find(fieldID);
            Plant plant = db.Plants.Find(plantID);
            Character character = db.Characters.Where(x => x.ApplicationUserID == User.Identity.Name).FirstOrDefault();

            List<Mission> missions = db.Missions.Where(x => x.CharacterID == field.CharacterID).Where(x=>x.MissionType=="gathering").ToList();

            foreach (var miss in missions) {
                if (miss.MissionTaskID == plantID) {
                    miss.MissionTaskProgress += 1;
                }
            }

            field.PlantID = 0;
            field.IsEmpty = true;
            field.isFinished = false;

            character.CharacterMoney += plant.PlantRewardCoin;
            character.CharacterFood += plant.PlantRewardFood;
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
