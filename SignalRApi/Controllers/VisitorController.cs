using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SignalRApi.DAL;
using SignalRApi.Models;

namespace SignalRApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VisitorController : ControllerBase
    {
        private readonly VisitorServiceModel _visitorServiceModel;
        private readonly Context _context;
        public VisitorController(VisitorServiceModel visitorServiceModel, Context context)
        {
            _visitorServiceModel = visitorServiceModel;
            _context = context;
        }

        [HttpGet]
        public IActionResult VisitorCreate()
        {
            Random random = new Random();
            Enumerable.Range(1, 10).ToList().ForEach(x => 
            {
                foreach (ECity item in Enum.GetValues(typeof(ECity)))
                {
                    var newVisitor = new Visitor
                    {
                        City = item,
                        CityVisitCount = random.Next(100,2000),
                        VisitDate = DateTime.Now.Date.AddDays(x)
                    };
                    _visitorServiceModel.SaveVisitor(newVisitor).Wait();
                    System.Threading.Thread.Sleep(1000);
                }
            });
            return Ok("Ziyaretçiler Başarıyla Eklendi.");
        }
    }
}