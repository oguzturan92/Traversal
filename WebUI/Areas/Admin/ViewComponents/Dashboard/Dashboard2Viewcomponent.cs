using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Concrete;
using Data.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Areas.Admin.ViewComponents.Dashboard
{
    public class Dashboard2Viewcomponent : ViewComponent
    {
        DestinationManager _destinationManager = new DestinationManager(new DestinationDal());
        ReservationManager _reservationManager = new ReservationManager(new ReservationDal());
        public IViewComponentResult Invoke()
        {
            ViewBag.destinationCount = _destinationManager.GetAll().Count();
            ViewBag.reservationCount = _reservationManager.GetAll().Count();
            return View();
        }
    }
}