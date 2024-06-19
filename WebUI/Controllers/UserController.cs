using Entity.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class UserController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        public UserController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult UserList()
        {
            return View();
        }

        [HttpGet]
        public IActionResult UserRegister()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UserRegister(UserRegisterModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new AppUser()
                {
                    Name = model.Name,
                    Surname = model.Surname,
                    Email = model.Email,
                    UserName = model.UserName
                };
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    TempData["icon"] = "success";
                    TempData["text"] = "Kullanıcı oluşturuldu.";
                    if (model.IsLoginPageDirect)
                    {
                        return RedirectToAction("UserLogin", "User");
                    } else
                    {
                        return RedirectToAction("UserList", "User", new { Area = "Admin"});
                    }
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
        public IActionResult UserLogin(string ReturnUrl = null)
        {
            var model = new UserLoginModel(){
                ReturnUrl = ReturnUrl
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> UserLogin(UserLoginModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
                if (user != null)
                {
                    var result = await _signInManager.PasswordSignInAsync(user, model.Password, false, false);
                    if (result.Succeeded)
                    {
                        TempData["icon"] = "success";
                        TempData["text"] = "Giriş yapıldı.";
                        return Redirect(model.ReturnUrl ?? "~/");
                    } else
                    {
                        ModelState.AddModelError("", "Bir sorun oluştu, lütfen tekrar deneyin.");
                        return View(model);
                    }
                }
            }
            return View(model);
        }
    
        public async Task<IActionResult> UserLogout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}