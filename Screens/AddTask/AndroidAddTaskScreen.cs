using System;
using Xamarin.UITest.Queries;

namespace BddWithXamarinUITest
{
	public class AndroidAddTaskScreen : IAddTaskScreen
	{
		public Func<AppQuery, AppQuery> nameEntry { get; } = new Func<AppQuery, AppQuery> (c => c.Marked("txtName"));
		public Func<AppQuery, AppQuery> saveButton { get; } = new Func<AppQuery, AppQuery> (c => c.Marked("btnSave"));
		public Func<AppQuery, AppQuery> deleteButton { get; } = new Func<AppQuery, AppQuery> (c => c.Marked("btnCancelDelete"));
	}	
}