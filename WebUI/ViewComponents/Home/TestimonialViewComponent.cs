using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.ViewComponents.Home
{
    public class TestimonialViewComponent : ViewComponent
    {
        private readonly ITestimonialService _testimonialService;
        public TestimonialViewComponent(ITestimonialService testimonialService)
        {
            _testimonialService = testimonialService;
        }

        public IViewComponentResult Invoke()
        {
            var values = _testimonialService.GetAll();
            return View(values);
        }
    }
}