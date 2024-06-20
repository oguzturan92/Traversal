using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dto.DTOs.BannerDTOs
{
    public class BannerCreateDTO
    {
        public string BannerTitle { get; set; }
        public string BannerDescription { get; set; }
        public string BannerImage { get; set; }
    }
}