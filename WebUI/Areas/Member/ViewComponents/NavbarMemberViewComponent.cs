using Microsoft.AspNetCore.Mvc;

namespace WebUI.Areas.Member.ViewComponents
{
    public class NavbarMemberViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}