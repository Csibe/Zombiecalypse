﻿using System;
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
    public class AdventuresController : BaseController
    {

        public ActionResult AddToTolerance() {
            Character character = db.Characters.Where(y => y.ApplicationUserID == User.Identity.Name).FirstOrDefault();

            character.Tolerance += 1;

            db.SaveChanges();
            return RedirectToAction("Details", "Characters", new { id = User.Identity.Name });
        }


        public ActionResult StopAdventure(int AdId, int ChId)
        {
            AdventureViewModel model = new AdventureViewModel();

            Character character = db.Characters.Where(y => y.CharacterID == ChId).FirstOrDefault();
            List<ZombieAttackAdventurer> zombies = db.ZombieAttackAdventurers.Where(x => x.CharacterID == ChId).ToList();

            zombies.ForEach(x => db.ZombieAttackAdventurers.Remove(x));
            character.IsOnAdventure = false;
            character.FinishAdventure = DateTime.MaxValue;
            db.SaveChanges();


            base.SetModelProperties(model);
            return View(model);


            //   return RedirectToAction("Details", "Characters", new { id = User.Identity.Name });
        }


        public ActionResult CheckAdventure()
        {

            Character character = db.Characters.Where(y => y.ApplicationUserID == User.Identity.Name).FirstOrDefault();

            if (character == null) {
                return RedirectToAction("Details", "Characters", new { id = User.Identity.Name });
            }


            if (character.IsOnAdventure == true && character.FinishAdventure > DateTime.Now && character.FinishAdventure < DateTime.MaxValue.AddDays(-1))
            {

                return RedirectToAction("AdventureCounter", "Adventures", new { AdId = character.AdventureID, ChId = User.Identity.Name });
            }

            else if (character.IsOnAdventure == true && (character.FinishAdventure <= DateTime.Now || character.FinishAdventure >= DateTime.MaxValue.AddDays(-1)))
            {
                if (character.FinishAdventure <= DateTime.Now) {
                    character.FinishAdventure = DateTime.MaxValue;
                    db.SaveChanges();
                }
                return RedirectToAction("OnAdventure", "Adventures", new { id = User.Identity.Name });
            }

            else if (character.IsOnAdventure == false)
            {
                return RedirectToAction("Details", "Characters", new { id = User.Identity.Name });
            }

            return RedirectToAction("Details", "Characters", new { id = User.Identity.Name });
        }

        public ActionResult AdventureCounter(int AdId, string ChId)
        {
            AdventureViewModel model = new AdventureViewModel();

            model.Character = db.Characters.Where(y => y.ApplicationUserID == User.Identity.Name).FirstOrDefault();
            model.Adventure = db.Adventures.Find(AdId);

            base.SetModelProperties(model);
            return View(model);
        }


        public ActionResult ZombieAttackAdventurer(string id, int zId, string returnUrl)
        {
            ZombieAttackAdventurer2 model = new ZombieAttackAdventurer2();

            model.Character = db.Characters.Where(y => y.ApplicationUserID == id).FirstOrDefault();
            model.ZombieAttackAdventurer = db.ZombieAttackAdventurers.Find(zId);
            model.ZombieAttackAdventurer.isYourTourn = true;
            model.Zombie = db.Zombies.Find(model.ZombieAttackAdventurer.ZombieID);
            model.Adventure = db.Adventures.Find(model.Character.AdventureID);

            Random rand = new Random();
            int attackPower = rand.Next(0, model.Zombie.ZombieDamage + 1);

            model.Character.Tolerance -= attackPower;

            if (model.Character.Tolerance <= 0) {

                model.Character.Tolerance = 0;
                List<ZombieAttackAdventurer> zombies = db.ZombieAttackAdventurers.Where(x => x.CharacterID == model.Character.CharacterID).ToList();

                zombies.ForEach(x => db.ZombieAttackAdventurers.Remove(x));
                model.Character.IsOnAdventure = false;
                model.Character.FinishAdventure = DateTime.MaxValue;
                db.SaveChanges();
                return RedirectToAction("StopAdventure", "Adventures", new { AdId = model.Adventure.AdventureID , ChId = model.Character.CharacterID });

            }

            db.SaveChanges();
            return RedirectToAction(returnUrl);
        }



        public ActionResult AttackZombie(int zAAID, int invID)
        {
            Character character = db.Characters.Where(y => y.ApplicationUserID == User.Identity.Name).FirstOrDefault();


            ZombieAttackAdventurer model = db.ZombieAttackAdventurers.Find(zAAID);


            model.Zombie = db.Zombies.Find(model.ZombieID);
            Inventory item = db.Inventories.Find(invID);
            Weapon weapon = db.Weapons.Find(item.ItemID);

            var inv = db.Inventories.Find(invID);
            if (inv.ItemCurrentDurability > 0 && inv.ItemMaxDurability != 999)
            {
                inv.ItemCurrentDurability--;
            }
            else if (inv.ItemCurrentDurability > 0 && inv.ItemMaxDurability == 999)
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

            if (model.ZombieLife > weapon.WeaponDamage)
            {
                model.ZombieLife = model.ZombieLife - weapon.WeaponDamage;
                List<ZombieAttackAdventurer> zAA = db.ZombieAttackAdventurers.Where(x => x.CharacterID == character.CharacterID).Where(x => x.State == character.AdventureState).ToList();
                zAA.ToArray()[0].isYourTourn = true;
            }
            else
            {
                var addXP = new CharactersController().ManageXPAndLevelUp(User.Identity.Name, model.Zombie.RewardXP, this.Request.FilePath);
                character.CharacterMoney += model.Zombie.RewardCoins;
                db.ZombieAttackAdventurers.Remove(model);
                db.SaveChanges();
                List<ZombieAttackAdventurer> zAA = db.ZombieAttackAdventurers.Where(x => x.CharacterID == character.CharacterID).Where(x => x.State == character.AdventureState).ToList();
                if (zAA.Count >= 1)
                {
                    zAA.ToArray()[0].isYourTourn = true;
                }

                List<Mission> zombieMission = db.Missions.Where(x => x.CharacterID == character.CharacterID).Where(x => x.MissionType == "zombiekilling").ToList();


                if (zombieMission != null)
                {
                    foreach (var mission in zombieMission)
                    {

                        mission.MissionTaskProgress++;
                    }
                }
            }


            db.SaveChanges();
            return RedirectToAction("OnAdventure", "Adventures", new { id = User.Identity.Name });
        }


        public ActionResult ManageTurns(string id, string returnUrl)
        {
            Character character = db.Characters.Where(y => y.ApplicationUserID == id).FirstOrDefault();
            List<ZombieAttackAdventurer> zombieAttackInThisTurn = new List<ZombieAttackAdventurer>();

            zombieAttackInThisTurn = db.ZombieAttackAdventurers.Where(x => x.CharacterID == character.CharacterID).Where(x => x.State == character.AdventureState).ToList();

            for (int c = 0; c < zombieAttackInThisTurn.Count; c++)
            {

                if (zombieAttackInThisTurn.ToArray()[c].isYourTourn == true && c < zombieAttackInThisTurn.Count - 1)
                {
                    int d = c + 1;
                    zombieAttackInThisTurn.ToArray()[c].isYourTourn = false;
                    zombieAttackInThisTurn.ToArray()[d].isYourTourn = true;
                    break;
                }
                else if (zombieAttackInThisTurn.ToArray()[c].isYourTourn == true && c == zombieAttackInThisTurn.Count - 1)
                {
                    zombieAttackInThisTurn.ToArray()[c].isYourTourn = false;
                }
            }

            db.SaveChanges();

            return RedirectToAction(returnUrl);
        }


        public string WhosTurn(string id)
        {
            Character character = db.Characters.Where(y => y.ApplicationUserID == id).FirstOrDefault();
            List<ZombieAttackAdventurer> zombieAttackInThisTurn = new List<ZombieAttackAdventurer>();

            zombieAttackInThisTurn = db.ZombieAttackAdventurers.Where(x => x.CharacterID == character.CharacterID).Where(x => x.State == character.AdventureState).ToList();


            string result = "characters turn";

            for (int c = 0; c < zombieAttackInThisTurn.Count; c++)
            {

                if (zombieAttackInThisTurn.ToArray()[c].isYourTourn == true)
                {
                    result = "zombies turn: " + zombieAttackInThisTurn.ToArray()[c].ZombieAttackAdventurerID;
                    break;
                }
            }

            return result;
        }



        public ActionResult OnAdventure(string id)
        {

            AdventureViewModel model = new AdventureViewModel();
            model.Character = db.Characters.Where(y => y.ApplicationUserID == User.Identity.Name).FirstOrDefault();


            if (model.Character.IsOnAdventure == false)
            {
                return RedirectToAction("Index", "Adventures");
            }

            model.Adventure = db.Adventures.Find(model.Character.AdventureID);

            model.ZombiesAttackAdventurer = db.ZombieAttackAdventurers.Where(x => x.CharacterID == model.Character.CharacterID).ToList();
            model.Weapons = db.Weapons.ToList();
            model.Adventure.AdventureSteps = db.Adventures.Find(model.Character.AdventureID).AdventureSteps;

            ViewBag.WhosTurn = new AdventuresController().WhosTurn(User.Identity.Name);

            foreach (var zombie in model.ZombiesAttackAdventurer)
            {
                zombie.Zombie = db.Zombies.Find(zombie.ZombieID);
            }

            for (int c = 1; c < model.Adventure.AdventureSteps + 1; c++)
            {
                int counter = model.ZombiesAttackAdventurer.Where(x => x.State == c).Count();
                if (model.Character.AdventureState == c && counter == 0)
                {
                    model.Character.AdventureState++;
                    model.Character.FinishAdventure = DateTime.Now.AddSeconds(model.Adventure.AdventureWaitingTime);
                    db.SaveChanges();
                    return RedirectToAction("AdventureCounter", "Adventures", new { AdId = model.Adventure.AdventureID, ChId = User.Identity.Name });

                }
                if (counter > 0 && model.Character.AdventureState <= model.Adventure.AdventureSteps)
                {
                    model.Character.AdventureState = c;
                    break;
                }

            }

            List<ZombieAttackAdventurer> zombieAttackInThisTurn = new List<ZombieAttackAdventurer>();
            zombieAttackInThisTurn = db.ZombieAttackAdventurers.Where(x => x.CharacterID == model.Character.CharacterID).Where(x => x.State == model.Character.AdventureState).ToList();

            foreach (var zombie in zombieAttackInThisTurn)
            {
                if (zombie.isYourTourn == true)
                {
                    var attack = new AdventuresController().ZombieAttackAdventurer(User.Identity.Name, zombie.ZombieAttackAdventurerID, this.Request.FilePath);
                    var result = new AdventuresController().ManageTurns(User.Identity.Name, this.Request.FilePath);
                    return RedirectToAction("OnAdventure", "Adventures", new { id = User.Identity.Name });
                }
            }

            db.SaveChanges();

            base.SetModelProperties(model);
            return View(model);
        }


        public ActionResult AddToInventory(int ChId, int ItemId, int addPieces)
        {

            Character character = db.Characters.Where(x => x.CharacterID == ChId).FirstOrDefault();
            Inventory inventory = db.Inventories.Where(s => s.ItemID == ItemId).Where(s => s.CharacterID == ChId).FirstOrDefault();
            if (inventory == null)
            {
                Inventory newinventory = new Inventory { ItemID = ItemId, ItemPieces = addPieces, CharacterID = ChId };
                db.Inventories.Add(newinventory);
            }
            else
            {
                inventory.ItemPieces += addPieces;
            }
            db.SaveChanges();
            return RedirectToAction("Details", "Characters", new { id = character.ApplicationUserID });
        }


        public ActionResult CollectReward(int AdId, string ChId)
        {

            AdventureDropVM model = new AdventureDropVM();
            List<AdventureDrop> dropList = db.AdventureDrops.Where(a => a.AdventureID == AdId).ToList();
            model.ItemList = db.Items.ToList();
            model.Rewards = new List<Inventory>();
            Character character = db.Characters.Where(y => y.ApplicationUserID == User.Identity.Name).FirstOrDefault();

            if (character.IsOnAdventure == true)
            {
                Random rand = new Random();

                foreach (var drop in dropList)
                {
                    double myRand = rand.NextDouble();

                    if (myRand > (1 - drop.ItemDroprate))
                    {
                        int addPieces = rand.Next(1, drop.ItemMaxDrop);
                        Inventory inventory = new Inventory { CharacterID = character.CharacterID, ItemID = drop.DropableItemID, ItemPieces = addPieces };
                        var addItem = new AdventuresController().AddToInventory(character.CharacterID, drop.DropableItemID, addPieces);

                        Inventory item = new Inventory { ItemID = drop.DropableItemID, ItemPieces = addPieces };

                        model.Rewards.Add(item);
                       
                        db.SaveChanges();

                    }
                }

                model.AdventureXPReward = db.Adventures.Find(AdId).AdventureXPBonus;

                character.IsOnAdventure = false;
                character.FinishAdventure = DateTime.MaxValue;

                db.SaveChanges();
            }
            else {
                return RedirectToAction("Details", "Characters", new { id = User.Identity.Name });
            }


            base.SetModelProperties(model);
            return View(model);
        }


        public ActionResult StartAdventure(int AdId)
        {
            Adventure adventure = db.Adventures.Find(AdId);
            Character character = db.Characters.Where(y => y.ApplicationUserID == User.Identity.Name).FirstOrDefault();


            if (character.IsOnAdventure == false)
            {
                if (character.CurrentEnergy >= adventure.AdventureRequerdEnergy)
                {
                    var result = new CharactersController().ManageEnergy(User.Identity.Name, adventure.AdventureRequerdEnergy, this.Request.FilePath);

                    List<ZombieAttackAdventurer> zombies = new List<ZombieAttackAdventurer>();
                    Random rand = new Random();

                    int maxZombieRank = rand.Next(1, adventure.AdventureMaxZombiesPerRound);

                    List<Zombie> selectableZombies = new List<Zombie>();
                    foreach (var zombie in db.Zombies)
                    {
                        if (zombie.ZombieRank <= maxZombieRank && zombie.ZombiePlaceAppear.ToString() == adventure.AdventureType.ToString())
                        {
                            selectableZombies.Add(zombie);
                        }
                    }

                    for (int stepCounter = 0; stepCounter <= adventure.AdventureSteps; stepCounter++)
                    {
                        int maxZombiesPerRound = rand.Next(1, adventure.AdventureMaxZombiesPerRound);

                        for (int j = 0; j < maxZombiesPerRound; j++)
                        {
                            int zombieIndex = rand.Next(1, selectableZombies.Count());
                            Zombie selectedZombie = selectableZombies.ElementAt<Zombie>(zombieIndex);
                            ZombieAttackAdventurer attackingZombie = new ZombieAttackAdventurer { CharacterID = character.CharacterID, State = stepCounter, Zombie = selectedZombie, ZombieID = selectedZombie.ZombieID, ZombieLife = selectedZombie.ZombieLife, isYourTourn = false };
                            db.ZombieAttackAdventurers.Add(attackingZombie);
                        }
                    }

                    character.FinishAdventure = DateTime.MaxValue;
                    character.AdventureState = 1;
                    character.AdventureID = AdId;

                    character.IsOnAdventure = true;
                    db.SaveChanges();

                    return RedirectToAction("OnAdventure", "Adventures", new { id = User.Identity.Name });
                }
                else
                {
                    return RedirectToAction("Details", "Characters", new { id = User.Identity.Name });
                }
            }
            else
            {
                return RedirectToAction("Details", "Characters", new { id = User.Identity.Name });
            }

        }

        // GET: Adventures
        public ActionResult Index()
        {

            AdventureViewModel model = new AdventureViewModel();

            model.Character = db.Characters.Where(y => y.ApplicationUserID == User.Identity.Name).FirstOrDefault();
            model.Adventures = db.Adventures.ToList();
            model.AdventureDrops = db.AdventureDrops.ToList();

            base.SetModelProperties(model);
            return View(model);
        }
    }
}