using Data.Abstract.AbstractUOfWork;
using Data.Concrete;

namespace Data.Repository
{
    public class GenericUOfWorkRepository<T> : IGenericUOfWorkDal<T> where T : class
    {
        private readonly Context _context;
        public GenericUOfWorkRepository(Context context)
        {
            _context = context;
        }

        public void Create(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public void MultiUpdate(List<T> entity)
        {
            _context.Set<T>().UpdateRange(entity);
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }
    }
}