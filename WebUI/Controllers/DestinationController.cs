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
        
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult DestinationDetail(int id)
        {
            var value = _destinationService.GetDestination(id);
            return View(value);
        }

        [HttpPost]
        public IActionResult DestinationDetail(Destination destination)
        {
            return View();
        }
    }
}