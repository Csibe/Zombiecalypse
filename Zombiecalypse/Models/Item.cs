using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Zombiecalypse.Models
{
    public class Item
    {
        public int ItemID { get; set; }
        public string ItemName { get; set; }
        public string ItemType { get; set; }
        public string ItemPicture { get; set; }
        public virtual ICollection<Inventory> Inventories { get; set; }

    }
}