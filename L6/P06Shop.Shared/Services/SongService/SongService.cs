 
using Microsoft.Extensions.Options;
using Microsoft.VisualBasic.FileIO;
using Newtonsoft.Json;
using P06Shop.Shared.SongModel;
using P06Shop.Shared;
using P06Shop.Shared.Configuration;
using P06Shop.Shared.Shop;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace P06Shop.Shared.Services.SongService
{
    public class SongService : ISongService
    {

        private readonly HttpClient _httpClient;
        private readonly AppSettings _appSettings;

        public SongService(HttpClient httpClient, IOptions<AppSettings> appSettings)
        {
            _httpClient = httpClient;
            _appSettings = appSettings.Value;
        }

        public async Task<ServiceResponse<Song>> CreateSongAsync(Song song)
        {
            var response = await _httpClient.PostAsJsonAsync(_appSettings.BaseSongEndpoint.CreateSongEndpoint, song);
            var result = await response.Content.ReadFromJsonAsync<ServiceResponse<Song>>();
            return result;
        }

        public async Task<ServiceResponse<bool>> DeleteSongByIdAsync(int id)
        {
            // jesli uzyjemy / na poczatku to wtedy sciezka trakktowana jest od root czyli pomija czesc środkową adresu 
            // zazwyczaj unikamy stosowania / na poczatku 
            var response = await _httpClient.DeleteAsync($"{id}");
            var result = await response.Content.ReadFromJsonAsync<ServiceResponse<bool>>();
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
            if (!response.IsSuccessStatusCode)
                return new ServiceResponse<List<Song>>
                {
                    Success = false,
                    Message = "HTTP request failed"
                };

            var json = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<ServiceResponse<List<Song>>>(json)
                         ?? new ServiceResponse<List<Song>> { Success = false, Message = "Deserialization failed" };

            result.Success = result.Success && result.Data != null;

            return result;
        }

        public async Task<ServiceResponse<Song>> GetSongByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync(id.ToString());
            if (!response.IsSuccessStatusCode)
                return new ServiceResponse<Song>
                {
                    Success = false,
                    Message = "HTTP request failed"
                };

            var json = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<ServiceResponse<Song>>(json)
                         ?? new ServiceResponse<Song> { Success = false, Message = "Deserialization failed" };

            result.Success = result.Success && result.Data != null;

            return result;
        }


        // wersja 1 
        //public async Task<ServiceResponse<Product>> UpdateProductAsync(Product product)
        //{
        //    var response = await _httpClient.PutAsJsonAsync(_appSettings.BaseProductEndpoint.GetAllProductsEndpoint, product);
        //    var json = await response.Content.ReadAsStringAsync();
        //    var result = JsonConvert.DeserializeObject<ServiceResponse<Product>>(json);
        //    return result;
        //}

        // wersja 2 
        public async Task<ServiceResponse<Song>> UpdateSongAsync(Song song)
        {
            var response = await _httpClient.PutAsJsonAsync(_appSettings.BaseSongEndpoint.UpdateSongEndpoint, song);
            var result = await response.Content.ReadFromJsonAsync<ServiceResponse<Song>>();
            return result;
        }

        public async Task<ServiceResponse<List<Song>>> SearchSongsAsync(string text, int page, int pageSize)
        {

            try
            {
                string searchUrl = string.IsNullOrWhiteSpace(text) ? "" : $"/{text}";
                var response = await _httpClient.GetAsync(_appSettings.BaseSongEndpoint.SearchSongsEndpoint +
                                                          searchUrl + $"/{page}/{pageSize}");
                if (!response.IsSuccessStatusCode)
                    return new ServiceResponse<List<Song>>
                    {
                        Success = false,
                        Message = "HTTP request failed"
                    };

                var json = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<ServiceResponse<List<Song>>>(json)
                             ?? new ServiceResponse<List<Song>>
                                 { Success = false, Message = "Deserialization failed" };

                result.Success = result.Success && result.Data != null;

                return result;
            }
            catch (JsonException)
            {
                return new ServiceResponse<List<Song>>
                {
                    Success = false,
                    Message = "Cannot deserialize data"
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return new ServiceResponse<List<Song>>
                {
                    Success = false,
                    Message = "Network error"
                };
            }
        }
    }
}
