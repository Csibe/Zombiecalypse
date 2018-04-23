using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Zombiecalypse.Models
{
    public class Adventure
    {
        public int AdventureID { get; set; }
        public string AdventureName { get; set; }
        public int  AdventureWaitingTime { get; set; }
        public int AdventureSteps { get; set; }
        public int AdventureXPBonus { get; set; }
        public virtual Character Character { get; set; }
    }

    public class AdventureDrop {
        public int AdventureDropID { get; set; }
        public int AdventureID { get; set; }

        [ForeignKey("Item")]
        public int DropableItemID { get; set; }
        public virtual Item Item { get; set; }
        public double ItemDroprate { get; set; }
        public int ItemMaxDrop { get; set; }
    }

    public class ZombieAttackAdventurer
    {
        public int ZombieAttackAdventurerID { get; set; }
        public int ZombieID { get; set; }
        public int ZombieLife { get; set; }
        public int CharacterID { get; set; }
        public int State { get; set; }
    }


    public class AdventureViewModel
    {
        public virtual ICollection<ZombieAttackAdventurer> AttackingZombies { get; set; }
        public int CharacterID { get; set; }
        public virtual Character Character { get; set; }
    }


    public class ChosenZombie {
        public Zombie Zombie { get; set; }
    }
}