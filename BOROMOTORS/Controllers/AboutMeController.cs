using Microsoft.AspNetCore.Mvc;
using BOROMOTORS.Models;

namespace BOROMOTORS.Controllers
{
    public class AboutMeController : Controller
    {
        public IActionResult Index()
        {
            var aboutMeData = new AboutMeModel
            {
                Name = "Boris Hristov Marinov",
                Bio = "I am a passionate dirt bike enthusiast and web developer. I created DirtXtreme to combine my love for programming and dirt bikes.",
                ImageUrl = "https://s1.ezgif.com/tmp/ezgif-1-eb4f2efd76.webp"
            };

            return View(aboutMeData); // Подаваме модела към изгледа
        }
    }
}
