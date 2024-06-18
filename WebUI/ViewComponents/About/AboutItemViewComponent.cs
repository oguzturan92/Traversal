using Microsoft.AspNetCore.Mvc;

namespace WebUI.ViewComponents.About
{
    public class AboutItemViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}