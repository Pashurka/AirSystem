using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace AirSystem.ViewModels
{
    public class WeatherViewModel : INotifyPropertyChanged
    {
        private string _country;
        private string _city;
        private string _nearestStation;
        private string _humidity;
        private string _temperature;
        private string _pressure;
        private string _airQuality;
        private string _recommendations;

        public string Country
        {
            get => _country;
            set => SetProperty(ref _country, value);
        }

        public string City
        {
            get => _city;
            set => SetProperty(ref _city, value);
        }

        public string NearestStation
        {
            get => _nearestStation;
            set => SetProperty(ref _nearestStation, value);
        }

        public string Humidity
        {
            get => _humidity;
            set => SetProperty(ref _humidity, value);
        }

        public string Temperature
        {
            get => _temperature;
            set => SetProperty(ref _temperature, value);
        }

        public string Pressure
        {
            get => _pressure;
            set => SetProperty(ref _pressure, value);
        }

        public string AirQuality
        {
            get => _airQuality;
            set => SetProperty(ref _airQuality, value);
        }

        public string Recommendations
        {
            get => _recommendations;
            set => SetProperty(ref _recommendations, value);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected bool SetProperty<T>(ref T backingField, T value, [CallerMemberName] string propertyName = null)
        {
            if (Equals(backingField, value)) return false;
            backingField = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        // Генерація випадкових значень
        public void GenerateRandomValues()
        {
            var random = new Random();

            Country = new[] { "Україна", "США", "Канада", "Німеччина", "Японія" }[random.Next(5)];
            City = new[] { "Київ", "Львів", "Одеса", "Харків", "Дніпро" }[random.Next(5)];
            NearestStation = $"Станція {random.Next(1, 100)}";
            Humidity = $"{random.Next(30, 55)}%";
            Temperature = $"{random.Next(-1, 4)}°C";
            Pressure = $"{random.Next(750, 780)} мм рт. ст.";
            AirQuality = $"{random.Next(35, 60)} AQI";
            Recommendations = new[]
            {
                "Уникайте прогулянок у спеку.",
                "Візьміть парасольку.",
                "Носіть захисну маску.",
                "Пийте більше води.",
                "Вдягайте теплий одяг."
            }[random.Next(5)];
        }
    }
}
