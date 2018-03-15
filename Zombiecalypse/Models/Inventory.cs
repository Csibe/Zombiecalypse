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
        public virtual Item Item { get; set; }
        public virtual Building Building { get; set; }
        public virtual BuildingMaterial BuildingMaterial { get; set; }
        public virtual BuildingBuildingMaterial BuildingBuildingMaterial { get; set; }
        public int ItemPieces { get; set; }
    }
}