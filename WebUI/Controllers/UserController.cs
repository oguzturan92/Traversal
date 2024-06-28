using Entity.Concrete;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
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

        [HttpGet]
        public IActionResult UserRePassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UserRePassword(RePasswordModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
                if (user != null)
                {
                    var token = await _userManager.GeneratePasswordResetTokenAsync(user);
                    var url = Url.Action("UserSifreYenile", "User", new { userId = user.Id, token = token });

                    // 1- mimeMessage nesnesi türettik
                    MimeMessage mimeMessage = new MimeMessage();

                    // 2- Gönderici Adı ve Mail bilgisini aldık
                    MailboxAddress mailboxSenderAddress = new MailboxAddress("Traversal", "oguzhan_turan_52@hotmail.com");

                    // mimeMessage içine, kimden gideceği bilgileri eklendi
                    mimeMessage.From.Add(mailboxSenderAddress);

                    // 3- Alıcı Adı ve Mail bilgisini aldık
                    MailboxAddress mailboxReceiverAddress = new MailboxAddress(user.Name + " " + user.Surname, user.Email);

                    // mimeMessage içine, kime gideceği bilgileri eklendi
                    mimeMessage.To.Add(mailboxReceiverAddress);

                    // mail konu bilgisi eklendi
                    mimeMessage.Subject = "Şifre Sıfırlama";
                    // mail içerik eklendi
                    var bodyBuilder = new BodyBuilder();
                    bodyBuilder.TextBody = "https://localhost:7180/" + url;
                    mimeMessage.Body = bodyBuilder.ToMessageBody();


                    // smtp nesnesi oluşturuldu
                    SmtpClient smtpClient = new SmtpClient();

                    // gönderen mail bilgileri girildi. host(smtp.office365.com), port(587), enableSSL(false) bilgileri
                    smtpClient.Connect("smtp.office365.com", 587, false);

                    // mail gönderene ait mail ve mail şifre bilgilerini smtpClient'e gönderdik
                    smtpClient.Authenticate("oguzhan_turan_52@hotmail.com", "şifreniz");

                    // mimeMessage nesnesini smtpClient'e send ettik
                    smtpClient.Send(mimeMessage);

                    smtpClient.Disconnect(true);

                    TempData["icon"] = "success";
                    TempData["text"] = "Şifre sıfırlama linki email adresinize gönderilmiştir.";
                    return RedirectToAction("Index", "Home");
                }
            }
            return View(model);
        }   

        [HttpGet]
        public IActionResult UserSifreYenile(string userId, string token)
        {
            var model = new NewPasswordModel()
            {
                userId = userId,
                token = token
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> UserSifreYenile(NewPasswordModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByIdAsync(model.userId);
                if (user != null)
                {
                    var sonuc = await _userManager.ResetPasswordAsync(user, model.token, model.Password);
                    if (sonuc.Succeeded)
                    {
                        TempData["icon"] = "success";
                        TempData["text"] = "Şifreniz güncellendi.";
                        return RedirectToAction("UserLogin", "User");
                    } else
                    {
                        TempData["icon"] = "error";
                        TempData["text"] = "Bir hata oluştu. Lütfen gelen linke yeniden tıklayın ya da yeni bir link daha alın.";
                        return RedirectToAction("UserLogin", "User");
                    }
                }
            }
            return View(model);
        }

    }
}