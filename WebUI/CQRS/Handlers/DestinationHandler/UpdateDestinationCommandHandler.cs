using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Concrete;
using WebUI.CQRS.Commands.DestinationCommands;

namespace WebUI.CQRS.Handlers.DestinationHandler
{
    public class UpdateDestinationCommandHandler
    {
        private readonly Context _context;
        public UpdateDestinationCommandHandler(Context context)
        {
            _context = context;
        }

        public void Handle(UpdateDestinationCommand command)
        {
            var value = _context.Destinations.Find(command.DestinationId);
            value.DestinationCity = command.DestinationCity;
            value.DestinationDayNight = command.DestinationDayNight;
            value.DestinationPrice = command.DestinationPrice;
            value.DestinationImage = command.DestinationImage;
            value.DestinationDescription = command.DestinationDescription;
            value.DestinationStatus = command.DestinationStatus;
            value.DestinationCapacity = command.DestinationCapacity;
            _context.Update(value);
            _context.SaveChanges();
        }
    }
}