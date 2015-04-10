using TechTalk.SpecFlow;
using Xamarin.UITest;
using Should;
using System.Linq;

namespace BddWithXamarinUITest
{
	[Binding]
	public class CommonSteps
	{
		readonly IHomeScreen homeScreen;
		readonly IAddTaskScreen addTaskScreen;
		readonly IApp app;

		public CommonSteps ()
		{
			app = FeatureContext.Current.Get<IApp>("App");
			homeScreen = FeatureContext.Current.Get<IHomeScreen> (ScreenNames.Home);
			addTaskScreen = FeatureContext.Current.Get<IAddTaskScreen> (ScreenNames.AddTask);
		}

		[Given (@"I am on the Home screen")]
		public void GivenIAmOnTheHomeScreen ()
		{
		}

		[Given(@"I have at least one existing task named ""(.*)""")]
		public void GivenIHaveAtLeastOneExistingTask(string taskName)
		{
			app.WaitForElement (homeScreen.addButton);
			var count = app.Query (c => c.Marked (taskName)).Count ();
			if (count == 0) {
				app.Tap (homeScreen.addButton);

				app.WaitForElement (addTaskScreen.nameEntry);
				app.EnterText (addTaskScreen.nameEntry, taskName);
				app.Tap (addTaskScreen.saveButton);
				app.WaitForElement (c => c.Marked (taskName));
			}
			app.Query(c => c.Marked(taskName)).Count().ShouldBeGreaterThanOrEqualTo(1);
		}

		[When (@"I add a new task called ""(.*)""")]
		public void WhenIAddANewTaskCalled (string taskName)
		{
			app.WaitForElement (homeScreen.addButton);
			app.Tap (homeScreen.addButton);
			app.Screenshot ("Add button tapped");
			app.WaitForElement (addTaskScreen.nameEntry);
			app.EnterText (addTaskScreen.nameEntry, taskName);
			app.Screenshot ("Name entered");
		}

		[When (@"I save the task")]
		public void WhenISaveTheTask ()
		{
			app.Tap (addTaskScreen.saveButton);
			app.Screenshot ("Save button tapped");
		}

		[Then (@"I should see the ""(.*)"" task in the list")]
		public void ThenIShouldSeeTheTaskInTheList (string taskName)
		{
			app.WaitForElement (c => c.Marked (taskName));
			app.Query (c => c.Marked (taskName)).Length.ShouldBeGreaterThan (0);
			app.Screenshot ("Task list shown");
		}

		[When(@"I select the task named ""(.*)""")]
		public void WhenISelectTheTaskNamed(string taskName)
		{
			app.Tap(c => c.Marked(taskName));
		}
	}
	
}