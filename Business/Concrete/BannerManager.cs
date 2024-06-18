using Business.Abstract;
using Data.Abstract;
using Entity.Concrete;

namespace Business.Concrete
{
    public class BannerManager : IBannerService
    {
        private IBannerDal _bannerDal;
        public BannerManager(IBannerDal bannerDal)
        {
            _bannerDal = bannerDal;
        }

        public void Create(Banner entity)
        {
            _bannerDal.Create(entity);
        }

        public void Delete(Banner entity)
        {
            _bannerDal.Delete(entity);
        }

        public List<Banner> GetAll()
        {
            return _bannerDal.GetAll();
        }

        public Banner GetById(int id)
        {
            return _bannerDal.GetById(id);
        }

        public void Update(Banner entity)
        {
            _bannerDal.Update(entity);
        }
    }
}