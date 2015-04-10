using System;
using Xamarin.UITest.Queries;

namespace BddWithXamarinUITest
{
	public class iOSAddTaskScreen : IAddTaskScreen
	{
		public Func<AppQuery, AppQuery> nameEntry { get; } = new Func<AppQuery, AppQuery> (c => c.Marked("Name"));
		public Func<AppQuery, AppQuery> saveButton { get; } = new Func<AppQuery, AppQuery> (c => c.Marked("Save"));
		public Func<AppQuery, AppQuery> deleteButton { get; } = new Func<AppQuery, AppQuery> (c => c.Marked("Delete"));
	}	
}