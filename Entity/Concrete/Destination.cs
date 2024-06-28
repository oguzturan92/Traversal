using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public class Destination
    {
        public int DestinationId { get; set; }
        public string DestinationCity { get; set; }
        public string DestinationDayNight { get; set; }
        public double DestinationPrice { get; set; }
        public string DestinationImage { get; set; }
        public string DestinationDescription { get; set; }
        public string DestinationSubTitle { get; set; }
        public bool DestinationStatus { get; set; }
        public int DestinationCapacity { get; set; }
        public List<Comment> Comments { get; set; }
        public List<Reservation> Reservations { get; set; }
    }
}