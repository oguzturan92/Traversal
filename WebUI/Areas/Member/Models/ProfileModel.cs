using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.Areas.Member.Models
{
    public class ProfileUpdateModel
    {
        [Required(ErrorMessage = "Zorunlu alan.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Zorunlu alan.")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Zorunlu alan.")]
        public string UserName { get; set; }
        public string PhoneNumber { get; set; }
        public string City { get; set; }

        [Required(ErrorMessage = "Zorunlu alan.")]
        public string Email { get; set; }

        public string OldPassword { get; set; }
        public string Password { get; set; }
        
        [Compare("Password", ErrorMessage = "Şifreler eşleşmiyor.")]
        public string RePassword { get; set; }
    }
}