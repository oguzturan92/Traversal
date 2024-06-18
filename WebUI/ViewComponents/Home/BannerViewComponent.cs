using Microsoft.AspNetCore.Mvc;

namespace WebUI.ViewComponents.Home
{
    public class BannerViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}