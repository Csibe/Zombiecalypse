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
    public class BuildingsController : BaseController
    {

        int BuildingMaxLevel = 5;

        public ActionResult Details(int id)
        {
            BuildingDetailViewModel model = new BuildingDetailViewModel();

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            model.Building = db.Buildings.Find(id);

            List<CraftableWeaponMaterial> selectBuilding = new List<CraftableWeaponMaterial>();

            foreach (var weaponMaterial in db.CraftableWeaponMaterials.Where(x => x.MaterialID == id))
            {
                selectBuilding.Add(weaponMaterial);
            }



            List<CraftableWeapon> craftableWeapons = new List<CraftableWeapon>();
            List<CraftableWeaponMaterial> craftableWeaponMaterials = new List<CraftableWeaponMaterial>();

            foreach (var weapon in selectBuilding)
            {
                foreach (var weaponMaterial in db.CraftableWeaponMaterials)
                {
                    if (weapon.WeaponID == weaponMaterial.WeaponID)
                    {
                        if (craftableWeapons.Contains<CraftableWeapon>(db.CraftableWeapons.Find(weapon.WeaponID)))
                        {

                        }
                        else
                        {
                            craftableWeapons.Add(db.CraftableWeapons.Find(weapon.WeaponID));
                        }
                        craftableWeaponMaterials.Add(weaponMaterial);
                    }
                }
            }


            model.NextBuilding = db.Buildings.Find(id + 1);
            model.CraftableWeapons = craftableWeapons;
            model.ComponentOfCraftableWeapon = craftableWeaponMaterials;
            model.Character = db.Characters.Where(y => y.ApplicationUserID == User.Identity.Name).FirstOrDefault(); ;
            model.Materials = db.Materials.ToList();

            if (model.Building == null)
            {
                return HttpNotFound();
            }
            else
            {
                if (model.Building.BuildingLevel < BuildingMaxLevel)
                {
                    id += 1;
                    model.NextBuilding = db.Buildings.Find(id);
                    model.NextBuildingBuildingMaterials = db.BuildingBuildingMaterials.Where(x => x.BuildingID == id).ToList();
                    model.NextBuildingMaterials = db.BuildingMaterials.ToList();
                }
                else
                {
                    model.NextBuilding = db.Buildings.Find(id);
                    model.NextBuildingBuildingMaterials = db.BuildingBuildingMaterials.Where(x => x.BuildingID == id).ToList();
                    model.NextBuildingMaterials = db.BuildingMaterials.ToList();
                }
            }


            base.SetModelProperties(model);
            return View(model);
        }

        public ActionResult RepairFence(string id, string returnUrl)
        {

            Character character = db.Characters.Where(y => y.ApplicationUserID == User.Identity.Name).FirstOrDefault();
            Inventory item = character.Inventory.Where(x => x.ItemID == 55).FirstOrDefault(); //board
            Inventory fence = character.Inventory.Where(x => x.Item.ItemName == "Fence").FirstOrDefault();

            if (item == null)
            {
                return RedirectToAction("Details", "Characters", new { id = User.Identity.Name });
            }

            if (character.IsOnAdventure == false)
            {
                if (character.CurrentEnergy > 0)
                {
                    if (item.ItemPieces > 0)
                    {
                        var result = new CharactersController().ManageEnergy(User.Identity.Name, 1, this.Request.Path);
                        item.ItemPieces--;
                        fence.ItemCurrentDurability++;
                        db.SaveChanges();
                    }

                    return Redirect(returnUrl);
                }
                else
                {
                    return Redirect(returnUrl);
                }
            }
            else
            {
                return Redirect(returnUrl);
            }
        }


        public ActionResult RepairBuilding(int id, string returnUrl)
        {

            Character character = db.Characters.Where(y => y.ApplicationUserID == User.Identity.Name).FirstOrDefault();
            Inventory item = character.Inventory.Where(x => x.ItemID == 55).FirstOrDefault(); //board
            Inventory building = character.Inventory.Where(x => x.Item.ItemID == id).FirstOrDefault();
            List<CharacterMissionTask> characterMissionTasks = db.CharacterMissionTasks.Where(x => x.CharacterID == character.CharacterID).ToList();


            if (item == null)
            {
                return RedirectToAction("Details", "Characters", new { id = User.Identity.Name });
            }

            if (character.IsOnAdventure == false)
            {
                if (character.CurrentEnergy > 0)
                {
                    if (item.ItemPieces > 0)
                    {
                        var result = new CharactersController().ManageEnergy(User.Identity.Name, 1, this.Request.Path);
                        item.ItemPieces--;
                        building.ItemCurrentDurability++;
                        db.SaveChanges();
                    }

                    return Redirect(returnUrl);
                }
                else
                {
                    return Redirect(returnUrl);
                }
            }
            else
            {
                return Redirect(returnUrl);
            }
        }



    }
}
