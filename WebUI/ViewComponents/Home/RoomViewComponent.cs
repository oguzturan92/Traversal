using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Concrete;
using Data.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.ViewComponents.Home
{
    public class RoomViewComponent : ViewComponent
    {
        RoomManager _roomManager = new RoomManager(new RoomDal());
        public IViewComponentResult Invoke()
        {
            var values = _roomManager.GetAll();
            return View(values);
        }
    }
}