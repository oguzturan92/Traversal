using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRApi.DAL
{
    public enum ECity
    {
        Edirne = 1,
        İstanbul = 2,
        Ankara = 3,
        Antalya = 4,
        Bursa = 5
    }

    public class Visitor
    {
        public int VisitorId { get; set; }
        public ECity City { get; set; }
        public int CityVisitCount { get; set; } // Ziyaret sayısı
        public DateTime VisitDate { get; set; } // Gün bilgisi
    }
}