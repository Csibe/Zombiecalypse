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

    public class CharactersController : BaseController
    {


        public ActionResult UseEnergyPacks(int itemId, string returnUrl) {

            Energy energy = db.Energies.Find(itemId);
            Character character = db.Characters.Where(x => x.ApplicationUserID == User.Identity.Name).FirstOrDefault();

            Inventory invEnergy = character.Inventory.Where(x => x.ItemID == energy.ItemID).FirstOrDefault();


            invEnergy.ItemPieces -= 1;
            character.CurrentEnergy += energy.PlusEnergy;

            db.SaveChanges();

            return Redirect(returnUrl);
        }


        public ActionResult AddToEnergy()
        {
            Character character = db.Characters.Where(x => x.ApplicationUserID == User.Identity.Name).FirstOrDefault();
            character.CurrentEnergy++;
            db.SaveChanges();

            return RedirectToAction("Details", "Characters", new { id = User.Identity.Name });
        }


        public ActionResult ManageEnergy(string id, int energyCost, string returnUrl)
        {
            Character character = db.Characters.Where(x => x.ApplicationUserID == id).FirstOrDefault();

            if (character == null)
            {
                return HttpNotFound();
            }
            character.CurrentEnergy -= energyCost;


            if (character.CurrentEnergy == character.MaxEnergy && character.EnergyPlusDate.Year == DateTime.MaxValue.Year)
            {
            }
            else if (character.CurrentEnergy < character.MaxEnergy && character.EnergyPlusDate.Year == DateTime.MaxValue.Year)
            {
                character.EnergyPlusDate = DateTime.Now.AddSeconds(20);
            }
            else if (character.CurrentEnergy == character.MaxEnergy && character.EnergyPlusDate.Year < DateTime.MaxValue.Year)
            {
                character.EnergyPlusDate = DateTime.MaxValue;
            }
            else if (character.CurrentEnergy < character.MaxEnergy && character.EnergyPlusDate <= DateTime.Now)
            {
                character.EnergyPlusDate = DateTime.Now.AddSeconds(20);
                character.CurrentEnergy++;
            }
            else if (character.CurrentEnergy < character.MaxEnergy && character.EnergyPlusDate > DateTime.Now)
            {
            }
            else if (character.CurrentEnergy < character.MaxEnergy && character.EnergyPlusDate < DateTime.Now)
            {

                character.CurrentEnergy++;
                character.EnergyPlusDate = DateTime.MaxValue;
            }

            db.SaveChanges();
            return Redirect(returnUrl);
        }


        public ActionResult ManageXPAndLevelUp(string id, int add, string returnUrl)
        {

            Character character = db.Characters.Where(x => x.ApplicationUserID == id).FirstOrDefault();
            Level DbLevel = db.Levels.Where(x => x.LevelID == character.CharacterLevel).SingleOrDefault();
            int DbLevelID = DbLevel.LevelID;
            int DbLevelXP = DbLevel.LevelMaxXP;
            character.CharacterXP += add;

            if (character.CharacterXP >= DbLevelXP)
            {
                character.CharacterLevel++;
            }

            db.SaveChanges();
            return RedirectToAction(returnUrl);
        }

        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return View("Index", "Home", null);
            }

            CharacterDetailsViewModel model = new CharacterDetailsViewModel();

            model.Character = db.Characters.Where(y => y.ApplicationUserID == User.Identity.Name).FirstOrDefault();
            model.CharacterBuildings = new List<Building>();

            foreach (var item in model.Character.Inventory)
            {
                foreach (var build in db.Buildings)
                {
                    if (item.ItemID == build.ItemID && item.Item.ItemName != "Fence")
                    {
                        model.CharacterBuildings.Add(build);
                    }
                }
            }


            model.CharacterFields = db.CharacterFields.Where(x => x.CharacterID == model.Character.CharacterID).ToList();
            model.Adventures = db.Adventures.ToList();

            model.Missions = new List<MissionVM>();

            foreach (var miss in db.Missions)
            {
                if (miss.CharacterID == model.Character.CharacterID)
                {
                    MissionVM mission = new MissionVM();
                    mission.MissionID = miss.MissionID;
                    mission.MissionTaskNumber = miss.MissionTaskNumber;
                    mission.MissionFinishable = false;
                    mission.MissionRewardNumber = miss.MissionRewardNumber;

                    if (miss.MissionType == "collection") {

                        mission.CollectionMissionReward = db.BuildingMaterials.Find(miss.MissionRewardID);
                        mission.CollectionMissionTask = db.Materials.Find(miss.MissionTaskID);
                        mission.MissionType = miss.MissionType;
                        
                        foreach (var item in model.Character.Inventory)
                        {
                            if (item.ItemID == mission.CollectionMissionTask.ItemID && item.ItemPieces >= mission.MissionTaskNumber)
                            {
                                mission.MissionFinishable = true;
                            }

                        }
                    }

                    else if(miss.MissionType == "gathering"){

                        mission.MissionType = miss.MissionType;
                        mission.GatheringMissionReward = db.BuildingMaterials.Find(miss.MissionRewardID);
                        mission.GatheringMissionTask = db.Plants.Find(miss.MissionTaskID);
                        mission.MissionTaskProgress = miss.MissionTaskProgress;
                        foreach (var item in model.Character.Inventory)
                        {
                            if (item.ItemID == mission.GatheringMissionTask.ItemID && miss.MissionTaskProgress >= mission.MissionTaskNumber)
                            {
                                mission.MissionFinishable = true;
                            }

                        }
                    }
                    else if (miss.MissionType == "zombiekilling")
                    {

                        mission.MissionType = miss.MissionType;
                        mission.GatheringMissionReward = db.BuildingMaterials.Find(miss.MissionRewardID);
                        mission.MissionTaskProgress = miss.MissionTaskProgress;
                            if (miss.MissionTaskProgress >= mission.MissionTaskNumber)
                            {
                                mission.MissionFinishable = true;
                            }
                    }

                    model.Missions.Add(mission);

                }
            }


            model.CharacterNextLevelXP = db.Levels.Where(l => l.LevelID == model.Character.CharacterLevel).FirstOrDefault().LevelMaxXP;



            model.Fence = model.Character.Inventory.Where(x => x.Item.ItemName == "Fence").FirstOrDefault();

            model.ZombiesDB = db.Zombies.ToList();
            model.ZombieAttackBase = db.ZombieAttackBases.Where(x => x.CharacterID == db.Characters.Where(y => y.ApplicationUserID == User.Identity.Name).FirstOrDefault().CharacterID).ToList();
            model.EnergyPacks = db.Energies.ToList();


            string Picture = "/Content/Pictures/Base/";
            string[] BaseName;

            foreach (var build in model.CharacterBuildings)
            {
                BaseName = build.ItemName.Split(' ');
                Picture += BaseName[0] + build.BuildingLevel;
            }

            Picture += ".png";

            model.BasePicture = Picture;

            model.CharacterBuildings.Add(db.Buildings.Where(x => x.ItemID == model.Fence.ItemID).FirstOrDefault());

            model.OwnedDog = db.OwnedDogs.Where(x => x.CharacterID == model.Character.CharacterID).FirstOrDefault();


            base.SetModelProperties(model);
            return View(model);
        }

    }
}
