using Entity.Concrete;

namespace Data.Abstract
{
    public interface IDestinationDal : IGenericDal<Destination>
    {
        Destination GetDestinationAndComments(int id);
        List<Destination> DestinationAndReservationAndCommentCount();
    }
}