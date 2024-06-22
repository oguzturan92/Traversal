using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Concrete;
using WebUI.CQRS.Commands.DestinationCommands;

namespace WebUI.CQRS.Handlers.DestinationHandler
{
    public class RemoveDestinationCommandHandler
    {
        private readonly Context _context;
        public RemoveDestinationCommandHandler(Context context)
        {
            _context = context;
        }

        public void Handle(RemoveDestinationCommand command)
        {
            var value = _context.Destinations.Find(command.Id);
            _context.Destinations.Remove(value);
            _context.SaveChanges();
        }
    }
}