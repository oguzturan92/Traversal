using Business.Abstract;
using Data.Abstract;
using Entity.Concrete;

namespace Business.Concrete
{
    public class TestimonialManager : ITestimonialService
    {
        private ITestimonialDal _testimonialDal;
        public TestimonialManager(ITestimonialDal testimonialDal)
        {
            _testimonialDal = testimonialDal;
        }

        public void Create(Testimonial entity)
        {
            _testimonialDal.Create(entity);
        }

        public void Delete(Testimonial entity)
        {
            _testimonialDal.Delete(entity);
        }

        public List<Testimonial> GetAll()
        {
            return _testimonialDal.GetAll();
        }

        public Testimonial GetById(int id)
        {
            return _testimonialDal.GetById(id);
        }

        public void Update(Testimonial entity)
        {
            _testimonialDal.Update(entity);
        }
    }
}