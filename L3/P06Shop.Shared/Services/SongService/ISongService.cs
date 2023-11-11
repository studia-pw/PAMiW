using P06Shop.Shared;
using P06Shop.Shared.Shop;
using P06Shop.Shared.SongModel;

namespace P06Shop.Shared.Services.SongService
{
    public interface ISongService
    {
        Task<ServiceResponse<List<Song>>> GetSongsAsync();
        Task<ServiceResponse<Song>> GetSongByIdAsync(long id);
        Task<ServiceResponse<Song>> CreateSongAsync(Song song);
        Task<ServiceResponse<Song>> UpdateSongAsync(Song song);
        Task<ServiceResponse<bool>> DeleteMovieAsync(long id);
    }
}
