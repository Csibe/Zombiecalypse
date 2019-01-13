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
        public string ZombiePlaceAppear { get; set; }
        public int ZombieRank { get; set; }
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
        public int ZombieID { get; set; }
        public int MaterialID { get; set; }
        public int MaterialPieces { get; set; }
    }

    public class ZombieAttackBase
    {
        public int ZombieAttackBaseID { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime ZombieAttackStart { get; set; }
        public int ZombieID { get; set; }
        public int CharacterID { get; set; }
        public int ZombieLife { get; set; }
    }

    public class BaseDefenseFromZombiesVM : ViewModelBase
    {
        public virtual ZombieAttackBase ZombieAttackBase { get; set; }
        public virtual Character Character { get; set; }
        public virtual Zombie Zombie { get; set; }
        public virtual Weapon Weapon { get; set; }
        public virtual ICollection<Mission> Missions { get; set; }
        public virtual ICollection<Building> Buildings { get; set; }
        public virtual ICollection<CraftableWeapon> CraftableWeapons { get; set; }
        public virtual ICollection<BuyableWeapon> BuyableWeapons { get; set; }

    }

    public class ZombieAttackBaseVM : ViewModelBase
    {
        public virtual ZombieAttackBase ZombieAttackBase { get; set; }
        public virtual Character Character { get; set; }
        public virtual Zombie Zombie { get; set; }
        public virtual Weapon Weapon { get; set; }
        public virtual ICollection<Building> Buildings { get; set; }
        public virtual ICollection<CraftableWeapon> CraftableWeapons { get; set; }
        public virtual ICollection<BuyableWeapon> BuyableWeapons { get; set; }

    }

    public class ZombieVM : ViewModelBase
    {
        public virtual ICollection<Zombie> Zombies { get; set; }
    }


    public class AttackingZombieReward : ViewModelBase
    {
        public int RexardXP { get; set; }
        public int RewardCoin { get; set; }
    }


}