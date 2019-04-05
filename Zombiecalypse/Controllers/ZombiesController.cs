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
        [Authorize]
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

                var result = new MissionsController().KillingMission(model.Zombie.ZombieID, User.Identity.Name);
                //List<Mission> zombieMission = db.Missions.Where(x => x.CharacterID == model.Character.CharacterID).Where(x => x.MissionType == "zombiekilling").ToList();
               
                //if (zombieMission != null) {
                //    foreach (var mission in zombieMission) {
                //        mission.MissionTaskProgress++;
                //    }
                //}

                db.SaveChanges();

                base.SetModelProperties(model);
                return RedirectToAction("CollectReward", "Zombies", new { zABID = model.ZombieAttackBase.ZombieAttackBaseID, rewardXP = model.Zombie.RewardXP, rewardCoin = model.Zombie.RewardCoins });

            }

            db.SaveChanges();

            base.SetModelProperties(model);
            return View(model);

        }

        [Authorize]
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

    }

}