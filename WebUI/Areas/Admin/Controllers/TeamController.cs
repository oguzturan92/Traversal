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
    public class TeamController : Controller
    {
        private readonly ITeamService _teamService;
        public TeamController(ITeamService teamService)
        {
            _teamService = teamService;
        }

        public IActionResult TeamList()
        {
            ViewBag.teamActive = "active";
            var values = _teamService.GetAll();
            return View(values);
        }

        [HttpGet]
        public IActionResult TeamCreate()
        {
            ViewBag.teamActive = "active";
            return View();
        }

        [HttpPost]
        public IActionResult TeamCreate(Team team)
        {
            TeamValidator validationRules = new TeamValidator();
            ValidationResult result = validationRules.Validate(team);
            if (result.IsValid)
            {
                _teamService.Create(team);
                TempData["icon"] = "success";
                TempData["text"] = "İşlem başarılı.";
                return RedirectToAction("TeamList", "Team");
            } else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View(team);
        }

        [HttpGet]
        public IActionResult TeamUpdate(int id)
        {
            ViewBag.teamActive = "active";
            var value = _teamService.GetById(id);
            return View(value);
        }

        [HttpPost]
        public IActionResult TeamUpdate(Team team)
        {
            _teamService.Update(team);
            TempData["icon"] = "success";
            TempData["text"] = "İşlem başarılı.";
            return RedirectToAction("TeamList", "Team");
        }

        public IActionResult TeamStatus(int id)
        {
            var value = _teamService.GetById(id);
            value.TeamStatus = value.TeamStatus == true ? false:true;
            _teamService.Update(value);
            TempData["icon"] = "success";
            TempData["text"] = "İşlem başarılı.";
            return RedirectToAction("TeamList", "Team");
        }

        public IActionResult TeamDelete(int id)
        {
            var value = _teamService.GetById(id);
            _teamService.Delete(value);
            TempData["icon"] = "success";
            TempData["text"] = "İşlem başarılı.";
            return RedirectToAction("TeamList", "Team");
        }
    }
}