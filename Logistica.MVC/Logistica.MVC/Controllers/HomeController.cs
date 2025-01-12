using Microsoft.AspNetCore.Mvc;

namespace Logistica.MVC.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
