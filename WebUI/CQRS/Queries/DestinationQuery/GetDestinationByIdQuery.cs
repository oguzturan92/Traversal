using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.CQRS.Queries.DestinationQuery
{
    public class GetDestinationByIdQuery
    {
        public GetDestinationByIdQuery(int id)
        {
            this.Id = id;
        }
         public int Id { get; set; }
    }
}