using CommunityToolkit.Mvvm.ComponentModel;
using P04WeatherForecastAPI.Client.Models;

namespace P04WeatherForecastAPI.Client.ViewModels
{
    public class CityInfoViewModel
    {
        public string LocalizedName { get; set; }

        public string LocalizedCountryName { get; set; }

        public double Population { get; set; }

        public CityInfoViewModel(CityInfo cityInfo) {
            LocalizedName = cityInfo.LocalizedName;
            LocalizedCountryName = cityInfo.Country.LocalizedName;
            Population = cityInfo.Details.Population;
        }
    }
}