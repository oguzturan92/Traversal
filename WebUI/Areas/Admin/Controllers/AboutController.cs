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
    public class AboutController : Controller
    {
        private readonly IAboutService _aboutService;
        public AboutController(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }

        public IActionResult AboutList()
        {
            ViewBag.aboutActive = "active";
            var values = _aboutService.GetAll();
            return View(values);
        }

        [HttpGet]
        public IActionResult AboutCreate()
        {
            ViewBag.aboutActive = "active";
            return View();
        }

        [HttpPost]
        public IActionResult AboutCreate(About about)
        {
            AboutValidator validationRules = new AboutValidator();
            ValidationResult result = validationRules.Validate(about);
            if (result.IsValid)
            {
                _aboutService.Create(about);
                TempData["icon"] = "success";
                TempData["text"] = "İşlem başarılı.";
                return RedirectToAction("AboutList", "About");
            } else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View(about);
        }

        [HttpGet]
        public IActionResult AboutUpdate(int id)
        {
            ViewBag.aboutActive = "active";
            var value = _aboutService.GetById(id);
            return View(value);
        }

        [HttpPost]
        public IActionResult AboutUpdate(About about)
        {
            _aboutService.Update(about);
            TempData["icon"] = "success";
            TempData["text"] = "İşlem başarılı.";
            return RedirectToAction("AboutList", "About");
        }

        public IActionResult AboutDelete(int id)
        {
            var value = _aboutService.GetById(id);
            _aboutService.Delete(value);
            TempData["icon"] = "success";
            TempData["text"] = "İşlem başarılı.";
            return RedirectToAction("AboutList", "About");
        }
    }
}