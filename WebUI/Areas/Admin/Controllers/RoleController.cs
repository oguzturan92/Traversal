using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entity.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebUI.Areas.Admin.Models;

namespace WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class RoleController : Controller
    {
        private readonly RoleManager<AppRole> _roleManager;
        private readonly UserManager<AppUser> _userManager;
        public RoleController(RoleManager<AppRole> roleManager, UserManager<AppUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public IActionResult RoleList()
        {
            var values = _roleManager.Roles.ToList();
            return View(values);
        }

        [HttpGet]
        public IActionResult RoleCreate()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RoleCreate(RoleModel model)
        {
            if (ModelState.IsValid)
            {
                var appRole = new AppRole()
                {
                    Name = model.Name
                };
                var result = await _roleManager.CreateAsync(appRole);
                if (result.Succeeded)
                {
                    TempData["icon"] = "success";
                    TempData["text"] = "İşlem başarılı.";
                    return RedirectToAction("RoleList", "Role");
                } else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> RoleUpdate(int id)
        {
            var value = await _roleManager.FindByIdAsync(id.ToString());
            var model = new RoleModel()
            {
                Id = value.Id,
                Name = value.Name
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> RoleUpdate(RoleModel model)
        {
            if (ModelState.IsValid)
            {
                var appRole = await _roleManager.FindByIdAsync(model.Id.ToString());
                appRole.Name = model.Name;
                var result = await _roleManager.UpdateAsync(appRole);
                if (result.Succeeded)
                {
                    TempData["icon"] = "success";
                    TempData["text"] = "İşlem başarılı.";
                    return RedirectToAction("RoleList", "Role");
                } else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }
            return View(model);
        }

        public async Task<IActionResult> RoleDelete(int id)
        {
            var appRole = await _roleManager.FindByIdAsync(id.ToString());
            await _roleManager.DeleteAsync(appRole);
            TempData["icon"] = "success";
            TempData["text"] = "İşlem başarılı.";
            return RedirectToAction("RoleList", "Role");
        }
    }
}