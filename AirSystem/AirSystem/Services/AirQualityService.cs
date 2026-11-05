using System.Net.Http; // Бібліотека для виконання HTTP-запитів
using System.Threading.Tasks; // Бібліотека для роботи з асинхронними операціями
using Newtonsoft.Json; // Бібліотека для роботи з JSON
using Xamarin.Forms; // Бібліотека для побудови мобільних додатків на основі Xamarin

namespace AirSystem.Services
{
    // Сервіс для отримання даних про якість повітря
    public class AirQualityService
    {
        private readonly string _baseUrl = "https://airquality.googleapis.com/v1"; // Базова URL-адреса API
        private readonly string _apiKey = "AIzaSyDUXBLx5k6cy-yokt0xexvcuG22cH08Nhw"; // Ключ доступу до API

        // Метод для отримання даних про якість повітря на основі широти та довготи
        public async Task<AirQualityResponse> GetAirQualityAsync(double latitude, double longitude)
        {
            using (HttpClient client = new HttpClient()) // Ініціалізація HTTP-клієнта
            {
                // Формування повного URL для запиту
                // var url = $"{_baseUrl}?lat={latitude}&lon={longitude}&key={_apiKey}";
                var url = "https://airquality.googleapis.com/v1/currentConditions:lookup?key=AIzaSyDUXBLx5k6cy-yokt0xexvcuG22cH08Nhw&lat=37.419734&lng=-122.0827784";

                var response = await client.GetAsync(url); // Виконання GET-запиту до API

                if (response.IsSuccessStatusCode) // Перевірка на успішність відповіді
                {
                    var json = await response.Content.ReadAsStringAsync(); // Зчитування JSON-відповіді
                    // Десеріалізація JSON у модель AirQualityResponse
                    return JsonConvert.DeserializeObject<AirQualityResponse>(json);
                }
                else
                {
                    // Генерація виключення у випадку помилки API
                    throw new HttpRequestException($"API error: {response.StatusCode}");
                }
            }
        }
    }

    // Модель для представлення відповіді API
    public class AirQualityResponse
    {
        public string Status { get; set; } // Статус відповіді API
        public Data Data { get; set; } // Дані про якість повітря
    }

    // Модель для представлення даних про якість повітря
    public class Data
    {
        public int AQI { get; set; } // Індекс якості повітря (Air Quality Index)
        public string MainPollutant { get; set; } // Головний забруднювач
    }
}
