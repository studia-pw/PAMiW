using System.Windows.Controls.Primitives;

namespace P04WeatherForecastAPI.Client.Models
{
    public class Forecast
    {
        public DailyForecast[] DailyForecasts { get; set; }

        public Headline Headline { get; set; }

    }
}
