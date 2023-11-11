using Bogus;
using Microsoft.AspNetCore.Mvc;
using P06Shop.Shared;
using P06Shop.Shared.Services.ProductService;
using P06Shop.Shared.Services.SongService;
using P06Shop.Shared.Shop;
using P06Shop.Shared.SongModel;

namespace P05Shop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SongController : Controller
    {
        private readonly ISongService _songService;

        public SongController(ISongService songService)
        {
            _songService = songService;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<Song>>>> GetSongs()
        {
            //try
            //{
            //    var result = await _productService.GetProductsAsync();
            //    return Ok(result);
            //}
            //catch (Exception ex )
            //{
            //    return StatusCode(500, $"Internal server error {ex.Message}");
            //}  

            // ukrywanie wewnetrznych bledow 

            var result = await _songService.GetSongsAsync();

            if (result.Success)
                return Ok(result);
            else
                return  StatusCode(500, $"Internal server error {result.Message}");
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<List<Song>>>> GetSongById([FromRoute] long id)
        {
            var result = await _songService.GetSongByIdAsync(id);

            if (result.Success)
                return Ok(result);
            else
                return  StatusCode(500, $"Internal server error {result.Message}");
        }


        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<Song>>>> CreateSong([FromBody] Song song)
        {
            try {
                ValidateInputSong(song);
            } catch (Exception) {
                return BadRequest("Song object validation error");
            }

            var result = await _songService.CreateSongAsync(song);

            if (result.Success)
                return Ok(result);
            else
                return  StatusCode(500, $"Internal server error {result.Message}");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<bool>>> DeleteSong([FromRoute] long id)
        {
            var result = await _songService.DeleteMovieAsync(id);

            if (result.Success)
                return Ok(result);
            else
                return  StatusCode(500, $"Internal server error {result.Message}");
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<Song>>> UpdateSong([FromBody] Song song)
        {
            try {
                ValidateInputSong(song);
            } catch (Exception) {
                return BadRequest("Song object validation error");
            }

            var result = await _songService.UpdateSongAsync(song);

            if (result.Success)
                return Ok(result);
            else
                return  StatusCode(500, $"Internal server error {result.Message}");
        }


        private void ValidateInputSong(Song song)
        {
            if (
                song == null ||
                string.IsNullOrEmpty(song.Title) ||
                string.IsNullOrEmpty(song.Artist) ||
                song.Duration < 30 ||
                song.ReleaseDate == null
            )
                throw new Exception("Validation exception");

        }


    }
}
