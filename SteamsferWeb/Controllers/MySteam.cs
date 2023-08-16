using Microsoft.AspNetCore.Mvc;

namespace SteamsferWeb.Controllers
{
    public class MySteam : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
