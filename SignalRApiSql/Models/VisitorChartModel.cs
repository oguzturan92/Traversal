using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRApiSql.Models
{
    public class VisitorChartModel
    {
        public VisitorChartModel()
        {
            Counts = new List<int>();
        }
        public string VisitDate { get; set; }
        public List<int> Counts { get; set; }
    }
}