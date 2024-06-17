using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Concrete;
using Data.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Areas.Member.ViewComponents.Profile
{
    public class ProfileTeamViewComponent : ViewComponent
    {
        TeamManager _teamManager = new TeamManager(new TeamDal());
        public IViewComponentResult Invoke()
        {
            var values = _teamManager.GetAll();
            return View(values);
        }
    }
}