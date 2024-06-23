using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract.AbstractUOfWork;
using Data.Abstract.AbstractUOfWork;
using Data.Concrete;
using Data.UnitOfWork;
using Entity.Concrete;

namespace Business.Concrete.ConcreteUOfWork
{
    public class AccountUOfWorkManager : IAccountUOfWorkService
    {
        private readonly IAccountUOfWorkDal _accountUOfWorkDal;
        private readonly IUnitOfWorkDal _unitOfWorkDal;
        public AccountUOfWorkManager(IAccountUOfWorkDal accountUOfWorkDal, IUnitOfWorkDal unitOfWorkDal)
        {
            _accountUOfWorkDal = accountUOfWorkDal;
            _unitOfWorkDal = unitOfWorkDal;
        }

        public void Create(AccountUOfWork entity)
        {
            _accountUOfWorkDal.Create(entity);
            _unitOfWorkDal.Save();
        }

        public AccountUOfWork GetById(int id)
        {
            return _accountUOfWorkDal.GetById(id);
        }

        public void MultiUpdate(List<AccountUOfWork> entity)
        {
            _accountUOfWorkDal.MultiUpdate(entity);
            _unitOfWorkDal.Save();
        }

        public void Update(AccountUOfWork entity)
        {
            _accountUOfWorkDal.Update(entity);
            _unitOfWorkDal.Save();
        }
    }
}