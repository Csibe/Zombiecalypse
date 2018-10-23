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
    public class InventoriesController : Controller
    {
        private DataContext db = new DataContext();
        private int MaxBuildingLevel = 5;


        public ActionResult AddToItem(int itemId)
        {

            Inventory item = db.Inventories.Where(x => x.InventoryID == itemId).FirstOrDefault();
            item.ItemPieces++;
            db.SaveChanges();

            return RedirectToAction("Details", "Characters", new { id = User.Identity.Name });
        }


        public ActionResult LevelUpBuilding(int id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }


            Character character = db.Characters.Where(x => x.ApplicationUserID == User.Identity.Name).FirstOrDefault();

            if (character.IsOnAdventure == true)
            {
                return RedirectToAction("Details", "Characters", new { id = User.Identity.Name });
            }

            Inventory item = db.Inventories.Find(id);
            Building building = db.Buildings.Find(item.ItemID);


            if (item == null)
            {
                return HttpNotFound();
            }

            if (building == null)
            {
                return HttpNotFound();
            }
            if (character.IsOnAdventure == true)
            {
                return RedirectToAction("Details", "Characters", new { id = User.Identity.Name });
            }

            if (character.CurrentEnergy < building.BuildingEnergyCost)
            {
                return RedirectToAction("Details", "Characters", new { id = User.Identity.Name });
            }

            if (character.CharacterMoney < building.BuildingMoneyCost)
            {
                return RedirectToAction("Details", "Characters", new { id = User.Identity.Name });
            }

            if (building.BuildingLevel >= MaxBuildingLevel)
            {
                return RedirectToAction("Details", "Characters", new { id = User.Identity.Name });
            }

            ICollection<Inventory> characterInventory = db.Inventories.Where(x => x.CharacterID == character.CharacterID).ToList();

            int buildingLevel = building.BuildingLevel;
            int newBuildingLevel = ++buildingLevel;
            string buildingName = building.ItemName;

            Building newBuilding = db.Buildings.Where(x => x.ItemName == buildingName).Where(x => x.BuildingLevel == newBuildingLevel).FirstOrDefault();
            List<BuildingBuildingMaterial> newBuildingBuildingMaterials = db.BuildingBuildingMaterials.Where(x => x.BuildingID == newBuilding.ItemID).ToList();

            int counter = 0;


            foreach (var invMat in characterInventory)
            {
                foreach (var newMat in newBuildingBuildingMaterials)
                {
                    if (invMat.ItemID == newMat.BuildingMaterialID)
                    {
                        if (invMat.ItemPieces >= newMat.MaterialPieces)
                        {
                            counter++;
                        }
                    }

                }
            }
            if (counter == newBuildingBuildingMaterials.Count())
            {
                foreach (var invMat in characterInventory)
                {
                    foreach (var newMat in newBuildingBuildingMaterials)
                    {
                        if (invMat.ItemID == newMat.BuildingMaterialID)
                        {
                            invMat.ItemPieces = invMat.ItemPieces - newMat.MaterialPieces;

                        }
                    }
                }
                var newitem = db.Buildings.Where(p => p.ItemID == newBuilding.ItemID).FirstOrDefault();
                item.Item = db.Items.Find(newitem.ItemID);
                item.ItemID = newitem.ItemID;
                item.ItemMaxDurability = newitem.ItemMaxDurability;
                item.ItemCurrentDurability = newitem.ItemMaxDurability;

                character.CharacterMoney -= building.BuildingMoneyCost;
                var result = new CharactersController().ManageEnergy(User.Identity.Name,building.BuildingEnergyCost, this.Request.FilePath);

                db.SaveChanges();

                return RedirectToAction("Details", "Characters", new { id = User.Identity.Name });

            }
            else
            {
                return RedirectToAction("Details", "Characters", new { id = User.Identity.Name });
            }

        }

        public ActionResult CraftWeapon(int WeaponId, string ChId)
        {

            Character character = db.Characters.Where(x => x.ApplicationUserID == User.Identity.Name).FirstOrDefault();

            if (character.IsOnAdventure == true)
            {
                return RedirectToAction("Details", "Characters", new { id = User.Identity.Name });
            }



            if (WeaponId == null)
            {
                return HttpNotFound();
            }


            CraftableWeapon craftableWeapon = db.CraftableWeapons.Find(WeaponId);

            if (craftableWeapon == null)
            {
                return HttpNotFound();
            }


            List<CraftableWeaponMaterial> craftableWeaponMaterials = db.CraftableWeaponMaterials.Where(x => x.WeaponID == WeaponId).ToList();

            int counter = 0;


            foreach (var invMat in character.Inventory)
            {
                foreach (var weapMat in craftableWeaponMaterials)
                {
                    if (invMat.ItemID == weapMat.MaterialID)
                    {
                        if (invMat.ItemPieces >= weapMat.MaterialPieces)
                        {
                            counter++;
                        }
                    }

                }
            }


            if (counter == craftableWeaponMaterials.Count())
            {
                foreach (var invMat in character.Inventory)
                {
                    foreach (var weapMat in craftableWeaponMaterials)
                    {
                        if (invMat.ItemID == weapMat.MaterialID)
                        {
                            invMat.ItemPieces = invMat.ItemPieces - weapMat.MaterialPieces;

                        }
                    }
                }



                if (character.Inventory.Where(x => x.ItemID == WeaponId).FirstOrDefault() != null)
                {
                    Inventory inventory = character.Inventory.Where(x => x.ItemID == WeaponId).FirstOrDefault();
                    inventory.ItemPieces++;
                }
                else
                {
                    Inventory inventory = new Inventory { ItemID = WeaponId, CharacterID = character.CharacterID, ItemPieces = 1, ItemCurrentDurability = craftableWeapon.ItemMaxDurability, ItemMaxDurability = craftableWeapon.ItemMaxDurability };
                    db.Inventories.Add(inventory);
                }


                db.SaveChanges();

                return RedirectToAction("Details", "Characters", new { id = User.Identity.Name });

            }
            else
            {
                return RedirectToAction("Details", "Characters", new { id = User.Identity.Name });
            }
        }
    }
}