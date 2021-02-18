using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XAMARIN_MVVM.Models;
using XAMARIN_MVVM.ViewModels;
using XAMARIN_MVVM.Views;

namespace XAMARIN_MVVM.Views
{
    public partial class ItemsPage : ContentPage
    {
        ItemsViewModel _viewModel;

        public ItemsPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new ItemsViewModel();
            _viewModel.Load();
            
        }
      
        
       
    }
}