using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Zombiecalypse.Models;

namespace Zombiecalypse.ViewModels
{

    public class RegistrationViewModel
    {

        public int RegistrationViewModelID { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy.MM.dd. HH:mm}", ApplyFormatInEditMode = true)]
        public DateTime RegistrationDate { get; set; }
        
        public int UserID { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Username required")]
        [DisplayName("Username")]
        public string UserName { get; set; }


        [Required(AllowEmptyStrings = false, ErrorMessage = "Email is required")]
        [DataType(DataType.EmailAddress)]
        [DisplayName("Email")]
        public string UserEmail { get; set; }


        [Required(AllowEmptyStrings = false, ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "Minimum 6 characters required")]
        public string Password { get; set; }

        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Confirm password and password do not match")]
        public string ConfirmPassword { get; set; }

        
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