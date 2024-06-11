using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public class Address
    {
        public int AddressId { get; set; }
        public string AddressMail { get; set; }
        public string AddressPhone { get; set; }
        public string AddressContent { get; set; }
        public string AddressUrl { get; set; }
    }
}