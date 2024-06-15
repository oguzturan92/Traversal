using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public class Room
    {
        public int RoomId { get; set; }
        public string RoomImage { get; set; }
        public string RoomTitle { get; set; }
        public string RoomSubTitle { get; set; }
    }
}