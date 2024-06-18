using Data.Abstract;
using Data.Repository;
using Entity.Concrete;

namespace Data.EntityFramework
{
    public class TeamDal : GenericRepository<Team>, ITeamDal
    {
        
    }
}