using System; // Бібліотека для основних типів та класів
using System.Net.Http; // Бібліотека для виконання HTTP-запитів
using System.Threading.Tasks; // Бібліотека для роботи з асинхронними операціями

using Newtonsoft.Json; // Бібліотека для роботи з JSON
using AirSystem.Models; // Простір імен з моделями

namespace AirSystem.Services
{
    // Сервіс для отримання даних про рівень пилку
    public class PollenApiService
    {
        // Базова URL-адреса API
        private readonly string _baseUrl = "https://airquality.googleapis.com/v1/projects/airsystem-448620/locations/global/pollen";

        // Ключ доступу до API
        private readonly string _apiKey = "AIzaSyDUXBLx5k6cy-yokt0xexvcuG22cH08Nhw";

        // Метод для отримання даних про рівень пилку на основі широти та довготи
        public async Task<PollenInfo> GetPollenDataAsync(double latitude, double longitude)
        {
            using (HttpClient client = new HttpClient())
            {
                // var url = $"{_baseUrl}?lat={latitude}&lon={longitude}&key={_apiKey}";
                var url = "https://pollen.googleapis.com/v1/forecast:lookup?key=AIzaSyDUXBLx5k6cy-yokt0xexvcuG22cH08Nhw&location.longitude=35.32&location.latitude=32.32&days=1";
                HttpResponseMessage response = await client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<PollenInfo>(json); // Десеріалізація JSON
                }
                else
                {
                    throw new Exception($"API Error: {response.StatusCode}");
                }
            }
        }
    }
}
