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
        [Key]
        [ForeignKey("Building")]
        public int BuildingID { get; set; }
        [ForeignKey("BuildingMaterial")]
        public int BuildingMaterialID { get; set; }
        public Building Building { get; set; }
        public BuildingMaterial BuildingMaterial { get; set; }
        public int MaterialPieces { get; set; }
    }
}