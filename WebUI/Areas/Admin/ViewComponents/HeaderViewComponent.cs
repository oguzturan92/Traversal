using Microsoft.AspNetCore.Mvc;

namespace WebUI.Areas.Admin.ViewComponents
{
    public class HeaderViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}