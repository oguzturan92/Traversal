using Business.Abstract;
using Entity.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebUI.Areas.Admin.Models;

namespace WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class UserController : Controller
    {
        private readonly IAppUserService _appUserService;
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;
        public UserController(IAppUserService appUserService, UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            _appUserService = appUserService;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public IActionResult UserList()
        {
            ViewBag.userActive = "active";
            var values = _appUserService.GetAll();
            return View(values);
        }

        [HttpGet]
        public IActionResult UserCreate()
        {
            ViewBag.userActive = "active";
            return View();
        }

        // Post metodu, /User/UserCreate'e yönlendirildi

        [HttpGet]
        public async Task<IActionResult> UserUpdate(int id)
        {
            ViewBag.userActive = "active";
            var user = _appUserService.GetById(id);
            var model = new UserUpdateModel()
            {
                Id = user.Id,
                Name = user.Name,
                Surname = user.Surname,
                UserName = user.UserName,
                PhoneNumber = user.PhoneNumber,
                City = user.City,
                Email = user.Email,
                SeciliRoller = await _userManager.GetRolesAsync(user),
                TumRoller = _roleManager.Roles.Select(i => i.Name)
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> UserUpdate(UserUpdateModel model, string[] seciliRoller)
        {
            var user = await _userManager.FindByIdAsync(model.Id.ToString());
            if (ModelState.IsValid)
            {
                user.Name = model.Name;
                user.Surname = model.Surname;
                user.PhoneNumber = model.PhoneNumber;
                user.City = model.City;
                user.UserName = model.UserName;
                user.Email = model.Email;
                var result = await _userManager.UpdateAsync(user);
                if (result.Succeeded)
                {
                    var userRoles = await _userManager.GetRolesAsync(user);
                    seciliRoller = seciliRoller ?? new string[]{};
                    await _userManager.AddToRolesAsync(user, seciliRoller.Except(userRoles).ToArray<string>());
                    await _userManager.RemoveFromRolesAsync(user, userRoles.Except(seciliRoller).ToArray<string>());
                    
                    TempData["icon"] = "success";
                    TempData["text"] = "İşlem başarılı.";
                    return RedirectToAction("UserUpdate", "User", new { Area = "Admin", id = model.Id });
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

        public IActionResult UserDelete(int id)
        {
            var value = _appUserService.GetById(id);
            _appUserService.Delete(value);
            TempData["icon"] = "success";
            TempData["text"] = "İşlem başarılı.";
            return RedirectToAction("UserList", "User");
        }
    }
}