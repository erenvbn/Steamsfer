using Microsoft.AspNetCore.Mvc;

namespace SteamsferWeb.Controllers
{
    public class Login : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
