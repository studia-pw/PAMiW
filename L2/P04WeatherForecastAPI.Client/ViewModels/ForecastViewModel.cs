using System.Linq;
using CommunityToolkit.Mvvm.ComponentModel;
using P04WeatherForecastAPI.Client.Models;

namespace P04WeatherForecastAPI.Client.ViewModels
{
    public class ForecastViewModel
    {
        public string HeadlineText { get; set; }

        public Temperature Temperature { get; set; }

        public ForecastViewModel(Forecast forecast) {
            HeadlineText = forecast.Headline.Text;
            Temperature = forecast.DailyForecasts.First<DailyForecast>().Temperature;
        }
    }
}