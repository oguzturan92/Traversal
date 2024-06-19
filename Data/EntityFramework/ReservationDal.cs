using Data.Abstract;
using Data.Concrete;
using Data.Repository;
using Entity.Concrete;
using Microsoft.EntityFrameworkCore;

namespace Data.EntityFramework
{
    public class ReservationDal : GenericRepository<Reservation>, IReservationDal
    {
        public List<Reservation> ReservationsAndDestinationByUserId(int userId, string status)
        {
            using (var context = new Context())
            {
                if (!string.IsNullOrEmpty(status))
                {
                    return context.Reservations
                                .Where(i => i.AppUserId == userId && i.ReservationStatus == status)
                                .Include(i => i.Destination)
                                .ToList();
                }
                return context.Reservations
                                .Where(i => i.AppUserId == userId)
                                .Include(i => i.Destination)
                                .ToList();                
            }
        }

        public List<Reservation> ReservationsByUserId(int userId)
        {
            using (var context = new Context())
            {
                return context.Reservations
                                .Where(i => i.AppUserId == userId)
                                .Include(i => i.Destination)
                                .ToList();
            }
        }
    }
}