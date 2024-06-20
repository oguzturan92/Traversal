using Business.Abstract;
using Data.Abstract;
using Entity.Concrete;

namespace Business.Concrete
{
    public class AnnouncementManager : IAnnouncementService
    {
        private IAnnouncementDal _announcementDal;
        public AnnouncementManager(IAnnouncementDal announcementDal)
        {
            _announcementDal = announcementDal;
        }

        public void Create(Announcement entity)
        {
            _announcementDal.Create(entity);
        }

        public void Delete(Announcement entity)
        {
            _announcementDal.Delete(entity);
        }

        public List<Announcement> GetAll()
        {
            return _announcementDal.GetAll();
        }

        public Announcement GetById(int id)
        {
            return _announcementDal.GetById(id);
        }

        public void Update(Announcement entity)
        {
            _announcementDal.Update(entity);
        }
    }
}