using Entity.Concrete;

namespace Business.Abstract
{
    public interface IDestinationService : IGenericService<Destination>
    {
        Destination GetDestinationAndComments(int id);
        List<Destination> DestinationAndReservationAndCommentCount();
    }
}