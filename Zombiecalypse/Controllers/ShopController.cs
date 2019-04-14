using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Zombiecalypse.DAL;
using Zombiecalypse.Models;

namespace Zombiecalypse.Controllers
{
    public class ShopController : BaseController
    {

        // GET: Shop
        public ActionResult Index()
        {
            Shop model = new Shop();

            model.Character = db.Characters.Where(x => x.ApplicationUserID == User.Identity.Name).FirstOrDefault();
            model.Weapons = db.BuyableWeapons.ToList();
            model.Plants = db.Plants.ToList();
            model.Energies = db.Energies.ToList();

            base.SetModelProperties(model);
            return View(model);
        }

        public ActionResult Buy(string id, int ItemID, string returnUrl)
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
            else
            {
                character.CharacterMoney -= price;
            }


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

            return Redirect(returnUrl);
        }

        public ActionResult BuyField(string id, string returnUrl)
        {

            Character character = db.Characters.Where(x => x.ApplicationUserID == id).FirstOrDefault();
            CharacterField characterField = new CharacterField { CharacterID = character.CharacterID, FinishDate = DateTime.MaxValue, isFinished = false, IsEmpty = true };

            character.CharacterMoney -= 300;
            db.CharacterFields.Add(characterField);
            db.SaveChanges();

            return Redirect(returnUrl);
        }
    }
}