using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Foundation;
using FlickerTest.iOS;
using FlickerTest.Models;
using FlickerTest.Services;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(Environment_iOS))]
namespace FlickerTest.iOS
{
	// ReSharper disable once InconsistentNaming
	[SuppressMessage("ReSharper", "InconsistentNaming")]
	[SuppressMessage("Naming", "CA1707:Identifiers should not contain underscores", Justification = "<Pending>")]
	public class Environment_iOS : IEnvironment
	{
		public Theme GetOperatingSystemTheme()
		{
			UIViewController currentUIViewController = GetVisibleViewController();

			UIUserInterfaceStyle userInterfaceStyle = currentUIViewController.TraitCollection.UserInterfaceStyle;

			return userInterfaceStyle switch
			{
				UIUserInterfaceStyle.Light => Theme.Light,
				UIUserInterfaceStyle.Dark => Theme.Dark,
				_ => throw new NotSupportedException($"UIUserInterfaceStyle {userInterfaceStyle} not supported"),
			};
		}
		private static UIViewController GetVisibleViewController()
		{
			UIViewController rootController = UIApplication.SharedApplication.KeyWindow.RootViewController;

			return rootController.PresentedViewController switch
			{
				UINavigationController navigationController => navigationController.TopViewController,
				UITabBarController tabBarController => tabBarController.SelectedViewController,
				null => rootController,
				_ => rootController.PresentedViewController,
			};
		}


		public async Task<Theme> GetOperatingSystemThemeAsync()
		{
			//Ensure the current device is running 12.0 or higher, because `TraitCollection.UserInterfaceStyle` was introduced in iOS 12.0
			if (!UIDevice.CurrentDevice.CheckSystemVersion(12, 0)) { return Theme.Light; }

			UIViewController currentUIViewController = await GetVisibleViewControllerAsync().ConfigureAwait(true);

			UIUserInterfaceStyle userInterfaceStyle = currentUIViewController.TraitCollection.UserInterfaceStyle;

			switch (userInterfaceStyle)
			{
				case UIUserInterfaceStyle.Unspecified:
				case UIUserInterfaceStyle.Light:
					return Theme.Light;
				case UIUserInterfaceStyle.Dark:
					return Theme.Dark;
				default:
					throw new NotSupportedException($"UIUserInterfaceStyle {userInterfaceStyle} not supported");
			}
		}
		private static Task<UIViewController> GetVisibleViewControllerAsync()
		{
			// UIApplication.SharedApplication can only be referenced on by Main Thread, so we'll use Device.InvokeOnMainThreadAsync which was introduced in Xamarin.Forms v4.2.0
			return Device.InvokeOnMainThreadAsync(() =>
			{
				UIViewController rootController = UIApplication.SharedApplication.KeyWindow.RootViewController;

				return rootController.PresentedViewController switch
				{
					UINavigationController navigationController => navigationController.TopViewController,
					UITabBarController tabBarController => tabBarController.SelectedViewController,
					null => rootController,
					_ => rootController.PresentedViewController
				};
			});

		}
	}
	
}