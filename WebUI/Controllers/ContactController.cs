using Business.Abstract;
using Dto.DTOs.MessageDTOs;
using Dto.DTOs.NewsletterDTOs;
using Entity.Concrete;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace WebUI.Controllers
{
    public class ContactController : Controller
    {
        private readonly IMessageService _messageService;
        private readonly INewsletterService _newsletterService;
        public ContactController(IMessageService messageService, INewsletterService newsletterService)
        {
            _messageService = messageService;
            _newsletterService = newsletterService;
        }

        public IActionResult Index()
        {
            ViewBag.contactActive = "active";
            return View();
        }

        public IActionResult NewMessage(MessageCreateDTO messageCreateDTO)
        {
            if (ModelState.IsValid)
            {
                var message = new Message()
                {
                    MessageFullname = messageCreateDTO.MessageFullname,
                    MessageMail = messageCreateDTO.MessageMail,
                    MessageSubject = messageCreateDTO.MessageSubject,
                    MessageContent = messageCreateDTO.MessageContent,
                    MessageDate = DateTime.Now
                };
                _messageService.Create(message);
                var value = JsonConvert.SerializeObject(message);
                return Json(value);
            }
            return Json("error");
        }

        public IActionResult NewNewsletter(NewsletterCreateDTO newsletterCreateDTO)
        {
            if (ModelState.IsValid)
            {
                var newsletter = new Newsletter()
                {
                    NewsletterMail = newsletterCreateDTO.NewsletterMail,
                    NewsletterDate = DateTime.Now
                };
                _newsletterService.Create(newsletter);
                var value = JsonConvert.SerializeObject(newsletter);
                return Json(value);
            }
            return Json("error");
        }
    }
}