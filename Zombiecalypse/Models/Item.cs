using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Zombiecalypse.Models
{
    public class Item
    {
        public int ItemID { get; set; }
        public string ItemName { get; set; }
        public string ItemType { get; set; }
        public string ItemPicture { get; set; }
        public int ItemDurability { get; set; }
        public virtual ICollection<Inventory> Inventories { get; set; }

    }
    public class Material : Item
    {
        public int MaterialID { get; set; }
    }

    public class PlantField : Item {
        public int PlantFieldId { get; set; }
       // [DataType(DataType.DateTime)]
        //public DateTime StartPlant {get;set;}
        public bool IsFieldEmpty { get; set; }
        public int PlantID { get; set; }
        public virtual Plant Plant { get; set; }
        public virtual ICollection<Plant> PlantablePlants { get; set; }
    }

    public class Plant : Item {
        public int PlantID { get; set; }
        public string PlantFinishedPicture { get; set; }
        public string PlantStartPicture { get; set; }
        public int PlantCost { get; set; }
        public int GrowTime { get; set; }
        public int PlantRewardCoin { get; set; }
        public int PlantRewardFood { get; set; }
    }
    public class Energy : Item {
        public int EnergyID { get; set; }
        public int PlusEnergy { get; set; }
        public int Cost { get; set; }
    }
}