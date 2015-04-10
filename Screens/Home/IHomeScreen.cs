using System;
using Xamarin.UITest.Queries;

namespace BddWithXamarinUITest
{
	public interface IHomeScreen
	{
		Func<AppQuery, AppQuery> addButton {get;}
	}	
}