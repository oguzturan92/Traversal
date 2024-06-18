using Microsoft.AspNetCore.Mvc;

namespace WebUI.Areas.Member.ViewComponents.Profile
{
    public class ProfileSettingViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}