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
        public UserController(IAppUserService appUserService, UserManager<AppUser> userManager)
        {
            _appUserService = appUserService;
            _userManager = userManager;
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
        public IActionResult UserUpdate(int id)
        {
            ViewBag.userActive = "active";
            var value = _appUserService.GetById(id);
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> UserUpdate(UserUpdateModel model)
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