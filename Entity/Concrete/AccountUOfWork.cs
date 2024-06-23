using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public class AccountUOfWork
    {
        public int AccountUOfWorkId { get; set; }
        public string AccountUOfWorkFullname { get; set; }
        public decimal AccountUOfWorkBalance { get; set; }
    }
}