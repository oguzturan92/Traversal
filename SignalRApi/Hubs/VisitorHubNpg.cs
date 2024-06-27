using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using SignalRApi.Models;

namespace SignalRApi.Hubs
{
    public class VisitorHubNpg : Hub
    {
        private readonly VisitorServiceModel _visitorServiceModel;
        public VisitorHubNpg(VisitorServiceModel visitorServiceModel)
        {
            _visitorServiceModel = visitorServiceModel;
        }

        public async Task GetVisitorList()
        {
            await Clients.All.SendAsync("CallVisitList", _visitorServiceModel.GetVisitorChartList());
        }
    }
}