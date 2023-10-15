using System.Windows.Controls.Primitives;

namespace P04WeatherForecastAPI.Client.Models
{
    internal class DailyForecast
    {
        public Temperature Temperature { get; set; }

        public long EpochDate { get; set; }

    }
}
