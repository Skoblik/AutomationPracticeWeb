using System;
using System.IO;
using System.Linq;
using AutomationPracticeInjection.Models;
using Newtonsoft.Json;

namespace AutomationPracticeInjection.Utility
{
	public static class Settings
	{
		static Settings()
		{
			string json = File.ReadAllText(ConfigurationFile);
			var configuration = JsonConvert.DeserializeObject<AppConfiguration>(json);
			Url = configuration.Url;
			ScreenShotFolder = configuration.ScreenShotFolder;
			PositiveUser = configuration.Users.First(i => i.Type.Equals("positive"));
			NegativeUser = configuration.Users.First(i => i.Type.Equals("negative"));
		}

		public static string Url { get; }
		public static string ScreenShotFolder { get; }
		public static User PositiveUser { get; }
		public static User NegativeUser { get; }

		private static string ConfigurationFile => Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "configuration.json");
	}
}