using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using SignalRApiSql.Models;

namespace SignalRApiSql.Hubs
{
    public class VisitorHub : Hub
    {
        private readonly VisitorServiceModel _visitorServiceModel;
        public VisitorHub(VisitorServiceModel visitorServiceModel)
        {
            _visitorServiceModel = visitorServiceModel;
        }

        public async Task GetVisitorList()
        {
            await Clients.All.SendAsync("ReceiveVisitorList", _visitorServiceModel.GetVisitorChartList());
        }
    }
}