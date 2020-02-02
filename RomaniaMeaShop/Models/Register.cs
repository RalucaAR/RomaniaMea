using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RomaniaMeaShop.Models
{
    public class Register
    {
        [Required]
        [Display(Name = "Username")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Parolă")]
        public string Password { get; set; }

        [Display(Name = "Confirmă parola")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "The passwords does not match!")]
        public string ConfirmPassword { get; set; }
    }
}
