using Data.Abstract;
using Data.Repository;
using Entity.Concrete;

namespace Data.EntityFramework
{
    public class AddressDal : GenericRepository<Address>, IAddressDal
    {
        
    }
}