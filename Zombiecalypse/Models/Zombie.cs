using System;
using System.Collections.Generic;
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
        public virtual ICollection<Material> ZombieDrops { get; set; }
    }

    public class ZombieDrop
    {
        public int ZombieDropID { get; set; }
        public int ZombieID { get; set; }
        public Zombie Zombie { get; set; }

        [ForeignKey("Material")]
        public int MaterialID { get; set;}
        public Material Material { get; set; }
        public int MaterialPieces { get; set; }
    }
}