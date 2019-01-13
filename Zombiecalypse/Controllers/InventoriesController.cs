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

            Inventory item = db.Inventories.Find(id);
            Character character = db.Characters.Where(x => x.ApplicationUserID == User.Identity.Name).FirstOrDefault();
            Building building = db.Buildings.Find(item.ItemID);


            if (item == null)
            {
                return HttpNotFound();
            }

            if (building == null)
            {
                return HttpNotFound();
            }
            if (character == null)
            {
                return HttpNotFound();
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
                            invMat.ItemPieces -= newMat.MaterialPieces;

                        }
                    }
                }

                var newitem = db.Buildings.Where(p => p.ItemID == newBuilding.ItemID).FirstOrDefault();
                item.Item = db.Items.Find(newitem.ItemID);
                item.ItemID = newitem.ItemID;
                item.ItemMaxDurability = newitem.ItemMaxDurability;
                item.ItemCurrentDurability = newitem.ItemMaxDurability;

                character.CharacterMoney -= building.BuildingMoneyCost;
                var result = new CharactersController().ManageEnergy(User.Identity.Name, building.BuildingEnergyCost, this.Request.FilePath);

                db.SaveChanges();

            }
            return RedirectToAction("Details", "Buildings", new { id = item.ItemID });
        }


        public ActionResult LevelUpFence(int id, string returnUrl)
        {

            Inventory item = db.Inventories.Find(id);
            Character character = db.Characters.Where(x => x.ApplicationUserID == User.Identity.Name).FirstOrDefault();
            Building fence = db.Buildings.Find(item.ItemID);


            if (item == null)
            {
                return HttpNotFound();
            }

            if (fence == null)
            {
                return HttpNotFound();
            }
            if (character == null)
            {
                return HttpNotFound();
            }


            ICollection<Inventory> characterInventory = db.Inventories.Where(x => x.CharacterID == character.CharacterID).ToList();

            int buildingLevel = fence.BuildingLevel;
            int newBuildingLevel = ++buildingLevel;
            string buildingName = fence.ItemName;

            Building newBuilding = db.Buildings.Where(x => x.ItemName == buildingName).Where(x => x.BuildingLevel == newBuildingLevel).FirstOrDefault();
            BuildingBuildingMaterial newBuildingBuildingMaterial = db.BuildingBuildingMaterials.Where(x => x.BuildingID == newBuilding.ItemID).FirstOrDefault();


            foreach (var invMat in characterInventory)
            {
                if (invMat.ItemID == newBuildingBuildingMaterial.BuildingMaterialID)
                {
                    if (invMat.ItemPieces >= newBuildingBuildingMaterial.MaterialPieces)
                    {
                        var newitem = db.Buildings.Where(p => p.ItemID == newBuilding.ItemID).FirstOrDefault();
                        item.Item = db.Items.Find(newitem.ItemID);
                        item.ItemID = newitem.ItemID;
                        item.ItemMaxDurability = newitem.ItemMaxDurability;
                        item.ItemCurrentDurability = newitem.ItemMaxDurability;

                        invMat.ItemPieces -= newBuildingBuildingMaterial.MaterialPieces;

                        character.CharacterMoney -= fence.BuildingMoneyCost;

                        var result = new CharactersController().ManageEnergy(User.Identity.Name, fence.BuildingEnergyCost, this.Request.FilePath);
                    }
                }
            }

            db.SaveChanges();

            return Redirect(returnUrl);
    }






    public ActionResult CraftWeapon(int WeaponId)
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

        Building building = new Building();

        foreach (var mat in craftableWeaponMaterials)
        {
            foreach (var b in db.Buildings)
            {
                if (mat.MaterialID == b.ItemID)
                {
                    building = db.Buildings.Find(b.ItemID);

                }
            }
        }

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
                    if (invMat.ItemID == weapMat.MaterialID && invMat.ItemID != building.ItemID)
                    {
                        invMat.ItemPieces -= weapMat.MaterialPieces;

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