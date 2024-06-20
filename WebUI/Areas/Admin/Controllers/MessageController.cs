using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class MessageController : Controller
    {
        private readonly IMessageService _messageService;
        public MessageController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        public IActionResult MessageList()
        {
            ViewBag.messageActive = "active";
            var values = _messageService.GetAll();
            return View(values);
        }

        public IActionResult MessageDetail(int id)
        {
            ViewBag.messageActive = "active";
            var value = _messageService.GetById(id);
            return View(value);
        }

        public IActionResult MessageDelete(int id)
        {
            var value = _messageService.GetById(id);
            _messageService.Delete(value);
            TempData["icon"] = "success";
            TempData["text"] = "İşlem başarılı.";
            return RedirectToAction("MessageList", "Message");
        }
    }
}