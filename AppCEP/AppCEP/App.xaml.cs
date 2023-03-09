using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppCEP
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new Views.Menu()) { BarBackgroundColor = Color.FromHex("#004677") };
        }   

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
