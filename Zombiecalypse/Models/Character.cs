using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Zombiecalypse.Models
{

    public class Character
    {
        public int CharacterID { get; set; }
        [DisplayName("User ID")]
        public string ApplicationUserID { get; set; }
        [DisplayName("Name")]
        public string CharacterName { get; set; }
        [DisplayName("Type")]
        public int CharacterType { get; set; }
        [DisplayName("Money")]
        public int CharacterMoney { get; set; }
        [DisplayName("Max energy")]
        public int MaxEnergy { get; set; }
        [DisplayName("Current energy")]
        public int CurrentEnergy { get; set; }
        [DisplayName("Food")]
        public int CharacterFood { get; set; }
        [DisplayName("XP")]
        public int CharacterXP { get; set; }
        [DisplayName("Level")]
        public int CharacterLevel { get; set; }
        [DisplayName("Is on adventure")]
        public bool IsOnAdventure { get; set; }
        [DisplayName("Adventure ID")]
        public int AdventureID { get; set; }
        [DisplayName("Adventure state")]
        public int AdventureState { get; set; }
        [DataType(DataType.DateTime)]
        [DisplayName("Finish adventure time")]
        public DateTime FinishAdventure { get; set; }
        public virtual ICollection<Inventory> Inventory { get; set; }
    }

    public class CharacterDetailsViewModel
    {
        public int CharacterID { get; set; }

        [DisplayName("Name")]
        public string CharacterName { get; set; }
        [DisplayName("Type")]
        public int CharacterType { get; set; }
        [DisplayName("Money")]
        public int CharacterMoney { get; set; }
        [DisplayName("Max life")]
        public int CharacterMaxLife { get; set; }
        [DisplayName("Current life")]
        public int CharacterCurrentLife { get; set; }
        [DisplayName("Max energy")]
        public int MaxEnergy { get; set; }
        [DisplayName("Current energy")]
        public int CurrentEnergy { get; set; }
        [DisplayName("XP")]
        public int CharacterXP { get; set; }
        [DisplayName("Next level XP")]
        public int CharacterNextLevelXP { get; set; }
        [DisplayName("Level")]
        public int CharacterLevel { get; set; }
        [DisplayName("Food")]
        public int CharacterFood { get; set; }
        //public virtual ICollection<Level> Levels { get; set; }
        public virtual ICollection<Inventory> CharacterItems { get; set; }
        public virtual ICollection<Building> CharacterBuildings { get; set; }
        //public virtual ICollection<Adventure> Adventures { get; set; }
        //public virtual ICollection<ZombieAttackBase> AttackingZombies { get; set; }

    }
}