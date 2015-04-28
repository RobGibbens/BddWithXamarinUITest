using TechTalk.SpecFlow;
using Xamarin.UITest;
using Should;
using System.Linq;

namespace BddWithXamarinUITest
{
	[Binding]
	public class RemoveATaskSteps : StepsBase
	{
		[When(@"I tap delete"), Scope(Tag = Scopes.RemoveTask)]
		public void WhenITapDelete()
		{
			app.Tap(addTaskScreen.deleteButton);
			app.Screenshot ("When I tap delete");
		}

		[Then(@"the task named ""(.*)"" no longer exists"), Scope(Tag = Scopes.RemoveTask)]
		public void ThenTheTaskNoLongerExists(string taskName)
		{
			app.WaitForElement (homeScreen.addButton);
			app.Screenshot("Then the task named '" + taskName + "' no longer exists");
			app.Query(c => c.Marked(taskName)).Count().ShouldEqual(0);
		}
	}
}