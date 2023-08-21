using Steamsfer.Models;

namespace Steamsfer.Models
{
    public class SteamCredentialsViewModel
    {
        public SteamCredentialsViewModel()
        {
            Games = new List<Game>();
        }
        public string SteamName { get; set; }
        public string SteamId { get; set; }
        public string Description { get; set; }
        public string ProfileUrl { get; set; }
        public string Avatar { get; set; }
        public int CommunityVisibility { get; set; }
        public List<Game> Games { get; set; }

        //BACKING FIELDS
        public int _totalPlayTimeInDHM;

        //CUSTOM PROPERTIES

        public string TotalPlayTimeInDHM
        {
            get
            {
                _totalPlayTimeInDHM = 0;
                foreach (var game in Games)
                    {
                        _totalPlayTimeInDHM += game.PlayTimeAll;
                    }
                return ConvertMinToDHM(_totalPlayTimeInDHM);
            }
        }

        //METHODS
        public string ConvertMinToDHM(int totalPlayTimeInMinutes)
        {
            TimeSpan time = TimeSpan.FromMinutes(totalPlayTimeInMinutes);
            int days = time.Days;
            int hours = time.Hours;
            int minutes = time.Minutes;

            string result = "";
            if (days > 0)
            {
                result += $"{days} day{(days > 1 ? "s" : "")}, ";
            }
            if (hours > 0)
            {
                result += $"{hours} hour{(hours > 1 ? "s" : "")}, ";
            }
            if (minutes > 0)
            {
                result += $"{minutes} minute{(minutes > 1 ? "s" : "")}";
            }

            return result.TrimEnd(',', ' ');
        }
    }
}
