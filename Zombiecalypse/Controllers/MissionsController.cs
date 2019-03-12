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
    public class MissionsController : BaseController
    {


        //public ActionResult GenerateDailyMissions() {

        //    Mission model = new Mission();
        //    Character character = db.Characters.Where(y => y.ApplicationUserID == User.Identity.Name).FirstOrDefault();
        //    List<BuildingMaterial> buildingMaterials = db.BuildingMaterials.ToList();

        //    List<Material> materials = db.Materials.ToList();

        //    Random rand = new Random();

        //    int rewardItem = rand.Next(0, db.BuildingMaterials.Count());
        //    int taskItem = rand.Next(0, db.Materials.Count());

        //    Mission mission = new Mission { CharacterID = character.CharacterID, MissionTaskID = db.Materials.ToArray()[taskItem].ItemID, MissionTaskNumber = 2, MissionRewardID = buildingMaterials.ToArray()[rewardItem].ItemID, MissionRewardNumber = 1, MissionRewardXP = 10, MissionType = "collection" };
        //    db.Missions.Add(mission);
        //    db.SaveChanges();

        //    List<Plant> plants = db.Plants.ToList();

        //    rand = new Random();

        //    rewardItem = rand.Next(0, db.BuildingMaterials.Count());
        //    taskItem = rand.Next(0, db.Plants.Count());

        //    mission = new Mission { CharacterID = character.CharacterID, MissionTaskID = db.Plants.ToArray()[taskItem].ItemID, MissionTaskNumber = 2, MissionRewardID = buildingMaterials.ToArray()[rewardItem].ItemID, MissionRewardNumber = 1, MissionType = "gathering", MissionRewardXP = 10, MissionTaskProgress = 0 };
        //    db.Missions.Add(mission);
        //    db.SaveChanges();

        //    List<Zombie> zombies = db.Zombies.ToList();

        //    rand = new Random();

        //    rewardItem = rand.Next(0, db.BuildingMaterials.Count());
        //    //  int taskItem = rand.Next(0, db.Plants.Count());

        //    mission = new Mission { CharacterID = character.CharacterID, MissionTaskNumber = 2, MissionRewardID = buildingMaterials.ToArray()[rewardItem].ItemID, MissionRewardNumber = 1, MissionType = "zombiekilling", MissionRewardXP = 10, MissionTaskProgress = 0 };
        //    db.Missions.Add(mission);
        //    db.SaveChanges();


        //    rand = new Random();

        //    rewardItem = rand.Next(0, db.BuildingMaterials.Count());
        //    taskItem = rand.Next(0, db.Materials.Count());

        //    mission = new Mission { CharacterID = character.CharacterID, MissionTaskID = db.Materials.ToArray()[taskItem].ItemID, MissionTaskNumber = 2, MissionRewardID = buildingMaterials.ToArray()[rewardItem].ItemID, MissionRewardNumber = 1, MissionRewardXP = 10, MissionType = "collection" };
        //    db.Missions.Add(mission);

        //    character.DailyMissionDate.AddMinutes(10);

        //    db.SaveChanges();



        //    return RedirectToAction("Details", "Characters", new { id = User.Identity.Name });
        //}

        //public ActionResult GenerateGatheringMission(string returnUrl)
        //{

        //    Mission model = new Mission();
        //    Character character = db.Characters.Where(y => y.ApplicationUserID == User.Identity.Name).FirstOrDefault();
        //    List<BuildingMaterial> buildingMaterials = db.BuildingMaterials.ToList();

        //    List<Plant> plants = db.Plants.ToList();

        //    Random rand = new Random();

        //    int rewardItem = rand.Next(0, db.BuildingMaterials.Count());
        //    int taskItem = rand.Next(0, db.Plants.Count());

        //    Mission mission = new Mission { CharacterID = character.CharacterID, MissionTaskID = db.Plants.ToArray()[taskItem].ItemID, MissionTaskNumber = 2, MissionRewardID = buildingMaterials.ToArray()[rewardItem].ItemID, MissionRewardNumber = 1, MissionType = "gathering", MissionRewardXP = 10, MissionTaskProgress = 0 };
        //    db.Missions.Add(mission);
        //    db.SaveChanges();


        //    return Redirect(returnUrl);
        //}

        //public ActionResult GenerateZombieKillingMission(string returnUrl)
        //{

        //    Mission model = new Mission();
        //    Character character = db.Characters.Where(y => y.ApplicationUserID == User.Identity.Name).FirstOrDefault();
        //    List<BuildingMaterial> buildingMaterials = db.BuildingMaterials.ToList();

        //    List<Zombie> plants = db.Zombies.ToList();

        //    Random rand = new Random();

        //    int rewardItem = rand.Next(0, db.BuildingMaterials.Count());
        //    //  int taskItem = rand.Next(0, db.Plants.Count());

        //    Mission mission = new Mission { CharacterID = character.CharacterID, MissionTaskNumber = 2, MissionRewardID = buildingMaterials.ToArray()[rewardItem].ItemID, MissionRewardNumber = 1, MissionType = "zombiekilling", MissionRewardXP = 10, MissionTaskProgress = 0 };
        //    db.Missions.Add(mission);
        //    db.SaveChanges();

        //    return Redirect(returnUrl);
        //}


        //public ActionResult GetMissionReward(int id, string returnUrl)
        //{

        //    Mission mission = db.Missions.Find(id);

        //    Character character = db.Characters.Where(y => y.ApplicationUserID == User.Identity.Name).FirstOrDefault();

        //    foreach (var item in character.Inventory)
        //    {
        //        if (mission.MissionTaskID == item.ItemID && item.ItemPieces >= mission.MissionTaskNumber)
        //        {
        //            item.ItemPieces -= mission.MissionTaskNumber;
        //        }
        //    }

        //    foreach (var item in character.Inventory)
        //    {
        //        if (mission.MissionRewardID == item.ItemID)
        //        {
        //            item.ItemPieces += mission.MissionRewardNumber;
        //            db.Missions.Remove(mission);
        //        }
        //    }


        //    db.SaveChanges();


        //    return RedirectToAction(returnUrl);
        //}


        //public ActionResult AddToGatheringTaskProgress(int id, string returnUrl)
        //{

        //    Mission mission = db.Missions.Find(id);
        //    mission.MissionTaskProgress += 1;

        //    db.SaveChanges();

        //    return Redirect(returnUrl);
        //}


        //public ActionResult Index()
        //{
        //    MissionVM model = new MissionVM();

        //    model.Missions = new List<MissionVM>();
        //    model.Character = db.Characters.Where(x => x.ApplicationUserID == User.Identity.Name).First();

        //    foreach (var miss in db.Missions)
        //    {
        //        if (miss.CharacterID == model.Character.CharacterID)
        //        {
        //            MissionVM mission = new MissionVM();
        //            mission.MissionID = miss.MissionID;
        //            mission.MissionTaskNumber = miss.MissionTaskNumber;
        //            mission.MissionFinishable = false;
        //            mission.MissionRewardNumber = miss.MissionRewardNumber;

        //            if (miss.MissionType == "collection")
        //            {

        //                mission.CollectionMissionReward = db.BuildingMaterials.Find(miss.MissionRewardID);
        //                mission.CollectionMissionTask = db.Materials.Find(miss.MissionTaskID);
        //                mission.MissionType = miss.MissionType;

        //                foreach (var item in model.Character.Inventory)
        //                {
        //                    if (item.ItemID == mission.CollectionMissionTask.ItemID && item.ItemPieces >= mission.MissionTaskNumber)
        //                    {
        //                        mission.MissionFinishable = true;
        //                    }

        //                }
        //            }

        //            else if (miss.MissionType == "gathering")
        //            {

        //                mission.MissionType = miss.MissionType;
        //                mission.GatheringMissionReward = db.BuildingMaterials.Find(miss.MissionRewardID);
        //                mission.GatheringMissionTask = db.Plants.Find(miss.MissionTaskID);
        //                mission.MissionTaskProgress = miss.MissionTaskProgress;
        //                foreach (var item in model.Character.Inventory)
        //                {
        //                    if (item.ItemID == mission.GatheringMissionTask.ItemID && miss.MissionTaskProgress >= mission.MissionTaskNumber)
        //                    {
        //                        mission.MissionFinishable = true;
        //                    }

        //                }
        //            }
        //            else if (miss.MissionType == "zombiekilling")
        //            {

        //                mission.MissionType = miss.MissionType;
        //                mission.GatheringMissionReward = db.BuildingMaterials.Find(miss.MissionRewardID);
        //                mission.MissionTaskProgress = miss.MissionTaskProgress;
        //                if (miss.MissionTaskProgress >= mission.MissionTaskNumber)
        //                {
        //                    mission.MissionFinishable = true;
        //                }
        //            }
        //            model.Missions.Add(mission);

        //        }
        //    }

        //    db.SaveChanges();

        //    base.SetModelProperties(model);
        //    return View(model);
        //}



    }
}