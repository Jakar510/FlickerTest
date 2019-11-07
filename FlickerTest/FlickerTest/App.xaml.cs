using System;
using System.Linq;
using System.Threading.Tasks;
using FlickerTest.Models;
using FlickerTest.Services;
using FlickerTest.Views;
using Xamarin.Forms;

namespace FlickerTest
{
    public partial class App : Application
    {

        public App()
        {
            DependencyService.Register<MockDataStore>();
			
            if (Device.RuntimePlatform == Device.Android)
            {
	            Theme systemThemeAsync = GetOperatingSystemThemeAsync().Result;
	            InitializeComponent();
	            MainPage = new NavigationPage(new MainPage(systemThemeAsync));
            }
            else
            {
	            InitializeComponent();
	            MainPage = new NavigationPage(new MainPage());
            }

		}

        protected override void OnStart()
        {
            base.OnStart();

            GetOperatingSystemTheme();
        }

        protected override void OnResume()
        {
            base.OnResume();

            GetOperatingSystemTheme();
        }

        public static void GetOperatingSystemTheme()
        {
            Theme systemTheme = DependencyService.Get<IEnvironment>().GetOperatingSystemTheme();

            SetTheme(systemTheme);
        }

        public static async Task<Theme> GetOperatingSystemThemeAsync()
        {
            Theme systemTheme = await DependencyService.Get<IEnvironment>().GetOperatingSystemThemeAsync();

            SetTheme(systemTheme);
            return systemTheme;

        }

        internal static void SetTheme(Theme theme)
        {
            try
            {
                //Handle Light Theme & Dark Theme
                if (theme is Theme.Unspecified)
                    theme = CurrentTheme;

                if (Current.Resources.MergedDictionaries.Any())
                    Current.Resources.MergedDictionaries.Clear();

                switch (theme)
                {
                    // https://lalorosas.com/blog/dark-mode
                    // https://codetraveler.io/2019/09/11/check-for-dark-mode-in-xamarin-forms/

                    case Theme.Dark:
                        Current.Resources.Add(new DarkThemeDictionary());
                        break;
                    case Theme.Light:
                        Current.Resources.Add(new LightThemeDictionary());
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(theme), theme, null);
                }

                CurrentTheme = theme;
            }
            catch (Exception e)
            {
                Console.Write(e.StackTrace);
            }
        }

        public static Theme CurrentTheme { get; set; }
    }
}
