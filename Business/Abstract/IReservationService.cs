using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entity.Concrete;

namespace Business.Abstract
{
    public interface IReservationService : IGenericService<Reservation>
    {
        List<Reservation> ReservationsAndDestinationByUserId(int userId, string status);
    }
}