using System.Collections.Generic;

namespace AutomationPracticeInjection.Models
{
    public class AppConfiguration
    {
        public string Url { get; set; }
        public string ScreenShotFolder { get; set; }
        public IList<User> Users { get; set; }
    }
}