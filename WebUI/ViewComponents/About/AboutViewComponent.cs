using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.ViewComponents.About
{
    public class AboutViewComponent : ViewComponent
    {
        private readonly IAboutService _aboutService;
        public AboutViewComponent(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }
        public IViewComponentResult Invoke()
        {
            var value = _aboutService.GetAll().FirstOrDefault();
            return View(value);
        }
    }
}