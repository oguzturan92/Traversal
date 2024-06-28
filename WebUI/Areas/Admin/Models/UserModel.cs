using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.Areas.Admin.Models
{
    public class UserUpdateModel
    {
        public int Id { get; set; }
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
        public IEnumerable<string> SeciliRoller { get; set; }
        public IEnumerable<string> TumRoller { get; set; }
    }
}