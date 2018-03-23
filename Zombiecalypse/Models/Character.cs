using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Zombiecalypse.Models
{
    /*
    public class CreateCharacterViewModel
    {
        [Key]
        public int CharacterID { get; set; }
        public string CharacterName { get; set; }
        public int CharacterType { get; set; }
        public int MaxEnergy { get; set; }
        public int CurrentEnergy { get; set; }
        public int CharacterXP { get; set; }
        public int CharacterLevel { get; set; }
        public bool IsOnAdventure { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime FinishAdventure { get; set; }
    //    public virtual User User { get; set; }
        public virtual ICollection<Inventory> Inventory { get; set; }
    }
    */

    public class Character
    {

       // public int UserID { get; set; }
        //public virtual User User { get; set; }

        public int CharacterID { get; set; }
        public string CharacterName { get; set; }
        public int CharacterType { get; set; }
        public int MaxEnergy { get; set; }
        public int CurrentEnergy { get; set; }
        public int CharacterXP { get; set; }
        public int CharacterLevel { get; set; }
        public bool IsOnAdventure { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime FinishAdventure { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual ICollection<Inventory> Inventory { get; set; }
    }
}