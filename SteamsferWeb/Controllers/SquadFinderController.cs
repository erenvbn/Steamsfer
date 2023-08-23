using Microsoft.AspNetCore.Mvc;

namespace SteamsferWeb.Controllers
{
    public class SquadFinderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
