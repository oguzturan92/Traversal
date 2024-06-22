using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace WebUI.CQRS.Commands.TeamCommands
{
    public class UpdateStatusTeamCommand : IRequest
    {
        public UpdateStatusTeamCommand(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
    }
}