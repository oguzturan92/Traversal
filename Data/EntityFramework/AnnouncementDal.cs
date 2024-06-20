using Data.Abstract;
using Data.Repository;
using Entity.Concrete;

namespace Data.EntityFramework
{
    public class AnnouncementDal : GenericRepository<Announcement>, IAnnouncementDal
    {
        
    }
}