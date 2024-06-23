using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Abstract.AbstractUOfWork;
using Data.Concrete;
using Data.Repository;
using Entity.Concrete;

namespace Data.EntityFramework.EntityFrameworkUOfWork
{
    public class AccountUOfWorkDal : GenericUOfWorkRepository<AccountUOfWork>, IAccountUOfWorkDal
    {
        public AccountUOfWorkDal(Context context) : base(context)
        {
        }
    }
}