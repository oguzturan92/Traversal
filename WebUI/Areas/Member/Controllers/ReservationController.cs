using Business.Abstract;
using Entity.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Areas.Member.Controllers
{
    [Area("Member")]
    [Authorize]
    public class ReservationController : Controller
    {
        private readonly IDestinationService _destinationService;
        private readonly IReservationService _reservationService;
        private readonly UserManager<AppUser> _userManager;
        public ReservationController(UserManager<AppUser> userManager, IDestinationService destinationService, IReservationService reservationService)
        {
            _userManager = userManager;
            _destinationService = destinationService;
            _reservationService = reservationService;
        }

        public async Task<IActionResult> ReservationList(string status)
        {
            ViewBag.reservationActive = "active";
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var values = _reservationService.ReservationsAndDestinationByUserId(user.Id, status);
            return View(values);
        }

        [HttpGet]
        public IActionResult ReservationCreate()
        {
            ViewBag.reservationActive = "active";
            ViewBag.destinations = _destinationService.GetAll();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ReservationCreate(Reservation reservation)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            reservation.AppUserId = user.Id;
            reservation.ReservationStatus = "BEKLİYOR";
            _reservationService.Create(reservation);
            TempData["icon"] = "success";
            TempData["text"] = "İşlem tamamlandı.";
            return RedirectToAction("ReservationList", "Reservation");
        }
        
    }
}