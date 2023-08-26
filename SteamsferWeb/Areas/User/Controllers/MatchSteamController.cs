using Microsoft.AspNetCore.Mvc;
using Steamsfer.DataAccess.Repository;
using Steamsfer.Models;


namespace SteamsferWeb.Areas.User.Controllers
{
    [Area("User")]
    public class MatchSteamController : Controller
    {
        private readonly CommonMethods _commonMethods;
        public MatchSteamController(CommonMethods commonMethods)
        {
            _commonMethods = commonMethods;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult MatchSteamCredentials()
        {
            return View();
        }


        [HttpPost]
        public IActionResult MatchSteamCredentials(string input1, string input2)
        {
            var steamCredentials1 = _commonMethods.GetSteamInfoWithGames(input1);
            var steamCredentials2 = _commonMethods.GetSteamInfoWithGames(input2);

            var multipleSteamCredentialsViewModel = new MultipleSteamCredentialsViewModel();

            List<MultipleSteamCredentialsViewModel> gamesInBothAccounts =

                (from game1 in steamCredentials1.Games
                 join game2 in steamCredentials2.Games
                 on game1.Id equals game2.Id
                 select new MultipleSteamCredentialsViewModel
                 {
                     SteamId1 = steamCredentials1.SteamId,
                     SteamId2 = steamCredentials2.SteamId,
                     SteamName1 = steamCredentials1.SteamName,
                     SteamName2 = steamCredentials2.SteamName,
                     PlayTimeAll1 = game1.PlayTimeAll,
                     PlayTimeAll2 = game2.PlayTimeAll,
                     GameId = game1.Id,
                     GameName = game1.Name,
                     GameImage = game1.Image
                 }
                ).ToList();

            // compare the two steam credentials here
            return View(gamesInBothAccounts);
        }
    }
}
