using Data.Abstract;
using Data.Concrete;

namespace Data.Repository
{
    public class GenericRepository<T> : IGenericDal<T> where T : class
    {
        public void Create(T entity)
        {
            using var context = new Context();
            context.Set<T>().Add(entity);
            context.SaveChanges();
        }

        public void Delete(T entity)
        {
            using var context = new Context();
            context.Set<T>().Remove(entity);
            context.SaveChanges();
        }

        public List<T> GetAll()
        {
            using var context = new Context();
            return context.Set<T>().ToList();
        }

        public T GetById(int id)
        {
            using var context = new Context();
            return context.Set<T>().Find(id);
        }

        public void Update(T entity)
        {
            using var context = new Context();
            context.Set<T>().Update(entity);
            context.SaveChanges();
        }
    }
}