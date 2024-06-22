using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Concrete;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WebUI.CQRS.Queries.TeamQuery;
using WebUI.CQRS.Results.TeamResult;

namespace WebUI.CQRS.Handlers.TeamHandler
{
    public class GetAllTeamQueryHandler : IRequestHandler<GetAllTeamQuery, List<GettAllTeamQueryResult>>
    {
        private readonly Context _context;
        public GetAllTeamQueryHandler(Context context)
        {
            _context = context;
        }

        public async Task<List<GettAllTeamQueryResult>> Handle(GetAllTeamQuery request, CancellationToken cancellationToken)
        {
            return await _context.Teams.Select(x => new GettAllTeamQueryResult
            {
                TeamId = x.TeamId,
                TeamFullname = x.TeamFullname,
                TeamDescription = x.TeamDescription,
                TeamImage = x.TeamImage,
                TeamTwitterUrl = x.TeamTwitterUrl,
                TeamInstagramUrl = x.TeamInstagramUrl,
                TeamStatus = x.TeamStatus
            }).AsNoTracking().ToListAsync();
        }
    }
}