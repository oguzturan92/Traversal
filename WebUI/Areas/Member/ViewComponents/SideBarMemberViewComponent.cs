using Microsoft.AspNetCore.Mvc;

namespace WebUI.Areas.Member.ViewComponents
{
    public class SideBarMemberViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}