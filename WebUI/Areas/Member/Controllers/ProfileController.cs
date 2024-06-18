using Entity.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebUI.Areas.Member.Models;

namespace WebUI.Areas.Member.Controllers
{
    [Area("Member")]
    [Authorize]
    public class ProfileController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IPasswordValidator<AppUser> _passwordValidator;
        public ProfileController(UserManager<AppUser> userManager, IPasswordValidator<AppUser> passwordValidator)
        {
            _userManager = userManager;
            _passwordValidator = passwordValidator;
        }

        public async Task<IActionResult> ProfileIndex()
        {
            ViewBag.profileActive = "active";
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            return View(user);
        }

        [HttpGet]
        public async Task<IActionResult> ProfileUpdate()
        {
            ViewBag.myAccountActive = "active";
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            if (user == null)
            {
                TempData["icon"] = "warning";
                TempData["text"] = "Lütfen giriş yapınız.";
                return Redirect("/User/UserLogin");
            }
            var model = new ProfileUpdateModel()
            {
                Name = user.Name,
                Surname = user.Surname,
                UserName = user.UserName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                City = user.City
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> ProfileUpdate(ProfileUpdateModel model)
        {   
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            if (ModelState.IsValid)
            {
                user.Name = model.Name;
                user.Surname = model.Surname;
                user.PhoneNumber = model.PhoneNumber;
                user.City = model.City;
                if (!string.IsNullOrEmpty(model.OldPassword))
                {
                    if (await _userManager.CheckPasswordAsync(user, model.OldPassword))
                    {
                        user.UserName = model.UserName;
                        user.Email = model.Email;
                        if (!string.IsNullOrEmpty(model.Password)) 
                        {
                            IdentityResult validPass = await _passwordValidator.ValidateAsync(_userManager, user, model.Password);
                            if (validPass.Succeeded)
                            {
                                user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, model.Password);
                            } else
                            {
                                TempData["icon"] = "error";
                                TempData["text"] = "Bir sorun oluştu. Lütfen tekrar deneyin.";
                                return RedirectToAction("ProfileUpdate", "Profile");
                            }
                        }
                    } else
                    {
                        ModelState.AddModelError("OldPassword", "Mevcut şifre doğrulanamadı.");
                        return View(model);
                    }
                }
                await _userManager.UpdateAsync(user);
                TempData["icon"] = "success";
                TempData["text"] = "Değişiklikler kaydedildi.";
                return RedirectToAction("ProfileUpdate", "Profile");
            }
            return View(model);
        }

    }
}