using Microsoft.AspNetCore.Mvc;

namespace WebUI.Areas.Admin.ViewComponents.SubDashboard
{
    public class SubDashboard3ViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}