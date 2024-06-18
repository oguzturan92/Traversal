using Microsoft.AspNetCore.Mvc;

namespace WebUI.ViewComponents.About
{
    public class AboutViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}