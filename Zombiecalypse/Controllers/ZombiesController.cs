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
    public class ZombiesController : BaseController
    {

        public ActionResult ZombieStartAttackBase(string id, string returnUrl)
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

            return Redirect(returnUrl);
        }



        public ActionResult BaseDefenseFromZombie(int ZabID, int AttackPower, int invID)
        {
            BaseDefenseFromZombiesVM model = new BaseDefenseFromZombiesVM();
            model.ZombieAttackBase = db.ZombieAttackBases.Find(ZabID);
            model.Zombie = db.Zombies.Find(model.ZombieAttackBase.ZombieID);
            model.Character = db.Characters.Find(model.ZombieAttackBase.CharacterID);

            ICollection<Inventory> inventory = model.Character.Inventory;

            model.Weapon = db.Weapons.Find(59);


                if (invID != 0)
                {
                    var inv = db.Inventories.Find(invID);
                    if (inv.ItemCurrentDurability > 1 && inv.ItemMaxDurability != 999)
                    {
                        inv.ItemCurrentDurability--;
                    }
                    else if (inv.ItemCurrentDurability > 1 && inv.ItemMaxDurability == 999)
                    {

                    }
                    else
                    {
                        if (inv.ItemPieces > 0)
                        {
                            inv.ItemCurrentDurability = inv.ItemMaxDurability;
                            inv.ItemPieces--;
                        }
                    }
                }
                if (AttackPower > 0)
                {
                    model.ZombieAttackBase.ZombieLife -= AttackPower;
                    var result = new CharactersController().ManageEnergy(User.Identity.Name, 1, this.Request.Path);

            }


            model.BuyableWeapons = new List<BuyableWeapon>();
            model.CraftableWeapons = new List<CraftableWeapon>();

            foreach (var item in model.Character.Inventory)
            {
                foreach (var weap in db.BuyableWeapons)
                {
                    if (item.ItemID == weap.ItemID)
                    {
                        model.BuyableWeapons.Add(weap);
                    }
                }
            }

            foreach (var item in model.Character.Inventory)
            {
                foreach (var weap in db.CraftableWeapons)
                {
                    if (item.ItemID == weap.ItemID)
                    {
                        model.CraftableWeapons.Add(weap);
                    }
                }
            }

            if (model.ZombieAttackBase.ZombieLife <= 0)
            {
                List<Mission> zombieMission = db.Missions.Where(x => x.CharacterID == model.Character.CharacterID).Where(x => x.MissionType == "zombiekilling").ToList();
               
                if (zombieMission != null) {
                    foreach (var mission in zombieMission) {
                        mission.MissionTaskProgress++;
                    }
                }


                db.SaveChanges();

                base.SetModelProperties(model);
                return RedirectToAction("CollectReward", "Zombies", new { zABID = model.ZombieAttackBase.ZombieAttackBaseID, rewardXP = model.Zombie.RewardXP, rewardCoin = model.Zombie.RewardCoins });

            }


            db.SaveChanges();

            base.SetModelProperties(model);
            return View(model);

        }


        public ActionResult CollectReward(int zABID, int rewardXP, int rewardCoin)
        {

            AttackingZombieReward model = new AttackingZombieReward();

            model.RexardXP = rewardXP;
            model.RewardCoin = rewardCoin;

            Character character = db.Characters.Where(y => y.ApplicationUserID == User.Identity.Name).FirstOrDefault();

            ZombieAttackBase zAB = db.ZombieAttackBases.Find(zABID);

            var addXP = new CharactersController().ManageXPAndLevelUp(User.Identity.Name, rewardXP, this.Request.FilePath);
            character.CharacterMoney += rewardCoin;
            db.ZombieAttackBases.Remove(zAB);


            db.SaveChanges();
            base.SetModelProperties(model);

            return View(model);
        }



        public ActionResult ZombieAttackBase(int ZabID)
        {
            ZombieAttackBaseVM model = new ZombieAttackBaseVM();
            model.ZombieAttackBase = db.ZombieAttackBases.Find(ZabID);

            Character character = db.Characters.Where(y => y.ApplicationUserID == User.Identity.Name).FirstOrDefault();
            Inventory fence = character.Inventory.Where(x => x.Item.ItemName == "Fence").FirstOrDefault();
            Building destroyedBuilding = new Building();

            model.Zombie = db.Zombies.Find(model.ZombieAttackBase.ZombieID);

            model.Buildings = new List<Building>();


            Random rand = new Random();
            int attackPower = rand.Next(0, model.Zombie.ZombieDamage);
            int random;

            if (fence.ItemCurrentDurability > 0)
            {
                fence.ItemCurrentDurability -= attackPower;
                destroyedBuilding = db.Buildings.Where(x => x.ItemID == fence.ItemID).First();
                model.Buildings.Add(destroyedBuilding);
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

                destroyedBuilding = model.Buildings.ToArray()[random];
                int buildingLevel = destroyedBuilding.BuildingLevel;

                int newBuildingLevel = --buildingLevel;



                foreach (var inv in character.Inventory)
                {
                    if (inv.ItemID == destroyedBuilding.ItemID)
                    {
                        if (inv.ItemCurrentDurability >= attackPower)
                        {
                            inv.ItemCurrentDurability -= attackPower;
                        }
                        else
                        {
                            Building newBuilding = db.Buildings.Where(x => x.ItemName == destroyedBuilding.ItemName).Where(x => x.BuildingLevel == newBuildingLevel).FirstOrDefault();
                            inv.ItemID = newBuilding.ItemID;
                            inv.ItemCurrentDurability = newBuilding.ItemMaxDurability;
                            inv.ItemMaxDurability = newBuilding.ItemMaxDurability;
                            db.SaveChanges();
                        }
                    }
                }

            }

            else
            {
                db.ZombieAttackBases.Remove(model.ZombieAttackBase);
                db.SaveChanges();
                return RedirectToAction("Details", "Characters", new { id = User.Identity.Name });
            }


            //ViewBag.attackPower = attackPower;
            //ViewBag.zombieAttackBaseBuildings = model.Buildings;
            //ViewBag.destroyedBuilding = destroyedBuilding;
            //ViewBag.ItemCurrentDurability = fence.ItemCurrentDurability;
            //ViewBag.count = model.Buildings.Count();

            model.ZombieAttackBase.ZombieAttackStart = model.ZombieAttackBase.ZombieAttackStart.AddHours(1);
            db.SaveChanges();

            base.SetModelProperties(model);
            return View(model);
        }

        public ActionResult DestroyFence(string id)
        {
            Character character = db.Characters.Where(y => y.ApplicationUserID == User.Identity.Name).FirstOrDefault();
            Inventory fence = character.Inventory.Where(x => x.Item.ItemName == "Fence").FirstOrDefault();
            fence.ItemCurrentDurability--;


            db.SaveChanges();

            return RedirectToAction("Details", "Characters", new { id = User.Identity.Name });
        }


        public ActionResult Index()
        {
            ZombieVM model = new ZombieVM();

            model.Zombies = db.Zombies.ToList();

            base.SetModelProperties(model);
            return View(model);
        }


    }

}