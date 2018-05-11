using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Zombiecalypse.Models
{
    public abstract class Item
    {
        public int ItemID { get; set; }
        public string ItemName { get; set; }
        public string ItemPicture { get; set; }
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

    public class Building : Item
    {
        public int BuildingLevel { get; set; }
        public int BuildingEnergyCost { get; set; }
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

    public class BuildingDetailViewModel
    {
        public virtual Building Building { get; set; }
        public virtual ICollection<BuildingMaterial> BuildingMaterials { get; set; }
        public virtual ICollection<BuildingBuildingMaterial> BuildingBuildingMaterials { get; set; }
    }
}