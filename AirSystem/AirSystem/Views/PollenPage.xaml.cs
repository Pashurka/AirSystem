using AirSystem.Models;
using AirSystem.Services;
using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace AirSystem.Views
{
    public partial class PollenPage : ContentPage
    {
        private readonly PollenApiService _pollenApiService = new PollenApiService();

        public ObservableCollection<PollenTypeInfo> PollenData { get; set; }

        public PollenPage()
        {
            InitializeComponent();
            PollenData = new ObservableCollection<PollenTypeInfo>();
            PollenList.ItemsSource = PollenData;

            LoadDataAsync();
        }

        private async void LoadDataAsync()
        {
            try
            {
                var data = await _pollenApiService.GetPollenDataAsync(50.45, 30.52); // Київські координати
                if (data.DailyInfo != null && data.DailyInfo.Length > 0)
                {
                    foreach (var pollen in data.DailyInfo[0].PollenTypeInfo)
                    {
                        PollenData.Add(pollen);
                    }
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Помилка", $"Не вдалося завантажити дані: {ex.Message}", "OK");
            }
        }
    }
}
