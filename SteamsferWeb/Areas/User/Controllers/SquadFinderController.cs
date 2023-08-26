using Microsoft.AspNetCore.Mvc;

namespace SteamsferWeb.Areas.User.Controllers
{
    public class SquadFinderController : Controller
    {
        [Area("User")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
