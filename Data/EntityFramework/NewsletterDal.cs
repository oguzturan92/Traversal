using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Abstract;
using Data.Repository;
using Entity.Concrete;

namespace Data.EntityFramework
{
    public class NewsletterDal : GenericRepository<Newsletter>, INewsletterDal
    {
        
    }
}