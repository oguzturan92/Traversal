using Business.Abstract;
using Business.Validation;
using Entity.Concrete;
using FluentValidation.Results;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebUI.CQRS.Commands.TeamCommands;
using WebUI.CQRS.Queries.TeamQuery;

namespace WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class TeamMediatRController : Controller
    {
        private readonly IMediator _mediator;
        public TeamMediatRController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> TeamMediatRList()
        {
            ViewBag.teamMediatRActive = "active";
            var values = await _mediator.Send(new GetAllTeamQuery());
            return View(values);
        }

        [HttpGet]
        public IActionResult TeamMediatRCreate()
        {
            ViewBag.teamMediatRActive = "active";
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> TeamMediatRCreate(CreateTeamCommand command)
        {
            await _mediator.Send(command);
            TempData["icon"] = "success";
            TempData["text"] = "İşlem başarılı.";
            return RedirectToAction("TeamMediatRList", "TeamMediatR");
        }

        [HttpGet]
        public async Task<IActionResult> TeamMediatRUpdate(int id)
        {
            ViewBag.teamMediatRActive = "active";
            var value = await _mediator.Send(new GetTeamByIdQuery(id));
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> TeamMediatRUpdate(UpdateTeamCommand command)
        {
            await _mediator.Send(command);
            TempData["icon"] = "success";
            TempData["text"] = "İşlem başarılı.";
            return RedirectToAction("TeamMediatRList", "TeamMediatR");
        }

        public async Task<IActionResult> TeamMediatRStatus(int id)
        {
            await _mediator.Send(new UpdateStatusTeamCommand(id));
            TempData["icon"] = "success";
            TempData["text"] = "İşlem başarılı.";
            return RedirectToAction("TeamMediatRList", "TeamMediatR");
        }

        public async Task<IActionResult> TeamMediatRDelete(int id)
        {
            await _mediator.Send(new RemoveTeamCommand(id));
            TempData["icon"] = "success";
            TempData["text"] = "İşlem başarılı.";
            return RedirectToAction("TeamMediatRList", "TeamMediatR");
        }
    }
}