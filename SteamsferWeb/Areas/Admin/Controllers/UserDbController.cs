using Microsoft.AspNetCore.Mvc;

namespace SteamsferWeb.Areas.Admin.Controllers
{
    public class UserDbController : Controller
    {
        [Area("Admin")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
