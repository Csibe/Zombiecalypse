using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Zombiecalypse.Models
{
    public class Building : Item
    {
        public int BuildingLevel { get; set; }
        public int BuildingMoneyCost { get; set; }
        public int BuildingEnergyCost { get; set; }

        public virtual ICollection<BuildingMaterial> BuildingMaterials { get; set; }
        public virtual ICollection<BuildingBuildingMaterial> BuildingBuildingMaterials { get; set; }
     //   public virtual ICollection<Character> Characters { get; set; }
    }
}