﻿using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using P04WeatherForecastAPI.Client.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace P04WeatherForecastAPI.Client.Services
{
    internal class AccuWeatherService
    {
        private const string base_url = "http://dataservice.accuweather.com";
        private const string autocomplete_endpoint = "locations/v1/cities/autocomplete?apikey={0}&q={1}&language={2}";
        private const string current_conditions_endpoint = "currentconditions/v1/{0}?apikey={1}&language={2}";
        private const string top_50_cities_endpoint = "locations/v1/topcities/50?apikey={0}&language={1}";
        private const string city_info_endpoint = "locations/v1/{0}?apikey={1}&language={2}&details={3}";

        private const string city_1day_forecast_endpoint = "forecasts/v1/daily/1day/{0}?apikey={1}&language={2}&metric=true";
        private const string top_50_cities_conditions_endpoint = "currentconditions/v1/topcities/{0}?apikey={1}&language={2}";
        private const string region_list_endpoint = "locations/v1/regions?apikey={0}&language={1}";

        // private const string api_key = "5hFl75dja3ZuKSLpXFxUzSc9vXdtnwG5";
        string api_key;
        //private const string language = "pl";
        string language;

        public AccuWeatherService()
        {
            var builder = new ConfigurationBuilder()
                .AddUserSecrets<App>()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsetings.json"); 

            var configuration = builder.Build();
            api_key = configuration["api_key"];
            language = configuration["default_language"];
        }


        public async Task<City[]> GetLocations(string locationName)
        {
            string uri = base_url + "/" + string.Format(autocomplete_endpoint, api_key, locationName, language);
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(uri);
                string json = await response.Content.ReadAsStringAsync();
                City[] cities = JsonConvert.DeserializeObject<City[]>(json);
                return cities;

            }
        }

        public async Task<Weather> GetCurrentConditions(string cityKey)
        {
            string uri = base_url + "/" + string.Format(current_conditions_endpoint, cityKey, api_key,language);
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(uri);
                string json = await response.Content.ReadAsStringAsync();
                Weather[] weathers= JsonConvert.DeserializeObject<Weather[]>(json);
                return weathers.FirstOrDefault();
            }
        }

        public async Task<City[]> GetTop50Cities()
        {
            string uri = base_url + "/" + string.Format(top_50_cities_endpoint, api_key, language);
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(uri);
                string json = await response.Content.ReadAsStringAsync();
                City[] cities = JsonConvert.DeserializeObject<City[]>(json);
                return cities;
            }
        }

        public async Task<CityInfo> GetCityInfo(string cityKey)
        {
            string uri = base_url + "/" + string.Format(city_info_endpoint, cityKey, api_key, language, true);
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(uri);
                string json = await response.Content.ReadAsStringAsync();
                CityInfo cityInfo = JsonConvert.DeserializeObject<CityInfo>(json);
                return cityInfo;
            }
        }

        public async Task<Forecast> GetCity1DayForecast(string cityKey)
        {
            string uri = base_url + "/" + string.Format(city_1day_forecast_endpoint, cityKey, api_key, language);
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(uri);
                string json = await response.Content.ReadAsStringAsync();
                Forecast forecast = JsonConvert.DeserializeObject<Forecast>(json);
                return forecast;
            }
        }

        public async Task<TopCitiesConditions[]> GetTop50CitiesCurrentConditions()
        {
            string uri = base_url + "/" + string.Format(top_50_cities_conditions_endpoint, 50, api_key, language);
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(uri);
                string json = await response.Content.ReadAsStringAsync();
                TopCitiesConditions[] conditions = JsonConvert.DeserializeObject<TopCitiesConditions[]>(json);
                return conditions;
            }
        }

        public async Task<Region[]> GetRegionList()
        {
            string uri = base_url + "/" + string.Format(region_list_endpoint, api_key, language);
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(uri);
                string json = await response.Content.ReadAsStringAsync();
                Region[] regions = JsonConvert.DeserializeObject<Region[]>(json);
                return regions;
            }
        }
    }
}
