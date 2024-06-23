using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Abstract.AbstractUOfWork
{
    public interface IGenericUOfWorkDal<T> where T : class
    {
        void Create(T entity);
        void Update(T entity);
        void MultiUpdate(List<T> entity);
        T GetById(int id);
    }
}