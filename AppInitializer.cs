using Xamarin.UITest;
using TechTalk.SpecFlow;
using NUnit.Framework;
using System.Diagnostics;
using System;

namespace BddWithXamarinUITest
{
	public static class AppInitializer
	{
		public static IApp StartApp (Platform platform, string iOSSimulator, bool resetDevice)
		{
			// TODO: If the iOS or Android app being tested is included in the solution 
			// then open the Unit Tests window, right click Test Apps, select Add App Project
			// and select the app projects that should be tested.
			if (platform == Platform.Android) {

				if (resetDevice) {
					ResetEmulator ();
				}

				return ConfigureApp
					.Android
					.ApkFile ("../../binaries/com.xamarin.samples.taskydroidnew.exampleapp.apk")
					.EnableLocalScreenshots ()
					.StartApp ();
				
			} else if (platform == Platform.iOS) {

				if (resetDevice) {
					ResetSimulator (iOSSimulator);
				}

				return ConfigureApp
					.iOS
					.AppBundle ("../../binaries/TaskyiOS.app")
					.EnableLocalScreenshots ()
					.DeviceIdentifier(iOSSimulator)
					.StartApp ();
			}

			throw new ArgumentException ("Unsupported platform");
		}

		static void ResetEmulator()
		{
			//TODO : Generalize this
			//TODO : Make this work on Windows?

			if (TestEnvironment.Platform.Equals(TestPlatform.Local))
			{
				var eraseProcess = Process.Start ("/Users/rob/Library/Developer/Xamarin/android-sdk-macosx/platform-tools/adb", "shell pm uninstall com.xamarin.samples.taskydroid");
				eraseProcess.WaitForExit ();
			}
		}

		static void ResetSimulator(string iOSSimulator)
		{
			if (TestEnvironment.Platform.Equals (TestPlatform.Local)) {
				var deviceId = TestHelpers.GetDeviceID (iOSSimulator);

				if (string.IsNullOrEmpty (deviceId)) {
					throw new ArgumentException ($"No simulator found with device name [{iOSSimulator}]", iOSSimulator);
				}

				var shutdownProcess = Process.Start ("xcrun", string.Format ("simctl shutdown {0}", deviceId));
				shutdownProcess.WaitForExit ();
				var eraseProcess = Process.Start ("xcrun", string.Format ("simctl erase {0}", deviceId));
				eraseProcess.WaitForExit ();
			}
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