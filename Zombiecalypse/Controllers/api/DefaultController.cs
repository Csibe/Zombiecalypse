using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Zombiecalypse.DAL;
using Zombiecalypse.Models;

namespace Zombiecalypse.Controllers.api
{
    public class DefaultController : ApiController
    {

        DataContext db = new DataContext();

        [HttpGet]
        public IHttpActionResult GrowUpPlant()
        {
            var result = "";

            CharacterFieldVM model = new CharacterFieldVM();
            Character character = db.Characters.Where(x => x.ApplicationUserID == User.Identity.Name).FirstOrDefault();

            model.CharacterFields = db.CharacterFields.Where(x => x.CharacterID == character.CharacterID).Where(x => x.FinishDate <= DateTime.Now).ToList();

            foreach (var field in model.CharacterFields)
            {
                field.isFinished = true;
                field.FinishDate = DateTime.MaxValue;

                Plant plant = db.Plants.Find(field.PlantID);

                result += plant.ItemName + " grew up!";
                db.SaveChanges();
            }

            return Ok(result);
        }


        [HttpGet]
        public IHttpActionResult CheckAdventure()
        {
            Character character = db.Characters.Where(y => y.ApplicationUserID == User.Identity.Name).FirstOrDefault();

            var result = "";

            if (character.IsOnAdventure == true)
            {
                if (character.FinishAdventure <= DateTime.Now)
                {
                    character.FinishAdventure = DateTime.MaxValue;
                    character.isWaitingOnAdventure = false;
                    character.isYourTurn = true;
                    db.SaveChanges();
                    result = "Adventure finished!";
                }
                else if (character.FinishAdventure > DateTime.Now)
                {
                    character.isWaitingOnAdventure = true;
                    db.SaveChanges();
                    result = "You are on adventure!";
                }

            }
            else
            {
                result = "You are not on adventure!";
            }

            return Ok(result);
        }

        [HttpGet]
        public IHttpActionResult ManageEnergy(string id)
        {

            Character character = db.Characters.Where(x => x.ApplicationUserID == id).FirstOrDefault();
            TimeSpan distance = DateTime.Now - character.EnergyPlusDate;

            var result = "";

            if (character.CurrentEnergy < character.MaxEnergy && character.EnergyPlusDate.Year == DateTime.MaxValue.Year)
            {
                character.EnergyPlusDate = DateTime.Now.AddSeconds(20);
            }
            else if (character.CurrentEnergy == character.MaxEnergy && character.EnergyPlusDate.Year < DateTime.MaxValue.Year)
            {
                character.EnergyPlusDate = DateTime.MaxValue;
            }
            else if (character.CurrentEnergy < character.MaxEnergy && character.EnergyPlusDate <= DateTime.Now)
            {
                character.EnergyPlusDate = character.EnergyPlusDate.AddMinutes(1);
                character.CurrentEnergy++;
                result += "Energy recoverd!";

            }
            else if (character.CurrentEnergy < character.MaxEnergy && character.EnergyPlusDate > DateTime.Now)
            {
            }

             db.SaveChanges();

            return Ok(result);
        }



        [HttpGet]
        public IHttpActionResult ManageTolerance(string id)
        {

            Character character = db.Characters.Where(x => x.ApplicationUserID == id).FirstOrDefault();
            TimeSpan distance = DateTime.Now - character.TolerancePlusDate;

            var result = "";
            if (character.IsOnAdventure == false) {
                if (character.Tolerance < character.MaxTolerance && character.TolerancePlusDate.Year == DateTime.MaxValue.Year)
                {
                    character.TolerancePlusDate = DateTime.Now.AddSeconds(20);
                }
                else if (character.Tolerance == character.MaxTolerance && character.TolerancePlusDate.Year < DateTime.MaxValue.Year)
                {
                    character.TolerancePlusDate = DateTime.MaxValue;
                }
                else if (character.Tolerance < character.MaxTolerance && character.TolerancePlusDate <= DateTime.Now)
                {
                    character.TolerancePlusDate = character.TolerancePlusDate.AddMinutes(1);
                    character.Tolerance++;
                    result += "Energy recoverd!";

                }
                else if (character.Tolerance < character.MaxTolerance && character.TolerancePlusDate > DateTime.Now)
                {
                }

                db.SaveChanges();
            }
            return Ok(result);
        }



        [HttpGet]
        public IHttpActionResult ZombieDamageBase()
        {
            ZombieAttackBaseVM model = new ZombieAttackBaseVM();

           model.Character = db.Characters.Where(y => y.ApplicationUserID == User.Identity.Name).FirstOrDefault();

            model.ZombiesAttackBase = db.ZombieAttackBases.Where(x => x.CharacterID == model.Character.CharacterID).Where(x => x.ZombieAttackStart < DateTime.Now).ToList();

            Inventory fence = model.Character.Inventory.Where(x => x.Item.ItemName == "Fence").FirstOrDefault();
            Building attackedBuilding = new Building();


            model.Buildings = new List<Building>();

            var result = "";


            foreach (var build in db.Buildings)
            {
                foreach (var inv in model.Character.Inventory)
                {
                    if (inv.ItemID == build.ItemID)
                    {
                        Building building = db.Buildings.Find(inv.ItemID);
                        if (building.BuildingLevel > 0)
                        {
                            model.Buildings.Add(building);
                        }
                    }
                }
            }

            if (model.Buildings.Count <= 0)
            {
                foreach (var zombie in model.ZombiesAttackBase)
                {
                    db.ZombieAttackBases.Remove(zombie);
                    db.SaveChanges();
                }

                result = "No buildings!";

                return Ok(result);
            }

            //model.Buildings.Count > 0
            else
            {


                foreach (var zombie in model.ZombiesAttackBase)
                {


                    model.Zombie = db.Zombies.Find(zombie.ZombieID);

                    Random rand = new Random();
                    int attackPower = rand.Next(0, model.Zombie.ZombieDamage);
                    int random;
                    TimeSpan distance = DateTime.Now - zombie.ZombieAttackStart;

                    result += " " + model.Zombie.ZombieName + " attacked " + fence.Item.ItemName + " with " + attackPower + ".";

                    if (attackPower <= 0)
                    {

                        result = "Zombie couldn't attack your building";

                        zombie.ZombieAttackStart = zombie.ZombieAttackStart.AddMinutes(60);
                        db.SaveChanges();
                    }

                    //attack power > 0
                    else
                    {

                       if (model.Buildings.Where(x => x.ItemID == fence.ItemID).Count() <= 0)
                        {

                            random = rand.Next(0, model.Buildings.Count());

                            attackedBuilding = model.Buildings.ToArray()[random];
                            Inventory invBuilding = model.Character.Inventory.Where(x => x.ItemID == attackedBuilding.ItemID).First();
                            int buildingLevel = attackedBuilding.BuildingLevel;
                            int newBuildingLevel = buildingLevel;
                            newBuildingLevel--;


                            if (invBuilding.ItemCurrentDurability > attackPower)
                            {

                                invBuilding.ItemCurrentDurability -= attackPower;
                                zombie.ZombieAttackStart = zombie.ZombieAttackStart.AddMinutes(60);
                                db.SaveChanges();

                                result += " " + model.Zombie.ZombieName + " attacked " + fence.Item.ItemName + " with " + attackPower + ".";

                            }


                            // (model.Character.Inventory.Where(x => x.ItemID == attackedBuilding.ItemID).First().ItemCurrentDurability <= attackPower)
                            else
                            {

                                Building newBuilding = db.Buildings.Where(x => x.ItemName == attackedBuilding.ItemName).Where(x => x.BuildingLevel == newBuildingLevel).FirstOrDefault();
                                invBuilding.ItemID = newBuilding.ItemID;
                                invBuilding.ItemCurrentDurability = newBuilding.ItemMaxDurability;
                                invBuilding.ItemMaxDurability = newBuilding.ItemMaxDurability;

                                zombie.ZombieAttackStart = zombie.ZombieAttackStart.AddMinutes(60);
                                db.SaveChanges();

                                result += " " + model.Zombie.ZombieName + " attacked " + fence.Item.ItemName + " with " + attackPower + ".";


                            }


                        }
                        //  (model.Buildings.Where(x => x.ItemID == fence.ItemID).Count() > 0)
                        else
                        {

                            if (fence.ItemCurrentDurability > attackPower)
                            {

                                fence.ItemCurrentDurability -= attackPower;

                                zombie.ZombieAttackStart = zombie.ZombieAttackStart.AddMinutes(60);
                                db.SaveChanges();

                                result += " " +model.Zombie.ZombieName + " attacked " + fence.Item.ItemName + " with " + attackPower + ".";
                            }


                            // (model.Character.Inventory.Where(x => x.ItemID == attackedBuilding.ItemID).First().ItemCurrentDurability <= attackPower)
                            else
                            {

                                Inventory invBuilding = model.Character.Inventory.Where(x => x.ItemID == fence.ItemID).First();
                                Building fenceBuilding = db.Buildings.Find(invBuilding.ItemID);
                                int newBuildingLevel = --fenceBuilding.BuildingLevel;

                                Building newBuilding = db.Buildings.Where(x => x.ItemName == fence.Item.ItemName).Where(x => x.BuildingLevel == newBuildingLevel).FirstOrDefault();
                                fence.ItemID = newBuilding.ItemID;
                                fence.ItemCurrentDurability = newBuilding.ItemMaxDurability;
                                fence.ItemMaxDurability = newBuilding.ItemMaxDurability;

                                zombie.ZombieAttackStart = zombie.ZombieAttackStart.AddMinutes(60);
                                db.SaveChanges();

                                result += " " + model.Zombie.ZombieName + " attacked " + fence.Item.ItemName + " with " + attackPower + ".";

                            }
                        }

                    }

                    if (model.Buildings.Count <= 0)
                    {
                            db.ZombieAttackBases.Remove(zombie);
                            db.SaveChanges();

                        result = "No more buildings!";
                    }
                }

            }

            model.Buildings = new List<Building>();


            foreach (var build in db.Buildings)
            {
                foreach (var inv in model.Character.Inventory)
                {
                    if (inv.ItemID == build.ItemID)
                    {
                        Building building = db.Buildings.Find(inv.ItemID);
                        if (building.BuildingLevel > 0)
                        {
                            model.Buildings.Add(building);
                        }
                    }
                }
            }

            if (model.Buildings.Count <= 0)
            {
                foreach (var zombie in model.ZombiesAttackBase)
                {
                    db.ZombieAttackBases.Remove(zombie);
                    db.SaveChanges();
                }

                result = "No more buildings!";

                return Ok(result);
            }

            return Ok(result);
        }


        [HttpGet]
        public IHttpActionResult ZombieStartAttackBase(string id)
        {
            Character character = db.Characters.Where(x => x.ApplicationUserID == id).FirstOrDefault();

            List<Building> CharacterBuildings = new List<Building>();
            var result = "";
            foreach (var item in character.Inventory)
            {
                foreach (var build in db.Buildings)
                {
                    if (item.ItemID == build.ItemID && build.BuildingLevel != 0)
                    {
                        CharacterBuildings.Add(build);
                    }
                }
            }

            if (CharacterBuildings.Count > 0)
            {

                Random rand = new Random();
                int ZombId = rand.Next(1, db.Zombies.Count() + 1);
                Zombie zombie = db.Zombies.Find(ZombId);

                character.LastZombieAttackTime = DateTime.Now;
                db.SaveChanges();


                ZombieAttackBase zab = new ZombieAttackBase { ZombieAttackStart = DateTime.Now, CharacterID = character.CharacterID, ZombieID = zombie.ZombieID, ZombieLife = zombie.ZombieLife };
                db.ZombieAttackBases.Add(zab);
                db.SaveChanges();

                result += zombie.ZombieName + " attacked the base!";
            }
            else {
                character.LastZombieAttackTime = DateTime.Now;
                db.SaveChanges();
            }


            return Ok(result);
        }




        [HttpGet]
        public IHttpActionResult GenerateDailyMissions()
        {


            Character character = db.Characters.Where(y => y.ApplicationUserID == User.Identity.Name).FirstOrDefault();

            List<CharacterMission> characterMissions = db.CharacterMissions.Where(x => x.CharacterID == character.CharacterID).ToList();

            foreach (var mission in db.DailyMissions)
            {
                foreach (var cm in characterMissions)
                {
                    if (mission.MissionID == cm.MissionID)
                    {
                        foreach (var cmt in db.CharacterMissionTasks.Where(x => x.CharacterID == character.CharacterID).Where(x => x.CharacterMissionID == cm.CharacterMissionID).ToList())
                        {
                            db.CharacterMissionTasks.Remove(cmt);
                        }
                    }
                }
            }

            db.SaveChanges();


            foreach (var mission in db.DailyMissions)
            {
                foreach (var cm in characterMissions)
                {
                    if (mission.MissionID == cm.MissionID)
                    {
                        if (cm.CharacterMissionTasks.Count == 0)
                        {
                            db.CharacterMissions.Remove(cm);
                        }
                    }
                }
            }


            db.SaveChanges();

            Random rand = new Random();
            List<DailyMission> dailyCollectMissions = new List<DailyMission>();

            foreach (var mission in db.DailyMissions) {
                foreach (var task in db.CollectMissionTasks) {
                    if (task.MissionID == mission.MissionID) {
                        dailyCollectMissions.Add(mission);
                    }
                }
            }

            int missionIndex = rand.Next(0, dailyCollectMissions.Count());
            DailyMission selectedMission = dailyCollectMissions.ElementAt<DailyMission>(missionIndex);

            selectedMission.MissionTasks = db.MissionTasks.Where(x => x.MissionID == selectedMission.MissionID).ToList();


            CharacterMission charMiss = new CharacterMission { CharacterID = character.CharacterID, MissionID = selectedMission.MissionID, IsCompleted = false };

            db.CharacterMissions.Add(charMiss);
            db.SaveChanges();

            foreach (var m in selectedMission.MissionTasks)
            {
                CharacterMissionTask characterMissionTask = new CharacterMissionTask { CharacterID = character.CharacterID, MissionTaskID = m.MissionTaskID, CharacterMissionID = charMiss.CharacterMissionID, IsCompleted = false };
                db.CharacterMissionTasks.Add(characterMissionTask);
                db.SaveChanges();
            }


            selectedMission = db.DailyMissions.Find(27);
            selectedMission.MissionTasks = db.MissionTasks.Where(x => x.MissionID == selectedMission.MissionID).ToList();
            charMiss = new CharacterMission { CharacterID = character.CharacterID, MissionID = selectedMission.MissionID, IsCompleted = false };

            db.CharacterMissions.Add(charMiss);
            db.SaveChanges();

            foreach (var m in selectedMission.MissionTasks)
            {
                CharacterMissionTask characterMissionTask = new CharacterMissionTask { CharacterID = character.CharacterID, MissionTaskID = m.MissionTaskID, CharacterMissionID = charMiss.CharacterMissionID, IsCompleted = false };
                db.CharacterMissionTasks.Add(characterMissionTask);
                db.SaveChanges();
            }

            selectedMission = db.DailyMissions.Find(28);
            selectedMission.MissionTasks = db.MissionTasks.Where(x => x.MissionID == selectedMission.MissionID).ToList();
            charMiss = new CharacterMission { CharacterID = character.CharacterID, MissionID = selectedMission.MissionID, IsCompleted = false };

            db.CharacterMissions.Add(charMiss);
            db.SaveChanges();

            foreach (var m in selectedMission.MissionTasks)
            {
                CharacterMissionTask characterMissionTask = new CharacterMissionTask { CharacterID = character.CharacterID, MissionTaskID = m.MissionTaskID, CharacterMissionID = charMiss.CharacterMissionID, IsCompleted = false };
                db.CharacterMissionTasks.Add(characterMissionTask);
                db.SaveChanges();
            }

            selectedMission = db.DailyMissions.Find(29);
            selectedMission.MissionTasks = db.MissionTasks.Where(x => x.MissionID == selectedMission.MissionID).ToList();
            charMiss = new CharacterMission { CharacterID = character.CharacterID, MissionID = selectedMission.MissionID, IsCompleted = false };

            db.CharacterMissions.Add(charMiss);
            db.SaveChanges();

            foreach (var m in selectedMission.MissionTasks)
            {
                CharacterMissionTask characterMissionTask = new CharacterMissionTask { CharacterID = character.CharacterID, MissionTaskID = m.MissionTaskID, CharacterMissionID = charMiss.CharacterMissionID, IsCompleted = false };
                db.CharacterMissionTasks.Add(characterMissionTask);
                db.SaveChanges();
            }

            character.DailyMissionDate = DateTime.Now;

            db.SaveChanges();

            return Ok();
        }


        [HttpGet]
        public IHttpActionResult ManageTurns(string id)
        {

            Character character = db.Characters.Where(y => y.ApplicationUserID == id).FirstOrDefault();
            var result = "";
            if (character.isYourTurn == false)
            {
                List<ZombieAttackAdventurer> zombieAttackInThisTurn = new List<ZombieAttackAdventurer>();

                zombieAttackInThisTurn = db.ZombieAttackAdventurers.Where(x => x.CharacterID == character.CharacterID).Where(x => x.State == character.AdventureState).ToList();

                for (int c = 0; c < zombieAttackInThisTurn.Count; c++)
                {

                    if (zombieAttackInThisTurn.ToArray()[c].isYourTurn == true && c < zombieAttackInThisTurn.Count - 1)
                    {
                        int d = c + 1;
                        var zombieAttack = new DefaultController().ZombieAttackAdventurer(User.Identity.Name);
                        zombieAttackInThisTurn.ToArray()[c].isYourTurn = false;
                        zombieAttackInThisTurn.ToArray()[d].isYourTurn = true;
                        db.SaveChanges();
                        break;
                        //  result += " " + zombieAttackInThisTurn.ToArray()[d].ZombieAttackAdventurerID + "is attacking ";
                    }
                    else if (zombieAttackInThisTurn.ToArray()[c].isYourTurn == true && c == zombieAttackInThisTurn.Count - 1)
                    {
                        var zombieAttack = new DefaultController().ZombieAttackAdventurer(User.Identity.Name);
                        zombieAttackInThisTurn.ToArray()[c].isYourTurn = false;
                        character.isYourTurn = true;
                    }

                }

                db.SaveChanges();
            }
            else
            {
                result += "Your turn!";
            }

            return Ok(result);
        }


        [HttpGet]
        public IHttpActionResult ZombieAttackAdventurer(string userID)
        {
            ZombieAttackAdventurerVM model = new ZombieAttackAdventurerVM();

            var result = "Zombie attacked adventurer";

            model.Character = db.Characters.Where(y => y.ApplicationUserID == userID).FirstOrDefault();
            model.ZombieAttackAdventurer = db.ZombieAttackAdventurers.Where(x => x.CharacterID == model.Character.CharacterID).Where(x => x.isYourTurn == true).FirstOrDefault();
          //  model.ZombieAttackAdventurer.isYourTurn = false;
            model.Zombie = db.Zombies.Find(model.ZombieAttackAdventurer.ZombieID);
            model.Adventure = db.Adventures.Find(model.Character.AdventureID);

            Random rand = new Random();
            int attackPower = rand.Next(1, model.Zombie.ZombieDamage + 1);

            model.Character.Tolerance -= attackPower;

            if (model.Character.Tolerance <= 0)
            {

                model.Character.Tolerance = 0;
                List<ZombieAttackAdventurer> zombies = db.ZombieAttackAdventurers.Where(x => x.CharacterID == model.Character.CharacterID).ToList();

                zombies.ForEach(x => db.ZombieAttackAdventurers.Remove(x));
                model.Character.IsOnAdventure = false;
                model.Character.isWaitingOnAdventure = false;
                model.Character.FinishAdventure = DateTime.MaxValue;
                model.Character.TolerancePlusDate = DateTime.Now.AddMinutes(5);
                db.SaveChanges();

            }

            db.SaveChanges();
            return Ok(result);
        }

    }
}
