using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.ViewComponents.Home
{
    public class BannerViewComponent : ViewComponent
    {
        private readonly IBannerService _bannerService;
        public BannerViewComponent(IBannerService bannerService)
        {
            _bannerService = bannerService;
        }

        public IViewComponentResult Invoke()
        {
            var value = _bannerService.GetAll().FirstOrDefault();
            return View(value);
        }
    }
}