using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Concrete;
using MediatR;
using WebUI.CQRS.Commands.TeamCommands;

namespace WebUI.CQRS.Handlers.TeamHandler
{
    public class UpdateTeamCommandHandler : IRequestHandler<UpdateTeamCommand>
    {
        private readonly Context _context;
        public UpdateTeamCommandHandler(Context context)
        {
            _context = context;
        }

        public async Task Handle(UpdateTeamCommand request, CancellationToken cancellationToken)
        {
            var value = await _context.Teams.FindAsync(request.TeamId);
            value.TeamFullname = request.TeamFullname;
            value.TeamDescription = request.TeamDescription;
            value.TeamImage = request.TeamImage;
            value.TeamTwitterUrl = request.TeamTwitterUrl;
            value.TeamInstagramUrl = request.TeamInstagramUrl;
            await _context.SaveChangesAsync();
        }
    }
}