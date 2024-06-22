using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.CQRS.Commands.DestinationCommands
{
    public class CreateDestinationCommand
    {
        public string DestinationCity { get; set; }
        public string DestinationDayNight { get; set; }
        public double DestinationPrice { get; set; }
        public string DestinationImage { get; set; }
        public string DestinationDescription { get; set; }
        public bool DestinationStatus { get; set; }
        public int DestinationCapacity { get; set; }
    }
}