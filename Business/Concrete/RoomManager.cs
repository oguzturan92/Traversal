using Business.Abstract;
using Data.Abstract;
using Entity.Concrete;

namespace Business.Concrete
{
    public class RoomManager : IRoomService
    {
        private IRoomDal _roomDal;
        public RoomManager(IRoomDal roomDal)
        {
            _roomDal = roomDal;
        }

        public void Create(Room entity)
        {
            _roomDal.Create(entity);
        }

        public void Delete(Room entity)
        {
            _roomDal.Delete(entity);
        }

        public List<Room> GetAll()
        {
            return _roomDal.GetAll();
        }

        public Room GetById(int id)
        {
            return _roomDal.GetById(id);
        }

        public void Update(Room entity)
        {
            _roomDal.Update(entity);
        }
    }
}