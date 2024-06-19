using Business.Abstract;
using Data.Abstract;
using Entity.Concrete;

namespace Business.Concrete
{
    public class AppUserManager : IAppUserService
    {
        private IAppUserDal _appUserDal;
        public AppUserManager(IAppUserDal appUserDal)
        {
            _appUserDal = appUserDal;
        }

        public void Create(AppUser entity)
        {
            _appUserDal.Create(entity);
        }

        public void Delete(AppUser entity)
        {
            _appUserDal.Delete(entity);
        }

        public List<AppUser> GetAll()
        {
            return _appUserDal.GetAll();
        }

        public AppUser GetById(int id)
        {
            return _appUserDal.GetById(id);
        }

        public void Update(AppUser entity)
        {
            _appUserDal.Update(entity);
        }
    }
}