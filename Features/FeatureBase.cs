using NUnit.Framework;
using Xamarin.UITest;
using TechTalk.SpecFlow;

namespace BddWithXamarinUITest
{
	[TestFixture (Platform.Android, "")]
	[TestFixture (Platform.iOS, iPhone5s.OS_8_1)]
	[TestFixture (Platform.iOS, iPhone5s.OS_8_2)]
	[TestFixture (Platform.iOS, iPhone5s.OS_8_3)]

	[TestFixture (Platform.iOS, iPhone6.OS_8_1)]
	[TestFixture (Platform.iOS, iPhone6.OS_8_2)]
	[TestFixture (Platform.iOS, iPhone6.OS_8_3)]

	//[TestFixture (Platform.iOS, iPadAir.OS_8_1)]
	//[TestFixture (Platform.iOS, iPadAir.OS_8_2)]
	//[TestFixture (Platform.iOS, iPadAir.OS_8_3)]
	public class FeatureBase
	{
		protected static IApp app;
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
			FeatureContext.Current.Add ("App", app);
			AppInitializer.InitializeScreens (platform);
		}
	}

}