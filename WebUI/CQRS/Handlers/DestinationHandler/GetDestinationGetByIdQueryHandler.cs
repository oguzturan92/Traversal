using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Concrete;
using WebUI.CQRS.Queries.DestinationQuery;
using WebUI.CQRS.Results.DestinationResult;

namespace WebUI.CQRS.Handlers.DestinationHandler
{
    public class GetDestinationGetByIdQueryHandler
    {
        private readonly Context _context;
        public GetDestinationGetByIdQueryHandler(Context context)
        {
            _context = context;
        }

        public GetDestinationByIdQueryResult Handle(GetDestinationByIdQuery query)
        {
            var value = _context.Destinations.Find(query.Id);
            var value2 = new GetDestinationByIdQueryResult
            {
                DestinationId = value.DestinationId,
                DestinationCity = value.DestinationCity,
                DestinationDayNight = value.DestinationDayNight,
                DestinationPrice = value.DestinationPrice,
                DestinationImage = value.DestinationImage,
                DestinationDescription = value.DestinationDescription,
                DestinationStatus = value.DestinationStatus,
                DestinationCapacity = value.DestinationCapacity  
            };
            return value2;
        }
    }
}