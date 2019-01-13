﻿using System;
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
            model.Dogs = db.Dogs.ToList();

            base.SetModelProperties(model);
            return View(model);
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
            else if (item.GetType().Name.Contains("Dog"))
            {
                Dog variable = db.Dogs.Find(ItemID);
                price = variable.Cost;
            }

            if (item.GetType().Name.Contains("Energy"))
            {
                character.CharacterFood -= price;
            }
            else
            {
                character.CharacterMoney -= price;
            }



            if (item.GetType().Name.Contains("Dog"))
            {
                OwnedDog dog = new OwnedDog { CharacterID = character.CharacterID, DogLevel = 1, DogMaxLife = 3, DogCurrentLife = 3, DogPicture = item.ItemPicture, DogCurrentEnergy = 5, DogMaxEnergy = 5, EndOfExplore = DateTime.MaxValue, IsOnExplore = false };
                db.OwnedDogs.Add(dog);
            }
            else
            {
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