using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Concrete;
using MediatR;
using WebUI.CQRS.Commands.TeamCommands;

namespace WebUI.CQRS.Handlers.TeamHandler
{
    public class RemoveTeamCommandHandler : IRequestHandler<RemoveTeamCommand>
    {
        private readonly Context _context;
        public RemoveTeamCommandHandler(Context context)
        {
            _context = context;
        }

        public async Task Handle(RemoveTeamCommand request, CancellationToken cancellationToken)
        {
            var value = _context.Teams.Find(request.Id);
            _context.Teams.Remove(value);
            await _context.SaveChangesAsync();
        }
    }
}