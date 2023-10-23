using System.Collections.Generic;
using CommunityToolkit.Mvvm.ComponentModel;
using P04WeatherForecastAPI.Client.Models;

namespace P04WeatherForecastAPI.Client.ViewModels
{
    public class Top50CitiesViewModel
    {
        public string LocalizedName { get; set; }

        public string LocalizedCountryName { get; set; }
        public string LocalizedRegionName { get; set; }

        public Top50CitiesViewModel(City city) {
            LocalizedName = city.LocalizedName;
            LocalizedCountryName = city.Country.LocalizedName;
            LocalizedRegionName = city.Region.LocalizedName;
        }
    }
}