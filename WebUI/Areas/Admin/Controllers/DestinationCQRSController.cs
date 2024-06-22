using Business.Abstract;
using Entity.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebUI.CQRS.Commands.DestinationCommands;
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
        private readonly CreateDestinationCommandHandler _createDestinationCommandHandler;
        private readonly UpdateDestinationCommandHandler _updateDestinationCommandHandler;
        private readonly RemoveDestinationCommandHandler _removeDestinationCommandHandler;
        public DestinationCQRSController(GetAllDestinationQueryHandler getAllDestinationQueryHandler, GetDestinationGetByIdQueryHandler getDestinationGetByIdQueryHandler, CreateDestinationCommandHandler createDestinationCommandHandler, RemoveDestinationCommandHandler removeDestinationCommandHandler, UpdateDestinationCommandHandler updateDestinationCommandHandler)
        {
            _getAllDestinationQueryHandler = getAllDestinationQueryHandler;
            _getDestinationGetByIdQueryHandler = getDestinationGetByIdQueryHandler;
            _createDestinationCommandHandler = createDestinationCommandHandler;
            _removeDestinationCommandHandler = removeDestinationCommandHandler;
            _updateDestinationCommandHandler = updateDestinationCommandHandler;
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

        [HttpPost]
        public IActionResult DestinationCQRSCreate(CreateDestinationCommand command)
        {
            _createDestinationCommandHandler.Handle(command);
            TempData["icon"] = "success";
            TempData["text"] = "İşlem başarılı.";
            return RedirectToAction("DestinationCQRSList", "DestinationCQRS");
        }

        [HttpGet]
        public IActionResult DestinationCQRSUpdate(int id)
        {
            ViewBag.destinationCQRSActive = "active";
            var value = _getDestinationGetByIdQueryHandler.Handle(new GetDestinationByIdQuery(id));
            return View(value);
        }

        [HttpPost]
        public IActionResult DestinationCQRSUpdate(UpdateDestinationCommand command)
        {
            _updateDestinationCommandHandler.Handle(command);
            TempData["icon"] = "success";
            TempData["text"] = "İşlem başarılı.";
            return RedirectToAction("DestinationCQRSList", "DestinationCQRS");
        }

        public IActionResult DestinationCQRSDelete(int id)
        {
            _removeDestinationCommandHandler.Handle(new RemoveDestinationCommand(id));
            TempData["icon"] = "success";
            TempData["text"] = "İşlem başarılı.";
            return RedirectToAction("DestinationCQRSList", "DestinationCQRS");
        }

    }
}