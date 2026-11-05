using System;
using Xamarin.Forms;
using AirSystem.Services;
using Xamarin.Forms.Xaml;

namespace AirSystem.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AirQualityPage : ContentPage
    {

        private readonly AirQualityService _airQualityService;

        public AirQualityPage()
        {
            InitializeComponent();
            _airQualityService = new AirQualityService();
        }

        private async void OnRefreshClicked(object sender, EventArgs e)
        {
            try
            {
                var response = await _airQualityService.GetAirQualityAsync(50.4501, 30.5234);
                aqiLabel.Text = $"AQI: {response.Data.AQI}";
            }
            catch (Exception ex)
            {
                await DisplayAlert("Помилка", $"Не вдалося отримати дані: {ex.Message}", "ОК");
            }
        }
    }
}