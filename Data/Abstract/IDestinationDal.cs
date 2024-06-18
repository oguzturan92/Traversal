using Entity.Concrete;

namespace Data.Abstract
{
    public interface IDestinationDal : IGenericDal<Destination>
    {
        Destination GetDestination(int id);
    }
}