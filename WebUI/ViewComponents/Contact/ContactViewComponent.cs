using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.ViewComponents.Contact
{
    public class ContactViewComponent : ViewComponent
    {
        private readonly IAddressService _addressService;
        public ContactViewComponent(IAddressService addressService)
        {
            _addressService = addressService;
        }

        public IViewComponentResult Invoke()
        {
            var value = _addressService.GetAll().FirstOrDefault();
            return View(value);
        }
    }
}