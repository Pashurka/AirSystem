using AirSystem.ViewModels;
using Xamarin.Forms;

namespace AirSystem.Views
{
    public partial class WeatherPage : ContentPage
    {
        private readonly WeatherViewModel _viewModel;

        public WeatherPage()
        {
            InitializeComponent();
            _viewModel = new WeatherViewModel();
            BindingContext = _viewModel;

            // Генерація випадкових даних
            _viewModel.GenerateRandomValues();
        }
    }
}
