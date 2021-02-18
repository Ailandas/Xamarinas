using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using XAMARIN_MVVM.Models;
using XAMARIN_MVVM.Views;

namespace XAMARIN_MVVM.ViewModels
{
    public class ItemsViewModel : BaseViewModel
    {
        private Item _selectedItem;
        public ObservableCollection<Item> Items { get; }
        public Command LoadItemsCommand { get; }
        public Command AddItemCommand { get; }
        public Command SendListCommand { get; }
        public Command<Item> ItemTapped { get; }

        public ItemsViewModel()
        {
            Title = "Groceries: "+Services.MockDataStore.GetSum().ToString()+ "€";
            Items = new ObservableCollection<Item>();
            ItemTapped = new Command<Item>(OnItemSelected);
            AddItemCommand = new Command(OnAddItem);
            SendListCommand = new Command(Send);
        }
        private async void Send()
        {
            string smstext = "";
            foreach(var i in Services.MockDataStore.items){
                smstext += i.Text + ", " + i.Description + ", " + i.Price.ToString() + "€ \n ";
            }
            smstext = smstext+ " Approximate total:  " +Services.MockDataStore.GetSum().ToString()+ " €";
            await Xamarin.Essentials.Sms.ComposeAsync(new Xamarin.Essentials.SmsMessage(smstext,""));
        }
        public async void Load()
        {
            IsBusy = true;

            try
            {
                Items.Clear();
                var items = Services.MockDataStore.GetItemsAsync();
                foreach (var item in items)
                {
                    Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        public void OnAppearing()
        {
            IsBusy = true;
            SelectedItem = null;
        }

        public Item SelectedItem
        {
            get => _selectedItem;
            set
            {
                
                SetProperty(ref _selectedItem, value);
                OnItemSelected(value);
            }
        }

        private async void OnAddItem(object obj)
        {
            await App.Current.MainPage.Navigation.PushAsync(new NewItemPage(), true);
        }

        async void OnItemSelected(Item item)
        {
            if (item == null)
                return;
            
            bool r = await Application.Current.MainPage.DisplayAlert("Question", $"Do you wish to open or delete item {item.Id}? ","Delete","Open");

            if (r)
            {
                Services.MockDataStore.Delete(item);
                Load();
                Title = "Groceries: " + Services.MockDataStore.GetSum().ToString() + "€";
            }
            else
            {
                await App.Current.MainPage.Navigation.PushAsync(new ItemDetailPage(item.Id), true);

            }


        }
    }
}