using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Zombiecalypse.Models
{
    public class BuildingMaterial : Item
    {
        public virtual ICollection<Building> Buildings { get; set; }
        public virtual ICollection<BuildingMaterial> BuildingMaterials { get; set; }
        public virtual ICollection<BuildingBuildingMaterial> BuildingBuildingMaterials { get; set; }
    }
}