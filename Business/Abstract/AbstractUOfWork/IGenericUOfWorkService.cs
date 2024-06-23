using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Business.Abstract.AbstractUOfWork
{
    public interface IGenericUOfWorkService<T>
    {
        void Create(T entity);
        void Update(T entity);
        void MultiUpdate(List<T> entity);
        T GetById(int id);
    }
}