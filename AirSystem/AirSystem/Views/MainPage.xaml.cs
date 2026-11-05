using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AirSystem.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            CheckAndRequestLocationPermission();
        }

        private async void CheckAndRequestLocationPermission()
        {
            var status = await Permissions.CheckStatusAsync<Permissions.LocationWhenInUse>();

            if (status != PermissionStatus.Granted)
            {
                status = await Permissions.RequestAsync<Permissions.LocationWhenInUse>();
            }

            if (status == PermissionStatus.Granted)
            {
                await DisplayAlert("Доступ надано", "Доступ до місцезнаходження дозволено", 
                    "ОК");
            }
            else
            {
                await DisplayAlert("Доступ заборонено", "Будь ласка, " +
                    "надайте доступ до місцезнаходження в налаштуваннях", "ОК");
            }
        }

        private async void GetLocation()
        {
            try
            {
                var location = await Geolocation.GetLastKnownLocationAsync();

                if (location != null)
                {
                    StatusMessage.Text = $"Широта: {location.Latitude}, " +
                        $"Довгота: {location.Longitude}";
                    await DisplayAlert("Місцезнаходження", $"Широта: {location.Latitude}, " +
                        $"Довгота: {location.Longitude}", "OK");
                }
                else
                {
                    StatusMessage.Text = "Не вдалося отримати місцезнаходження.";
                    await DisplayAlert("Помилка", "Не вдалося отримати місцезнаходження", 
                        "OK");
                }
            }
            catch (Exception ex)
            {
                StatusMessage.Text = $"Виникла помилка: {ex.Message}";
                await DisplayAlert("Помилка", $"Виникла помилка: {ex.Message}", "OK");
            }
        }

        private void OnGetLocationClicked(object sender, EventArgs e)
        {
            GetLocation();

        }
    }
}
