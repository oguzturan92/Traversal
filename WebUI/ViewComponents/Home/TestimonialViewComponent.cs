using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Concrete;
using Data.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.ViewComponents.Home
{
    public class TestimonialViewComponent : ViewComponent
    {
        TestimonialManager _testimonialManager = new TestimonialManager(new TestimonialDal());
        public IViewComponentResult Invoke()
        {
            var values = _testimonialManager.GetAll();
            return View(values);
        }
    }
}