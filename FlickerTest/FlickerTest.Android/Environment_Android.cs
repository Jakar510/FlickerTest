using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using Android.Content.Res;
using Android.OS;
using FlickerTest.Droid;
using FlickerTest.Services;
using Plugin.CurrentActivity;
using Xamarin.Forms;

[assembly: Dependency(typeof(Environment_Android))]
namespace FlickerTest.Droid
{

	// ReSharper disable once InconsistentNaming
	[SuppressMessage("Naming", "CA1707:Identifiers should not contain underscores", Justification = "<Pending>")]
	public class Environment_Android : IEnvironment
	{
		public Theme GetOperatingSystemTheme()
		{
			//Ensure the device is running Android Froyo or higher because UIMode was added in Android Froyo, API 8.0
			if (Build.VERSION.SdkInt < BuildVersionCodes.Froyo) return Theme.Light;
			
			UiMode uiModelFlags = CrossCurrentActivity.Current.AppContext.Resources.Configuration.UiMode & UiMode.NightMask;

			return uiModelFlags switch
			{
				UiMode.NightYes => Theme.Dark,
				UiMode.NightNo => Theme.Light,
				//_ => throw new NotSupportedException($"UiMode {uiModelFlags} not supported")
				_ => Theme.Light
			};
		}
		public Task<Theme> GetOperatingSystemThemeAsync()

		{
			//Ensure the device is running Android Froyo or higher because UIMode was added in Android Froyo, API 8.0
			if (Build.VERSION.SdkInt < BuildVersionCodes.Froyo) { return Task.FromResult(Theme.Light); }

			UiMode uiModelFlags = CrossCurrentActivity.Current.AppContext.Resources.Configuration.UiMode & UiMode.NightMask;

			return uiModelFlags switch
			{
				UiMode.NightYes => Task.FromResult(Theme.Dark),
				UiMode.NightNo => Task.FromResult(Theme.Light),
				//_ => throw new NotSupportedException($"UiMode {uiModelFlags} not supported")
				_ => Task.FromResult(Theme.Light)
			};
		}
	}
}