using NUnit.Framework;
using Xamarin.UITest;

namespace BddWithXamarinUITest
{
	[TestFixture (Platform.Android, "")]
	[TestFixture (Platform.iOS, iPhone6.OS_8_1)]
	[TestFixture (Platform.iOS, iPhone6.OS_8_2)]
	[TestFixture (Platform.iOS, iPadAir.OS_8_1)]
	[TestFixture (Platform.iOS, iPadAir.OS_8_2)]
	public class FeatureBase
	{
		public static IApp app;
		protected Platform platform;
		protected string iOSSimulator;

		public FeatureBase (Platform platform, string iOSSimulator)
		{
			this.iOSSimulator = iOSSimulator;
			this.platform = platform;
		}

		[SetUp]
		public void BeforeEachTest ()
		{
			app = AppInitializer.StartApp (platform, iOSSimulator);

			AppInitializer.InitializeScreens (platform);
		}
	}

}