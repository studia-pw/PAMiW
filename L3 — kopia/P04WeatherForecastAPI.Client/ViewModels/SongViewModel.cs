using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using P04WeatherForecastAPI.Client.Models;
using P04WeatherForecastAPI.Client.Services.WeatherServices;
using P06Shop.Shared.MessageBox;
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
using System.Windows.Input;

namespace P04WeatherForecastAPI.Client.ViewModels
{
    public partial class SongViewModel : ObservableObject
    {
        private readonly ISongService _songService;
        private readonly SongDetailsView _songDetailsView;
        private readonly IMessageDialogService _messageDialogService;

        [ObservableProperty]
        private Song selectedSong;

        public ObservableCollection<Song> Songs { get; set; }

        public SongViewModel(ISongService songService, SongDetailsView songDetailsView, IMessageDialogService messageDialogService)
        {
            _messageDialogService = messageDialogService;
            _songService = songService;
            _songDetailsView = songDetailsView;
            Songs = new ObservableCollection<Song>();
        }

        public async Task GetSongs()
        {
            Songs.Clear();
            var songsResult = await _songService.GetSongsAsync();
            if (songsResult.Success)
            {
                foreach (var p in songsResult.Data)
                {
                    Songs.Add(p);
                }
            }
        }

        public async Task CreateSong()
        {
            var newSong = new Song()
            {
                Title = selectedSong.Title,
                AlbumTitle = selectedSong.AlbumTitle,
                Artist = selectedSong.Artist,
                Duration = selectedSong.Duration,
                ReleaseDate = selectedSong.ReleaseDate,
            };

            var result = await _songService.CreateSongAsync(newSong);
            if (result.Success)
                await GetSongs();
            else
                _messageDialogService.ShowMessage(result.Message);
        }

        public async Task UpdateSong()
        {
            var songToUpdate = new Song()
            {
                Id = selectedSong.Id,
                Title = selectedSong.Title,
                AlbumTitle = selectedSong.AlbumTitle,
                Artist = selectedSong.Artist,
                Duration = selectedSong.Duration,
                ReleaseDate = selectedSong.ReleaseDate,
            };

            await _songService.UpdateSongAsync(songToUpdate);
            await GetSongs();
        }

        public async Task DeleteSong()
        {
            await _songService.DeleteSongByIdAsync(selectedSong.Id);
            await GetSongs();
        }


        [RelayCommand]
        public async Task Save()
        {
            if (selectedSong.Id == 0)
            {
                CreateSong();
            }
            else
            {
                UpdateSong();
            }

        }


        [RelayCommand]
        public async Task DeleteSongById(long id)
        {
            await _songService.DeleteSongByIdAsync(id);
        }

        [RelayCommand]
        public async Task New()
        {
            _songDetailsView.Show();
            _songDetailsView.DataContext = this;
            SelectedSong = new Song();
        }

        [RelayCommand]
        public async Task Delete()
        {
            DeleteSong();
        }

        [RelayCommand]
        public async Task ShowDetails(Song song)
        {
            _songDetailsView.Show();
            _songDetailsView.DataContext = this;
            //selectedProduct = product;
            //OnPropertyChanged("SelectedProduct");
            SelectedSong = song;
        }

        [RelayCommand]
        public void CreateSong(Song song)
        {
            _songService.CreateSongAsync(song);
        }
    }
}
