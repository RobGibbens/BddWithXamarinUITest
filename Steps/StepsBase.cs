using TechTalk.SpecFlow;
using Xamarin.UITest;
using Should;
using System.Linq;
using Xamarin.UITest.Queries;
using System;

namespace BddWithXamarinUITest
{
	public class StepsBase
	{
		protected readonly IHomeScreen homeScreen;
		protected readonly IAddTaskScreen addTaskScreen;
		protected readonly IApp app;

		public StepsBase ()
		{
			app = FeatureContext.Current.Get<IApp>("App");
			homeScreen = FeatureContext.Current.Get<IHomeScreen> (ScreenNames.Home);
			addTaskScreen = FeatureContext.Current.Get<IAddTaskScreen> (ScreenNames.AddTask);	
		}
	}
	
}