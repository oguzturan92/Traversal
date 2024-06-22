using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Concrete;
using Entity.Concrete;
using MediatR;
using WebUI.CQRS.Commands.TeamCommands;

namespace WebUI.CQRS.Handlers.TeamHandler
{
    public class CreateTeamCommandHandler : IRequestHandler<CreateTeamCommand>
    {
        private readonly Context _context;
        public CreateTeamCommandHandler(Context context)
        {
            _context = context;
        }
        public async Task Handle(CreateTeamCommand request, CancellationToken cancellationToken)
        {
            var newEntity = new Team
            {
                TeamFullname = request.TeamFullname,
                TeamDescription = request.TeamDescription,
                TeamImage = request.TeamImage,
                TeamTwitterUrl = request.TeamTwitterUrl,
                TeamInstagramUrl = request.TeamInstagramUrl,
                TeamStatus = request.TeamStatus
            };
            await _context.Teams.AddAsync(newEntity);
            await _context.SaveChangesAsync();
        }
    }
}