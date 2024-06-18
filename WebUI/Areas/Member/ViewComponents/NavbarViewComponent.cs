using Microsoft.AspNetCore.Mvc;

namespace WebUI.Areas.Member.ViewComponents
{
    public class NavbarViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}