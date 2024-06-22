using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using WebUI.CQRS.Results.TeamResult;

namespace WebUI.CQRS.Queries.TeamQuery
{
    public class GetTeamByIdQuery : IRequest<GetTeamByIdQueryResult>
    {
        public GetTeamByIdQuery(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
    }
}