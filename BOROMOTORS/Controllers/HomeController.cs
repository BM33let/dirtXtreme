using BOROMOTORS.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BOROMOTORS.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

// Controllers/HomeController.cs
public class HomeController : Controller
{
    public IActionResult Reviews()
    {
        return View();  // Това ще изведе Views/Home/Reviews.cshtml
    }
}


