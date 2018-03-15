using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.ViewModels
{
    public class CharacterViewModel
    {
        public int CharacterViewModelID { get; set; }
        public string CharacterName { get; set; }
        public int CharacterType { get; set; }

        public Character Character { get; set; }
        public virtual ICollection<Inventory> CharacterItems { get; set; }

    }
}