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
            shop.Items = db.Items.ToList();
            shop.Weapons = db.BuyableWeapons.ToList();
            shop.Plants = db.Plants.ToList();
            shop.Energies = db.Energies.ToList();
            shop.Field = db.PlantFields.FirstOrDefault();
            return View(shop);
        }

        public ActionResult Buy(string id, int ItemID) {
            Character character = db.Characters.Where(x=> x.ApplicationUserID == id).FirstOrDefault();
            Item item = db.Items.Find(ItemID);
            if (character.Inventory.Where(x => x.ItemID == ItemID).FirstOrDefault() != null)
            {
                Inventory inventory = character.Inventory.Where(x => x.ItemID == ItemID).FirstOrDefault();
                inventory.ItemPieces++;
            }
            else {
                Inventory inventory = new Inventory { ItemID = ItemID, CharacterID = character.CharacterID, Item = item, ItemPieces = 1, ItemCurrentDurability = item.ItemDurability, ItemMaxDurability = item.ItemDurability, isFinished = false };
                db.Inventories.Add(inventory);
            }
            db.SaveChanges();
            return RedirectToAction("CharacterDetails", "Characters", new { id = User.Identity.Name });
        }


        public ActionResult BuyField(string id)
        {

            Character character = db.Characters.Where(x => x.ApplicationUserID == id).FirstOrDefault();
            PlantField originalField = db.PlantFields.Find(64);
            PlantField field = new PlantField { ItemName = originalField.ItemName, ItemType = originalField.ItemType, ItemPicture = originalField.ItemPicture, IsFieldEmpty = originalField.IsFieldEmpty };
            var item = new Inventory { CharacterID = character.CharacterID, ItemID = field.ItemID, ItemPieces = 1, PlantField = field };
            db.Inventories.Add(item);
            db.SaveChanges();
            return RedirectToAction("CharacterDetails", "Characters", new { id = User.Identity.Name });
        }
    }
}