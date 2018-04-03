using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Zombiecalypse.Models
{
    public class Weapon : Item
    {
        public int WeaponID { get; set; }
        public int WeaponDurability { get; set; }
        public int WeaponDamage { get; set; }
    }

    public class CraftableWeapon : Weapon
    {
        public virtual ICollection<CraftableWeaponMaterial> WeaponMaterials { get; set; }
    }

    public class BuyableWeapon : Weapon
    {
        public int Cost { get; set; }

    }



    public class CraftableWeaponMaterial : Item {

        [Key]
        public int CraftableWeaponMaterialID { get; set; }
       
        [ForeignKey("Item")]
        public int MaterialID { get; set; }

        [ForeignKey("Weapon")]
        public int WeaponID { get; set; }

        public int MaterialPieces { get; set; }

        public virtual Item Item { get; set; }
        public virtual Weapon Weapon { get; set; }


    }
}