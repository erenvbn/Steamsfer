using Microsoft.AspNetCore.Mvc;
using Steamsfer.DataAccess.Repository;
using Steamsfer.Models;

namespace SteamsferWeb.Controllers
{
    public class MatchSteam : Controller
    {
        private readonly CommonMethods _commonMethods;
        public MatchSteam(CommonMethods commonMethods)
        {
            _commonMethods = commonMethods;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string steamid)
        {
            _commonMethods.GetSteamInfoOnly(steamid);

            return View();
        }

    }
}
