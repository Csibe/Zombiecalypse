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
                var addXP = new CharactersController().ManageXPAndLevelUp(character.ApplicationUserID, zombieAttackBaseVM.ZombieAttackBase.Zombie.RewardXP, this.Request.FilePath);
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
            ZombieAttackBase zombieAttackBase = db.ZombieAttackBases.Find(ZabID);
            Character character = zombieAttackBase.Character;
            Zombie zombie = zombieAttackBase.Zombie;

            Random rand = new Random();
            int random = rand.Next(0, zombie.ZombieDamage);

            if (character.FenceCurrentDurability > 0)
            {
                character.FenceCurrentDurability -= random;
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
                                zombieAttackBase.Buildings.Add(building);
                            }
                        }
                    }
                }
  
                random = rand.Next(0, zombieAttackBase.Buildings.Count());

                Building destroyedBuilding = db.ZombieAttackBases.Find(ZabID).Buildings.ToArray()[random];
                int buildingLevel = destroyedBuilding.BuildingLevel;

                int newBuildingLevel = --buildingLevel;

                ViewBag.random = random;
                ViewBag.zombieAttackBaseBuildings = zombieAttackBase.Buildings.Count();
                ViewBag.destroyedBuilding = destroyedBuilding.BuildingLevel;
                ViewBag.buildingLevel = buildingLevel;
                ViewBag.newBuildingLevel = newBuildingLevel;
                ViewBag.count = zombieAttackBase.Buildings.Count();

                foreach (var inv in character.Inventory)
                {
                    if (inv.ItemID == destroyedBuilding.ItemID)
                    {
                        if (inv.ItemCurrentDurability > 1)
                        {
                            inv.ItemCurrentDurability--;
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
                db.SaveChanges();
            }


            return View(zombieAttackBase);
            //  return RedirectToAction("CharacterDetails", "Characters", new { id = User.Identity.Name });
        }

        public ActionResult DestroyFence(string id)
        {
            Character character = db.Characters.Where(y => y.ApplicationUserID == User.Identity.Name).FirstOrDefault();
            character.FenceCurrentDurability--;

            db.SaveChanges();

            return RedirectToAction("Details", "Characters", new { id = User.Identity.Name });
        }
    }
     
}