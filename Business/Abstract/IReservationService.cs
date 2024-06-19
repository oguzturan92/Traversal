using Entity.Concrete;

namespace Business.Abstract
{
    public interface IReservationService : IGenericService<Reservation>
    {
        List<Reservation> ReservationsAndDestinationByUserId(int userId, string status);
        List<Reservation> ReservationsByUserId(int userId);
    }
}