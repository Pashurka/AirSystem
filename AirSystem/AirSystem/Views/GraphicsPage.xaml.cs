using System;
using Xamarin.Forms;
using Microcharts;
using SkiaSharp;
using System.Collections.Generic;

namespace AirSystem.Views
{
    public partial class GraphicsPage : ContentPage
    {
        public GraphicsPage()
        {
            InitializeComponent();
            LoadTemperatureChart();
            LoadHumidityChart();
            LoadPressureChart();
        }

        private void LoadTemperatureChart()
        {
            var temperatures = new List<int> { 3, 6, 7, 9, 7, 8, 6 };
            var dates = new List<string>
            {
                "21.02", "22.02", "23.02", "24.02", "25.02", "26.02", "27.02"
            };

            var entries = new List<Microcharts.ChartEntry>();

            for (int i = 0; i < temperatures.Count; i++)
            {
                entries.Add(new Microcharts.ChartEntry(temperatures[i])
                {
                    Label = dates[i],
                    ValueLabel = temperatures[i].ToString(),
                    Color = SKColor.Parse("#3498db")
                });
            }

            TemperatureChart.Chart = new LineChart
            {
                Entries = entries,
                LineMode = LineMode.Straight,
                LineSize = 5,
                PointMode = PointMode.Circle,
                PointSize = 10,
                BackgroundColor = SKColors.Transparent
            };
        }

        private void LoadHumidityChart()
        {
            var humidities = new List<int> { 85, 86, 88, 91, 93, 89, 86 };
            var dates = new List<string>
            {
                "21.02", "22.02", "23.02", "24.02", "25.02", "26.02", "27.02"
            };

            var entries = new List<Microcharts.ChartEntry>();

            for (int i = 0; i < humidities.Count; i++)
            {
                entries.Add(new Microcharts.ChartEntry(humidities[i])
                {
                    Label = dates[i],
                    ValueLabel = humidities[i].ToString(),
                    Color = SKColor.Parse("#3498db")
                });
            }

            HumidityChart.Chart = new LineChart
            {
                Entries = entries,
                LineMode = LineMode.Straight,
                LineSize = 5,
                PointMode = PointMode.Circle,
                PointSize = 10,
                BackgroundColor = SKColors.Transparent
            };
        }

        private void LoadPressureChart()
        {
            var pressures = new List<int> { 765, 761, 758, 757, 760, 764, 760 };
            var dates = new List<string>
            {
                "21.02", "22.02", "23.02", "24.02", "25.02", "26.02", "27.02"
            };

            var entries = new List<Microcharts.ChartEntry>();

            for (int i = 0; i < pressures.Count; i++)
            {
                entries.Add(new Microcharts.ChartEntry(pressures[i])
                {
                    Label = dates[i],
                    ValueLabel = pressures[i].ToString(),
                    Color = SKColor.Parse("#3498db")
                });
            }

            PressureChart.Chart = new LineChart
            {
                Entries = entries,
                LineMode = LineMode.Straight,
                LineSize = 5,
                PointMode = PointMode.Circle,
                PointSize = 10,
                BackgroundColor = SKColors.Transparent
            };
        }
    }
}
