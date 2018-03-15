using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class User
    {
        public int UserID { get; set; }

        [DisplayName("Name")]
        public string UserName { get; set; }

        [DisplayName("Email")]
        public string UserEmail { get; set; }


        [DisplayName("Password")]
        [DataType(DataType.Password)]
        public string UserPassword { get; set; }
        public virtual Character Character { get; set; }


    }
}