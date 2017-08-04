using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace junming
{

    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Market : ContentPage
    {

        private TapGestureRecognizer tapGestureRecognizer = new TapGestureRecognizer();

        public Market()
        {
            InitializeComponent();

            PopulateProductsLists(SampleData.Products);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            tapGestureRecognizer.Tapped += OnBannerTapped;
            EcommerceProductGridBanner.GestureRecognizers.Add(tapGestureRecognizer);
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            tapGestureRecognizer.Tapped -= OnBannerTapped;
            EcommerceProductGridBanner.GestureRecognizers.Remove(tapGestureRecognizer);
        }

        private void PopulateProductsLists(List<Product> productsList)
        {
            var lastHeight = "100";
            var y = 0;
            var column = LeftColumn;
            var productTapGestureRecognizer = new TapGestureRecognizer();
            productTapGestureRecognizer.Tapped += OnProductTapped;

            for (var i = 0; i < productsList.Count; i++)
            {
                var item = new ProductGridItemTemplate();

                if (i % 2 == 0)
                {
                    column = LeftColumn;
                    y++;
                }
                else
                {

                    column = RightColumn;
                }

                productsList[i].ThumbnailHeight = lastHeight;
                item.BindingContext = productsList[i];
                item.GestureRecognizers.Add(productTapGestureRecognizer);
                column.Children.Add(item);
            }
        }

        private async void OnProductTapped(Object sender, EventArgs e)
        {
            var selectedItem = (Product)((ProductGridItemTemplate)sender).BindingContext;

            var productView = new ProductItemViewPage()
            {
                BindingContext = selectedItem
            };

            await Navigation.PushAsync(productView);
        }

        private async void OnBannerTapped(Object sender, EventArgs e)
        {
            uint duration = 500;
            var visualElement = (VisualElement)sender;

            await Task.WhenAll(
                visualElement.FadeTo(0, duration / 2, Easing.CubicIn),
                visualElement.ScaleTo(0, duration / 2, Easing.CubicInOut)
            );

            visualElement.HeightRequest = 0;
        }

        //private bool _showWelcome;

        //public Market() : this(false)
        //{
        //    InitializeComponent();
        //}

        //public Market(bool sayWelcome)
        //{
        //    InitializeComponent();

        //    _showWelcome = sayWelcome;

        //    // Empty pages are initially set to get optimal launch experience
        //    Master = new ContentPage { Title = "Grial" };
        //    Detail = NavigationPageHelper.Create(new ContentPage());
        //}

        ////public async void OnSettingsTapped(Object sender, EventArgs e)
        ////{
        ////    await Navigation.PushAsync(new SettingsPage());
        ////}

        //protected async override void OnAppearing()
        //{
        //    base.OnAppearing();

        //    //SampleCoordinator.SampleSelected += SampleCoordinator_SampleSelected;

        //    //if (_showWelcome)
        //    //{
        //    //    _showWelcome = false;

        //    //    await Navigation.PushModalAsync(NavigationPageHelper.Create(new WelcomePage()));

        //    //    await Task.Delay(500)
        //    //        .ContinueWith(t => NavigationService.BeginInvokeOnMainThreadAsync(InitializeMasterDetail));
        //    //}
        //}

        //protected override void OnDisappearing()
        //{
        //    base.OnDisappearing();

        //    //SampleCoordinator.SampleSelected -= SampleCoordinator_SampleSelected;
        //}

        //private void InitializeMasterDetail()
        //{
        //    Master = new MainMenuPage(new NavigationService(Navigation, LaunchSampleInDetail));
        //    Detail = NavigationPageHelper.Create(new DashboardPage());
        //}

        //private void LaunchSampleInDetail(Page page, bool animated)
        //{
        //    // CustomNavBarPage must be handled differently because XF seems not to be considering the
        //    // "NavigationPage.SetHasNavigationBar(this, false);" when you add the page as the 
        //    // root of the NavigationPage, when you are working in Android.
        //    if (page is CustomNavBarPage)
        //    {
        //        var navigationPage = NavigationPageHelper.Create(new ContentPage());

        //        Detail = navigationPage;

        //        navigationPage.PushAsync(page, false);
        //    }
        //    else
        //    {
        //        Detail = NavigationPageHelper.Create(page);
        //    }

        //    IsPresented = false;
        //}

        //private void SampleCoordinator_SampleSelected(object sender, SampleEventArgs e)
        //{
        //    if (e.Sample.PageType == typeof(RootPage))
        //    {
        //        IsPresented = true;
        //    }
        //}


    }
}