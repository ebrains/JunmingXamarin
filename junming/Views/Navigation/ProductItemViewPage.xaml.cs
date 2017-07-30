using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace junming
{
    public partial class ProductItemViewPage : ContentPage
    {
        public ProductItemViewPage()
        {
            InitializeComponent();

            BindingContext = SampleData.Products[0];
        }


        async void OnLoginButtonClicked(object sender, EventArgs e)
        {

            Navigation.InsertPageBefore(new ProductOrder(), this);
            //Navigation.PushAsync(ProductOrder);
            await Navigation.PopAsync();
        }

        //private async void OnImageTapped(Object sender, EventArgs e)
        //{
        //    var imagePreview = new ProductImageFullScreenPage((sender as FFImageLoading.Forms.CachedImage).Source);

        //    await Navigation.PushModalAsync(NavigationPageHelper.Create(imagePreview));
        //}
    }
}

