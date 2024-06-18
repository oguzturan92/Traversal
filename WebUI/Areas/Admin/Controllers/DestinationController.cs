using Business.Abstract;
using Entity.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class DestinationController : Controller
    {
        private readonly IDestinationService _destinationService;
        public DestinationController(IDestinationService destinationService)
        {
            _destinationService = destinationService;
        }

        public IActionResult DestinationList()
        {
            ViewBag.destinationActive = "active";
            var values = _destinationService.GetAll();
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
            _destinationService.Create(destination);
            TempData["icon"] = "success";
            TempData["text"] = "İşlem başarılı.";
            return RedirectToAction("DestinationList", "Destination");
        }

        [HttpGet]
        public IActionResult DestinationUpdate(int id)
        {
            ViewBag.destinationActive = "active";
            var value = _destinationService.GetById(id);
            return View(value);
        }

        [HttpPost]
        public IActionResult DestinationUpdate(Destination destination)
        {
            _destinationService.Update(destination);
            TempData["icon"] = "success";
            TempData["text"] = "İşlem başarılı.";
            return RedirectToAction("DestinationList", "Destination");
        }

        public IActionResult DestinationDelete(int id)
        {
            var value = _destinationService.GetById(id);
            _destinationService.Delete(value);
            TempData["icon"] = "success";
            TempData["text"] = "İşlem başarılı.";
            return RedirectToAction("DestinationList", "Destination");
        }

    }
}