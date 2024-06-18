using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.ViewComponents.Home
{
    public class SliderViewComponent : ViewComponent
    {
        private readonly ISliderService _sliderService;
        public SliderViewComponent(ISliderService sliderService)
        {
            _sliderService = sliderService;
        }

        public IViewComponentResult Invoke()
        {
            var values = _sliderService.GetAll();
            return View(values);
        }
    }
}