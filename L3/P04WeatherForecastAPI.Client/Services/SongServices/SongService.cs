using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.VisualBasic.FileIO;
using Newtonsoft.Json;
using P04WeatherForecastAPI.Client.Configuration;
using P06Shop.Shared;
using P06Shop.Shared.Services.ProductService;
using P06Shop.Shared.Services.SongService;
using P06Shop.Shared.Shop;
using P06Shop.Shared.SongModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace P04WeatherForecastAPI.Client.Services.SongServices
{
    internal class SongService : ISongService
    {
        private readonly HttpClient _httpClient;
        private readonly AppSettings _appSettings;
        public SongService(HttpClient httpClient, IOptions<AppSettings> appSettings)
        {
            _httpClient= httpClient;
            _appSettings= appSettings.Value;
        }

        public Task<ServiceResponse<Song>> CreateSongAsync(Song song)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<bool>> DeleteMovieAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<Song>> GetSongByIdAsync(long id)
        {
            throw new NotImplementedException();
        }


        //// skopiowane z postmana 
        //public async Task<ServiceResponse<List<Product>>> GetProductsAsync()
        //{
        //    //var client = new HttpClient();   
        //    var request = new HttpRequestMessage(HttpMethod.Get, _appSettings.BaseProductEndpoint.GetAllProductsEndpoint);
        //    var response = await _httpClient.SendAsync(request);
        //    response.EnsureSuccessStatusCode();        
        //    var json = await response.Content.ReadAsStringAsync();
        //    var result = JsonConvert.DeserializeObject<ServiceResponse<List<Product>>>(json);
        //    return result;
        //}


        // alternatywny sposób pobierania danych 
        public async Task<ServiceResponse<List<Song>>> GetSongsAsync()
        {
            var response = await _httpClient.GetAsync(_appSettings.BaseSongEndpoint.GetAllSongsEndpoint);
            var json = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<ServiceResponse<List<Song>>>(json);
            return result;
        }

        public Task<ServiceResponse<Song>> UpdateSongAsync(Song song)
        {
            throw new NotImplementedException();
        }
    }
}
