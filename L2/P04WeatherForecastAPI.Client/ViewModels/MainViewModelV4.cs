using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using P04WeatherForecastAPI.Client.Commands;
using P04WeatherForecastAPI.Client.DataSeeders;
using P04WeatherForecastAPI.Client.Models;
using P04WeatherForecastAPI.Client.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace P04WeatherForecastAPI.Client.ViewModels
{
    // przekazywanie wartosci do innego formularza 
    public partial class MainViewModelV4 : ObservableObject
    {
        private CityViewModel _selectedCity;
        private Weather _weather;
        private readonly IAccuWeatherService _accuWeatherService;
        private readonly FavoriteCitiesView _favoriteCitiesView;
        private readonly FavoriteCityViewModel _favoriteCityViewModel;
        //public ICommand LoadCitiesCommand { get;  }


        public MainViewModelV4(IAccuWeatherService accuWeatherService, FavoriteCityViewModel favoriteCityViewModel, FavoriteCitiesView favoriteCitiesView)
        {
            _favoriteCitiesView = favoriteCitiesView;
            _favoriteCityViewModel = favoriteCityViewModel;
            // _serviceProvider= serviceProvider; 
            //LoadCitiesCommand = new RelayCommand(x => LoadCities(x as string));
            _accuWeatherService = accuWeatherService;
            Cities = new ObservableCollection<CityViewModel>(); // podejście nr 2 
            Regions = new ObservableCollection<RegionViewModel>(); // podejście nr 2 
            Top50Cities = new ObservableCollection<Top50CitiesViewModel>();
            Top50CitiesConditions = new ObservableCollection<Top50CitiesConditionsViewModel>();
        }

        //[ObservableProperty]
        //private WeatherViewModel weatherView;
        //public WeatherViewModel WeatherView { 
        //    get { return weatherView; } 
        //    set { 
        //        weatherView = value;
        //        OnPropertyChanged();
        //    }
        //}
        [ObservableProperty]
        private WeatherViewModel weatherView;

        [ObservableProperty]
        private CityInfoViewModel cityInfoView;


        public CityViewModel SelectedCity
        {
            get => _selectedCity;
            set
            {
                _selectedCity = value;
                OnPropertyChanged();
                LoadWeather();
                LoadCityInfo();
            }
        }

         
        private async void LoadWeather()
        {
            if(SelectedCity != null)
            {
                _weather = await _accuWeatherService.GetCurrentConditions(SelectedCity.Key); 
                WeatherView = new WeatherViewModel(_weather);
            }
        } 

        private async void LoadCityInfo() {
            if (_selectedCity != null) {
                var info = await _accuWeatherService.GetCityInfo(_selectedCity.Key);
                CityInfoView = new CityInfoViewModel(info);
            }
        }

        // podajście nr 2 do przechowywania kolekcji obiektów:
        public ObservableCollection<CityViewModel> Cities { get; set; }

        [RelayCommand]
        public async void LoadCities(string locationName)
        {
            // podejście nr 2:
            var cities = await _accuWeatherService.GetLocations(locationName);
            Cities.Clear();
            foreach (var city in cities) 
                Cities.Add(new CityViewModel(city));
        }

        public ObservableCollection<RegionViewModel> Regions { get; set; }

        [RelayCommand]
        public async void LoadRegions()
        {
            var regions = await _accuWeatherService.GetRegionList();
            Regions.Clear();
            foreach (var region in regions) {
                Regions.Add(new RegionViewModel(region));
            }

        }

        public ObservableCollection<Top50CitiesViewModel> Top50Cities { get; set; }

        [RelayCommand]
        public async void LoadTop50Cities() {
            var top50 = await _accuWeatherService.GetTop50Cities();
            Top50Cities.Clear();
            foreach (var city in top50) {
                Top50Cities.Add(new Top50CitiesViewModel(city));
            }

        }

        public ObservableCollection<Top50CitiesConditionsViewModel> Top50CitiesConditions { get; set; }

        [RelayCommand]
        public async void LoadTop50CitiesConditions()
        {
            var top50 = await _accuWeatherService.GetTop50CitiesCurrentConditions();
            Top50CitiesConditions.Clear();
            foreach (var city in top50) {
                Top50CitiesConditions.Add(new Top50CitiesConditionsViewModel(city));
            }
        }

        [ObservableProperty]
        private ForecastViewModel forecastView;

        [RelayCommand]
        public async void LoadForecast() 
        {
            if (_selectedCity == null) return;
            var forecast = await _accuWeatherService.GetCity1DayForecast(_selectedCity.Key);
            ForecastView = new ForecastViewModel(forecast);
        }

        [RelayCommand]
        public void OpenFavotireCities()
        {
            //var favoriteCitiesView = new FavoriteCitiesView();
            _favoriteCityViewModel.SelectedCity = new FavoriteCity() { Name = "Warsaw" };
            _favoriteCitiesView.Show();
        }
    }
}
