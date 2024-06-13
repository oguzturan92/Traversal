using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Concrete;
using Data.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.ViewComponents.Home
{
    public class DestinationViewComponent : ViewComponent
    {
        DestinationManager _destinationManager = new DestinationManager(new DestinationDal());
        public IViewComponentResult Invoke()
        {
            var values = _destinationManager.GetAll();
            return View(values);
        }
    }
}