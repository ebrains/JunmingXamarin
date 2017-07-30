using System;
using Xamarin.Forms;

namespace junming
{
	public static class NavigationPageHelper
	{
		public static NavigationPage Create(Page page)
		{
			return new NavigationPage(page) { BarTextColor = Color.White };
		}
	}
}
