using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Concrete;
using Data.EntityFramework;
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
        DestinationManager _destinationManager = new DestinationManager(new DestinationDal());
        ReservationManager _reservationManager = new ReservationManager(new ReservationDal());
        private readonly UserManager<AppUser> _userManager;
        public ReservationController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> ReservationList(string status)
        {
            ViewBag.reservationActive = "active";
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var values = _reservationManager.ReservationsAndDestinationByUserId(user.Id, status);
            return View(values);
        }

        [HttpGet]
        public IActionResult ReservationCreate()
        {
            ViewBag.reservationActive = "active";
            ViewBag.destinations = _destinationManager.GetAll();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ReservationCreate(Reservation reservation)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            reservation.AppUserId = user.Id;
            reservation.ReservationStatus = "BEKLİYOR";
            _reservationManager.Create(reservation);
            TempData["icon"] = "success";
            TempData["text"] = "İşlem tamamlandı.";
            return RedirectToAction("ReservationList", "Reservation");
        }
        
    }
}