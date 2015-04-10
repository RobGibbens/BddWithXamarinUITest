using System;
using Xamarin.UITest.Queries;

namespace BddWithXamarinUITest
{
	public interface IAddTaskScreen
	{
		Func<AppQuery, AppQuery> nameEntry {get;}
		Func<AppQuery, AppQuery> saveButton {get;}
		Func<AppQuery, AppQuery> deleteButton {get;}
	}
}