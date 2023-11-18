using P06Shop.Shared;
using P06Shop.Shared.Services.ProductService;
using P06Shop.Shared.Services.SongService;
using P06Shop.Shared.Shop;
using P06Shop.Shared.SongModel;
using P07Shop.DataSeeder;

namespace P05Shop.API.Services.SongService
{
    public class SongService : ISongService
    {

        private List<Song> _songRepository { get; set; }
        private bool _songSeederError;

        public SongService() 
        {
            _songSeederError = false;

            try
            {
                _songRepository = SongSeeder.GenerateSongData();
            } catch (Exception e)
            {
                _songSeederError = true;
            }
        }

        public async Task<ServiceResponse<List<Song>>> GetSongsAsync()
        {
            if (!_songSeederError)
            {
                var response = new ServiceResponse<List<Song>>()
                {
                    Data = _songRepository,
                    Message = "Ok",
                    Success = true
                };

                return response;
            }
            else 
            {
                return new  ServiceResponse<List<Song>>()
                {
                    Data = null,
                    Message = "Problem with dataseeder library",
                    Success = false
                };
            }
        }

        public async Task<ServiceResponse<Song>> CreateSongAsync(Song song)
        {
            if (!CheckIfSongExistsById(song.Id))
            {
                _songRepository.Add(song);

                var response = new ServiceResponse<Song>()
                {
                    Data = song,
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
                    Message = "Song already exists",
                    Success = false
                };

                return response;
            }
        }

        public async Task<ServiceResponse<bool>> DeleteMovieAsync(long id)
        {
            if (CheckIfSongExistsById(id))
            {
                _songRepository = _songRepository.Where(x => x.Id != id).ToList();

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


        public async Task<ServiceResponse<Song>> GetSongByIdAsync(long id)
        {
            try 
            {
                var song = _songRepository.Where(x => x.Id == id).First();
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
            if (CheckIfSongExistsById(song.Id))
            {
                _songRepository = _songRepository.Where(x => x.Id != song.Id).ToList();
                _songRepository.Add(song);

                var response = new ServiceResponse<Song>()
                {
                    Data = song,
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

        private bool CheckIfSongExistsById(long id) {
            if (_songRepository.Select(data => data.Id).Contains(id)) 
                return true;

            return false;
        }   
    }
}
