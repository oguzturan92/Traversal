using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Areas.Admin.ViewComponents.Dashboard
{
    public class Dashboard2Viewcomponent : ViewComponent
    {
        private readonly IDestinationService _destinationService;
        private readonly IReservationService _reservationService;
        public Dashboard2Viewcomponent(IDestinationService destinationService, IReservationService reservationService)
        {
            _destinationService = destinationService;
            _reservationService = reservationService;
        }
        public IViewComponentResult Invoke()
        {
            ViewBag.destinationCount = _destinationService.GetAll().Count();
            ViewBag.reservationCount = _reservationService.GetAll().Count();
            return View();
        }
    }
}