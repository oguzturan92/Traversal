using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.UnitOfWork
{
    public interface IUnitOfWorkDal
    {
        void Save();
    }
}