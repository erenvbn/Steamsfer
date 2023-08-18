using Newtonsoft.Json;
using RestSharp;
using Steamsfer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Steamsfer.DataAccess.Repository
{
    public class CommonMethods
    {
        //METHODS
        //Requesting SteamIDInformations, (uses "steamids")
        public SteamCredentials GetSteamInfoOnly(string steamid)
        {
            var client = new RestClient("https://api.steampowered.com");
            var request = new RestRequest("ISteamUser/GetPlayerSummaries/v0002", Method.Get);
            request.AddParameter("key", "A99213BE49E808604BD57C9081D1B41D");
            request.AddParameter("steamids", steamid);
            request.AddParameter("format", "json");
            RestResponse response = client.Execute(request);

            dynamic contentParsed = JsonConvert.DeserializeObject(response.Content);
            var steamCredentials = new SteamCredentials
            {
                SteamID = contentParsed.response.players[0].steamid,
                ProfileUrl = contentParsed.response.players[0].profileurl,
                SteamName = contentParsed.response.players[0].personaname,
                Avatar = contentParsed.response.players[0].avatar,
                CommunityVisibility = contentParsed.response.players[0].communityvisibilitystate
            };
            return steamCredentials;
        }

        //Requesting SteamIDInformations with Games, (uses "steamid")
        public SteamCredentials GetSteamInfoWithGames(SteamCredentials steamCredentials)
        {
            var client = new RestClient("https://api.steampowered.com");
            if (steamCredentials.CommunityVisibility == (int)CommunityVisibility.Public)
            {
                //Requesting Games, uses steamid
                var requestGame = new RestRequest("IPlayerService/GetOwnedGames/v0001", Method.Get);
                requestGame.AddParameter("key", "A99213BE49E808604BD57C9081D1B41D");
                requestGame.AddParameter("steamid", steamCredentials.SteamID);
                requestGame.AddParameter("include_appinfo", "1");
                requestGame.AddParameter("format", "json");
                RestResponse responseGame = client.Execute(requestGame);

                dynamic contentGameParsed = JsonConvert.DeserializeObject(responseGame.Content);
                if (contentGameParsed.response.games != null)
                {
                    foreach (var game in contentGameParsed.response.games)
                    {
                        Game gameAdded = new Game()
                        {
                            Image = $"http://media.steampowered.com/steamcommunity/public/images/apps/{game.appid}/{game.img_icon_url}.jpg",
                            //Image = "http://media.steampowered.com/steamcommunity/public/images/apps/40700/"+33e11d52f0a2335671d7bf73341c14ae6e596809+".jpg",
                            Name = game.name,
                            Id = game.appid,
                            PlayTimeAll = game.playtime_forever
                        };

                        steamCredentials.Games.Add(gameAdded);
                    }
                }
            }
            return steamCredentials;
        }
    }
}
