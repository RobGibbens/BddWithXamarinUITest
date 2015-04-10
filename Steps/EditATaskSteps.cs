using TechTalk.SpecFlow;
using Should;
using System.Linq;

namespace BddWithXamarinUITest
{
	[Binding]
	public class EditATaskSteps : StepsBase
	{
		[Then(@"the task named ""(.*)"" no longer exists"), Scope(Tag = Scopes.EditTask)]
		public void ThenTheTaskNamedNoLongerExists(string taskName)
		{
			app.Query(c => c.Marked(taskName)).Count().ShouldEqual(0);
		}

		[When(@"I edit the task name to be ""(.*)"""), Scope(Tag = Scopes.EditTask)]
		public void WhenIEditTheTaskNameToBe(string taskName)
		{
			app.Repl ();
			app.ClearText(addTaskScreen.nameEntry);
			app.ClearText(addTaskScreen.nameEntry);
			app.EnterText(addTaskScreen.nameEntry, taskName);
		}
	}
	
}