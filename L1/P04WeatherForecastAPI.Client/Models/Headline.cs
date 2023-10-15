using System.Windows.Controls.Primitives;

namespace P04WeatherForecastAPI.Client.Models
{
    internal class Headline {
        public long EffectiveEpochDate { get; set; }

        public int Severity { get; set; }
        public string Text { get; set; }


    }
}
