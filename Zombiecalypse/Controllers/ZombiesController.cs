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
    public class ZombiesController : Controller
    {
        private DataContext db = new DataContext();

        public ActionResult StartAttack(string id, int forCounter)
        {
            for (int i = 0; i < forCounter; i++)
            {
                Random rand = new Random();
                int ZombId = rand.Next(1, db.Zombies.Count() + 1);
                Zombie zombie = db.Zombies.Find(ZombId);
                Character character = db.Characters.Where(x => x.ApplicationUserID == id).FirstOrDefault();

                ZombieAttackBase zab = new ZombieAttackBase { ZombieAttackStart = DateTime.Now, Zombie = zombie, Character = character, CharacterID = character.CharacterID, ZombieID = zombie.ZombieID, ZombieLife = zombie.ZombieLife };
                db.ZombieAttackBases.Add(zab);
                db.SaveChanges();
            }

            return RedirectToAction("Details", "Characters", new { id = User.Identity.Name, AttackPower = 0 });
        }



        public ActionResult BaseDefenseFromZombie(int ZabID, int AttackPower, int invID)
        {
            ZombieAttackBaseVM zombieAttackBaseVM = new ZombieAttackBaseVM();
            zombieAttackBaseVM.ZombieAttackBase = db.ZombieAttackBases.Find(ZabID);

            Character character = zombieAttackBaseVM.ZombieAttackBase.Character;
            ICollection<Inventory> inventory = character.Inventory;
            var isEnergyNull = true;
            if (isEnergyNull)
            {

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
                    zombieAttackBaseVM.ZombieAttackBase.ZombieLife -= AttackPower;
                    zombieAttackBaseVM.ZombieAttackBase.Character.CurrentEnergy--;
                }

            }
            else
            {
                return View("~/Views/shared/NotEnoughtEnergy.cshtml");
            }


            foreach (var item in inventory)
            {
                foreach (var weap in db.BuyableWeapons)
                {
                    if (item.ItemID == weap.ItemID)
                    {
                        zombieAttackBaseVM.ZombieAttackBase.BuyableWeapons.Add(weap);
                    }
                }
            }

            foreach (var item in inventory)
            {
                foreach (var weap in db.CraftableWeapons)
                {
                    if (item.ItemID == weap.ItemID)
                    {
                        zombieAttackBaseVM.ZombieAttackBase.CraftableWeapons.Add(weap);
                    }
                }
            }

            zombieAttackBaseVM.ZombieAttackBase.Weapon = db.Weapons.Find(59);

            if (zombieAttackBaseVM.ZombieAttackBase.ZombieLife <= 0)
            {
                var result = character.CharacterXP += zombieAttackBaseVM.ZombieAttackBase.Zombie.RewardXP;
                var addXP = new CharactersController().ManageXPAndLevelUp(User.Identity.Name,zombieAttackBaseVM.ZombieAttackBase.Zombie.RewardXP, this.Request.FilePath);
                character.CharacterMoney += zombieAttackBaseVM.ZombieAttackBase.Zombie.RewardCoins;
                db.ZombieAttackBases.Remove(zombieAttackBaseVM.ZombieAttackBase);

                db.SaveChanges();
                return RedirectToAction("Details", "Characters", new { id = User.Identity.Name });
            }


            //var checkEnergy = new CharactersController().CheckEnergy(character.CharacterID, this.Request.FilePath);

            db.SaveChanges();

            zombieAttackBaseVM.UserKe = db.Characters.Where(y => y.ApplicationUserID == User.Identity.Name).FirstOrDefault().ApplicationUserID;
            zombieAttackBaseVM.Fields = db.CharacterFields.Where(x => x.CharacterID == db.Characters.Where(y => y.ApplicationUserID == User.Identity.Name).FirstOrDefault().CharacterID).ToList();
            zombieAttackBaseVM.EnergyPlusDate = db.Characters.Where(y => y.ApplicationUserID == User.Identity.Name).FirstOrDefault().EnergyPlusDate;
            zombieAttackBaseVM.AttackingZombies = db.ZombieAttackBases.Where(x => x.CharacterID == db.Characters.Where(y => y.ApplicationUserID == User.Identity.Name).FirstOrDefault().CharacterID).ToList();
            zombieAttackBaseVM.AdventureFinishDate = db.Characters.Where(y => y.ApplicationUserID == User.Identity.Name).FirstOrDefault().FinishAdventure;

            return View(zombieAttackBaseVM);

        }

        public ActionResult ZombieAttackBase(int ZabID)
        {
            ZombieAttackBaseVM model = new ZombieAttackBaseVM();
            model.ZombieAttackBase = db.ZombieAttackBases.Find(ZabID);

            Character character = db.Characters.Where(y => y.ApplicationUserID == User.Identity.Name).FirstOrDefault();
            Inventory fence = character.Inventory.Where(x => x.Item.ItemName == "Fence").FirstOrDefault();
            Building destroyedBuilding = new Building();

            Zombie zombie = model.ZombieAttackBase.Zombie;

            model.ZombieAttackBase.Buildings = new List<Building>();


            Random rand = new Random();
            int attackPower = rand.Next(0, zombie.ZombieDamage);
            int random = -9;

            if (fence.ItemCurrentDurability > 0)
            {
                fence.ItemCurrentDurability -= attackPower;
                destroyedBuilding = db.Buildings.Where(x => x.ItemID == fence.ItemID).First();
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
                                model.ZombieAttackBase.Buildings.Add(building);
                            }
                        }
                    }
                }
            

                random = rand.Next(0, model.ZombieAttackBase.Buildings.Count());

                destroyedBuilding = model.ZombieAttackBase.Buildings.ToArray()[random];
                int buildingLevel = destroyedBuilding.BuildingLevel;

                int newBuildingLevel = --buildingLevel;



                foreach (var inv in character.Inventory)
                {
                    if (inv.ItemID == destroyedBuilding.ItemID)
                    {
                        if (inv.ItemCurrentDurability >= attackPower)
                        {
                            inv.ItemCurrentDurability-= attackPower;
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

            ViewBag.random = random;
            ViewBag.attackPower = attackPower;
            ViewBag.zombieAttackBaseBuildings = model.ZombieAttackBase.Buildings;
            ViewBag.destroyedBuilding = destroyedBuilding;
            ViewBag.ItemCurrentDurability = fence.ItemCurrentDurability;
            //ViewBag.buildingLevel = buildingLevel;
            //ViewBag.newBuildingLevel = newBuildingLevel;
            ViewBag.count = model.ZombieAttackBase.Buildings.Count();

            model.ZombieAttackBase.ZombieAttackStart = DateTime.Now;
            db.SaveChanges();


            model.UserKe = db.Characters.Where(y => y.ApplicationUserID == User.Identity.Name).FirstOrDefault().ApplicationUserID;
            model.Fields = db.CharacterFields.Where(x => x.CharacterID == db.Characters.Where(y => y.ApplicationUserID == User.Identity.Name).FirstOrDefault().CharacterID).ToList();
            model.EnergyPlusDate = db.Characters.Where(y => y.ApplicationUserID == User.Identity.Name).FirstOrDefault().EnergyPlusDate;
            model.AttackingZombies = db.ZombieAttackBases.Where(x => x.CharacterID == db.Characters.Where(y => y.ApplicationUserID == User.Identity.Name).FirstOrDefault().CharacterID).ToList();
            model.AdventureFinishDate = db.Characters.Where(y => y.ApplicationUserID == User.Identity.Name).FirstOrDefault().FinishAdventure;


            return View(model);
            //  return RedirectToAction("CharacterDetails", "Characters", new { id = User.Identity.Name });
        }

        public ActionResult DestroyFence(string id)
        {
            Character character = db.Characters.Where(y => y.ApplicationUserID == User.Identity.Name).FirstOrDefault();
            Inventory fence = character.Inventory.Where(x => x.Item.ItemName == "Fence").FirstOrDefault();
            fence.ItemCurrentDurability--;

            db.SaveChanges();

            return RedirectToAction("Details", "Characters", new { id = User.Identity.Name });
        }
    }

}