using Business.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Areas.Member.ViewComponents.Profile
{
    public class ProfileTeamViewComponent : ViewComponent
    {
        private readonly ITeamService _teamService;
        public ProfileTeamViewComponent(ITeamService teamService)
        {
            _teamService = teamService;
        }

        public IViewComponentResult Invoke()
        {
            var values = _teamService.GetAll();
            return View(values);
        }
    }
}