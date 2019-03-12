using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace Zombiecalypse.Models
{
    public abstract class Item
    {
        public int ItemID { get; set; }
        [DisplayName("Name")]
        public string ItemName { get; set; }
        [DisplayName("Picture")]
        public string ItemPicture { get; set; }
        [DisplayName("Max durability")]
        public int ItemMaxDurability { get; set; }

    }

    public class Plant : Item 
    {

        public int PlantMoneyCost { get; set; }
        public int PlantGrowTime { get; set; }
        public int PlantRewardCoin { get; set; }
        public int PlantRewardFood { get; set; }
        public string PlantStartPicture { get; set; }
        public string PlantFinishedPicture { get; set; }
    }

    public class Field : Item
    {
    }

    public class Building : Item
    {
        [DisplayName("Level")]
        public int BuildingLevel { get; set; }
        [DisplayName("Energy cost")]
        public int BuildingEnergyCost { get; set; }
        [DisplayName("Money cost")]
        public int BuildingMoneyCost { get; set; }
    }

    public class Material : Item
    {
    }

    public class BuildingMaterial : Item
    {
    }

    public class BuildingBuildingMaterial
    {
        public int BuildingBuildingMaterialID { get; set; }
        public int BuildingID { get; set; }
        public int BuildingMaterialID { get; set; }
        public int MaterialPieces { get; set; }
    }



    public class Weapon : Item
    {
        [DisplayName("Damage")]
        public int WeaponDamage { get; set; }
        public bool IsRanged { get; set; }
    }

    public class Energy : Item
    {
        public int PlusEnergy { get; set; }
        public int Cost { get; set; }
    }

    public class CraftableWeapon : Weapon
    {
        public virtual ICollection<CraftableWeaponMaterial> CraftableWeaponMaterials { get; set; }
    }

    public class BuyableWeapon : Weapon
    {
        public int Cost { get; set; }

    }


    public class CraftableWeaponMaterial
    {
        public int CraftableWeaponMaterialID { get; set; }

        public int WeaponID { get; set; }
        public int MaterialID { get; set; }

        public int MaterialPieces { get; set; }
    }



    public class BuildingDetailViewModel : ViewModelBase
    {
        public virtual Building Building { get; set; }
        public virtual Building NextBuilding { get; set; }
        public virtual Character Character { get; set; }
        public virtual ICollection<Material> Materials { get; set; }
        public virtual ICollection<BuildingMaterial> NextBuildingMaterials { get; set; }
        public virtual ICollection<BuildingBuildingMaterial> NextBuildingBuildingMaterials { get; set; }
        public virtual ICollection<CraftableWeapon> CraftableWeapons { get; set; }
        public virtual ICollection<CraftableWeaponMaterial> ComponentOfCraftableWeapon { get; set; }
    }

    public class PlantOnFieldVM : ViewModelBase
    {
        public virtual ICollection<Plant> Plants { get; set; }
        public int FieldID { get; set; }
        public virtual ICollection<Inventory> Inventory { get; set; }
    }
}