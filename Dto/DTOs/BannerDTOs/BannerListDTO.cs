using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dto.DTOs.BannerDTOs
{
    public class BannerListDTO
    {
        public int BannerId { get; set; }
        public string BannerTitle { get; set; }
        public string BannerDescription { get; set; }
        public string BannerImage { get; set; }
    }
}