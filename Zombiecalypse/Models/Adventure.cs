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
        public int AdventureTime { get; set; }
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
}