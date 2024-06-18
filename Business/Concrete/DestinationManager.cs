using Business.Abstract;
using Data.Abstract;
using Entity.Concrete;

namespace Business.Concrete
{
    public class DestinationManager : IDestinationService
    {
        private IDestinationDal _destinationDal;
        public DestinationManager(IDestinationDal destinationDal)
        {
            _destinationDal = destinationDal;
        }

        public void Create(Destination entity)
        {
            _destinationDal.Create(entity);
        }

        public void Delete(Destination entity)
        {
            _destinationDal.Delete(entity);
        }

        public List<Destination> GetAll()
        {
            return _destinationDal.GetAll();
        }

        public Destination GetById(int id)
        {
            return _destinationDal.GetById(id);
        }

        public Destination GetDestination(int id)
        {
            return _destinationDal.GetDestination(id);
        }

        public void Update(Destination entity)
        {
            _destinationDal.Update(entity);
        }
    }
}