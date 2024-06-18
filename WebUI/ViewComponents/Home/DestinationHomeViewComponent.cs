using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.ViewComponents.Home
{
    public class DestinationHomeViewComponent : ViewComponent
    {
        private readonly IDestinationService _destinationService;
        public DestinationHomeViewComponent(IDestinationService destinationService)
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