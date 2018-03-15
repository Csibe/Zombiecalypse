using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.ViewModels
{
    public class RegistrationViewModel
    {

        public int RegistrationViewModelID { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy.MM.dd. HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime RegistrationDate { get; set; }

        public int UserID { get; set; }

        [DisplayName("Username")]
        public string UserName { get; set; }

        [DisplayName("Email")]
        public string UserEmail { get; set; }

        [DisplayName("Password")]
        [DataType(DataType.Password)]
        public string UserPassword { get; set; }

        /*
        [DisplayName("Password again")]
        [Required(ErrorMessage = "Password doesn't match")]
        [Compare("UserPassword")]
        [DataType(DataType.Password)]
        public string UserRePassword { get; set; }
        */
        public int CharacterID { get; set; }

        [DisplayName("Character name")]
        public string CharacterName { get; set; }

        [DisplayName("Character type")]
        public int CharacterType { get; set; }
        public int MaxEnergy { get; set; }
        public int CurrentEnergy { get; set; }
        public int CharacterXP { get; set; }
        public int CharacterLevel { get; set; }
    }
}