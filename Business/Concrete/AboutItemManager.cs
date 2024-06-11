using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Data.Abstract;
using Entity.Concrete;

namespace Business.Concrete
{
    public class AboutItemManager : IAboutItemService
    {
        private IAboutItemDal _aboutItemDal;
        public AboutItemManager(IAboutItemDal aboutItemDal)
        {
            _aboutItemDal = aboutItemDal;
        }

        public void Create(AboutItem entity)
        {
            _aboutItemDal.Create(entity);
        }

        public void Delete(AboutItem entity)
        {
            _aboutItemDal.Delete(entity);
        }

        public List<AboutItem> GetAll()
        {
            return _aboutItemDal.GetAll();
        }

        public AboutItem GetById(int id)
        {
            return _aboutItemDal.GetById(id);
        }

        public void Update(AboutItem entity)
        {
            _aboutItemDal.Update(entity);
        }
    }
}