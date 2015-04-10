using Xamarin.UITest;
using TechTalk.SpecFlow;
using NUnit.Framework;
using System.Diagnostics;
using System;

namespace BddWithXamarinUITest
{
	public static class AppInitializer
	{
		public static IApp StartApp (Platform platform, string iOSSimulator)
		{
			// TODO: If the iOS or Android app being tested is included in the solution 
			// then open the Unit Tests window, right click Test Apps, select Add App Project
			// and select the app projects that should be tested.
			if (platform == Platform.Android) {
				return ConfigureApp
					.Android
				// TODO: Update this path to point to your Android app and uncomment the
				// code if the app is not included in the solution.
				//.ApkFile ("../../../Droid/bin/Debug/xamarinforms.apk")
					.ApkFile ("/Users/rob/dev/BddWithXamarinUITest/binaries/com.xamarin.samples.taskyandroid.apk")
					.EnableLocalScreenshots ()
					.StartApp ();
			} else if (platform == Platform.iOS) {
				var deviceId = TestHelpers.GetDeviceID(iOSSimulator);

				if (string.IsNullOrEmpty(deviceId))
				{
					throw new ArgumentException ($"No simulator found with device name [{iOSSimulator}]", iOSSimulator);
				}

				ResetSimulator(deviceId);

				return ConfigureApp
				.iOS
					// TODO: Update this path to point to your iOS app and uncomment the
					// code if the app is not included in the solution.
					//.AppBundle ("../../../iOS/bin/iPhoneSimulator/Debug/XamarinForms.iOS.app")
					.AppBundle ("/Users/rob/dev/BddWithXamarinUITest/binaries/TaskyiOS.app")
					.EnableLocalScreenshots ()
					.DeviceIdentifier(iOSSimulator)
					.StartApp ();
			}

			throw new ArgumentException ("Unsupported platform");
		}

		static void ResetSimulator(string deviceId)
		{
			var shutdownProcess = Process.Start("xcrun", string.Format("simctl shutdown {0}", deviceId));
			shutdownProcess.WaitForExit();
			var eraseProcess = Process.Start("xcrun", string.Format("simctl erase {0}", deviceId));
			eraseProcess.WaitForExit();
		}

		public static void InitializeScreens(Platform platform)
		{
			if (platform == Platform.iOS) {
				FeatureContext.Current.Add (ScreenNames.Home, new iOSHomeScreen ());
				FeatureContext.Current.Add (ScreenNames.AddTask, new iOSAddTaskScreen ());
			} else if (platform == Platform.Android) {
				FeatureContext.Current.Add (ScreenNames.Home, new AndroidHomeScreen ());
				FeatureContext.Current.Add (ScreenNames.AddTask, new AndroidAddTaskScreen ());
			}
		}
	}
}