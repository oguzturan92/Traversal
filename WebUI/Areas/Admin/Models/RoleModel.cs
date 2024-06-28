using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.Areas.Admin.Models
{
    public class RoleModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Zorunlu alan")]
        public string Name { get; set; }
    }
}