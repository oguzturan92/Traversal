using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public class Reservation
    {
        public int ReservationId { get; set; }
        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        public string ReservationPersonCount { get; set; }
        public DateTime ReservationDate { get; set; }
        public string ReservationDescription{ get; set; }
        public string ReservationStatus { get; set; }
        public int DestinationId { get; set; }
        public Destination Destination { get; set; }
    }
}