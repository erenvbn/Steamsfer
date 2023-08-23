using Microsoft.AspNetCore.Mvc;

namespace SteamsferWeb.Controllers
{
    public class SquadFinder : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
