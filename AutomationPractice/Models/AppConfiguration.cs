using System.Collections.Generic;

namespace AutomationPractice.Models
{
    public class AppConfiguration
    {
        public string Url { get; set; }
        public string ScreenShotFolder { get; set; }
        public IList<User> Users { get; set; }
    }
}