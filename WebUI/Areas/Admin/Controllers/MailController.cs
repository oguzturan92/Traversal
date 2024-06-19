using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using WebUI.Areas.Admin.Models;

namespace WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class MailController : Controller
    {
        [HttpGet]
        public IActionResult MailCreate()
        {
            ViewBag.mailActive = "active";
            return View();
        }

        [HttpPost]
        public IActionResult MailCreate(MailRequestModel mailRequestModel)
        {
            // 1- mimeMessage nesnesi türettik
            MimeMessage mimeMessage = new MimeMessage();

            // 2- Gönderici Adı ve Mail bilgisini aldık
            MailboxAddress mailboxSenderAddress = new MailboxAddress(mailRequestModel.SenderName, mailRequestModel.SenderMail);

            // mimeMessage içine, kimden gideceği bilgileri eklendi
            mimeMessage.From.Add(mailboxSenderAddress);

            // 3- Alıcı Adı ve Mail bilgisini aldık
            MailboxAddress mailboxReceiverAddress = new MailboxAddress(mailRequestModel.ReceiverName, mailRequestModel.ReceiverMail);

            // mimeMessage içine, kime gideceği bilgileri eklendi
            mimeMessage.To.Add(mailboxReceiverAddress);

            // mail konu bilgisi eklendi
            mimeMessage.Subject = mailRequestModel.Subject;
            // mail içerik eklendi
            var bodyBuilder = new BodyBuilder();
            bodyBuilder.TextBody = mailRequestModel.Body;
            mimeMessage.Body = bodyBuilder.ToMessageBody();


            // smtp nesnesi oluşturuldu
            SmtpClient smtpClient = new SmtpClient();

            // gönderen mail bilgileri girildi. host(smtp.office365.com), port(587), enableSSL(false) bilgileri
            smtpClient.Connect(mailRequestModel.SenderMailHost, mailRequestModel.SenderMailPort, mailRequestModel.SenderMailEnableSSL);

            // mail gönderene ait mail ve mail şifre bilgilerini smtpClient'e gönderdik
            smtpClient.Authenticate(mailRequestModel.SenderMail, mailRequestModel.SenderMailPassword);

            // mimeMessage nesnesini smtpClient'e send ettik
            smtpClient.Send(mimeMessage);

            smtpClient.Disconnect(true);

            TempData["icon"] = "success";
            TempData["text"] = "Mail gönderildi.";
            return RedirectToAction("MailCreate", "Mail", new { Area = "Admin" });
        }
    }
}