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
    public class AdventuresController : BaseController
    {


        public ActionResult AddToTolerance() {
            Character character = db.Characters.Where(y => y.ApplicationUserID == User.Identity.Name).FirstOrDefault();

            character.Tolerance += 1;

            db.SaveChanges();
            return RedirectToAction("Details", "Characters", new { id = User.Identity.Name });
        }



        public ActionResult StopAdventure(int AdId, int ChId, string returnUrl)
        {
            AdventureViewModel model = new AdventureViewModel();

            Character character = db.Characters.Where(y => y.CharacterID == ChId).FirstOrDefault();
            List<ZombieAttackAdventurer> zombies = db.ZombieAttackAdventurers.Where(x => x.CharacterID == ChId).ToList();
            Adventure adventure = db.Adventures.Find(AdId);

            zombies.ForEach(x => db.ZombieAttackAdventurers.Remove(x));
            character.IsOnAdventure = false;
            character.FinishAdventure = DateTime.MaxValue;

            db.SaveChanges();

            return RedirectToAction(returnUrl);
        }



        public ActionResult CheckAdventure()
        {

            Character character = db.Characters.Where(y => y.ApplicationUserID == User.Identity.Name).FirstOrDefault();

            if (character.IsOnAdventure == true && character.FinishAdventure > DateTime.Now && character.FinishAdventure < DateTime.MaxValue.AddDays(-1))
            {

                return RedirectToAction("AdventureCounter", "Adventures", new { AdId = character.AdventureID, ChId = User.Identity.Name });
            }

            if (character.IsOnAdventure == true && (character.FinishAdventure <= DateTime.Now || character.FinishAdventure >= DateTime.MaxValue.AddDays(-1)))
            {
                    character.FinishAdventure = DateTime.MaxValue;
                    db.SaveChanges();
                    return RedirectToAction("OnAdventure", "Adventures", new { id = User.Identity.Name });
            }
            return RedirectToAction("Index", "Adventures");
        }


        public ActionResult AdventureCounter(string ChId)
        {
            AdventureViewModel model = new AdventureViewModel();

            model.Character = db.Characters.Where(y => y.ApplicationUserID == User.Identity.Name).FirstOrDefault();
            model.Adventure = db.Adventures.Find(model.Character.AdventureID);

            base.SetModelProperties(model);
            return View(model);
        }


        //public ActionResult ZombieAttackAdventurer(string id, int zId, string returnUrl)
        //{
        //    ZombieAttackAdventurerVM model = new ZombieAttackAdventurerVM();

        //    model.Character = db.Characters.Where(y => y.ApplicationUserID == id).FirstOrDefault();
        //    model.ZombieAttackAdventurer = db.ZombieAttackAdventurers.Find(zId);
        //    model.ZombieAttackAdventurer.isYourTurn = true;
        //    model.Zombie = db.Zombies.Find(model.ZombieAttackAdventurer.ZombieID);
        //    model.Adventure = db.Adventures.Find(model.Character.AdventureID);

        //    Random rand = new Random();
        //    int attackPower = rand.Next(0, model.Zombie.ZombieDamage + 1);

        //    model.Character.Tolerance -= attackPower;

        //    if (model.Character.Tolerance <= 0) {

        //        model.Character.Tolerance = 0;
        //        List<ZombieAttackAdventurer> zombies = db.ZombieAttackAdventurers.Where(x => x.CharacterID == model.Character.CharacterID).ToList();

        //        zombies.ForEach(x => db.ZombieAttackAdventurers.Remove(x));
        //        model.Character.IsOnAdventure = false;
        //        model.Character.FinishAdventure = DateTime.MaxValue;
        //        db.SaveChanges();
        //        return RedirectToAction("StopAdventure", "Adventures", new { AdId = model.Adventure.AdventureID , ChId = model.Character.CharacterID, returnUrl = returnUrl });

        //    }

        //    db.SaveChanges();
        //    return RedirectToAction(returnUrl);
        //}


        public ActionResult AttackZombie(string zAAID, int invID)
        {
            Character character = db.Characters.Where(y => y.ApplicationUserID == User.Identity.Name).FirstOrDefault();

            List<int> zombik = System.Web.Helpers.Json.Decode<List<int>>(zAAID);

            List<ZombieAttackAdventurer> zombies = new List<ZombieAttackAdventurer>();

            foreach (var z in zombik)
            {
                var zombie = db.ZombieAttackAdventurers.Find(z);
                zombies.Add(zombie);
            }


            Inventory item = db.Inventories.Find(invID);
            Weapon weapon = db.Weapons.Find(item.ItemID);


            foreach (var z in zombies)
            {


                ZombieAttackAdventurer model = db.ZombieAttackAdventurers.Find(z.ZombieAttackAdventurerID);
                model.Zombie = db.Zombies.Find(model.ZombieID);

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
                    zAA.ToArray()[0].isYourTurn = true;
                    db.SaveChanges();
                }
                else
                {
                    var addXP = new CharactersController().ManageXPAndLevelUp(User.Identity.Name, model.Zombie.RewardXP, this.Request.FilePath);
                    character.CharacterMoney += model.Zombie.RewardCoins;
                    db.ZombieAttackAdventurers.Remove(model);
                    List<ZombieAttackAdventurer> zAA = db.ZombieAttackAdventurers.Where(x => x.CharacterID == character.CharacterID).Where(x => x.State == character.AdventureState).ToList();
                    zAA.ToArray()[0].isYourTurn = true;
                    db.SaveChanges();

                }
            }

            character.isYourTurn = false;
            db.SaveChanges();
            return RedirectToAction("OnAdventure", "Adventures", new { id = User.Identity.Name });
        }


        //public ActionResult ManageTurns(string id, string returnUrl)
        //{
        //    Character character = db.Characters.Where(y => y.ApplicationUserID == id).FirstOrDefault();
        //    List<ZombieAttackAdventurer> zombieAttackInThisTurn = new List<ZombieAttackAdventurer>();

        //    zombieAttackInThisTurn = db.ZombieAttackAdventurers.Where(x => x.CharacterID == character.CharacterID).Where(x => x.State == character.AdventureState).ToList();

        //    for (int c = 0; c < zombieAttackInThisTurn.Count; c++)
        //    {

        //        if (zombieAttackInThisTurn.ToArray()[c].isYourTurn == true && c < zombieAttackInThisTurn.Count - 1)
        //        {
        //            int d = c + 1;
        //            zombieAttackInThisTurn.ToArray()[c].isYourTurn = false;
        //            zombieAttackInThisTurn.ToArray()[d].isYourTurn = true;
        //            break;
        //        }
        //        else if (zombieAttackInThisTurn.ToArray()[c].isYourTurn == true && c == zombieAttackInThisTurn.Count - 1)
        //        {
        //            zombieAttackInThisTurn.ToArray()[c].isYourTurn = false;
        //        }
        //    }

        //    db.SaveChanges();

        //    return RedirectToAction(returnUrl);
        //}


        [Authorize]
        public string WhosTurn(string id)
        {
            Character character = db.Characters.Where(y => y.ApplicationUserID == id).FirstOrDefault();
            List<ZombieAttackAdventurer> zombieAttackInThisTurn = new List<ZombieAttackAdventurer>();

            zombieAttackInThisTurn = db.ZombieAttackAdventurers.Where(x => x.CharacterID == character.CharacterID).Where(x => x.State == character.AdventureState).ToList();


            string result = "characters turn";

            for (int c = 0; c < zombieAttackInThisTurn.Count; c++)
            {

                if (zombieAttackInThisTurn.ToArray()[c].isYourTurn == true)
                {
                    result = "zombies turn: " + zombieAttackInThisTurn.ToArray()[c].ZombieAttackAdventurerID;
                    break;
                }
            }

            return result;
        }


        [Authorize]
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
                    model.Character.isWaitingOnAdventure = true;
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

            //foreach (var zombie in zombieAttackInThisTurn)
            //{
            //    if (zombie.isYourTurn == true)
            //    {
            //        var attack = new AdventuresController().ZombieAttackAdventurer(User.Identity.Name, zombie.ZombieAttackAdventurerID, this.Request.FilePath);
            //        var result = new AdventuresController().ManageTurns(User.Identity.Name, this.Request.FilePath);
            //        return RedirectToAction("OnAdventure", "Adventures", new { id = User.Identity.Name });
            //    }
            //}

            db.SaveChanges();

            base.SetModelProperties(model);
            return View(model);
        }


        [Authorize]
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

                if (AdId > character.AdventureMapState)
                {
                    character.AdventureMapState = AdId;
                }


                db.SaveChanges();
            }
            else {
                return RedirectToAction("Details", "Characters", new { id = User.Identity.Name });
            }


            base.SetModelProperties(model);
            return View(model);
        }


        [Authorize]
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

                    int maxZombieRank = adventure.AdventureID;

                    List<Zombie> selectableZombies = new List<Zombie>();
                    foreach (var zombie in db.Zombies)
                    {
                        if (zombie.ZombieRank <= maxZombieRank && zombie.ZombieRank >= maxZombieRank-2 && zombie.ZombiePlaceAppear.ToString() == adventure.AdventureType.ToString())
                        {
                            selectableZombies.Add(zombie);
                        }
                    }

                    for (int stepCounter = 1; stepCounter <= adventure.AdventureSteps; stepCounter++)
                    {
                        int maxZombiesPerRound = rand.Next(1, adventure.AdventureMaxZombiesPerRound);

                        for (int j = 0; j < maxZombiesPerRound; j++)
                        {
                            int zombieIndex = rand.Next(0, selectableZombies.Count()-1);
                            Zombie selectedZombie = selectableZombies.ElementAt<Zombie>(zombieIndex);
                            ZombieAttackAdventurer attackingZombie = new ZombieAttackAdventurer { CharacterID = character.CharacterID, State = stepCounter, ZombieID = selectedZombie.ZombieID, ZombieLife = selectedZombie.ZombieLife, isYourTurn = false };
                            db.ZombieAttackAdventurers.Add(attackingZombie);
                        }
                    }

                    character.FinishAdventure = DateTime.MaxValue;
                    character.AdventureState = 1;
                    character.AdventureID = AdId;
                    character.isYourTurn = true;
                    character.isWaitingOnAdventure = false;

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

        [Authorize]
        // GET: Adventures
        public ActionResult Index()
        {

            AdventureViewModel model = new AdventureViewModel();

            model.Character = db.Characters.Where(y => y.ApplicationUserID == User.Identity.Name).FirstOrDefault();
            model.Adventures = db.Adventures.ToList();
            model.AdventureDrops = db.AdventureDrops.ToList();
            model.PossibleZombies = db.Zombies.ToList();

            base.SetModelProperties(model);
            return View(model);
        }
    }
}