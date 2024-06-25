using Business.Abstract;
using Business.Validation;
using Entity.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class NewsletterController : Controller
    {
        private readonly INewsletterService _newsletterService;
        public NewsletterController(INewsletterService newsletterService)
        {
            _newsletterService = newsletterService;
        }

        public IActionResult NewsletterList()
        {
            ViewBag.newsletterActive = "active";
            var values = _newsletterService.GetAll();
            return View(values);
        }

        public IActionResult NewsletterDelete(int id)
        {
            var value = _newsletterService.GetById(id);
            _newsletterService.Delete(value);
            TempData["icon"] = "success";
            TempData["text"] = "İşlem başarılı.";
            return RedirectToAction("NewsletterList", "Newsletter");
        }
    }
}