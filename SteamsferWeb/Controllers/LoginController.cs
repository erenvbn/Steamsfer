using Microsoft.AspNetCore.Mvc;

namespace SteamsferWeb.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
