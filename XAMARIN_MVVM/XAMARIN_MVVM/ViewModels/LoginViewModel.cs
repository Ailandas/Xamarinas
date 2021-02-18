using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using XAMARIN_MVVM.Views;

namespace XAMARIN_MVVM.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public Command LoginCommand { get; }
        public ICommand ShowAlertCommand { get; set; }

        public INavigation Navigation;


        public string Username { get; set; }
        public string Password { get; set; }

        public LoginViewModel(INavigation MainPageNav)
        {
            Navigation = MainPageNav;
            LoginCommand = new Command(OnLoginClicked);
            ShowAlertCommand = new Command(get => MakeAlter(false));
        }
      
        void MakeAlter(bool r)
        {
            if (r)
                Application.Current.MainPage.DisplayAlert("Congratulations", "You have successfuly logged in", "Ok");
            else
                Application.Current.MainPage.DisplayAlert("Sorry", "Your credentials are invalid", "Try again");
                
        }
        private async void OnLoginClicked(object obj)
        {
            bool r=Login();
            MakeAlter(r);
            if (r == false) { return; }
            GoToItems();
        }
        private bool Login()
        {
            Services.MockDataStore.PopulateItems();
            bool r = false;
            List<Models.User> users = Models.Users.GetUsers();
            foreach(Models.User U in users)
            {
                if(U.Username==Username && U.Password == Password)
                {
                    return true;
                }
            }
            return r;
            
        }
     



        public async void GoToItems()
        {

            //await Navigation.PushAsync(new NavigationPage(new ()));
            await App.Current.MainPage.Navigation.PushAsync(new ItemsPage(), true);



        }
    }
}
