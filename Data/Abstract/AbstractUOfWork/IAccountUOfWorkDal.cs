using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entity.Concrete;

namespace Data.Abstract.AbstractUOfWork
{
    public interface IAccountUOfWorkDal : IGenericUOfWorkDal<AccountUOfWork>
    {
        
    }
}