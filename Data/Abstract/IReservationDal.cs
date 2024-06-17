using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entity.Concrete;

namespace Data.Abstract
{
    public interface IReservationDal : IGenericDal<Reservation>
    {
        List<Reservation> ReservationsAndDestinationByUserId(int userId, string status);
    }
}