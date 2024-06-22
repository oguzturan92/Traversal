using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Concrete;
using MediatR;
using WebUI.CQRS.Commands.TeamCommands;

namespace WebUI.CQRS.Handlers.TeamHandler
{
    public class UpdateStatusTeamCommandHandler : IRequestHandler<UpdateStatusTeamCommand>
    {
        private readonly Context _context;
        public UpdateStatusTeamCommandHandler(Context context)
        {
            _context = context;
        }

        public async Task Handle(UpdateStatusTeamCommand request, CancellationToken cancellationToken)
        {
            var value = _context.Teams.Find(request.Id);
            value.TeamStatus = value.TeamStatus == true ? false:true;
            await _context.SaveChangesAsync();
        }
    }
}