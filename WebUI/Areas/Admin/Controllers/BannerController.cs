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
    public class BannerController : Controller
    {
        private readonly IBannerService _bannerService;
        public BannerController(IBannerService bannerService)
        {
            _bannerService = bannerService;
        }

        public IActionResult BannerList()
        {
            ViewBag.bannerActive = "active";
            var values = _bannerService.GetAll();
            return View(values);
        }

        [HttpGet]
        public IActionResult BannerCreate()
        {
            ViewBag.bannerActive = "active";
            return View();
        }

        [HttpPost]
        public IActionResult BannerCreate(Banner banner)
        {
            BannerValidator validationRules = new BannerValidator();
            ValidationResult result = validationRules.Validate(banner);
            if (result.IsValid)
            {
                _bannerService.Create(banner);
                TempData["icon"] = "success";
                TempData["text"] = "İşlem başarılı.";
                return RedirectToAction("BannerList", "Banner");
            } else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View(banner);
        }

        [HttpGet]
        public IActionResult BannerUpdate(int id)
        {
            ViewBag.bannerActive = "active";
            var value = _bannerService.GetById(id);
            return View(value);
        }

        [HttpPost]
        public IActionResult BannerUpdate(Banner banner)
        {
            _bannerService.Update(banner);
            TempData["icon"] = "success";
            TempData["text"] = "İşlem başarılı.";
            return RedirectToAction("BannerList", "Banner");
        }

        public IActionResult BannerDelete(int id)
        {
            var value = _bannerService.GetById(id);
            _bannerService.Delete(value);
            TempData["icon"] = "success";
            TempData["text"] = "İşlem başarılı.";
            return RedirectToAction("BannerList", "Banner");
        }
    }
}