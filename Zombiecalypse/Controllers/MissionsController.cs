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

        public ActionResult Index()
        {

            MissionVM model = new MissionVM();

            model.Character = db.Characters.Where(x => x.ApplicationUserID == User.Identity.Name).First();
            model.Missions = db.Missions.ToList();
            model.Items = db.Items.ToList();
            model.InProgressMissions = db.CharacterMissions.Where(x => x.CharacterID == model.Character.CharacterID).ToList();
            model.Zombies = db.Zombies.ToList();


            foreach (var mission in model.InProgressMissions)
            {
                mission.CharacterMissionTasks = db.CharacterMissionTasks.Where(x => x.CharacterMissionID == mission.CharacterMissionID).ToList();
            }


            foreach (var mission in model.Missions)
            {
                mission.MissionTasks = db.MissionTasks.Where(x => x.MissionID == mission.MissionID).ToList();
            }

            foreach (var mission in model.InProgressMissions)
            {
                var result = new MissionsController().CheckMission(mission.CharacterMissionID, User.Identity.Name);
            }


            db.SaveChanges();

            base.SetModelProperties(model);
            return View(model);
        }

        public ActionResult StartMission(int id, string userID)
        {
            if (userID == null)
            {
                userID = User.Identity.Name;
            }


            Character character = db.Characters.Where(y => y.ApplicationUserID == userID).FirstOrDefault();
            Mission mission = db.Missions.Find(id);
            mission.MissionTasks = db.MissionTasks.Where(x => x.MissionID == mission.MissionID).ToList();

            CharacterMission charMiss = new CharacterMission { CharacterID = character.CharacterID, MissionID = mission.MissionID, IsCompleted = false };

            db.CharacterMissions.Add(charMiss);
            db.SaveChanges();

            foreach (var m in mission.MissionTasks)
            {
                CharacterMissionTask characterMissionTask = new CharacterMissionTask { CharacterMissionTaskID = 1, CharacterID = character.CharacterID, MissionTaskID = m.MissionTaskID, CharacterMissionID = charMiss.CharacterMissionID, IsCompleted = false };
                db.CharacterMissionTasks.Add(characterMissionTask);
                db.SaveChanges();
            }


            var result = new MissionsController().CheckMission(charMiss.CharacterMissionID, userID);

            return RedirectToAction("Index", "Missions", new { id = userID });
        }

        public ActionResult CheckMission(int id, string userID)
        {

            Character character = db.Characters.Where(y => y.ApplicationUserID == userID).FirstOrDefault();
            character.Inventory = db.Inventories.Where(x => x.CharacterID == character.CharacterID).ToList();

            List<Item> items = db.Items.ToList();

            CharacterMission characterMission = db.CharacterMissions.Find(id);
            List<CharacterMissionTask> characterMissionTasks = db.CharacterMissionTasks.Where(x => x.CharacterMissionID == characterMission.CharacterMissionID).ToList();

            Mission mission = db.Missions.Find(characterMission.MissionID);
            List<MissionTask> missionTasks = db.MissionTasks.Where(x => x.MissionID == mission.MissionID).ToList();


            foreach (var cmt in characterMissionTasks)
            {
                foreach (var mt in missionTasks)
                {
                    if (mt.MissionTaskID == cmt.MissionTaskID && mt.GetType().Name == "CollectMissionTask")
                    {

                        foreach (var inv in character.Inventory)
                        {
                            if (mt.ItemID == inv.ItemID)
                            {
                                cmt.TaskProgress = inv.ItemPieces;
                                db.SaveChanges();
                                if (cmt.TaskProgress < mt.ItemPieces)
                                {
                                    cmt.IsCompleted = false;
                                }
                                else
                                {
                                    cmt.IsCompleted = true;
                                }
                            }
                        }
                    }
                }
            }

            foreach (var cmt in characterMissionTasks)
            {
                foreach (var mt in missionTasks)
                {
                    if (mt.MissionTaskID == cmt.MissionTaskID)
                    {
                        if (cmt.TaskProgress < mt.ItemPieces)
                        {
                            cmt.IsCompleted = false;
                        }
                        else
                        {
                            cmt.IsCompleted = true;
                        }
                    }
                }
            }

            db.SaveChanges();


            int taskcounter = 0;

            foreach (var task in characterMissionTasks)
            {
                if (task.IsCompleted == true)
                {
                    taskcounter++;
                }
            }

            if (taskcounter == mission.MissionTasks.Count())
            {
                characterMission.IsCompleted = true;
            }
            else
            {
                characterMission.IsCompleted = false;
            }


            db.SaveChanges();

            return RedirectToAction("Index", "Missions", new { id = userID });
        }

        public ActionResult GetReward(int id)
        {

            Character character = db.Characters.Where(y => y.ApplicationUserID == User.Identity.Name).FirstOrDefault();
            character.Inventory = db.Inventories.Where(x => x.CharacterID == character.CharacterID).ToList();

            List<Item> items = db.Items.ToList();

            CharacterMission characterMission = db.CharacterMissions.Find(id);
            List<CharacterMissionTask> characterMissionTasks = db.CharacterMissionTasks.Where(x => x.CharacterMissionID == characterMission.CharacterMissionID).ToList();

            Mission mission = db.Missions.Find(characterMission.MissionID);
            List<MissionTask> missionTasks = db.MissionTasks.Where(x => x.MissionID == mission.MissionID).ToList();

            foreach (var cmt in characterMissionTasks)
            {
                foreach (var mt in missionTasks)
                {
                    if (mt.MissionTaskID == cmt.MissionTaskID)
                    {

                        foreach (var inv in character.Inventory)
                        {
                            if (mt.ItemID == inv.ItemID)
                            {
                                if (cmt.TaskProgress >= mt.ItemPieces)
                                {
                                    inv.ItemPieces -= mt.ItemPieces;
                                    db.CharacterMissionTasks.Remove(cmt);
                                    character.CharacterMoney += mission.RewardICoins;
                                    var resultXP = new CharactersController().ManageXPAndLevelUp(User.Identity.Name, mission.RewardXP, this.Request.FilePath);
                                }
                            }
                        }
                        if (mt.ItemID == 0)
                        {
                            if (cmt.TaskProgress >= mt.ItemPieces)
                            {
                                db.CharacterMissionTasks.Remove(cmt);
                                character.CharacterMoney += mission.RewardICoins;
                                var resultXP = new CharactersController().ManageXPAndLevelUp(User.Identity.Name, mission.RewardXP, this.Request.FilePath);
                            }
                        }
                    }
                }
            }
            db.SaveChanges();


            characterMissionTasks = db.CharacterMissionTasks.Where(x => x.CharacterMissionID == characterMission.CharacterMissionID).ToList();


            if (characterMissionTasks.Count() == 0)
            {
                db.CharacterMissions.Remove(characterMission);
            }

            db.SaveChanges();

            if (mission.IsNextMission)
            {
                var result = new MissionsController().StartMission(mission.MissionID + 1, User.Identity.Name);
            }


            return RedirectToAction("Index", "Missions", new { id = User.Identity.Name });
        }


        public ActionResult RepairMission(int id)
        {
            Character character = db.Characters.Where(y => y.ApplicationUserID == User.Identity.Name).FirstOrDefault();
            character.Inventory = db.Inventories.Where(x => x.CharacterID == character.CharacterID).ToList();

            List<Item> items = db.Items.ToList();

            CharacterMission characterMission = db.CharacterMissions.Find(id);
            List<CharacterMissionTask> characterMissionTasks = db.CharacterMissionTasks.Where(x => x.CharacterMissionID == characterMission.CharacterMissionID).ToList();

            Mission mission = db.Missions.Find(characterMission.MissionID);
            List<MissionTask> missionTasks = db.MissionTasks.Where(x => x.MissionID == mission.MissionID).ToList();


            foreach (var cmt in characterMissionTasks)
            {
                foreach (var mt in missionTasks)
                {
                    if (mt.MissionTaskID == cmt.MissionTaskID && mt.GetType().Name == "RepairMissionTask")
                    {

                        foreach (var inv in character.Inventory)
                        {
                            if (mt.ItemID == inv.ItemID)
                            {
                                cmt.TaskProgress++;
                            }
                        }
                    }
                }
            }

            db.SaveChanges();

            return RedirectToAction("Index", "Missions", new { id = User.Identity.Name });
        }

        public ActionResult HarvestMission(int id, string userID)
        {

            if (userID == null)
            {
                userID = User.Identity.Name;
            }

            Character character = db.Characters.Where(y => y.ApplicationUserID == userID).FirstOrDefault();
            character.Inventory = db.Inventories.Where(x => x.CharacterID == character.CharacterID).ToList();

            List<Item> items = db.Items.ToList();


            List<Mission> missions = db.Missions.ToList();
            List<CharacterMission> inProgressMissions = db.CharacterMissions.Where(x => x.CharacterID == character.CharacterID).ToList();

            foreach (var mission in inProgressMissions)
            {
                mission.CharacterMissionTasks = db.CharacterMissionTasks.Where(x => x.CharacterMissionID == mission.CharacterMissionID).ToList();
            }

            foreach (var mission in missions)
            {
                mission.MissionTasks = db.MissionTasks.Where(x => x.MissionID == mission.MissionID).ToList();
            }


            foreach (var cm in inProgressMissions)
            {
                foreach (var m in missions)
                {
                    if (cm.MissionID == m.MissionID)
                    {
                        foreach (var cmt in cm.CharacterMissionTasks)
                        {
                            foreach (var mt in m.MissionTasks)
                            {
                                if (cmt.MissionTaskID == mt.MissionTaskID)
                                {
                                    if (mt.ItemID == id)
                                    {
                                        cmt.TaskProgress++;
                                    }
                                }

                            }
                        }
                    }
                }
            }

            db.SaveChanges();

            return RedirectToAction("Index", "Missions", new { id = userID });
        }




        public ActionResult KillingMission(int id, string userID)
        {

            if (userID == null)
            {
                userID = User.Identity.Name;
            }

            Character character = db.Characters.Where(y => y.ApplicationUserID == userID).FirstOrDefault();

            List<Mission> missions = db.Missions.ToList();
            List<CharacterMission> inProgressMissions = db.CharacterMissions.Where(x => x.CharacterID == character.CharacterID).ToList();

            foreach (var mission in inProgressMissions)
            {
                mission.CharacterMissionTasks = db.CharacterMissionTasks.Where(x => x.CharacterMissionID == mission.CharacterMissionID).ToList();
            }

            foreach (var mission in missions)
            {
                mission.MissionTasks = db.MissionTasks.Where(x => x.MissionID == mission.MissionID).ToList();
            }


            foreach (var cm in inProgressMissions)
            {
                foreach (var m in missions)
                {
                    if (cm.MissionID == m.MissionID)
                    {
                        foreach (var cmt in cm.CharacterMissionTasks)
                        {
                            foreach (var mt in m.MissionTasks)
                            {
                                if (mt.ItemID == 0 && mt.GetType().Name == "KillingMissionTask")
                                {
                                    cmt.TaskProgress++;
                                }
                                else
                                {
                                    if (cmt.MissionTaskID == mt.MissionTaskID)
                                    {
                                        if (mt.ItemID == id)
                                        {
                                            cmt.TaskProgress++;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }


            db.SaveChanges();

            return RedirectToAction("Index", "Missions", new { id = userID });
        }



        public ActionResult AdventureMission(string userID)
        {

            if (userID == null)
            {
                userID = User.Identity.Name;
            }

            Character character = db.Characters.Where(y => y.ApplicationUserID == userID).FirstOrDefault();

            List<Mission> missions = db.Missions.ToList();
            List<CharacterMission> inProgressMissions = db.CharacterMissions.Where(x => x.CharacterID == character.CharacterID).ToList();

            foreach (var mission in inProgressMissions)
            {
                mission.CharacterMissionTasks = db.CharacterMissionTasks.Where(x => x.CharacterMissionID == mission.CharacterMissionID).ToList();
            }

            foreach (var mission in missions)
            {
                mission.MissionTasks = db.MissionTasks.Where(x => x.MissionID == mission.MissionID).ToList();
            }


            foreach (var cm in inProgressMissions)
            {
                foreach (var m in missions)
                {
                    if (cm.MissionID == m.MissionID)
                    {
                        foreach (var cmt in cm.CharacterMissionTasks)
                        {
                            foreach (var mt in m.MissionTasks)
                            {
                                if (cmt.MissionTaskID == mt.MissionTaskID && mt.GetType().Name == "AdventureMissionTask")
                                {
                                    if (mt.ItemID == 0)
                                    {
                                        cmt.TaskProgress++;
                                    }
                                }

                            }
                        }
                    }
                }
            }

            db.SaveChanges();

            return RedirectToAction("Index", "Missions", new { id = userID });
        }


        //public ActionResult GetReward(string userID)
        //{

        //    if (userID == null)
        //    {
        //        userID = User.Identity.Name;
        //    }

        //    Character character = db.Characters.Where(y => y.ApplicationUserID == userID).FirstOrDefault();

        //    List<Mission> missions = db.Missions.ToList();
        //    List<CharacterMission> inProgressMissions = db.CharacterMissions.Where(x => x.CharacterID == character.CharacterID).ToList();

        //    foreach (var mission in inProgressMissions)
        //    {
        //        mission.CharacterMissionTasks = db.CharacterMissionTasks.Where(x => x.CharacterMissionID == mission.CharacterMissionID).ToList();
        //    }

        //    foreach (var mission in missions)
        //    {
        //        mission.MissionTasks = db.MissionTasks.Where(x => x.MissionID == mission.MissionID).ToList();
        //    }



        //    return RedirectToAction("Index", "Missions", new { id = userID });
        //}

    }
}