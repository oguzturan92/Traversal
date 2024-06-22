using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace WebUI.CQRS.Commands.TeamCommands
{
    public class UpdateTeamCommand : IRequest
    {
        public int TeamId { get; set; }
        public string TeamFullname { get; set; }
        public string TeamDescription { get; set; }
        public string TeamImage { get; set; }
        public string TeamTwitterUrl { get; set; }
        public string TeamInstagramUrl { get; set; }
    }
}