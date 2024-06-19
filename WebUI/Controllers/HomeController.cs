using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        // Output LOGLAMA --------------------------------------
        // sonuçları görmek için, debug modunda çalıştır ve console/hata ayıklama konsolu menüsünden çıktıyı görebiliriz
        // DateTime dateTime= DateTime.Now;
        // _logger.LogInformation(dateTime + " Index Sayfası Çağrıldı");
        return View();
    }
}
