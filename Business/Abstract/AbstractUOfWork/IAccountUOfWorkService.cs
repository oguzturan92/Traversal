using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entity.Concrete;

namespace Business.Abstract.AbstractUOfWork
{
    public interface IAccountUOfWorkService : IGenericUOfWorkService<AccountUOfWork>
    {
        
    }
}