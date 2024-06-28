using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.Models
{
    public class NewPasswordModel
    {
        public string userId { get; set; }
        public string token { get; set; }
        [Required(ErrorMessage = "Zorunlu alan.")]
        public string Password { get; set; }
        
        [Required(ErrorMessage = "Zorunlu alan.")]
        [Compare("Password", ErrorMessage = "Şifreler eşleşmiyor.")]
        public string RePassword { get; set; }
    }
}