using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Concrete;
using Microsoft.EntityFrameworkCore;
using WebUI.CQRS.Results.DestinationResult;

namespace WebUI.CQRS.Handlers.DestinationHandler
{
    public class GetAllDestinationQueryHandler
    {
        private readonly Context _context;
        public GetAllDestinationQueryHandler(Context context)
        {
            _context = context;
        }

        public List<GetAllDestinationQueryResult> Handle()
        {
            var values = _context.Destinations.Select(x => new GetAllDestinationQueryResult
            {
                DestinationId = x.DestinationId,
                DestinationCity = x.DestinationCity,
                DestinationDayNight = x.DestinationDayNight,
                DestinationPrice = x.DestinationPrice,
                DestinationImage = x.DestinationImage,
                DestinationDescription = x.DestinationDescription,
                DestinationStatus = x.DestinationStatus,
                DestinationCapacity = x.DestinationCapacity                
            }).AsNoTracking().ToList();
            return values;
        }
    }
}