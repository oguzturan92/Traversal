using Business.Abstract;
using Data.Abstract;
using Entity.Concrete;

namespace Business.Concrete
{
    public class SliderManager : ISliderService
    {
        private ISliderDal _sliderDal;
        public SliderManager(ISliderDal sliderDal)
        {
            _sliderDal = sliderDal;
        }

        public void Create(Slider entity)
        {
            _sliderDal.Create(entity);
        }

        public void Delete(Slider entity)
        {
            _sliderDal.Delete(entity);
        }

        public List<Slider> GetAll()
        {
            return _sliderDal.GetAll();
        }

        public Slider GetById(int id)
        {
            return _sliderDal.GetById(id);
        }

        public void Update(Slider entity)
        {
            _sliderDal.Update(entity);
        }
    }
}