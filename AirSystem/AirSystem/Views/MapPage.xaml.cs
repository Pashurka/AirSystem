using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace AirSystem.Views
{
    public partial class MapPage : ContentPage
    {
        // Константи для геолокації
        private const GeolocationAccuracy LocationAccuracy = GeolocationAccuracy.Medium;
        private const int LocationTimeoutInSeconds = 30;

        public MapPage()
        {
            InitializeComponent();
            InitializeMap();
        }

        private async void InitializeMap()
        {
            try
            {
                // Отримання поточного місцезнаходження
                var location = await Geolocation.GetLastKnownLocationAsync();

                if (location == null)
                {
                    location = await Geolocation.GetLocationAsync(new GeolocationRequest
                    {
                        DesiredAccuracy = LocationAccuracy,
                        Timeout = TimeSpan.FromSeconds(LocationTimeoutInSeconds)
                    });
                }

                if (location != null)
                {
                    // Центрування карти на місцезнаходження користувача
                    var userPosition = new Position(location.Latitude, location.Longitude);
                    UserMap.MoveToRegion(MapSpan.FromCenterAndRadius(userPosition, Distance.FromKilometers(1)));

                    // Додавання маркера
                    UserMap.Pins.Add(new Pin
                    {
                        Label = "Ви тут",
                        Address = "Ваше поточне місцезнаходження",
                        Position = userPosition
                    });
                }
                else
                {
                    await DisplayAlert("Помилка", "Не вдалося отримати місцезнаходження.", "OK");
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Помилка", $"Щось пішло не так: {ex.Message}", "OK");
            }
        }
    }
}
