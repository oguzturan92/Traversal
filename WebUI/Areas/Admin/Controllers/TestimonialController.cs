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
    public class TestimonialController : Controller
    {
        private readonly ITestimonialService _testimonialService;
        public TestimonialController(ITestimonialService testimonialService)
        {
            _testimonialService = testimonialService;
        }

        public IActionResult TestimonialList()
        {
            ViewBag.testimonialActive = "active";
            var values = _testimonialService.GetAll();
            return View(values);
        }

        [HttpGet]
        public IActionResult TestimonialCreate()
        {
            ViewBag.testimonialActive = "active";
            return View();
        }

        [HttpPost]
        public IActionResult TestimonialCreate(Testimonial testimonial)
        {
            TestimonialValidator validationRules = new TestimonialValidator();
            ValidationResult result = validationRules.Validate(testimonial);
            if (result.IsValid)
            {
                _testimonialService.Create(testimonial);
                TempData["icon"] = "success";
                TempData["text"] = "İşlem başarılı.";
                return RedirectToAction("TestimonialList", "Testimonial");
            } else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View(testimonial);
        }

        [HttpGet]
        public IActionResult TestimonialUpdate(int id)
        {
            ViewBag.testimonialActive = "active";
            var value = _testimonialService.GetById(id);
            return View(value);
        }

        [HttpPost]
        public IActionResult TestimonialUpdate(Testimonial testimonial)
        {
            _testimonialService.Update(testimonial);
            TempData["icon"] = "success";
            TempData["text"] = "İşlem başarılı.";
            return RedirectToAction("TestimonialList", "Testimonial");
        }

        public IActionResult TestimonialDelete(int id)
        {
            var value = _testimonialService.GetById(id);
            _testimonialService.Delete(value);
            TempData["icon"] = "success";
            TempData["text"] = "İşlem başarılı.";
            return RedirectToAction("TestimonialList", "Testimonial");
        }
    }
}