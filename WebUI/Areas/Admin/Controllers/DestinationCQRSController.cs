using Business.Abstract;
using Entity.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebUI.CQRS.Handlers.DestinationHandler;
using WebUI.CQRS.Queries.DestinationQuery;

namespace WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class DestinationCQRSController : Controller
    {
        private readonly GetAllDestinationQueryHandler _getAllDestinationQueryHandler;
        private readonly GetDestinationGetByIdQueryHandler _getDestinationGetByIdQueryHandler;
        public DestinationCQRSController(GetAllDestinationQueryHandler getAllDestinationQueryHandler, GetDestinationGetByIdQueryHandler getDestinationGetByIdQueryHandler)
        {
            _getAllDestinationQueryHandler = getAllDestinationQueryHandler;
            _getDestinationGetByIdQueryHandler = getDestinationGetByIdQueryHandler;
        }

        public IActionResult DestinationCQRSList()
        {
            ViewBag.destinationCQRSActive = "active";
            var values = _getAllDestinationQueryHandler.Handle();
            return View(values);
        }

        [HttpGet]
        public IActionResult DestinationCQRSCreate()
        {
            ViewBag.destinationCQRSActive = "active";
            return View();
        }

        // [HttpPost]
        // public IActionResult DestinationCQRSCreate(DestinationCQRS destinationCQRS)
        // {
        //     _destinationCQRSService.Create(destinationCQRS);
        //     TempData["icon"] = "success";
        //     TempData["text"] = "İşlem başarılı.";
        //     return RedirectToAction("DestinationCQRSList", "DestinationCQRS");
        // }

        [HttpGet]
        public IActionResult DestinationCQRSUpdate(int id)
        {
            ViewBag.destinationCQRSActive = "active";
            var value = _getDestinationGetByIdQueryHandler.Handle(new GetDestinationByIdQuery(id));
            return View(value);
        }

        // [HttpPost]
        // public IActionResult DestinationCQRSUpdate(DestinationCQRS destinationCQRS)
        // {
        //     _destinationCQRSService.Update(destinationCQRS);
        //     TempData["icon"] = "success";
        //     TempData["text"] = "İşlem başarılı.";
        //     return RedirectToAction("DestinationCQRSList", "DestinationCQRS");
        // }

        // public IActionResult DestinationCQRSDelete(int id)
        // {
        //     var value = _destinationCQRSService.GetById(id);
        //     _destinationCQRSService.Delete(value);
        //     TempData["icon"] = "success";
        //     TempData["text"] = "İşlem başarılı.";
        //     return RedirectToAction("DestinationCQRSList", "DestinationCQRS");
        // }

    }
}