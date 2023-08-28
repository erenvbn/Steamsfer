using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Steamsfer.Models
{
    public class Game
    {
        public string Image { get; set; }
        public string Name { get; set; }
        public string Id { get; set; }
        public int PlayTimeAll { get; set; }
        public string TotalPlayTimeInHM
        {
            get
            {
                return ConvertMinToHM(PlayTimeAll);
            }
        }
        public string ConvertMinToHM(int totalPlayTimeInMinutes)
        {
            TimeSpan time = TimeSpan.FromMinutes(totalPlayTimeInMinutes);
            int hours = (int)time.TotalHours;
            int minutes = time.Minutes;

            return $"{hours}:{minutes:00}";
        }

    }
}
