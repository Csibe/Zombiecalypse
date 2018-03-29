using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Zombiecalypse.Models
{
    public class Zombie
    {
        public int ZombieID { get; set; }
        public string ZombieName { get; set; }
        public int ZombieType { get; set; }
        public int ZombieLife { get; set; }
        public int ZombieDamage { get; set; }
        public int RewardCoins { get; set; }
        public int RewardXP { get; set; }
        public string ZombiePicture { get; set; }
        public virtual ICollection<Material> ZombieDrops { get; set; }
    }

    public class ZombieDrop
    {
        public int ZombieDropID { get; set; }

        [ForeignKey("Zombie")]
        public int ZombieID { get; set; }
        public Zombie Zombie { get; set; }

        [ForeignKey("Material")]
        public int MaterialID { get; set;}
        public Material Material { get; set; }
        public int MaterialPieces { get; set; }
    }

    public class ZombieAttackBase {
        public int ZombieAttackBaseID { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime ZombieAttackStart { get; set; }

        [ForeignKey("Zombie")]
        public int ZombieID { get; set; }
        public virtual Zombie Zombie { get; set; }
        [ForeignKey("Character")]
        public int CharacterID { get; set; }
        public virtual Character Character { get; set; }
    }
}