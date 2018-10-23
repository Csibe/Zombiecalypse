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
    public class AdventuresController : Controller
    {
        private DataContext db = new DataContext();

        public ActionResult StopAdventure(string id)
        {
            Character character = db.Characters.Where(y => y.ApplicationUserID == User.Identity.Name).FirstOrDefault();


            List<ZombieAttackAdventurer> zombies = db.ZombieAttackAdventurers.Where(x => x.ZombieAttackAdventurerID == character.CharacterID).ToList();


            zombies.ForEach(x => db.ZombieAttackAdventurers.Remove(x));
            character.IsOnAdventure = false;
            character.FinishAdventure = DateTime.MaxValue;
            db.SaveChanges();



            return RedirectToAction("Details", "Characters", new { id = User.Identity.Name });
        }



        public ActionResult CheckAdventure(string id)
        {

            Character character = db.Characters.Where(y => y.ApplicationUserID == User.Identity.Name).FirstOrDefault();

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }


            if (character.IsOnAdventure && character.FinishAdventure > DateTime.Now)
            {

                return RedirectToAction("AdventureCounter", "Adventures", new { AdId = character.AdventureID, ChId = User.Identity.Name });
            }

            else if (character.IsOnAdventure == true && character.FinishAdventure <= DateTime.Now)
            {
                return RedirectToAction("AdventureZombieAttack", "Adventures", new { id = User.Identity.Name });
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

            model.UserKe = db.Characters.Where(y => y.ApplicationUserID == User.Identity.Name).FirstOrDefault().ApplicationUserID;
            model.Fields = db.CharacterFields.Where(x => x.CharacterID == db.Characters.Where(y => y.ApplicationUserID == User.Identity.Name).FirstOrDefault().CharacterID).ToList();
            model.EnergyPlusDate = db.Characters.Where(y => y.ApplicationUserID == User.Identity.Name).FirstOrDefault().EnergyPlusDate;
            model.AttackingZombies = db.ZombieAttackBases.Where(x => x.CharacterID == db.Characters.Where(y => y.ApplicationUserID == User.Identity.Name).FirstOrDefault().CharacterID).ToList();
            model.AdventureFinishDate = db.Characters.Where(y => y.ApplicationUserID == User.Identity.Name).FirstOrDefault().FinishAdventure;

            return View(model);
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
            }
            else
            {
                var addXP = new CharactersController().ManageXPAndLevelUp(character.ApplicationUserID, model.Zombie.RewardXP, this.Request.FilePath);
                character.CharacterMoney += model.Zombie.RewardCoins;
                db.ZombieAttackAdventurers.Remove(model);
            }

            db.SaveChanges();
            return RedirectToAction("AdventureZombieAttack", "Adventures", new { id = User.Identity.Name });
        }


        public ActionResult AdventureZombieAttack(string id)
        {

            AdventureViewModel model = new AdventureViewModel();
            Character character = db.Characters.Where(y => y.ApplicationUserID == User.Identity.Name).FirstOrDefault();

            if (character.IsOnAdventure == false)
            {
                return RedirectToAction("Details", "Characters", new { id = User.Identity.Name });
            }

            model.Adventure = db.Adventures.Find(1);
            model.CharacterID = character.CharacterID;
            model.ZombiesAttackAdventurer = db.ZombieAttackAdventurers.Where(x => x.CharacterID == model.CharacterID).ToList();
            model.Character = db.Characters.Find(model.CharacterID);
            model.Weapons = db.Weapons.ToList();
            model.Adventure.AdventureSteps = db.Adventures.Find(character.AdventureID).AdventureSteps;


            foreach (var zombie in model.ZombiesAttackAdventurer)
            {
                zombie.Zombie = db.Zombies.Find(zombie.ZombieID);
            }

            for (int c = 1; c < model.Adventure.AdventureSteps + 1; c++)
            {
                int counter = model.ZombiesAttackAdventurer.Where(x => x.State == c).Count();
                if (character.AdventureState == c && counter == 0)
                {
                    character.AdventureState++;
                    character.FinishAdventure = DateTime.Now.AddSeconds(model.Adventure.AdventureWaitingTime);
                    db.SaveChanges();
                    return RedirectToAction("AdventureCounter", "Adventures", new { AdId = model.Adventure.AdventureID, ChId = model.CharacterID });

                }
                if (counter > 0 && character.AdventureState <= model.Adventure.AdventureSteps)
                {
                    character.AdventureState = c;
                    break;
                }
            }

           // character.FinishAdventure = DateTime.Now.AddSeconds(model.Adventure.AdventureWaitingTime);
            db.SaveChanges();

            model.UserKe = db.Characters.Where(y => y.ApplicationUserID == User.Identity.Name).FirstOrDefault().ApplicationUserID;
            model.Fields = db.CharacterFields.Where(x => x.CharacterID == db.Characters.Where(y => y.ApplicationUserID == User.Identity.Name).FirstOrDefault().CharacterID).ToList();
            model.EnergyPlusDate = db.Characters.Where(y => y.ApplicationUserID == User.Identity.Name).FirstOrDefault().EnergyPlusDate;
            model.AttackingZombies = db.ZombieAttackBases.Where(x => x.CharacterID == db.Characters.Where(y => y.ApplicationUserID == User.Identity.Name).FirstOrDefault().CharacterID).ToList();
            model.AdventureFinishDate = db.Characters.Where(y => y.ApplicationUserID == User.Identity.Name).FirstOrDefault().FinishAdventure;

            return View(model);
        }


        public ActionResult AddToInventory(int ChId, int ItemId, int addPieces)
        {

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
            return View();
        }


        public ActionResult CollectReward(int AdId, string ChId)
        {

            AdventureDropVM model = new AdventureDropVM();
            List<AdventureDrop> dropList = db.AdventureDrops.Where(a => a.AdventureID == AdId).ToList();
            model.ItemList = db.Items.ToList();
            model.Rewards = new List<Inventory>();
            Character character = db.Characters.Where(y => y.ApplicationUserID == User.Identity.Name).FirstOrDefault();

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
                    model.AdventureXPReward = db.Adventures.Find(AdId).AdventureXPBonus;
                    db.SaveChanges();

                }
            }

            character.IsOnAdventure = false;
            character.FinishAdventure = DateTime.MaxValue;

            db.SaveChanges();


            model.UserKe = db.Characters.Where(y => y.ApplicationUserID == User.Identity.Name).FirstOrDefault().ApplicationUserID;
            model.Fields = db.CharacterFields.Where(x => x.CharacterID == db.Characters.Where(y => y.ApplicationUserID == User.Identity.Name).FirstOrDefault().CharacterID).ToList();
            model.EnergyPlusDate = db.Characters.Where(y => y.ApplicationUserID == User.Identity.Name).FirstOrDefault().EnergyPlusDate;
            model.AttackingZombies = db.ZombieAttackBases.Where(x => x.CharacterID == db.Characters.Where(y => y.ApplicationUserID == User.Identity.Name).FirstOrDefault().CharacterID).ToList();
            model.AdventureFinishDate = db.Characters.Where(y => y.ApplicationUserID == User.Identity.Name).FirstOrDefault().FinishAdventure;

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
                        if (zombie.ZombieRank <= maxZombieRank)
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
                            ZombieAttackAdventurer attackingZombie = new ZombieAttackAdventurer { CharacterID = character.CharacterID, State = stepCounter, Zombie = selectedZombie, ZombieID = selectedZombie.ZombieID, ZombieLife = selectedZombie.ZombieLife };
                            db.ZombieAttackAdventurers.Add(attackingZombie);
                        }
                    }

                    character.FinishAdventure = DateTime.Now;
                    character.AdventureState = 1;
                    character.AdventureID = AdId;

                    character.IsOnAdventure = true;
                    db.SaveChanges();

                    return RedirectToAction("AdventureZombieAttack", "Adventures", new { id = User.Identity.Name });
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

            model.UserKe = db.Characters.Where(y => y.ApplicationUserID == User.Identity.Name).FirstOrDefault().ApplicationUserID;
            model.Fields = db.CharacterFields.Where(x => x.CharacterID == db.Characters.Where(y => y.ApplicationUserID == User.Identity.Name).FirstOrDefault().CharacterID).ToList();
            model.EnergyPlusDate = db.Characters.Where(y => y.ApplicationUserID == User.Identity.Name).FirstOrDefault().EnergyPlusDate;
            model.AttackingZombies = db.ZombieAttackBases.Where(x => x.CharacterID == db.Characters.Where(y => y.ApplicationUserID == User.Identity.Name).FirstOrDefault().CharacterID).ToList();
            model.AdventureFinishDate = db.Characters.Where(y => y.ApplicationUserID == User.Identity.Name).FirstOrDefault().FinishAdventure;

            return View(model);
        }

        // GET: Adventures/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Adventure adventure = db.Adventures.Find(id);
            if (adventure == null)
            {
                return HttpNotFound();
            }
            return View(adventure);
        }
    }
}