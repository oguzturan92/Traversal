using Microsoft.AspNetCore.Mvc;

namespace WebUI.ViewComponents.Home
{
    public class StatisticViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}