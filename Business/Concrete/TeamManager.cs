using Business.Abstract;
using Data.Abstract;
using Entity.Concrete;

namespace Business.Concrete
{
    public class TeamManager : ITeamService
    {
        private ITeamDal _teamDal;
        public TeamManager(ITeamDal teamDal)
        {
            _teamDal = teamDal;
        }

        public void Create(Team entity)
        {
            _teamDal.Create(entity);
        }

        public void Delete(Team entity)
        {
            _teamDal.Delete(entity);
        }

        public List<Team> GetAll()
        {
            return _teamDal.GetAll();
        }

        public Team GetById(int id)
        {
            return _teamDal.GetById(id);
        }

        public void Update(Team entity)
        {
            _teamDal.Update(entity);
        }
    }
}