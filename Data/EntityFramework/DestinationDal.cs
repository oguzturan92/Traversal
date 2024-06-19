using Data.Abstract;
using Data.Concrete;
using Data.Repository;
using Entity.Concrete;
using Microsoft.EntityFrameworkCore;

namespace Data.EntityFramework
{
    public class DestinationDal : GenericRepository<Destination>, IDestinationDal
    {
        public List<Destination> DestinationAndReservationAndCommentCount()
        {
            using (var context = new Context())
            {
                return context.Destinations
                                .Include(i => i.Reservations)
                                .Include(i => i.Comments)
                                .ToList();
            }
        }

        public Destination GetDestinationAndComments(int id)
        {
            using (var context = new Context())
            {
                return context.Destinations
                                .Where(i => i.DestinationId == id)
                                .Include(i => i.Comments.OrderByDescending(i => i.CommentDate))
                                .FirstOrDefault();
            }
        }
    }
}