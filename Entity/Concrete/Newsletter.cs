using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public class Newsletter
    {
        public int NewsletterId { get; set; }
        public string NewsletterMail { get; set; }
        public DateTime NewsletterDate { get; set; }
    }
}