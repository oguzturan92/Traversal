using Business.Abstract;
using Entity.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    public class DestinationController : Controller
    {
        private readonly IDestinationService _destinationService;
        public DestinationController(IDestinationService destinationService)
        {
            _destinationService = destinationService;
        }
        
        [HttpGet]
        public IActionResult Index(string search)
        {
            ViewBag.destinationActive = "active";
            var values = _destinationService.GetAll();
            if (!string.IsNullOrEmpty(search))
            {
                values = _destinationService.GetAll().Where(i => i.DestinationCity.ToLower().Contains(search.ToLower())).ToList();
            }
            return View(values);
        }

        [HttpGet]
        public IActionResult DestinationDetail(int id)
        {
            var value = _destinationService.GetDestinationAndComments(id);
            return View(value);
        }

        [HttpPost]
        public IActionResult DestinationDetail(Destination destination)
        {
            return View();
        }
    }
}