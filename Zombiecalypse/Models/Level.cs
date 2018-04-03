using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Zombiecalypse.Models
{
    public class Level
    {
        public int LevelID { get; set; }
        public int LevelMaxXP { get; set; }
        public int LevelMaxEnergy { get; set; }
    }
}