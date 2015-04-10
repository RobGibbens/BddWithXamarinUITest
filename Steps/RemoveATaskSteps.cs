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
		}

		[Then(@"the task named ""(.*)"" no longer exists"), Scope(Tag = "removeTask")]
		public void ThenTheTaskNoLongerExists(string taskName)
		{
			app.Query(c => c.Marked(taskName)).Count().ShouldEqual(0);
		}
	}
}