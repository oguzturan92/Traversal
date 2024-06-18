using Data.Abstract;
using Data.Repository;
using Entity.Concrete;

namespace Data.EntityFramework
{
    public class FeatureDal : GenericRepository<Feature>, IFeatureDal
    {
        
    }
}