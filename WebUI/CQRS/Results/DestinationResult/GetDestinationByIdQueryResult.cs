using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.CQRS.Results.DestinationResult
{
    public class GetDestinationByIdQueryResult
    {
        // Hangi prop'lar lazımsa onları alıyoruz
        public int DestinationId { get; set; }
        public string DestinationCity { get; set; }
        public string DestinationDayNight { get; set; }
        public double DestinationPrice { get; set; }
        public string DestinationImage { get; set; }
        public string DestinationDescription { get; set; }
        public bool DestinationStatus { get; set; }
        public int DestinationCapacity { get; set; }
    }
}