using System.Collections.Generic;
using CommunityToolkit.Mvvm.ComponentModel;
using P04WeatherForecastAPI.Client.Models;

namespace P04WeatherForecastAPI.Client.ViewModels
{
    public class Top50CitiesConditionsViewModel
    {
        public string LocalizedName { get; set; }

        public string LocalizedCountryName { get; set; }

        public double Temperature { get; set; }

        public Top50CitiesConditionsViewModel(TopCitiesConditions city) {
            LocalizedName = city.LocalizedName;
            LocalizedCountryName = city.Country.LocalizedName;
            Temperature = city.Temperature.Metric.Value;
        }
    }
}