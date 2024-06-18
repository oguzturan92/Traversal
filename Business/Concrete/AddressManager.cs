using Business.Abstract;
using Data.Abstract;
using Entity.Concrete;

namespace Business.Concrete
{
    public class AddressManager : IAddressService
    {
        private IAddressDal _addressDal;
        public AddressManager(IAddressDal addressDal)
        {
            _addressDal = addressDal;
        }

        public void Create(Address entity)
        {
            _addressDal.Create(entity);
        }

        public void Delete(Address entity)
        {
            _addressDal.Delete(entity);
        }

        public List<Address> GetAll()
        {
            return _addressDal.GetAll();
        }

        public Address GetById(int id)
        {
            return _addressDal.GetById(id);
        }

        public void Update(Address entity)
        {
            _addressDal.Update(entity);
        }
    }
}