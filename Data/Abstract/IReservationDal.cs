using Entity.Concrete;

namespace Data.Abstract
{
    public interface IReservationDal : IGenericDal<Reservation>
    {
        List<Reservation> ReservationsAndDestinationByUserId(int userId, string status);
        List<Reservation> ReservationsByUserId(int userId);
    }
}