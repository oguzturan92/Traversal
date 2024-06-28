using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using SignalRApi.DAL;
using SignalRApi.Hubs;

namespace SignalRApi.Models
{
    public class VisitorServiceModel
    {
        private readonly Context _context;
        private readonly IHubContext<VisitorHubNpg> _hubContext;
        public VisitorServiceModel(Context context, IHubContext<VisitorHubNpg> hubContext)
        {
            _context = context;
            _hubContext = hubContext;
        }

        public IQueryable<Visitor> GetList()
        {
            return _context.Visitors.AsQueryable();
        }

        public async Task SaveVisitor(Visitor visitor)
        {
            await _context.Visitors.AddAsync(visitor);
            await _context.SaveChangesAsync();
            await _hubContext.Clients.All.SendAsync("GetVisitorList", GetVisitorChartList());
        }

        public List<VisitorChartModel> GetVisitorChartList()
        {
            List<VisitorChartModel> visitorChartModels = new List<VisitorChartModel>();
            using (var command = _context.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = "Select * From crosstab (	'Select VisitDate,City,CityVisitCount From Visitors Order By 1,2') As ct(VisitDate date,City1 int,City2 int,City3 int,City4 int,City5 int);";
                command.CommandType = System.Data.CommandType.Text;
                _context.Database.OpenConnection();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        VisitorChartModel visitorChart = new VisitorChartModel();
                        visitorChart.VisitDate = reader.GetDateTime(0).ToShortDateString();
                        Enumerable.Range(1, 5).ToList().ForEach(x => 
                        {
                            visitorChart.Counts.Add(reader.GetInt32(x));
                        });
                        visitorChartModels.Add(visitorChart);
                    }
                }
            }
            _context.Database.CloseConnection();
            return visitorChartModels;
        }
    }
}