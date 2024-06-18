using Microsoft.AspNetCore.Mvc;

namespace WebUI.Areas.Member.ViewComponents
{
    public class SideBarViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}