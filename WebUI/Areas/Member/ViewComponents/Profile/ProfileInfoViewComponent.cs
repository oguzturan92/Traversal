using Entity.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Areas.Member.ViewComponents.Profile
{
    public class ProfileInfoViewComponent : ViewComponent
    {
        private readonly UserManager<AppUser> _userManager;
        public ProfileInfoViewComponent(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            return View(user);
        }
    }
}