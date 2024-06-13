using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Concrete;
using Data.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.ViewComponents.Home
{
    public class SliderViewComponent : ViewComponent
    {
        // SliderManager _sliderManager = new SliderManager(new SliderDal());
        public IViewComponentResult Invoke()
        {
            // var values = _sliderManager.GetAll();
            return View();
        }
    }
}