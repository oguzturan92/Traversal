using Business.Abstract;
using Data.Abstract;
using Entity.Concrete;

namespace Business.Concrete
{
    public class ReservationManager : IReservationService
    {
        private IReservationDal _reservationDal;
        public ReservationManager(IReservationDal reservationDal)
        {
            _reservationDal = reservationDal;
        }

        public void Create(Reservation entity)
        {
            _reservationDal.Create(entity);
        }

        public void Delete(Reservation entity)
        {
            _reservationDal.Delete(entity);
        }

        public List<Reservation> GetAll()
        {
            return _reservationDal.GetAll();
        }

        public Reservation GetById(int id)
        {
            return _reservationDal.GetById(id);
        }

        public List<Reservation> ReservationsAndDestinationByUserId(int userId, string status)
        {
            return _reservationDal.ReservationsAndDestinationByUserId(userId, status);
        }

        public List<Reservation> ReservationsByUserId(int userId)
        {
            return _reservationDal.ReservationsByUserId(userId);
        }

        public void Update(Reservation entity)
        {
            _reservationDal.Update(entity);
        }
    }
}