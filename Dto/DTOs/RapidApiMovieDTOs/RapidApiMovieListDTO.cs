using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dto.DTOs.RapidApiMovieDTOs
{
    public class RapidApiMovieListDTO
    {
        public int rank { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string big_image { get; set; }
        public string rating { get; set; }
        public int year { get; set; }
    }
}