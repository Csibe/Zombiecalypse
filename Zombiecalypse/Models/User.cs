using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Zombiecalypse.Models
{
    public class User
    {

        
        public int UserID { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Username required")]
        [DisplayName("Name")]
        public string UserName { get; set; }


        [Required(AllowEmptyStrings = false, ErrorMessage = "Email is required")]
        [DataType(DataType.EmailAddress)]
        [DisplayName("Email")]
        public string UserEmail { get; set; }


        [Required(AllowEmptyStrings = false, ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "Minimum 6 characters required")]
        public string UserPassword { get; set; }

        public Character Character { get; set; }

    }
}