using Business.Abstract;
using Data.Abstract;
using Entity.Concrete;

namespace Business.Concrete
{
    public class NewsletterManager : INewsletterService
    {
        private INewsletterDal _newsletterDal;
        public NewsletterManager(INewsletterDal newsletterDal)
        {
            _newsletterDal = newsletterDal;
        }

        public void Create(Newsletter entity)
        {
            _newsletterDal.Create(entity);
        }

        public void Delete(Newsletter entity)
        {
            _newsletterDal.Delete(entity);
        }

        public List<Newsletter> GetAll()
        {
            return _newsletterDal.GetAll();
        }

        public Newsletter GetById(int id)
        {
            return _newsletterDal.GetById(id);
        }

        public void Update(Newsletter entity)
        {
            _newsletterDal.Update(entity);
        }
    }
}