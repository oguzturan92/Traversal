using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.dashboardActive = "active";
            return View();
        }
    }
}