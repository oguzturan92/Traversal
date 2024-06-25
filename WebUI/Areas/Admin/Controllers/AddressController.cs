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
    public class AddressController : Controller
    {
        private readonly IAddressService _addressService;
        public AddressController(IAddressService addressService)
        {
            _addressService = addressService;
        }

        public IActionResult AddressList()
        {
            ViewBag.addressActive = "active";
            var values = _addressService.GetAll();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddressCreate()
        {
            ViewBag.addressActive = "active";
            return View();
        }

        [HttpPost]
        public IActionResult AddressCreate(Address address)
        {
            AddressValidator validationRules = new AddressValidator();
            ValidationResult result = validationRules.Validate(address);
            if (result.IsValid)
            {
                _addressService.Create(address);
                TempData["icon"] = "success";
                TempData["text"] = "İşlem başarılı.";
                return RedirectToAction("AddressList", "Address");
            } else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View(address);
        }

        [HttpGet]
        public IActionResult AddressUpdate(int id)
        {
            ViewBag.addressActive = "active";
            var value = _addressService.GetById(id);
            return View(value);
        }

        [HttpPost]
        public IActionResult AddressUpdate(Address address)
        {
            _addressService.Update(address);
            TempData["icon"] = "success";
            TempData["text"] = "İşlem başarılı.";
            return RedirectToAction("AddressList", "Address");
        }

        public IActionResult AddressDelete(int id)
        {
            var value = _addressService.GetById(id);
            _addressService.Delete(value);
            TempData["icon"] = "success";
            TempData["text"] = "İşlem başarılı.";
            return RedirectToAction("AddressList", "Address");
        }
    }
}