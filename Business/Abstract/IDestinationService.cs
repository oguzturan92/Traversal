using Entity.Concrete;

namespace Business.Abstract
{
    public interface IDestinationService : IGenericService<Destination>
    {
        Destination GetDestination(int id);
    }
}