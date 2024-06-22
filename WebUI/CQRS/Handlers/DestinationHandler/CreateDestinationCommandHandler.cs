using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Concrete;
using Entity.Concrete;
using WebUI.CQRS.Commands.DestinationCommands;

namespace WebUI.CQRS.Handlers.DestinationHandler
{
    public class CreateDestinationCommandHandler
    {
        private readonly Context _context;
        public CreateDestinationCommandHandler(Context context)
        {
            _context = context;
        }

        public void Handle(CreateDestinationCommand command)
        {
            var newEntity = new Destination
            {
                DestinationCity = command.DestinationCity,
                DestinationDayNight = command.DestinationDayNight,
                DestinationPrice = command.DestinationPrice,
                DestinationImage = command.DestinationImage,
                DestinationDescription = command.DestinationDescription,
                DestinationStatus = command.DestinationStatus,
                DestinationCapacity = command.DestinationCapacity
            };
            _context.Destinations.Add(newEntity);
            _context.SaveChanges();
        }
    }
}