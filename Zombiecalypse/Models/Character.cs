using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Zombiecalypse.Models
{

    public class Character
    {
        public int CharacterID { get; set; }
        public string ApplicationUserID { get; set; }
        public string CharacterName { get; set; }
        public int CharacterType { get; set; }
        public int CharacterMoney { get; set; }
        public int MaxEnergy { get; set; }
        public int CurrentEnergy { get; set; }
        public int CharacterXP { get; set; }
        public int CharacterLevel { get; set; }
        public bool IsOnAdventure { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime FinishAdventure { get; set; }
        public virtual ICollection<Inventory> Inventory { get; set; }
    }

    public class CharacterDetailsViewModel
    {
        public int CharacterID { get; set; }
        public string CharacterName { get; set; }
        public int CharacterType { get; set; }
        public int CharacterMoney { get; set; }
        public int CharacterMaxLife { get; set; }
        public int CharacterCurrentLife { get; set; }
        public int MaxEnergy { get; set; }
        public int CurrentEnergy { get; set; }
        public int CharacterXP { get; set; }
        public int CharacterNextLevelXP { get; set; }
        public int CharacterLevel { get; set; }
        public virtual ICollection<Level> Levels { get; set;}
        public virtual ICollection<Inventory> CharacterItems { get; set; }
        public virtual ICollection<Adventure> Adventures { get; set; }

        public virtual ICollection<ZombieAttackBase> AttackingZombies { get; set; }

    }
}