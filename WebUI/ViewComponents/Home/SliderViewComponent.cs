using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.ViewComponents.Home
{
    public class SliderViewComponent : ViewComponent
    {
        private readonly ISliderService _sliderService;
        private readonly IDestinationService _destinationService;
        public SliderViewComponent(ISliderService sliderService, IDestinationService destinationService)
        {
            _sliderService = sliderService;
            _destinationService = destinationService;
        }

        public IViewComponentResult Invoke()
        {
            var value = _sliderService.GetAll().FirstOrDefault();
            ViewBag.destinations = _destinationService.GetAll();
            return View(value);
        }
    }
}