using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Areas.Member.Controllers
{
    [Area("Member")]
    [Authorize]
    public class InformationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}