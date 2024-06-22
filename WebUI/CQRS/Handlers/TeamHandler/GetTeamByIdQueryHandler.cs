using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Concrete;
using MediatR;
using WebUI.CQRS.Queries.TeamQuery;
using WebUI.CQRS.Results.TeamResult;

namespace WebUI.CQRS.Handlers.TeamHandler
{
    public class GetTeamByIdQueryHandler : IRequestHandler<GetTeamByIdQuery, GetTeamByIdQueryResult>
    {
        private readonly Context _context;
        public GetTeamByIdQueryHandler(Context context)
        {
            _context = context;
        }
        public async Task<GetTeamByIdQueryResult> Handle(GetTeamByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _context.Teams.FindAsync(request.Id);
            var value2 = new GetTeamByIdQueryResult
            {
                TeamId = value.TeamId,
                TeamFullname = value.TeamFullname,
                TeamDescription = value.TeamDescription,
                TeamImage = value.TeamImage,
                TeamTwitterUrl = value.TeamTwitterUrl,
                TeamInstagramUrl = value.TeamInstagramUrl
            };
            return value2;
        }
    }
}