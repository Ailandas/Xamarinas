using System.ComponentModel;
using Xamarin.Forms;
using XAMARIN_MVVM.ViewModels;

namespace XAMARIN_MVVM.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage(string id)
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel(id);
        }
    }
}