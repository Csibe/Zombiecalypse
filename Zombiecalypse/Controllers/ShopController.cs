using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Zombiecalypse.DAL;
using Zombiecalypse.Models;

namespace Zombiecalypse.Controllers
{
    public class ShopController : Controller
    {

        DataContext db = new DataContext();

        // GET: Shop
        public ActionResult Index()
        {
            Shop shop = new Shop();
            shop.Weapons = db.BuyableWeapons.ToList();
            shop.Plants = db.Plants.ToList();
            shop.Energies = db.Energies.ToList();


            shop.UserKe = db.Characters.Where(y => y.ApplicationUserID == User.Identity.Name).FirstOrDefault().ApplicationUserID;
            shop.Fields = db.CharacterFields.Where(x => x.CharacterID == db.Characters.Where(y => y.ApplicationUserID == User.Identity.Name).FirstOrDefault().CharacterID).ToList();
            shop.EnergyPlusDate = db.Characters.Where(y => y.ApplicationUserID == User.Identity.Name).FirstOrDefault().EnergyPlusDate;
            shop.AttackingZombies = db.ZombieAttackBases.Where(x => x.CharacterID == db.Characters.Where(y => y.ApplicationUserID == User.Identity.Name).FirstOrDefault().CharacterID).ToList();
            shop.AdventureFinishDate = db.Characters.Where(y => y.ApplicationUserID == User.Identity.Name).FirstOrDefault().FinishAdventure;


            return View(shop);
        }

        public ActionResult Buy(string id, int ItemID)
        {
            Character character = db.Characters.Where(x => x.ApplicationUserID == id).FirstOrDefault();
            if (character == null)
            {
                return HttpNotFound();
            }

            Item item = db.Items.Find(ItemID);
            int price = 0;

            if (item.GetType().Name.Contains("Weapon"))
            {
                BuyableWeapon variable = db.BuyableWeapons.Find(ItemID);
                price = variable.Cost;
            }
            else if (item.GetType().Name.Contains("Plant"))
            {
                Plant variable = db.Plants.Find(ItemID);
                price = variable.PlantMoneyCost;
            }
            else if (item.GetType().Name.Contains("Energy"))
            {
                Energy variable = db.Energies.Find(ItemID);
                price = variable.Cost;
            }

            //if (character.CharacterMoney >= price)
            //{
            character.CharacterMoney -= price;
            if (character.Inventory.Where(x => x.ItemID == ItemID).FirstOrDefault() != null)
            {
                Inventory inventory = character.Inventory.Where(x => x.ItemID == ItemID).FirstOrDefault();
                inventory.ItemPieces++;
            }
            else
            {
                Inventory inventory = new Inventory { ItemID = ItemID, CharacterID = character.CharacterID, Item = item, ItemPieces = 1, ItemCurrentDurability = item.ItemMaxDurability, ItemMaxDurability = item.ItemMaxDurability };
                db.Inventories.Add(inventory);
            }
            db.SaveChanges();
            //}

            return RedirectToAction("Details", "Characters", new { id = User.Identity.Name });
        }

        public ActionResult BuyField(string id)
        {

            Character character = db.Characters.Where(x => x.ApplicationUserID == id).FirstOrDefault();
            CharacterField characterField = new CharacterField { CharacterID = character.CharacterID, FinishDate = DateTime.MaxValue, isFinished = false, IsEmpty = true };

            //if (character.CharacterMoney >= 300)
            //{
                character.CharacterMoney -= 300;
                db.CharacterFields.Add(characterField);
                db.SaveChanges();
            //}
                return RedirectToAction("Details", "Characters", new { id = User.Identity.Name });
            }
        }
    }