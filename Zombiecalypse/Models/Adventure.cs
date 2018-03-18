using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Zombiecalypse.Models
{
    public class Adventure
    {
        public int AdventureID { get; set; }

        public string AdventureName { get; set; }
        public int AdventureTime { get; set; }

        public Character Character { get; set; }
    }
}