using CommunityToolkit.Mvvm.ComponentModel;
using P04WeatherForecastAPI.Client.Models;
using P04WeatherForecastAPI.Client.Services.WeatherServices;
using P06Shop.Shared.Services.ProductService;
using P06Shop.Shared.Services.SongService;
using P06Shop.Shared.Shop;
using P06Shop.Shared.SongModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace P04WeatherForecastAPI.Client.ViewModels
{
    public partial class SongViewModel : ObservableObject
    {
        private readonly ISongService _songService;

        public ObservableCollection<Song> Songs { get; set; }

        public SongViewModel(ISongService songService)
        {
            _songService = songService;
            Songs = new ObservableCollection<Song>();          
        }

        public async void GetSongs()
        {
            var songsResult = await _songService.GetSongsAsync();
            if (songsResult.Success)
            {
                foreach (var p in songsResult.Data)
                {
                    Songs.Add(p);
                }
            }
        }

    }
}
