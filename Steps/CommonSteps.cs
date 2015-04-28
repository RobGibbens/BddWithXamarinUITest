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
			app.Screenshot ("Given I am on the Home screen");
		}

		[Given(@"I have at least one existing task named ""(.*)""")]
		public void GivenIHaveAtLeastOneExistingTask(string taskName)
		{
			app.WaitForElement (homeScreen.addButton);
			var count = app.Query (c => c.Marked (taskName)).Count ();
			if (count == 0) {
				app.Screenshot ("Give I have at least one existing task named '" + taskName + "'");
				app.Tap (homeScreen.addButton);

				app.WaitForElement (addTaskScreen.nameEntry);
				app.EnterText (addTaskScreen.nameEntry, taskName);
				app.Tap (addTaskScreen.saveButton);
				app.WaitForElement (c => c.Marked (taskName));
			}
			app.Screenshot ("Give I have at least one existing task named '" + taskName + "'");

			app.Query(c => c.Marked(taskName)).Count().ShouldBeGreaterThanOrEqualTo(1);
		}

		[When (@"I add a new task called ""(.*)""")]
		public void WhenIAddANewTaskCalled (string taskName)
		{
			app.WaitForElement (homeScreen.addButton);
			app.Tap (homeScreen.addButton);
			app.Screenshot ("When I add a new task called '" + taskName + "'");
			app.WaitForElement (addTaskScreen.nameEntry);
			app.EnterText (addTaskScreen.nameEntry, taskName);
			app.Screenshot ("When I add a new task called '" + taskName + "'");
		}

		[When (@"I save the task")]
		public void WhenISaveTheTask ()
		{
			app.Tap (addTaskScreen.saveButton);
			app.Screenshot ("When I save the task");
		}

		[Then (@"I should see the ""(.*)"" task in the list")]
		public void ThenIShouldSeeTheTaskInTheList (string taskName)
		{
			app.WaitForElement (c => c.Marked (taskName));
			app.Query (c => c.Marked (taskName)).Length.ShouldBeGreaterThan (0);
			app.Screenshot ("Then I should see the '" + taskName + "' task in the list");
		}

		[When(@"I select the task named ""(.*)""")]
		public void WhenISelectTheTaskNamed(string taskName)
		{
			app.Tap(c => c.Marked(taskName));
			app.Screenshot ("When I select the task named '" + taskName + "'");
		}
	}
	
}