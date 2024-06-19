using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public class Team
    {
        public int TeamId { get; set; }
        public string TeamFullname { get; set; }
        public string TeamDescription { get; set; }
        public string TeamImage { get; set; }
        public string TeamTwitterUrl { get; set; }
        public string TeamInstagramUrl { get; set; }
        public bool TeamStatus { get; set; }
    }
}