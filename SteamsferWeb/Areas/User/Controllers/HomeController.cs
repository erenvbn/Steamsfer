using Microsoft.AspNetCore.Mvc;
using Steamsfer.Models;
using System.Diagnostics;

namespace SteamsferWeb.Areas.Guest
{
    [Area("User")]
    public class HomeController : Controller
    {

        private readonly ILogger<HomeController> _logger;

        //Constructor
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        //Actions
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}