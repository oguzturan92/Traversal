using Business.Abstract.AbstractUOfWork;
using Entity.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebUI.Areas.Admin.Models;

namespace WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class AccountUOfWorkController : Controller
    {
        private readonly IAccountUOfWorkService _accountUOfWorkService;
        public AccountUOfWorkController(IAccountUOfWorkService accountUOfWorkService)
        {
            _accountUOfWorkService = accountUOfWorkService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(AccountUOfWorkModel model)
        {
            ViewBag.accountUOfWorkActive = "active";

            var valueSender = _accountUOfWorkService.GetById(model.SenderId);
            var valueReceiver = _accountUOfWorkService.GetById(model.ReceiverId);

            valueSender.AccountUOfWorkBalance -= model.Amount;
            valueReceiver.AccountUOfWorkBalance += model.Amount;

            var accounts = new List<AccountUOfWork>()
            {
                valueSender,
                valueReceiver
            };

            _accountUOfWorkService.MultiUpdate(accounts);

            TempData["icon"] = "success";
            TempData["text"] = "Bakiye gönderildi.";
            return RedirectToAction("Index", "AccountUOfWork");
        }
    }
}