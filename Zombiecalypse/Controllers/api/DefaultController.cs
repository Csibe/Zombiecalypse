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

        [Route("/api/Default/test")]
        [HttpGet]
        public IHttpActionResult test()
        {
            return Ok();
        }

        [Route("/api/Default/test/")]
        [HttpGet]
        public IHttpActionResult getTest(int id)
        {
            int num = id;
            return Ok(num);
        }


        [HttpGet]
        public IHttpActionResult GrowUpPlant(int id)
        {
            
            CharacterFieldVM model = new CharacterFieldVM();

            model.CharacterField = db.CharacterFields.Find(id);
            model.CharacterField.isFinished = true;
            model.CharacterField.FinishDate = DateTime.MaxValue;

            db.SaveChanges();

            var result = "IsEmpty: " +model.CharacterField.IsEmpty.ToString() + ", isFinished: " + model.CharacterField.isFinished.ToString();

            return Ok(result);
        }


        [HttpGet]
        public IHttpActionResult CheckAdventure()
        {
            Character character = db.Characters.Where(y => y.ApplicationUserID == User.Identity.Name).FirstOrDefault();

            if (character.IsOnAdventure == true && (character.FinishAdventure <= DateTime.Now || character.FinishAdventure >= DateTime.MaxValue.AddDays(-1)))
            {
                if (character.FinishAdventure <= DateTime.Now)
                {
                    character.FinishAdventure = DateTime.MaxValue;
                    db.SaveChanges();
                }
            }
            return Ok();
        }

        [HttpGet]
        public IHttpActionResult ManageEnergy(string id)
        {

            Character character = db.Characters.Where(x => x.ApplicationUserID == id).FirstOrDefault();
           

            if (character.CurrentEnergy < character.MaxEnergy && character.EnergyPlusDate.Year == DateTime.MaxValue.Year)
            {
                character.EnergyPlusDate = DateTime.Now.AddMinutes(2);
            }
            else if (character.CurrentEnergy == character.MaxEnergy && character.EnergyPlusDate.Year < DateTime.MaxValue.Year)
            {
                character.EnergyPlusDate = DateTime.MaxValue;
            }
            else if (character.CurrentEnergy < character.MaxEnergy && character.EnergyPlusDate <= DateTime.Now)
            {
                character.EnergyPlusDate = character.EnergyPlusDate.AddMinutes(2);
                character.CurrentEnergy++;
            }
            else if (character.CurrentEnergy < character.MaxEnergy && character.EnergyPlusDate > DateTime.Now)
            {
            }

            TimeSpan distance = DateTime.Now - character.EnergyPlusDate;
            db.SaveChanges();
         //   var result = "Character engery: " +character.CurrentEnergy +",  date: " +character.EnergyPlusDate +", distance: " + distance + ", minutes: " + distance.Minutes + ", seconds: " +distance.Seconds;

            return Ok();
        }


        [HttpGet]
        public IHttpActionResult ZombieDamageBase(int id)
        {
            ZombieAttackBaseVM model = new ZombieAttackBaseVM();
            model.ZombieAttackBase = db.ZombieAttackBases.Find(id);

            Character character = db.Characters.Where(y => y.ApplicationUserID == User.Identity.Name).FirstOrDefault();
            Inventory fence = character.Inventory.Where(x => x.Item.ItemName == "Fence").FirstOrDefault();
            Building attackedBuilding = new Building();

            model.Zombie = db.Zombies.Find(model.ZombieAttackBase.ZombieID);
            model.Buildings = new List<Building>();


            Random rand = new Random();
            int attackPower = rand.Next(0, model.Zombie.ZombieDamage);
            int random;

            string result;

            if (fence.ItemCurrentDurability > 0)
            {
                attackedBuilding = db.Buildings.Where(x => x.ItemID == fence.ItemID).First();
                model.Buildings.Add(attackedBuilding);
                db.SaveChanges();
            }
            else
            {

                foreach (var build in db.Buildings)
                {
                    foreach (var inv in character.Inventory)
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
            }

            if (model.Buildings.Count() > 0)
            {
                random = rand.Next(0, model.Buildings.Count());

                attackedBuilding = model.Buildings.ToArray()[random];
                int buildingLevel = attackedBuilding.BuildingLevel;

                int newBuildingLevel = --buildingLevel;



                foreach (var inv in character.Inventory)
                {
                    if (inv.ItemID == attackedBuilding.ItemID)
                    {
                        if (inv.ItemCurrentDurability >= attackPower)
                        {
                            inv.ItemCurrentDurability -= attackPower;
                        }
                        else
                        {
                            Building newBuilding = db.Buildings.Where(x => x.ItemName == attackedBuilding.ItemName).Where(x => x.BuildingLevel == newBuildingLevel).FirstOrDefault();
                            inv.ItemID = newBuilding.ItemID;
                            inv.ItemCurrentDurability = newBuilding.ItemMaxDurability;
                            inv.ItemMaxDurability = newBuilding.ItemMaxDurability;
                            db.SaveChanges();

                            
                        }
                    }
                }
                result = model.Zombie.ZombieName + " zombie attacked the" + attackedBuilding.ItemName + ". Attack power: " + attackPower;
            }

            else
            {
                db.ZombieAttackBases.Remove(model.ZombieAttackBase);
                db.SaveChanges();

                result = "Zombies left your base.";
            }

            model.ZombieAttackBase.ZombieAttackStart = model.ZombieAttackBase.ZombieAttackStart.AddHours(1);
            db.SaveChanges();



            return Ok(result);

        }


        [HttpGet]
        public IHttpActionResult ZombieStartAttackBase(string id)
        {
            Character character = db.Characters.Where(x => x.ApplicationUserID == id).FirstOrDefault();

            Random rand = new Random();
            int ZombId = rand.Next(1, db.Zombies.Count() + 1);
            Zombie zombie = db.Zombies.Find(ZombId);

            character.LastZombieAttackTime = DateTime.Now;
            db.SaveChanges();


            ZombieAttackBase zab = new ZombieAttackBase { ZombieAttackStart = DateTime.Now, CharacterID = character.CharacterID, ZombieID = zombie.ZombieID, ZombieLife = zombie.ZombieLife };
            db.ZombieAttackBases.Add(zab);
            db.SaveChanges();

            return Ok();
        }


        [HttpGet]
        public IHttpActionResult GenerateDailyMissions()
        {
            Character character = db.Characters.Where(y => y.ApplicationUserID == User.Identity.Name).FirstOrDefault();


            List<Mission> missions = db.Missions.Where(x => x.CharacterID == character.CharacterID).ToList();

            if (missions.Count() > 0) {
                missions.ForEach(s => db.Missions.Remove(s));
                db.SaveChanges();
            }

            Mission model = new Mission();
           
            List<BuildingMaterial> buildingMaterials = db.BuildingMaterials.ToList();

            List<Material> materials = db.Materials.ToList();

            Random rand = new Random();

            int rewardItem = rand.Next(0, db.BuildingMaterials.Count());
            int taskItem = rand.Next(0, db.Materials.Count());

            Mission mission = new Mission { CharacterID = character.CharacterID, MissionTaskID = db.Materials.ToArray()[taskItem].ItemID, MissionTaskNumber = 2, MissionRewardID = buildingMaterials.ToArray()[rewardItem].ItemID, MissionRewardNumber = 1, MissionRewardXP = 10, MissionType = "collection" };
            db.Missions.Add(mission);
            db.SaveChanges();

            List<Plant> plants = db.Plants.ToList();

            rand = new Random();

            rewardItem = rand.Next(0, db.BuildingMaterials.Count());
            taskItem = rand.Next(0, db.Plants.Count());

            mission = new Mission { CharacterID = character.CharacterID, MissionTaskID = db.Plants.ToArray()[taskItem].ItemID, MissionTaskNumber = 2, MissionRewardID = buildingMaterials.ToArray()[rewardItem].ItemID, MissionRewardNumber = 1, MissionType = "gathering", MissionRewardXP = 10, MissionTaskProgress = 0 };
            db.Missions.Add(mission);
            db.SaveChanges();

            List<Zombie> zombies = db.Zombies.ToList();

            rand = new Random();

            rewardItem = rand.Next(0, db.BuildingMaterials.Count());
            //  int taskItem = rand.Next(0, db.Plants.Count());

            mission = new Mission { CharacterID = character.CharacterID, MissionTaskNumber = 2, MissionRewardID = buildingMaterials.ToArray()[rewardItem].ItemID, MissionRewardNumber = 1, MissionType = "zombiekilling", MissionRewardXP = 10, MissionTaskProgress = 0 };
            db.Missions.Add(mission);
            db.SaveChanges();


            rand = new Random();

            rewardItem = rand.Next(0, db.BuildingMaterials.Count());
            taskItem = rand.Next(0, db.Materials.Count());

            mission = new Mission { CharacterID = character.CharacterID, MissionTaskID = db.Materials.ToArray()[taskItem].ItemID, MissionTaskNumber = 2, MissionRewardID = buildingMaterials.ToArray()[rewardItem].ItemID, MissionRewardNumber = 1, MissionRewardXP = 10, MissionType = "collection" };
            db.Missions.Add(mission);

            character.DailyMissionDate = DateTime.Now;

            db.SaveChanges();

            return Ok();
        }




        [HttpGet]
        public IHttpActionResult AttackZombie(int[] zAAID, int invID)
        {

            var result = zAAID.ToArray();

            return Ok(result);
        }
    }
}
