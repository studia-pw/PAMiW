using Microsoft.EntityFrameworkCore;
using P05Shop.API.Models;
using P06Shop.Shared;
using P06Shop.Shared.Services.ProductService;
using P06Shop.Shared.Services.SongService;
using P06Shop.Shared.Shop;
using P06Shop.Shared.SongModel;
using P07Shop.DataSeeder;
using System.Runtime.InteropServices;

namespace P05Shop.API.Services.SongService
{
    public class SongService : ISongService
    {

        private readonly DataContext _dataContext;
        private bool _songSeederError;

        public SongService(DataContext dataContext) 
        {
            _songSeederError = false;
            _dataContext = dataContext;
        }

        public async Task<ServiceResponse<List<Song>>> GetSongsAsync()
        {
            try
            {
                var songs = await _dataContext.Songs.ToListAsync();
                var response = new ServiceResponse<List<Song>>()
                {
                    Data = songs,
                    Message = "Ok",
                    Success = true
                };

                return response;
            }
            catch (Exception ex)
            {
                return new  ServiceResponse<List<Song>>()
                {
                    Data = null,
                    Message = "Problem getting the songs",
                    Success = false
                };
            }
        }

        public async Task<ServiceResponse<Song>> CreateSongAsync(Song song)
        {
            try
            {
                await _dataContext.AddAsync(song);
                await _dataContext.SaveChangesAsync();

                var response = new ServiceResponse<Song>()
                {
                    Data = null,
                    Message = "OK",
                    Success = true
                };

                return response;
            }
            catch (Exception) 
            {
                var response = new ServiceResponse<Song>()
                {
                    Data = null,
                    Message = "Cannot add song",
                    Success = false
                };

                return response;
            }
        }

        public async Task<ServiceResponse<bool>> DeleteSongByIdAsync(int id)
        {
            var toDelete = _dataContext.Songs.Find(id);
            if (toDelete != null)
            {
                _dataContext.Songs.Remove(toDelete);
                await _dataContext.SaveChangesAsync();

                var response = new ServiceResponse<bool>()
                {
                    Data = true,
                    Message = "OK",
                    Success = true
                };

                return response;
            } 
            else 
            {
                var response = new ServiceResponse<bool>()
                {
                    Data = false,
                    Message = "Movie doesn't exist",
                    Success = false
                };

                return response;
            }
        }


        public async Task<ServiceResponse<Song>> GetSongByIdAsync(int id)
        {
            try 
            {
                var song = _dataContext.Songs.Find(id);
                if (song == null)
                {
                    return new ServiceResponse<Song>()
                    {
                        Data = null,
                        Message = "Song not found",
                        Success = false
                    };
                }
                else 
                {
                    return new ServiceResponse<Song>()
                    {
                        Data = song,
                        Message = "OK",
                        Success = true
                    };
                }
            }
            catch (Exception)
            {
                return new ServiceResponse<Song>()
                {
                    Data = null,
                    Message = "Problem with dataseeder library",
                    Success = false
                };
            }
        }

        public async Task<ServiceResponse<Song>> UpdateSongAsync(Song song)
        {
            var toUpdate = _dataContext.Songs.Find(song.Id);
            if (toUpdate != null)
            {
                
                updateSongFromUpdateRequest(toUpdate, song);
                await _dataContext.SaveChangesAsync();

                var response = new ServiceResponse<Song>()
                {
                    Data = toUpdate,
                    Message = "OK",
                    Success = true
                };

                return response;
            }
            else
            {
                var response = new ServiceResponse<Song>()
                {
                    Data = null,
                    Message = "Song doesn't exist",
                    Success = false
                };

                return response;
            }
        }


        public async Task<ServiceResponse<List<Song>>> SearchSongsAsync(string text, int page, int pageSize)
        {
            IQueryable<Song> query = _dataContext.Songs;

            if (!string.IsNullOrEmpty(text))
                query = query.Where(x => x.Title.Contains(text) || x.Artist.Contains(text));

        var songs = await query
                .Skip(pageSize * (page - 1))
                .Take(pageSize)
                .ToListAsync();
            
            try
            {
                var response = new ServiceResponse<List<Song>>()
                {
                    Data = songs,
                    Message = "Ok",
                    Success = true
                };

                return response;
            }
            catch (Exception)
            {
                return new ServiceResponse<List<Song>>()
                {
                    Data = null,
                    Message = "Problem with database",
                    Success = false
                };
            }
        }

        private void updateSongFromUpdateRequest(Song song, Song songReq)
        {
            if (!string.IsNullOrWhiteSpace(songReq.Artist))
            {
                song.Artist = songReq.Artist;
            }

            if (songReq.Duration > 0) {
                song.Duration = songReq.Duration;
            }

            if (!string.IsNullOrWhiteSpace(songReq.AlbumTitle))
            {
                song.AlbumTitle = songReq.AlbumTitle;
            }

            if (!string.IsNullOrWhiteSpace(songReq.Title))
            {
                song.Title = songReq.Title;
            }
        }
        
    }
}
