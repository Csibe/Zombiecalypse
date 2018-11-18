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
        public int MaxTolerance { get; set; }
        public int Tolerance { get; set; }
        public bool IsOnAdventure { get; set; }
        [DisplayName("Adventure ID")]
        public int AdventureID { get; set; }
        [DisplayName("Adventure state")]
        public int AdventureState { get; set; }
        [DataType(DataType.DateTime)]
        [DisplayName("Finish adventure time")]
        public DateTime FinishAdventure { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime EnergyPlusDate { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime LastZombieAttackTime { get; set; }
        public virtual ICollection<Inventory> Inventory { get; set; }
    }

    public class CharacterDetailsViewModel : ViewModelBase
    {
        public int CharacterID { get; set; }

        public virtual Character Character { get; set; }

        [DisplayName("Next level XP")]
        public int CharacterNextLevelXP { get; set; }
        public int FenceMaxDurability { get; set; }
        public int FenceCurrentDurability { get; set; }
        
        public string BasePicture { get; set; }

        public virtual ICollection<Mission> Missions { get; set; }
        public virtual ICollection<Inventory> CharacterItems { get; set; }
        public virtual ICollection<Building> CharacterBuildings { get; set; }
        public virtual ICollection<CharacterField> CharacterFields { get; set; }
        public virtual ICollection<Adventure> Adventures { get; set; }
        public virtual ICollection<ZombieAttackBase> ZombieAttackBase { get; set; }
        public virtual ICollection<Zombie> ZombiesDB { get; set; }
       
    }
}