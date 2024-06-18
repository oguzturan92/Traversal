using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.ViewComponents.Home
{
    public class RoomViewComponent : ViewComponent
    {
        private readonly IRoomService _roomService;
        public RoomViewComponent(IRoomService roomService)
        {
            _roomService = roomService;
        }

        public IViewComponentResult Invoke()
        {
            var values = _roomService.GetAll();
            return View(values);
        }
    }
}