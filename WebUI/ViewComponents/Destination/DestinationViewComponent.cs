using Business.Abstract;
using Business.Concrete;
using Data.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.ViewComponents.Destination
{
    public class DestinationViewComponent : ViewComponent
    {
        private readonly IDestinationService _destinationService;
        public DestinationViewComponent(IDestinationService destinationService)
        {
            _destinationService = destinationService;
        }
        public IViewComponentResult Invoke()
        {
            var values = _destinationService.GetAll();
            return View(values);
        }
    }
}