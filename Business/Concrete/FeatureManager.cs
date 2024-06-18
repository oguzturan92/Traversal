using Business.Abstract;
using Data.Abstract;
using Entity.Concrete;

namespace Business.Concrete
{
    public class FeatureManager : IFeatureService
    {
        private IFeatureDal _featureDal;
        public FeatureManager(IFeatureDal featureDal)
        {
            _featureDal = featureDal;
        }

        public void Create(Feature entity)
        {
            _featureDal.Create(entity);
        }

        public void Delete(Feature entity)
        {
            _featureDal.Delete(entity);
        }

        public List<Feature> GetAll()
        {
            return _featureDal.GetAll();
        }

        public Feature GetById(int id)
        {
            return _featureDal.GetById(id);
        }

        public void Update(Feature entity)
        {
            _featureDal.Update(entity);
        }
    }
}