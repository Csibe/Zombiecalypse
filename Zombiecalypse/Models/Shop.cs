﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Zombiecalypse.Models
{
    public class Shop : ViewModelBase
    {   public virtual Character Character { get; set; }
        public virtual ICollection<BuyableWeapon> Weapons { get; set; }
        public virtual ICollection<Plant> Plants { get; set; }
        public virtual ICollection<Energy> Energies { get; set; }
        public virtual ICollection<Dog> Dogs { get; set; }

    }
}