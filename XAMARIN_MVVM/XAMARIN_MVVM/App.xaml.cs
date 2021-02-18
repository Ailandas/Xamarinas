using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XAMARIN_MVVM.Services;
using XAMARIN_MVVM.Views;

namespace XAMARIN_MVVM
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new LoginPage());
            //MainPage = new NavigationPage(new ItemsPage());
            
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
