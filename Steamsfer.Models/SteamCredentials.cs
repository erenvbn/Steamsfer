namespace Steamsfer.Models
{
    public class SteamCredentials
    {
        public SteamCredentials()
        {
            Games = new List<Game>();
        }
        public string SteamName { get; set; }
        public string SteamID { get; set; }
        public string Description { get; set; }
        public string ProfileUrl { get; set; }
        public string Avatar { get; set; }
        public int CommunityVisibility { get; set; }
        public List<Game> Games { get;}
    }
}
