using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.Models
{
    public class UserRegisterModel
    {
        [Required(ErrorMessage = "Zorunlu alan.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Zorunlu alan.")] 
        public string Surname { get; set; }

        [Required(ErrorMessage = "Zorunlu alan.")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Zorunlu alan.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Zorunlu alan.")]
        public string Password { get; set; }
        
        [Required(ErrorMessage = "Zorunlu alan.")]
        [Compare("Password", ErrorMessage = "Şifreler eşleşmiyor.")]
        public string RePassword { get; set; }
        public bool IsLoginPageDirect { get; set; }
    }

    public class UserLoginModel
    {
        [Required(ErrorMessage = "Zorunlu alan.")]
        public string Email { get; set; }
        
        [Required(ErrorMessage = "Zorunlu alan.")]
        public string Password { get; set; }
        public string ReturnUrl { get; set; }
    }
}