using Microsoft.AspNetCore.Mvc;

namespace SteamsferWeb.Areas.User.Controllers
{
    public class LoginController : Controller
    {
        [Area("User")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
