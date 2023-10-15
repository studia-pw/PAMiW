using System.Windows.Controls.Primitives;

namespace P04WeatherForecastAPI.Client.Models
{
    internal class Forecast
    {
        public DailyForecast[] DailyForecasts { get; set; }

        public Headline Headline { get; set; }

    }
}
