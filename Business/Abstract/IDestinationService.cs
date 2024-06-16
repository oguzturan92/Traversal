using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entity.Concrete;

namespace Business.Abstract
{
    public interface IDestinationService : IGenericService<Destination>
    {
        Destination GetDestination(int id);
    }
}