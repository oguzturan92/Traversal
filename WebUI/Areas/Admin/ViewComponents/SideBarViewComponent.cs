using Microsoft.AspNetCore.Mvc;

namespace WebUI.Areas.Admin.ViewComponents
{
    public class SideBarViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}