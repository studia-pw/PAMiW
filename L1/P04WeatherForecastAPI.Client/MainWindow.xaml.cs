﻿using P04WeatherForecastAPI.Client.Models;
using P04WeatherForecastAPI.Client.Services;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Resources;
using System.Windows.Shapes;

namespace P04WeatherForecastAPI.Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        AccuWeatherService accuWeatherService;
        public MainWindow()
        {
            InitializeComponent();
            accuWeatherService = new AccuWeatherService();
        }

        private async void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            
            City[] cities = await accuWeatherService.GetLocations(txtCity.Text);

            // standardowy sposób dodawania elementów
            //lbData.Items.Clear();
            //foreach (var c in cities)
            //    lbData.Items.Add(c.LocalizedName);

            // teraz musimy skorzystac z bindowania danych bo chcemy w naszej kontrolce przechowywac takze id miasta 
            lbData.ItemsSource = cities;
        }

        private async void lbData_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedCity = (City)lbData.SelectedItem;
            if (selectedCity != null)
            {
                var weather = await accuWeatherService.GetCurrentConditions(selectedCity.Key);
                lblCityName.Content = selectedCity.LocalizedName;
                double tempValue = weather.Temperature.Metric.Value;
                lblTemperatureValue.Content = Convert.ToString(tempValue);

                CityInfo cityInfo = await accuWeatherService.GetCityInfo(selectedCity.Key);

                lblCountryName.Content = cityInfo.Country.LocalizedName;


                if (cityInfo.Details.Population != null) {
                    lblPopulation.Content = Convert.ToString(cityInfo.Details.Population);
                }
            }
        }

        private async void btnTop50Cities_Click(object sender, RoutedEventArgs e) {
            City[] cities = await accuWeatherService.GetTop50Cities();

            List<BindindTop50> bindingTop50s = new List<BindindTop50>();

            foreach (City city in cities) {
                bindingTop50s.Add(new BindindTop50 {
                    Property1 = city.LocalizedName,
                    Property2 = city.Country.LocalizedName,
                    Property3 = city.Region.LocalizedName
                });
            }

            lbData1.ItemsSource = bindingTop50s;
        }

          private async void btnForecast_Click(object sender, RoutedEventArgs e) {
            var selectedCity = (City)lbData.SelectedItem;
            if (selectedCity != null) {
                Forecast forecast = await accuWeatherService.GetCity1DayForecast(selectedCity.Key);
                lblForecastText.Text = forecast.Headline.Text;
                var temps = new {
                    minTemp = forecast.DailyForecasts.FirstOrDefault().Temperature.Minimum.Value,
                    maxTemp = forecast.DailyForecasts.FirstOrDefault().Temperature.Maximum.Value
                };
                DataContext = temps;
            }

        }

        private async void btnTop50CitiesConditions_Click(object sender, RoutedEventArgs e) {
            TopCitiesConditions[] cities = await accuWeatherService.GetTop50CitiesCurrentConditions();

            List<BindindTop50> bindingTop50s = new List<BindindTop50>();

            foreach (TopCitiesConditions city in cities) {
                bindingTop50s.Add(new BindindTop50 {
                    Property1 = city.LocalizedName,
                    Property2 = city.Country.LocalizedName,
                    Property3 = Convert.ToString(city.Temperature.Metric.Value)
                });
            }

            lbData2.ItemsSource = bindingTop50s;
        }

          private async void btnRegionList_Click(object sender, RoutedEventArgs e) {
            Region[] regions = await accuWeatherService.GetRegionList();


            lbData3.ItemsSource = regions;
        }

    }
}
