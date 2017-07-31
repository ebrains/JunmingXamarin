using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace junming
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LandRental : ContentPage
    {
        public LandRental()
        {
            InitializeComponent();
        }

        public void OnBtnLightClicked()
        {
            //Application.Current.Resources.MergedWith = typeof(grialfull.GrialLightTheme);
        }

        public void OnBtnDarkClicked()
        {
            //Application.Current.Resources.MergedWith = typeof(grialfull.GrialDarkTheme);
        }
    }
}