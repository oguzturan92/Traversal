using Microsoft.AspNetCore.Mvc;

namespace WebUI.Areas.Admin.ViewComponents.Dashboard
{
    public class Dashboard1Viewcomponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}