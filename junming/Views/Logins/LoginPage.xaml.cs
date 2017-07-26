using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace junming
{
	
	public partial class LoginPage : ContentPage
	{
        public LoginPage()
        {
            InitializeComponent();
            //NavigationPage.SetHasNavigationBar(this, false);
        }

        //public async void OnSignupStackTapped(object sender, EventArgs e)
        //{
        //    if (LoginPage.IsPageInNavigationStack<SignUpPage>(Navigation))
        //    {
        //        await Navigation.PopAsync();
        //        return;
        //    }

        //    var signUpPage = new SignUpPage();
        //    await Navigation.PushAsync(signUpPage);
        //}

        //async void OnCloseButtonClicked(object sender, EventArgs args)
        //{
        //    await Navigation.PopModalAsync();
        //}

        public static bool IsPageInNavigationStack<TPage>(INavigation navigation) where TPage : Page
        {
            if (navigation.NavigationStack.Count > 1)
            {
                var last = navigation.NavigationStack[navigation.NavigationStack.Count - 2];

                if (last is TPage)
                {
                    return true;
                }
            }
            return false;
        }

        async void OnLoginButtonClicked(object sender, EventArgs e)
        {

            Navigation.InsertPageBefore(new HomeTabPage(), this);
            await Navigation.PopAsync();
            //await Navigation.PushModalAsync(new WelcomeStarterPage());

            //var user = new User
            //{
            //    Username = usernameEntry.Text,
            //    Password = passwordEntry.Text
            //};

            //var isValid = AreCredentialsCorrect(user);
            //if (isValid)
            //{
            //    App.IsUserLoggedIn = true;
            //    Navigation.InsertPageBefore(new HomeTabPage(), this);
            //    await Navigation.PopAsync();
            //}
            //else
            //{
            //    messageLabel.Text = "Login failed";
            //    passwordEntry.Text = string.Empty;
            //}
        }

        bool AreCredentialsCorrect(User user)
        {
            return user.Username == "xamarin" && user.Password == "password";
        }
    }
}