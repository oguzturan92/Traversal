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
    public class SliderController : Controller
    {
        private readonly ISliderService _sliderService;
        public SliderController(ISliderService sliderService)
        {
            _sliderService = sliderService;
        }

        public IActionResult SliderList()
        {
            ViewBag.sliderActive = "active";
            var values = _sliderService.GetAll();
            return View(values);
        }

        [HttpGet]
        public IActionResult SliderCreate()
        {
            ViewBag.sliderActive = "active";
            return View();
        }

        [HttpPost]
        public IActionResult SliderCreate(Slider slider)
        {
            SliderValidator validationRules = new SliderValidator();
            ValidationResult result = validationRules.Validate(slider);
            if (result.IsValid)
            {
                _sliderService.Create(slider);
                TempData["icon"] = "success";
                TempData["text"] = "İşlem başarılı.";
                return RedirectToAction("SliderList", "Slider");
            } else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View(slider);
        }

        [HttpGet]
        public IActionResult SliderUpdate(int id)
        {
            ViewBag.sliderActive = "active";
            var value = _sliderService.GetById(id);
            return View(value);
        }

        [HttpPost]
        public IActionResult SliderUpdate(Slider slider)
        {
            _sliderService.Update(slider);
            TempData["icon"] = "success";
            TempData["text"] = "İşlem başarılı.";
            return RedirectToAction("SliderList", "Slider");
        }

        public IActionResult SliderDelete(int id)
        {
            var value = _sliderService.GetById(id);
            _sliderService.Delete(value);
            TempData["icon"] = "success";
            TempData["text"] = "İşlem başarılı.";
            return RedirectToAction("SliderList", "Slider");
        }
    }
}