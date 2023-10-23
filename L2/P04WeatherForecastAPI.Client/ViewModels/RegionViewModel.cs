using CommunityToolkit.Mvvm.ComponentModel;
using P04WeatherForecastAPI.Client.Models;

namespace P04WeatherForecastAPI.Client.ViewModels
{
    public class RegionViewModel
    {
        public string ID { get; set; }
        public string LocalizedName { get; set; }

        public RegionViewModel(Region region) {
            ID = region.ID;
            LocalizedName = region.LocalizedName;
        }
    }
}