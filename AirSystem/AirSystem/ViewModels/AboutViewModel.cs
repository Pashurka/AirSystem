using System;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace AirSystem.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        public AboutViewModel()
        {
            Title = "Інформація";
            OpenWebCommand = new Command(async () => await Browser.OpenAsync("https://www.onua.edu.ua/ua/"));
        }

        public ICommand OpenWebCommand { get; }
    }
}