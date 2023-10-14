using System.Windows.Controls.Primitives;

namespace P04WeatherForecastAPI.Client.Models
{
    internal class CityInfo
    {
        public string Key { get; set; }
        public string LocalizedName { get; set; }
        public City ParentCity { get; set; }

        public Details Details { get; set; }

        public GeoPosition GeoPosition { get; set; }

    }
}
