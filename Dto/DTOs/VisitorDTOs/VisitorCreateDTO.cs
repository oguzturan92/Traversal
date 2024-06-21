using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dto.DTOs.VisitorDTOs
{
    public class VisitorCreateDTO
    {
        public string VisitorName { get; set; }
        public string VisitorSurname { get; set; }
        public string VisitorCity { get; set; }
        public string VisitorCountry { get; set; }
        public string VisitorMail { get; set; }
    }
}