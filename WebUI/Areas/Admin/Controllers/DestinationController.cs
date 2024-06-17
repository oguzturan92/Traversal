using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Concrete;
using Data.EntityFramework;
using Entity.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class DestinationController : Controller
    {
        DestinationManager _destinationManager = new DestinationManager(new DestinationDal());

        public IActionResult DestinationList()
        {
            ViewBag.destinationActive = "active";
            var values = _destinationManager.GetAll();
            return View(values);
        }

        [HttpGet]
        public IActionResult DestinationCreate()
        {
            ViewBag.destinationActive = "active";
            return View();
        }

        [HttpPost]
        public IActionResult DestinationCreate(Destination destination)
        {
            _destinationManager.Create(destination);
            TempData["icon"] = "success";
            TempData["text"] = "İşlem başarılı.";
            return RedirectToAction("DestinationList", "Destination");
        }

        [HttpGet]
        public IActionResult DestinationUpdate(int id)
        {
            ViewBag.destinationActive = "active";
            var value = _destinationManager.GetById(id);
            return View(value);
        }

        [HttpPost]
        public IActionResult DestinationUpdate(Destination destination)
        {
            _destinationManager.Update(destination);
            TempData["icon"] = "success";
            TempData["text"] = "İşlem başarılı.";
            return RedirectToAction("DestinationList", "Destination");
        }

        public IActionResult DestinationDelete(int id)
        {
            var value = _destinationManager.GetById(id);
            _destinationManager.Delete(value);
            TempData["icon"] = "success";
            TempData["text"] = "İşlem başarılı.";
            return RedirectToAction("DestinationList", "Destination");
        }

    }
}