using Business.Abstract;
using Data.Abstract;
using Entity.Concrete;

namespace Business.Concrete
{
    public class AboutManager : IAboutService
    {
        private IAboutDal _aboutDal;
        public AboutManager(IAboutDal aboutDal)
        {
            _aboutDal = aboutDal;
        }

        public void Create(About entity)
        {
            _aboutDal.Create(entity);
        }

        public void Delete(About entity)
        {
            _aboutDal.Delete(entity);
        }

        public List<About> GetAll()
        {
            return _aboutDal.GetAll();
        }

        public About GetById(int id)
        {
            return _aboutDal.GetById(id);
        }

        public void Update(About entity)
        {
            _aboutDal.Update(entity);
        }
    }
}