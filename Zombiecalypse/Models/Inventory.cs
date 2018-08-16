using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Zombiecalypse.Models
{
    public class Inventory
    {
        public int InventoryID { get; set; }

        [ForeignKey("Character")]
        public int CharacterID { get; set; }
        public virtual Character Character { get; set; }
        public int ItemID { get; set; }
        public int ItemMaxDurability { get; set; }
        public int ItemCurrentDurability { get; set; }
        public virtual Item Item { get; set; }
        //public virtual Building Building { get; set; }
        //public virtual BuildingMaterial BuildingMaterial { get; set; }
        //public virtual PlantField PlantField { get; set; }
        //public bool isFinished { get; set; }
        //public DateTime FinishDate { get; set; }
        public int ItemPieces { get; set; }
    }

    public class CharacterField
    {
        public int CharacterFieldID { get; set; }
        public int CharacterID { get; set; }
        public int PlantID { get; set; }
        public bool isFinished { get; set; }
        public bool IsEmpty { get; set; }
        public DateTime FinishDate { get; set; }
        public virtual Plant Plant { get; set; }
    }

    public class CharacterFieldVM : ViewModelBase
    {
        public CharacterField CharacterField { get; set; }
    }
}