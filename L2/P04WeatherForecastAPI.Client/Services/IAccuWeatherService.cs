using System.Threading.Tasks;
using P04WeatherForecastAPI.Client.Models;

namespace P04WeatherForecastAPI.Client.Services
{
    public interface IAccuWeatherService
    {
        Task<City[]> GetLocations(string locationName);

        Task<Weather> GetCurrentConditions(string cityKey);

        Task<City[]> GetTop50Cities();

        Task<CityInfo> GetCityInfo(string cityKey);

        Task<Forecast> GetCity1DayForecast(string cityKey);

        Task<TopCitiesConditions[]> GetTop50CitiesCurrentConditions();

        Task<Region[]> GetRegionList();
    }
}