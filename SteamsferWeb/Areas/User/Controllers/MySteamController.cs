using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using Newtonsoft.Json;
using RestSharp;
using Steamsfer.DataAccess.Repository;
using Steamsfer.Models;
using static System.Net.WebRequestMethods;

namespace SteamsferWeb.Areas.User.Controllers
{
    [Area("User")]
    public class MySteamController : Controller
    {
        public readonly CommonMethods _commonMethods;
        public MySteamController(CommonMethods commonMethods)
        {
            _commonMethods = commonMethods;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult IndexSteamCredentials(string steamid)
        {
            var steamCredentials = _commonMethods.GetSteamInfoOnly(steamid);
            var steamCredentialsWithGames = _commonMethods.GetSteamInfoWithGames(steamCredentials.SteamId);

            var steamCredentialsViewModel = new SteamCredentialsViewModel
            {
                SteamName = steamCredentialsWithGames.SteamName,
                SteamId = steamCredentialsWithGames.SteamId,
                Description = steamCredentialsWithGames.Description,
                ProfileUrl = steamCredentialsWithGames.ProfileUrl,
                Avatar = steamCredentialsWithGames.Avatar,
                Games = steamCredentialsWithGames.Games,
                CommunityVisibility = steamCredentialsWithGames.CommunityVisibility
            };
            return View(steamCredentialsViewModel);
        }
    }
}
