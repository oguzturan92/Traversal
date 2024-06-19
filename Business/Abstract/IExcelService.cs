using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IExcelService
    {
        byte[] ExelList<T>(List<T> entity) where T : class;
    }
}