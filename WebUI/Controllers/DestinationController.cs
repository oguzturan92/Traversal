using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Concrete;
using Data.EntityFramework;
using Entity.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    public class DestinationController : Controller
    {
        DestinationManager _destinationManager = new DestinationManager(new DestinationDal());
        
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult DestinationDetail(int id)
        {
            var value = _destinationManager.GetDestination(id);
            return View(value);
        }

        [HttpPost]
        public IActionResult DestinationDetail(Destination destination)
        {
            return View();
        }
    }
}