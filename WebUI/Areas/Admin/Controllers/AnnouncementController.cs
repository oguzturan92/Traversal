using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Business.Abstract;
using Dto.DTOs.AnnouncementDTOs;
using Entity.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class AnnouncementController : Controller
    {
        private readonly IAnnouncementService _announcementService;
        private readonly IMapper _mapper;
        public AnnouncementController(IAnnouncementService announcementService, IMapper mapper)
        {
            _announcementService = announcementService;
            _mapper = mapper;
        }

        public IActionResult AnnouncementList()
        {
            ViewBag.announcementActive = "active";
            var values = _announcementService.GetAll();
            var mapValues = _mapper.Map<List<AnnouncementListDTO>>(values);
            return View(mapValues);
        }

        [HttpGet]
        public IActionResult AnnouncementCreate()
        {
            ViewBag.announcementActive = "active";
            return View();
        }

        [HttpPost]
        public IActionResult AnnouncementCreate(AnnouncementCreateDTO announcementCreateDTO)
        {
            if (ModelState.IsValid)
            {
                var newEntity = new Announcement()
                {
                    AnnouncementTitle = announcementCreateDTO.AnnouncementTitle,
                    AnnouncementContent = announcementCreateDTO.AnnouncementContent,
                    AnnouncementDate = DateTime.Now
                };
                _announcementService.Create(newEntity);
                TempData["icon"] = "success";
                TempData["text"] = "İşlem başarılı.";
                return RedirectToAction("AnnouncementList", "Announcement");
            }
            return View(announcementCreateDTO);
        }

        [HttpGet]
        public IActionResult AnnouncementUpdate(int id)
        {
            ViewBag.announcementActive = "active";
            var value = _announcementService.GetById(id);
            var mapValue = _mapper.Map<AnnouncementUpdateDTO>(value);
            return View(mapValue);
        }

        [HttpPost]
        public IActionResult AnnouncementUpdate(AnnouncementUpdateDTO announcementUpdateDTO)
        {
            if (ModelState.IsValid)
            {
                var entity = new Announcement()
                {
                    AnnouncementId = announcementUpdateDTO.AnnouncementId,
                    AnnouncementTitle = announcementUpdateDTO.AnnouncementTitle,
                    AnnouncementContent = announcementUpdateDTO.AnnouncementContent,
                    AnnouncementDate = announcementUpdateDTO.AnnouncementDate
                };
                _announcementService.Update(entity);
                TempData["icon"] = "success";
                TempData["text"] = "İşlem başarılı.";
                return RedirectToAction("AnnouncementList", "Announcement");
            }
            return View(announcementUpdateDTO);
        }

        public IActionResult AnnouncementDelete(int id)
        {
            var value = _announcementService.GetById(id);
            _announcementService.Delete(value);
            TempData["icon"] = "success";
            TempData["text"] = "İşlem başarılı.";
            return RedirectToAction("AnnouncementList", "Announcement");
        }
    }
}