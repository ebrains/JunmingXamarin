using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace junming
{

    public partial class App : Application
	{
        public static bool IsUserLoggedIn { get; set; }
        

        public static MasterDetailPage MasterDetailPage;

		public App()
		{
            InitializeComponent();

            if (!IsUserLoggedIn)
            {
                MainPage = new NavigationPage(new LoginPage());

                MainPage.SetValue(NavigationPage.BarTextColorProperty, Color.White);
            }
            else
            {
                MainPage = new NavigationPage(new junming.HomeTabPage());

                MainPage.SetValue(NavigationPage.BarTextColorProperty, Color.White);
            }

            //MainPage = GetMainPage();

            
		}

		public static Page GetMainPage()
        {
            //return new WelcomeStarterPage();
            return new LoginPage();
            
        }
	}
}
