using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Zombiecalypse.Models
{
    public class BuildingBuildingMaterial : Item
    {
        public int BuildingID { get; set; }
        public int BuildingMaterialID { get; set; }
        public Item Building { get; set; }
        public Item BuildingMaterial { get; set; }
        public int MaterialPieces { get; set; }
    }
}