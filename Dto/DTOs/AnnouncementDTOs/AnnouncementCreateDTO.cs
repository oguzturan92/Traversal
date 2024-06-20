using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dto.DTOs.AnnouncementDTOs
{
    public class AnnouncementCreateDTO
    {
        public string AnnouncementTitle { get; set; }
        public string AnnouncementContent { get; set; }
        public DateTime AnnouncementDate { get; set; }
    }
}