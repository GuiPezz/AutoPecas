using Microsoft.AspNetCore.Mvc;

namespace AutoPecas.Controllers
{
    public class HomeController1 : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
