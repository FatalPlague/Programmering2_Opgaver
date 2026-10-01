using Microsoft.AspNetCore.Mvc;

namespace Pr02_MovieMania01.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
