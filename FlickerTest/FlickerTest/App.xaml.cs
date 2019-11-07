using System;
using System.Threading.Tasks;
using FlickerTest.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using FlickerTest.Services;
using FlickerTest.Views;
using Xamarin.Essentials;

namespace FlickerTest
{
	public partial class App : Application
	{

		public App()
		{
			InitializeComponent();

			DependencyService.Register<MockDataStore>();
			//Theme systemTheme = GetOperatingSystemTheme();
			Theme systemThemeAsync = GetOperatingSystemThemeAsync().Result;
			MainPage = new MainPage();
		}

		protected override void OnStart()
		{
			// Handle when your app starts
		}

		protected override void OnSleep()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume()
		{
			// Handle when your app resumes
		}



		public static Theme GetOperatingSystemTheme()
		{
			//Theme systemTheme = await DependencyService.Get<IEnvironment>().GetOperatingSystemTheme().ConfigureAwait(true);
			Theme systemTheme = DependencyService.Get<IEnvironment>().GetOperatingSystemTheme();

			SetTheme(systemTheme);
			return systemTheme;

		}
		public static async Task<Theme> GetOperatingSystemThemeAsync()
		{
			Theme systemTheme = await DependencyService.Get<IEnvironment>().GetOperatingSystemThemeAsync().ConfigureAwait(true);

			SetTheme(systemTheme);
			return systemTheme;

		}
		internal static async void SetTheme(Theme theme)
		{
			try
			{
				//Handle Light Theme & Dark Theme
				if (theme == Theme.Unspecified) theme = CurrentTheme;

				switch (theme)
				{
					// https://lalorosas.com/blog/dark-mode
					// https://codetraveler.io/2019/09/11/check-for-dark-mode-in-xamarin-forms/

					case Theme.Dark:
						Current.Resources = new DarkThemeDictionary();
						break;
					case Theme.Light:
						Current.Resources = new LightThemeDictionary();
						break;
					case Theme.Unspecified:
					default:
						throw new ArgumentOutOfRangeException(nameof(theme), theme, null);
				}

				CurrentTheme = theme;

				//... 
			}
			catch (Exception e)
			{
				Console.Write(e.StackTrace);
			}
		}

		public static Theme CurrentTheme { get; set; }
	}
}
