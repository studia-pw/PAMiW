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
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

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

        public async Task<ServiceResponse<Song>> CreateSongAsync(Song song)
        {
            var response = await _httpClient.PostAsJsonAsync(_appSettings.BaseSongEndpoint.CreateSongEndpoint, song);
            var result = await response.Content.ReadFromJsonAsync<ServiceResponse<Song>>();
            return result;
        }

        public async Task<ServiceResponse<bool>> DeleteSongByIdAsync(long id)
        {
            var URI = string.Format(_appSettings.BaseSongEndpoint.DeleteSongEndpoint, id.ToString());
            var response = await _httpClient.DeleteAsync(URI);
            var result = await response.Content.ReadFromJsonAsync<ServiceResponse<bool>>();
            return result;
        }

        public async Task<ServiceResponse<Song>> GetSongByIdAsync(long id)
        {
            var url = _appSettings.BaseSongEndpoint.GetSongEndpoint.Replace("{id}", id.ToString());

            var response = await _httpClient.GetAsync(url);
            var result = await response.Content.ReadFromJsonAsync<ServiceResponse<Song>>();
            return result;
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

        public async Task<ServiceResponse<Song>> UpdateSongAsync(Song song)
        {
            var response = await _httpClient.PutAsJsonAsync(_appSettings.BaseSongEndpoint.UpdateSongEndpoint, song);
            var result = await response.Content.ReadFromJsonAsync<ServiceResponse<Song>>();
            return result;
        }
    }
}
