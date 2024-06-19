using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Entity.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class RoomController : Controller
    {
        private readonly IRoomService _roomService;
        public RoomController(IRoomService roomService)
        {
            _roomService = roomService;
        }

        public IActionResult Index()
        {
            ViewBag.roomActive = "active";
            return View();
        }

        public IActionResult RoomList()
        {
            var values = _roomService.GetAll();
            var jsonValues = JsonConvert.SerializeObject(values);
            return Json(jsonValues);
        }

        // [HttpGet]
        // public IActionResult RoomCreate()
        // {
        //     return View();
        // }

        [HttpPost]
        public IActionResult RoomCreate(Room room)
        {
            _roomService.Create(room);
            var value = JsonConvert.SerializeObject(room);
            return Json(value);
        }

        [HttpGet]
        public IActionResult RoomUpdate(int id)
        {
            var value = _roomService.GetById(id);
            var jsonValue = JsonConvert.SerializeObject(value);
            return Json(jsonValue);
        }

        [HttpPost]
        public IActionResult RoomUpdate(Room room)
        {
            _roomService.Update(room);
            var value = JsonConvert.SerializeObject(room);
            return Json(value);
        }

        public IActionResult RoomDelete(int id)
        {
            var entity = _roomService.GetById(id);
            _roomService.Delete(entity);
            var value = JsonConvert.SerializeObject(entity);
            return Json(value);
        }
    }
}