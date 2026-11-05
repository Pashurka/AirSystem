using AirSystem.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace AirSystem.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}