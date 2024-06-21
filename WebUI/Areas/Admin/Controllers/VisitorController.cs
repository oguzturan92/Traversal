using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dto.DTOs.VisitorDTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace WebUI.Areas.Admin.Controllers
{
    // API ------------------------------------------------------------------------------------------------------------
    [Area("Admin")]
    [Authorize]
    public class VisitorController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public VisitorController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> VisitorList()
        {
            ViewBag.visitorActive = "active";

            // Client oluşturduk
            var client = _httpClientFactory.CreateClient();

            // Client'a, işlem yapmak istediğimiz api adresini gönderdik.
            var responseMessage = await client.GetAsync("https://localhost:7253/api/Visitor");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<VisitorListDTO>>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpGet]
        public IActionResult VisitorCreate()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> VisitorCreate(VisitorCreateDTO visitorCreateDTO)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(visitorCreateDTO);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var responseMessage = await client.PostAsync("https://localhost:7253/api/Visitor", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                TempData["icon"] = "success";
                TempData["text"] = "İşlem başarılı.";
                return RedirectToAction("VisitorList", "Visitor");
            }
            return View(visitorCreateDTO);
        }

        [HttpGet]
        public async Task<IActionResult> VisitorUpdate(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7253/api/Visitor/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var value = JsonConvert.DeserializeObject<VisitorUpdateDTO>(jsonData);
                return View(value);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> VisitorUpdate(VisitorUpdateDTO visitorUpdateDTO)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(visitorUpdateDTO);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var responseMessage = await client.PutAsync("https://localhost:7253/api/Visitor", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                TempData["icon"] = "success";
                TempData["text"] = "İşlem başarılı.";
                return RedirectToAction("VisitorList", "Visitor");
            }
            return View();
        }

        public async Task<IActionResult> VisitorDelete(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync("https://localhost:7253/api/Visitor/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                TempData["icon"] = "success";
                TempData["text"] = "İşlem başarılı.";
                return RedirectToAction("VisitorList", "Visitor");
            }
            return RedirectToAction("VisitorList", "Visitor");
        }
    }
}