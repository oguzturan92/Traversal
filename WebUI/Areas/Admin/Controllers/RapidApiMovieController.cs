using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dto.DTOs.RapidApiMovieDTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class RapidApiMovieController : Controller
    {
        public async Task<IActionResult> Index()
        {
            ViewBag.rapidApiActive = "active";

            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://imdb-top-100-movies.p.rapidapi.com/"),
                Headers =
                {
                    { "x-rapidapi-key", "284c37bb44msh75f9c69b5e31064p1cbed5jsnb965f4713f5e" },
                    { "x-rapidapi-host", "imdb-top-100-movies.p.rapidapi.com" },
                },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var model = JsonConvert.DeserializeObject<List<RapidApiMovieListDTO>>(body);
                Console.WriteLine(body);
                return View(model);
            }
        }
    }
}