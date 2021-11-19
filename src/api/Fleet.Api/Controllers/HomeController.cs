using Microsoft.AspNetCore.Mvc;

namespace Fleet
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
