using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Zombiecalypse.Models
{
    public abstract class ViewModelBase
    {
        public string UserKe { get; set; }
        public ICollection<CharacterField> Fields { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime EnergyPlusDate { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime AdventureFinishDate { get; set; }
        public ICollection<ZombieAttackBase> AttackingZombies { get; set; }
       

    }

    public class HomeViewModel : ViewModelBase
    {
    }
}