using Business.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class CommentController : Controller
    {
        private readonly ICommentService _commentService;
        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        public IActionResult CommentList()
        {
            ViewBag.commentActive = "active";
            var values = _commentService.GetAll();
            return View(values);
        }

        [HttpGet]
        public IActionResult CommentDetail(int id)
        {
            ViewBag.commentActive = "active";
            var value = _commentService.GetById(id);
            return View(value);
        }

        public IActionResult CommentDelete(int id)
        {
            var value = _commentService.GetById(id);
            _commentService.Delete(value);
            TempData["icon"] = "success";
            TempData["text"] = "İşlem başarılı.";
            return RedirectToAction("CommentList", "Comment");
        }

    }
}